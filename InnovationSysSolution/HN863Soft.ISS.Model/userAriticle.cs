/**  版本信息模板在安装目录下，可自行修改。
* userAriticle.cs
*
* 功 能： N/A
* 类 名： userAriticle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/20 11:20:17   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// userAriticle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class userAriticle
	{
		public userAriticle()
		{}
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
        private int? _type;
        private string _logimg;

        /// <summary>
        /// Log
        /// </summary>
        public string Logimg
        {
            get { return _logimg; }
            set { _logimg = value; }
        }
        private string _keyword;
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
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
        /// 类型
        /// </summary>
        public int? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 审批备注
        /// </summary>
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
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 主题内容
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? datatime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public long? hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? lasttime
		{
			set{ _lasttime=value;}
			get{return _lasttime;}
		}
		#endregion Model

	}
}

