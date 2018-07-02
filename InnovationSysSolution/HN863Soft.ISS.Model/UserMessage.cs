using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// 用户短消息
    /// </summary>
    [Serializable]
    public partial class UserMessage
    {
        public UserMessage(){ }

        #region Model
        private int _id;
        private int _type = 1;
        private string _poster;
        private string _accepter;
        private int _isRead = 0;
        private string _title;
        private string _content;
        private DateTime _postTime = DateTime.Now;
        private DateTime _readTime = DateTime.Now;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 短信息类型0系统消息1收件箱2发件箱
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 发件人
        /// </summary>
        public string Poster
        {
            set { _poster = value; }
            get { return _poster; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Accepter
        {
            set { _accepter = value; }
            get { return _accepter; }
        }
        /// <summary>
        /// 是否查看0未阅1已阅
        /// </summary>
        public int IsRead
        {
            set { _isRead = value; }
            get { return _isRead; }
        }
        /// <summary>
        /// 短信息标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 短信息内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime PostTime
        {
            set { _postTime = value; }
            get { return _postTime; }
        }
        /// <summary>
        /// 阅读时间
        /// </summary>
        public DateTime ReadTime
        {
            set { _readTime = value; }
            get { return _readTime; }
        }
        #endregion Model
    }
}
