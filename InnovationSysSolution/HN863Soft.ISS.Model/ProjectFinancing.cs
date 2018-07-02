using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    public class ProjectFinancing
    {
        #region Model
        private int _id;
        private int? _jurisdiction;
        private int? _type;
        private string _cover;
        private string _title;
        private string _keyword;
        private string _objective;
        private string _place;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private string _promotionalvideo;
        private string _content;
        private int? _state;
        private int _userId;
        private string _describe;
        private string userName;
        private string _realName;

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        /// <summary>
        /// 发布人姓名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        /// <summary>
        /// 发布人id
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
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
        /// 查看权限 1：普通游客 2：会员 3：全部
        /// </summary>
        public int? Jurisdiction
        {
            set { _jurisdiction = value; }
            get { return _jurisdiction; }
        }
        /// <summary>
        /// 众筹类型  1：一般众筹 2：股权众筹 3：合作众筹
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
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
        /// 项目标题
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
        /// 目的
        /// </summary>
        public string Objective
        {
            set { _objective = value; }
            get { return _objective; }
        }
        /// <summary>
        /// 地点
        /// </summary>
        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 宣传视频地址
        /// </summary>
        public string PromotionalVideo
        {
            set { _promotionalvideo = value; }
            get { return _promotionalvideo; }
        }
        /// <summary>
        /// 项目详细
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 审核状态 0：未审核 1：审核通过
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model
    }
}
