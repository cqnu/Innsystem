using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    public class EnterpriseRegistration
    {
        #region Model
        private int _id;
        private int? _userid;
        private string _title;
        private string _keyword;
        private string _cover;
        private string _content;
        private int? _state;
        private string _describe;
        private string _introduce;

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduce
        {
            get { return _introduce; }
            set { _introduce = value; }
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
        /// 发布人ID
        /// </summary>
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// 关键词
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
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
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        #endregion Model
    }
}
