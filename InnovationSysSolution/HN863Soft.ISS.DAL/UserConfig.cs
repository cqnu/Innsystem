using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:会员配置
    /// </summary>
    public partial class UserConfig
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.UserConfig loadConfig(string configFilePath)
        {
            return (Model.UserConfig)SerializationHelper.Load(typeof(Model.UserConfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.UserConfig saveConifg(Model.UserConfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
    }
}
