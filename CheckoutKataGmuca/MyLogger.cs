using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CheckoutKataGmuca
{
    public class MyLogger 
    {
        private static readonly ILog log = LogManager.GetLogger("MyLogger");

        public MyLogger()
        {
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public void logError(string message)
        {
            log.Error(message);
        }

        public void logWarning(string message)
        {
            log.Warn(message);
        }

        public void logInfo(string message)
        {
            log.Info(message);
        }
        

    }
}
