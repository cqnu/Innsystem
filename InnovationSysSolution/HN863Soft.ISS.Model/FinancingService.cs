using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    public partial class FinancingService
    {
        #region Model
        private int _id;
        private int _userid;
        private string _title;
        private string _content;
        private DateTime? _datatime;
        private long? _hits;
        private DateTime? _lasttime;
        private int _lid;
        private int _state;
        private string _describe;

        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 楼层id
        /// </summary>
        public int Lid
        {
            get { return _lid; }
            set { _lid = value; }
        }

        private int _ariticleid;
        private int _beReplyId;

        /// <summary>
        /// 发帖顺序
        /// </summary>
        public int BeReplyId
        {
            get { return _beReplyId; }
            set { _beReplyId = value; }
        }

        /// <summary>
        /// 主表ID
        /// </summary>
        public int Ariticleid
        {
            get { return _ariticleid; }
            set { _ariticleid = value; }
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
        /// 主题内容
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? datatime
        {
            set { _datatime = value; }
            get { return _datatime; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public long? hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? lasttime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }
        #endregion Model
    }
}
