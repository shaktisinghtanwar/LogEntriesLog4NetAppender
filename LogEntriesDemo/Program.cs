using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace LogEntriesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Thread.SpinWait(4000);
            string repositoryName = string.Format("Repository");

            ILoggerRepository repository = LoggerManager.CreateRepository(repositoryName);
            log4net.Config.XmlConfigurator.Configure(repository);

            var log = LogManager.GetLogger(typeof(Program));

            Thread thread = Thread.CurrentThread;
            thread.Name = "Main Thread";
            ThreadContext.Properties["MainThreadContext"] = "MainThreadContextValue";
            log.Info("Nikhil test");
            log.Error("oops", new ArgumentOutOfRangeException("argArray"));
            log.Warn("hmmm", new ApplicationException("app exception"));
            log.Info("yawn");

          

            Console.ReadKey();

        }
    }
}
