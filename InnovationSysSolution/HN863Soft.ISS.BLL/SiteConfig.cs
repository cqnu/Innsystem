using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public partial class SiteConfig
    {
        private readonly DAL.SiteConfig dal = new DAL.SiteConfig();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.SiteConfig loadConfig()
        {
            Model.SiteConfig model = CacheHelper.Get<Model.SiteConfig>(KeysHelper.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(KeysHelper.CACHE_SITE_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(KeysHelper.FILE_SITE_XML_CONFING)),
                    Utils.GetXmlMapPath(KeysHelper.FILE_SITE_XML_CONFING));
                model = CacheHelper.Get<Model.SiteConfig>(KeysHelper.CACHE_SITE_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.SiteConfig saveConifg(Model.SiteConfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(KeysHelper.FILE_SITE_XML_CONFING));
        }
    }
}
