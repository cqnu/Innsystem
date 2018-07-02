using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class MailConfig
    {
        private readonly DAL.MailConfig dal = new DAL.MailConfig();
        /// <summary>
        ///  读取用户配置文件
        /// </summary>
        public Model.MailConfig loadConfig()
        {
            Model.MailConfig model = CacheHelper.Get<Model.MailConfig>(KeysHelper.CACHE_MAIL_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(KeysHelper.CACHE_MAIL_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(KeysHelper.FILE_MAIL_XML_CONFING)),
                    Utils.GetXmlMapPath(KeysHelper.FILE_MAIL_XML_CONFING));
                model = CacheHelper.Get<Model.MailConfig>(KeysHelper.CACHE_MAIL_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存用户配置文件
        /// </summary>
        public Model.MailConfig saveConifg(Model.MailConfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(KeysHelper.FILE_MAIL_XML_CONFING));
        }
    }
}
