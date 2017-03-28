using System;
using System.Messaging;
using System.Diagnostics;

using System.ServiceProcess;



namespace MessageWorker
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            this.ServiceName = "VDO_MessageWorker";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;


            
            InitializeComponent();
            
#if DEBUG
            Console.WriteLine("In Service 1");
#else
            EventLog m_EventLog;
            m_EventLog.WriteEntry("VDO_MessageWorker starting!");
#endif


        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            DebugMode();
#if DEBUG
            Console.WriteLine("Inside OnStart");
#endif

            const string pathMsg = @".\Private$\VDO";
            MessageQueue myQueue = new MessageQueue(pathMsg);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);

            myQueue.BeginReceive();
#if DEBUG
            Console.WriteLine("Just BeginReceive");
#endif

        }

        #region my stuff

        internal void TestStartupAndStop(string[] args)
        {
            
            this.OnStart(args);
           
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite); //This should keep the service alive! 
           
        }


        [Conditional("DEBUG_SERVICE")]
        private static void DebugMode()  //this doens't work, or I am using it wrong. 
        {
            Debugger.Break();
        }

        protected static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
#if DEBUG
            Console.WriteLine("inside MyReceiveCompleted");
#endif

            // Connect to the queue.
            System.Messaging.MessageQueue mq = (System.Messaging.MessageQueue)source;

            // End the asynchronous Receive operation.
            System.Messaging.Message m = mq.EndReceive(asyncResult.AsyncResult);

            //Add to log
            WriteToLog(m);


            // Restart the asynchronous Receive operation.
            mq.BeginReceive();

            return;
        }

        private static void WriteToLog(string strTestToFile)
        {
#if DEBUG
            Console.WriteLine("inside WriteToLog - string");
#endif
            System.IO.File.AppendAllText(@"C:\Users\XXXXXX\Documents\DavesTestProject\MessageLog.txt", strTestToFile + Environment.NewLine);

        }
        private static void WriteToLog(Message m)
        {
#if DEBUG
            Console.WriteLine("inside WriteToLog - message");
#endif
            string strTestToFile = "ID: " + m.Id + " BODY: " + m.Body + "|";
            System.IO.File.AppendAllText(@"C:\Users\XXXX\Documents\DavesTestProject\MessageLog.txt", strTestToFile + Environment.NewLine);

        }
        #endregion

        protected override void OnStop()
        {
            base.OnStop();
        }

        //Test method that can be called randomly to see firing orders 
        private void DoTheWork()
        {
#if DEBUG
            Console.WriteLine("Inside DoTheWork");
#endif
        }
    }
}
