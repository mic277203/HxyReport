using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"config\Log4Net.config", Watch = true)]
namespace HxyReport.Core
{
    public class Log4Helper
    {
        private static readonly ILog LogError = LogManager.GetLogger("LogError");
        private static readonly ILog LogInfo = LogManager.GetLogger("LogInfo");

        /// <summary>
        /// 创建Error log ，对应配置文件中的LogError节点
        /// </summary>
        /// <param name="msg"></param>
        public static void ErrorLog(string msg)
        {
            LogError.Error(msg);
        }

        /// <summary>
        /// 创建Error log ，对应配置文件中的LogError节点
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void ErrorLog(string msg, Exception ex)
        {
            LogError.Error(msg, ex);
        }

        /// <summary>
        /// 创建Debugger log ，对应配置文件中的LogDebug节点
        /// </summary>
        /// <param name="msg"></param>
        public static void InfoLog(string msg)
        {
            LogInfo.Info(msg);
        }
    }
}
