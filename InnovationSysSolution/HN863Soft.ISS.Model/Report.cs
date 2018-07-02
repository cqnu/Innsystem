using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.Model
{
    public class Report
    {
        #region Model
        private int _id;
        private string _url;
        private string _titile;
        private int? _uid;
        private DateTime? _time;
        private int? _state;
        private string _reason;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 举报标题
        /// </summary>
        public string Titile
        {
            set { _titile = value; }
            get { return _titile; }
        }
        /// <summary>
        /// 举报人id
        /// </summary>
        public int? uId
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 举报时间
        /// </summary>
        public DateTime? Time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 状态: 0:未处理 1：已处理
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 举报原因
        /// </summary>
        public string Reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        #endregion Model
    }
}
