using log4net;
using System;
using System.Configuration;
using System.Reflection;

namespace Logging
{
    public class LogHelper
    {
        /// <summary>
        /// Gestisce la scrittura del log applicativo generico.
        /// </summary>
        /// log4net.GlobalContext.Properties["logFileName"] = "log.txt";


        private static  ILog log;


        public static void LogConfigure(string folder)
        {
           
            //log.Info("Folder: " + log4net.GlobalContext.Properties["Folder"].ToString());
            log4net.GlobalContext.Properties["Folder"] = folder;
            log4net.GlobalContext.Properties["LogName"] = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(ConfigurationManager.AppSettings["LOGCONF"]));

            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }


        public static void LogConfigure(string folder, string logName)
        {
            log4net.GlobalContext.Properties["Folder"] = folder;
            log4net.GlobalContext.Properties["LogName"] = logName;
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"\log4net.config"));

            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }


        #region Logging Methods

        /// <summary>
        /// Scrive un informazione nel file di log dell'applicazione.
        /// </summary>
        /// <param name="sourceLogApp">Nome applicazione</param>
        /// <param name="logInfo">Informazione.</param>
        public static void LogInfo(String logInfo)
        {
            log.Info(logInfo);
        }

        /// <summary>
        /// Scrive un avviso nel file di log dell'applicazione.
        /// </summary>
        /// <param name="sourceLogApp">Nome applicazione</param>
        /// <param name="logWarning">Avviso.</param>
        /// 
        public static void LogWarning(String logWarning)
        {
            log.Warn(logWarning);
        }

        /// <summary>
        /// Scrive un errore nel file di log dell'applicazione. 
        /// </summary>
        /// <param name="sourceLogApp">Nome applicazione</param>
        /// <param name="logError">Errore.</param>
        public static void LogError(String logError)
        {
            log.Error(logError);
        }

        #endregion
    }
}
