using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

//From Eric: here's a simple command to register a service, like regsvc32 something something.  It's all done at command line (Dos prompt) and simple.  

namespace MessageListener
{
     public class Program
    {
        static void Main(string[] args)
        {
            decimal dBug = -1;
            //OldWay() ...this works

            /* TO TEST THIS: 
             Run wcfQueueTest, put a message on the outque, run this.. 
             */
            WCF_SOAP_Way();
            Console.ReadKey();
        }

        private static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            Console.WriteLine("here3");
            MessageQueue mq = (MessageQueue)source;

            Message m = mq.EndReceive(asyncResult.AsyncResult);
            WriteToLog(m);

            // Display message information on the screen.
            //Console.WriteLine("Message: " + (string)m.Body);
            //string tst = Console.ReadLine(); //brakes! Slow this btch down so the event can fire

            // Restart the asynchronous Receive operation.
            mq.BeginReceive();
            Console.WriteLine("here4");
            return;
        }

        private static void WriteToLog(Message m)
        {
            string strTestToFile = "ID: " + m.Id + " BODY: " + m.Body + "|";
            System.IO.File.AppendAllText(@"C:\Users\okaned\Documents\DavesTestProject\MessageLog.txt", strTestToFile + Environment.NewLine);

        }
        private static void WriteToLog(string strTestToFile)
        {
            System.IO.File.AppendAllText(@"C:\Users\okaned\Documents\DavesTestProject\MessageLog.txt", strTestToFile + Environment.NewLine);

        }


        [Serializable()]
        public class CanonicalDataModel
        {

            string _Member1;
            string _Member2;
            public CanonicalDataModel()
            {
                _Member1 = "default1";
                _Member2 = "default2"; //this doesn't get set if the value is Ignored in the sent class. Hmm? 
            }
            [System.Xml.Serialization.XmlElement("Member1")]
            public string Member1 { get; set; }
            [System.Xml.Serialization.XmlElement("Member2")]
            public string Member2 { get; set; }
        }

        private static void OldWay()
        {
            Console.WriteLine("Starting to listen");
            const string path = @".\Private$\VDO";

            // while (true) //well, this works but sheesh
            //{
            try
            {
                if (MessageQueue.Exists(path))
                {
                    MessageQueue myQueue = new MessageQueue(path);
                    Message[] messages = myQueue.GetAllMessages();  //now get myQueue.BeginReceive(); to work. And run this as a service instead of off a trigger
                    foreach (System.Messaging.Message message in messages)
                    {
                        if (message.Label == "CanonicalDataModel") //WOoo this works
                        {
                            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(CanonicalDataModel));

                            CanonicalDataModel cdm;
                            cdm = (CanonicalDataModel)serializer.Deserialize(message.BodyStream);

                            string strToLogFile = "Member1: " + cdm.Member1 + " member2: " + cdm.Member2;
                            WriteToLog(strToLogFile);
                        }
                        else
                        {
                            message.Formatter = new XmlMessageFormatter(new String[] { "System.String, mscorlib" });
                            //string msg = message.Body.ToString();
                            WriteToLog(message);

                        }
                        myQueue.ReceiveById(message.Id); //delete? What a weird ass way to delete them. 


                    }



                    //This works, but not from the trigger. Try the GetAllMessages() from the console app
                    // myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);
                    Console.WriteLine("here1");

                    // Begin the asynchronous receive operation.
                    //                    myQueue.BeginReceive();
                    Console.WriteLine("here2");

                }
            }
            catch (Exception e)
            {
#if true
                string dBug = e.ToString();
#endif
                Console.WriteLine(e.ToString());

            }
            Console.WriteLine("finish?");
            Console.ReadKey();
            // }

        }

        private static void WCF_SOAP_Way()
        {
            const string path_in = @".\Private$\soap_in";
            const string path_out = @".\Private$\soap_out";

            try
            {
                if (MessageQueue.Exists(path_in))
                {
                    MessageQueue qIN = new MessageQueue(path_in);
                    MessageQueue qOut = new MessageQueue(path_out);

                    Message[] messages = qIN.GetAllMessages();  //now get myQueue.BeginReceive(); to work. And run this as a service instead of off a trigger
                    foreach (System.Messaging.Message message_IN in messages)
                    {
                        if (message_IN.Label == "SOAP_IN") 
                        {
                            message_IN.Formatter = new XmlMessageFormatter(new String[] { "System.String, mscorlib" });

                            
                            string strBodyOut = message_IN.Body.ToString();
                            strBodyOut += "PASS";  //If this was a real process we could send this on to the BL of some application and let it do it's thing
                            Message message_OUT = new Message(strBodyOut);
                            message_OUT.CorrelationId = message_IN.Id;  //do this so wcfQueueTest can find it on the out queue. 
                            message_OUT.Label = "SOAP_OUT";
                            //qOut = message_IN.ResponseQueue; //what does this do? 
                            qOut.Send(message_OUT);

                            message_IN.Dispose();
                            
                        }


                    }

                    qIN.Close();
                    qOut.Close();

                    Console.WriteLine("here1");


                }
            }
            catch (Exception e)
            {
#if true
                string dBug = e.ToString();
#endif
                Console.WriteLine(e.ToString());

            }
            Console.WriteLine("finish?");
        }
    }
}
