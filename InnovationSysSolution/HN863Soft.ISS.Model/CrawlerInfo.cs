using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// CrawlerInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CrawlerInfo
    {
        public CrawlerInfo() { }

        #region Model
        private int _id;
        private string _title;
        private string _crawcontent;
        private string _url;
        private DateTime _crawdate;
        private string _source;
        private int _state;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 爬取内容
        /// </summary>
        public string CrawContent
        {
            set { _crawcontent = value; }
            get { return _crawcontent; }
        }
        /// <summary>
        /// 原文网址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 爬取时间
        /// </summary>
        public DateTime CrawDate
        {
            set { _crawdate = value; }
            get { return _crawdate; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        /// <summary>
        /// 状态：0、未审核，1、已审核
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        #endregion Model

    }
}
