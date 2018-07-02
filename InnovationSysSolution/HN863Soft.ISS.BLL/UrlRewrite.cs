using HN863Soft.ISS.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HN863Soft.ISS.BLL
{
    public class UrlRewrite
    {
        private readonly DAL.UrlRewrite dal = new DAL.UrlRewrite();

        #region 基本方法=================================
        /// <summary>
        /// 增加节点
        /// </summary>
        public bool Add(Model.UrlRewrite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        public bool Edit(Model.UrlRewrite model)
        {
            return dal.Edit(model);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        public bool Remove(string attrName, string attrValue)
        {
            return dal.Remove(attrName, attrValue);
        }

        /// <summary>
        /// 批量删除节点
        /// </summary>
        public bool Remove(XmlNodeList xnList)
        {
            return dal.Remove(xnList);
        }
        #endregion

        #region 扩展方法=================================

        /// <summary>
        /// 检查名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exists(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            foreach (var item in GetListAll())
            {
                if (item.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 取得节点配制信息
        /// </summary>
        public Model.UrlRewrite GetInfo(string attrValue)
        {
            return dal.GetInfo(attrValue);
        }

        /// <summary>
        /// 根据频道名称和类别返回一条URL映射
        /// </summary>
        public Model.UrlRewrite GetInfo(string channel, string attrType)
        {
            foreach (var item in GetListAll())
            {
                if (channel != "" && channel != item.channel)
                {
                    continue;
                }
                if (attrType != "" && attrType != item.type)
                {
                    continue;
                }
                return item;
            }
            return null;
        }

        /// <summary>
        /// 返回URL映射列表
        /// </summary>
        public Hashtable GetList()
        {
            Hashtable ht = CacheHelper.Get<Hashtable>(KeysHelper.CACHE_SITE_URLS);
            if (ht == null)
            {
                CacheHelper.Insert(KeysHelper.CACHE_SITE_URLS, dal.GetList(), Utils.GetXmlMapPath(KeysHelper.FILE_URL_XML_CONFING));
                ht = CacheHelper.Get<Hashtable>(KeysHelper.CACHE_SITE_URLS);
            }
            return ht;
        }

        /// <summary>
        /// 返回URL映射List列表
        /// </summary>
        public List<Model.UrlRewrite> GetListAll()
        {
            List<Model.UrlRewrite> ls = CacheHelper.Get<List<Model.UrlRewrite>>(KeysHelper.CACHE_SITE_URLS_LIST);
            if (ls == null)
            {
                CacheHelper.Insert(KeysHelper.CACHE_SITE_URLS_LIST, dal.GetList(""), Utils.GetXmlMapPath(KeysHelper.FILE_URL_XML_CONFING));
                ls = CacheHelper.Get<List<Model.UrlRewrite>>(KeysHelper.CACHE_SITE_URLS_LIST);
            }
            return ls;
        }

        /// <summary>
        /// 根据频道名称返回URL映射列表
        /// </summary>
        public List<Model.UrlRewrite> GetList(string channel)
        {
            List<Model.UrlRewrite> ls = GetListAll();
            if (channel == "")
            {
                return ls;
            }
            List<Model.UrlRewrite> nls = new List<Model.UrlRewrite>();
            foreach (Model.UrlRewrite modelt in ls)
            {
                if (modelt.channel == channel)
                {
                    nls.Add(modelt);
                }
            }
            return nls;
        }

        /// <summary>
        /// 根据频道名称和类别返回URL映射列表
        /// </summary>
        public List<Model.UrlRewrite> GetList(string channel, string attrType)
        {
            List<Model.UrlRewrite> nls = new List<Model.UrlRewrite>();
            foreach (Model.UrlRewrite modelt in GetListAll())
            {
                if (channel != "" && channel != modelt.channel)
                {
                    continue;
                }
                if (attrType != "" && attrType != modelt.type)
                {
                    continue;
                }
                nls.Add(modelt);
            }
            return nls;
        }

        #endregion
    }

}
