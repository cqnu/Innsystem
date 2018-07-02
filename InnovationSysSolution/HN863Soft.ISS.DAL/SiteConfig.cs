using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:站点配置
    /// </summary>
    public partial class SiteConfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.SiteConfig loadConfig(string configFilePath)
        {
            return (Model.SiteConfig)SerializationHelper.Load(typeof(Model.SiteConfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.SiteConfig saveConifg(Model.SiteConfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }

    }
}
