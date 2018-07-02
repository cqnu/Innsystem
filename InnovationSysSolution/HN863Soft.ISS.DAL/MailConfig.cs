using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    public class MailConfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.MailConfig loadConfig(string configFilePath)
        {
            return (Model.MailConfig)SerializationHelper.Load(typeof(Model.MailConfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.MailConfig saveConifg(Model.MailConfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
    }
}
