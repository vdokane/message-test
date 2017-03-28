using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testClientForWCFsoap
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWebServiceOnQAwebServer();
        }

        private void TestSOAPque()
        {
            Console.WriteLine("Client WCF queue start");

            //Hell yeah this works!! 
            ServiceReference1.SampleMessage sm = new ServiceReference1.SampleMessage();
            sm.Name = "name from console app";
            sm.BusinessKey = "33";

            ServiceReference1.MessageServicerClient sdsd = new ServiceReference1.MessageServicerClient();
            Console.WriteLine("Message is about to be sent (you now wait 30 seconds)");
            string tst = sdsd.GetMessage(sm);

            Console.WriteLine("Output: {0}", tst);
            Console.WriteLine("Press any key to end");


            //Now dave think, once the message is on the que, how can we proces it and then send a message back to Program.cs?
            //without doing the processing in GetMessage? Keep it loosely coupled and abstract!! 

            Console.ReadKey();
        }

        public static void TestWebServiceOnQAwebServer()
        {
            //To folks out in GitHub land, 
            /*
            1) You will have to publish the web service project
            2) Host it somewhere.
            3) Re-add the reference to the web service and re-add it to the project.
            4) And of course set up your own MSMQ queues 
            5) Then this ..might... work. 
            */
            Console.WriteLine("Can we reach the QA web server from here?");

            ServiceReference2.TestSOAPClient TSC = new ServiceReference2.TestSOAPClient();
            int retVal1 = TSC.AddTwoNumbers(46, 2);
            Console.WriteLine("Add two numbers: {0}", retVal1);

            int retVal2 = TSC.SubtractTwoNumbers(100, 10);
            Console.WriteLine("Subtract two numbers: {0}", retVal2);
            Console.ReadKey();

        }
    }
}
