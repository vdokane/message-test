using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MessageWorker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("start main");
#endif
            if (Environment.UserInteractive)
            {
#if DEBUG
                Console.WriteLine("inside userinteractive");
#endif
                Service1 service1 = new Service1();

                service1.TestStartupAndStop(args);

                Console.ReadLine();  
            }
            else
            {
                
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);  //This is what freaks out the debugger...
            }
            
        }
    }
}
