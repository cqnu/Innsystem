/**  版本信息模板在安装目录下，可自行修改。
* ActiveReply.cs
*
* 功 能： N/A
* 类 名： ActiveReply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 9:32:08   N/A    初版
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
	/// ActiveReply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActiveReply
	{
		public ActiveReply()
		{}
		#region Model
		private int _id;
		private int? _meetingid;
		private int? _uid;
		private int? _parentid;
		private string _content;
		private DateTime? _createtime;
		private int? _isvis;
        private int? _score;

        /// <summary>
        /// 得分
        /// </summary>
        public int? Score
        {
            get { return _score; }
            set { _score = value; }
        }
		/// <summary>
		/// 自标识主键 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 会议活动信息Id
		/// </summary>
		public int? MeetingId
		{
			set{ _meetingid=value;}
			get{return _meetingid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 父表Id
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 评论时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 是否审核：0 未审核；1：正常
		/// </summary>
		public int? IsVis
		{
			set{ _isvis=value;}
			get{return _isvis;}
		}
		#endregion Model

	}
}

