using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// CrawlerKeys:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CrawlerKeys
    {
        public CrawlerKeys() { }
        #region Model
        private int _id;
        private string _keys;
        private int _keytype;
        private string _keyname;
        private string _urlKey;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 关键词：网址或关键字
        /// </summary>
        public string Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// 关键字类型：0、关键字，1、网址
        /// </summary>
        public int KeyType
        {
            set { _keytype = value; }
            get { return _keytype; }
        }
        /// <summary>
        /// 关键字名称（网址名称）
        /// </summary>
        public string KeyName
        {
            set { _keyname = value; }
            get { return _keyname; }
        }
        /// <summary>
        /// 网站网址主目录（消息根目录）
        /// </summary>
        public string UrlKey
        {
            get { return _urlKey; }
            set { _urlKey = value; }
        }
        #endregion Model
    }
}
