using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleAppLog4net
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        { 
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            string LogName = logRepository.GetType().Assembly.GetName().Name + ".log";

            for(int i=1; i <= 10; i++)
            { 
                log4net.GlobalContext.Properties["LogName"] = $"{i}.txt";
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));           
             

                // Log some things
                log.Info("Hello logging world! "+$"{i}");
                 
            }
            Console.ReadLine();
        }
    }
}
