using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class UserConfig
    {
        private readonly DAL.UserConfig dal = new DAL.UserConfig();

        /// <summary>
        ///  读取用户配置文件
        /// </summary>
        public Model.UserConfig loadConfig()
        {
            Model.UserConfig model = CacheHelper.Get<Model.UserConfig>(KeysHelper.CACHE_USER_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(KeysHelper.CACHE_USER_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(KeysHelper.FILE_USER_XML_CONFING)),
                    Utils.GetXmlMapPath(KeysHelper.FILE_USER_XML_CONFING));
                model = CacheHelper.Get<Model.UserConfig>(KeysHelper.CACHE_USER_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存用户配置文件
        /// </summary>
        public Model.UserConfig saveConifg(Model.UserConfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(KeysHelper.FILE_USER_XML_CONFING));
        }
    }
}
