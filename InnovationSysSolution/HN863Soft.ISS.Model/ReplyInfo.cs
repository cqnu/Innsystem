/**  版本信息模板在安装目录下，可自行修改。
* ReplyInfo.cs
*
* 功 能： N/A
* 类 名： ReplyInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/21 10:03:12   N/A    初版
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
	/// ReplyInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ReplyInfo
	{
		public ReplyInfo()
		{}
		#region Model
		private int _id;
		private int? _sid;
		private int? _responderid;
		private string _content;
		private int? _commentid;
		private DateTime? _time;
        private int _isVis;
      
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 是否隐藏：0，是；1，否。
        /// </summary>
        public int IsVis
        {
            get { return _isVis; }
            set { _isVis = value; }
        }
		/// <summary>
		/// 发布信息Id
		/// </summary>
		public int? SId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 回复者Id
		/// </summary>
		public int? ResponderId
		{
			set{ _responderid=value;}
			get{return _responderid;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 回复信息Id
		/// </summary>
		public int? CommentId
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

