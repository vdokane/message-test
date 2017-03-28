using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Messaging;

namespace wcfQueueTest
{
    #region sample code that came with it
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
    #endregion

    public class MessageServicer : IMessageServicer
    {
        public string GetMessage(SampleMessage sampleMessage)
        {
            if (SendMessage(sampleMessage.Name))
                return string.Format("Message was sent! {0}", sampleMessage.Name);
            else return "it broke, message not sent"; 
        }

        private bool SendMessage(string strBody)
        {
            bool retVal = true;
            const string path_in = @".\Private$\soap_in";
            const string path_out = @".\Private$\soap_out";
            try
            {
                if (MessageQueue.Exists(path_in))
                {
                    MessageQueue messageQueue_IN = new MessageQueue(path_in);
                    

                    string strTimeStamp = DateTime.Now.TimeOfDay.ToString();
                    
                    
                    string SAVEKEY = Guid.NewGuid().ToString();
                    strBody = strBody + " BUS-ID: " + SAVEKEY; //try to assign a key that can be matched up from the SOAP_OUT

                    Message mSend = new Message(strBody + " " + strTimeStamp);
                    
                    messageQueue_IN.Label = "SOAP_IN";
                    messageQueue_IN.Send(mSend, "SOAP_IN");

                    //Send the message and get the ID
                    string MessageSendID = mSend.Id;


                    System.Threading.Thread.Sleep(20000); //give me time to start MessageListener 

                    MessageQueue messageQueue_OUT = new MessageQueue(path_out);
                    
                    Message mReturnMessage = messageQueue_OUT.ReceiveByCorrelationId(MessageSendID); //does the correlation ID need to be set in the daemon? mSend.CorrelationId = "111"; 

                    mReturnMessage.Formatter = new XmlMessageFormatter(new String[] { "System.String, mscorlib" });

                    if (mReturnMessage.Body.ToString().Contains(SAVEKEY)) retVal = true;
                    else retVal = false;

                    
                    mReturnMessage.Dispose(); //so this doesn't work? 
                    messageQueue_IN.Close();
                }
                else retVal = false;
            }
            catch(Exception e)
            {
                string dBug = e.ToString();
                retVal = false;
            }
            return retVal;
        }


    }

    public class TestIIS : ITestSOAP
    {
        public int AddTwoNumbers(int i1, int i2)
        {
            int retVal = 0;
            try
            {
                retVal = i1 + i2;
            }
            catch { }
            return retVal;
        }

        public int SubtractTwoNumbers(int i1, int i2)
        {
            int retVal = 0;
            try
            {
                retVal = i1 - i2;
            }
            catch { }
            return retVal;
        }
    }
}
