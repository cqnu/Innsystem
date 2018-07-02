using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
   public class Roadshow
    {
        #region Model
        private int _id;
        private int? _userid;
        private int? _jurisdiction;
        private string _cover;
        private string _title;
        private string _keyword;
        private string _organizationname;
        private string _speaker;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private string _video;
        private string _content;
        private int? _state;
        private string _describe;
        private string _objective;
        private string _place;
        private string _userName;
        private string _realName;

        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }

       /// <summary>
       /// 路演目的
       /// </summary>
        public string Objective
        {
            get { return _objective; }
            set { _objective = value; }
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
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Jurisdiction
        {
            set { _jurisdiction = value; }
            get { return _jurisdiction; }
        }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover
        {
            set { _cover = value; }
            get { return _cover; }
        }
        /// <summary>
        /// 主题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName
        {
            set { _organizationname = value; }
            get { return _organizationname; }
        }
        /// <summary>
        /// 主讲人
        /// </summary>
        public string Speaker
        {
            set { _speaker = value; }
            get { return _speaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Video
        {
            set { _video = value; }
            get { return _video; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        #endregion Model

    }
}
