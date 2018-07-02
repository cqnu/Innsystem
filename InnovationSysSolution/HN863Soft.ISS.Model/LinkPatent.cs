using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    public class LinkPatent
    {
        #region Model

        private int _id;
        private int _userid;
        private string _siteName;
        private string _siteUrl;
        private long? _hits;
        private string _siteDescription;
        private string _LogUrl;

        /// <summary>
        /// log URL地址
        /// </summary>
        public string LogUrl
        {
            get { return _LogUrl; }
            set { _LogUrl = value; }
        }

        /// <summary>
        /// 网站描述
        /// </summary>
        public string SiteDescription
        {
            get { return _siteDescription; }
            set { _siteDescription = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            set { _siteName = value; }
            get { return _siteName; }
        }
        /// <summary>
        /// 网站地址
        /// </summary>
        public string SiteUrl
        {
            set { _siteUrl = value; }
            get { return _siteUrl; }
        }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public long? hits
        {
            set { _hits = value; }
            get { return _hits; }
        }

        #endregion Model
    }
}
