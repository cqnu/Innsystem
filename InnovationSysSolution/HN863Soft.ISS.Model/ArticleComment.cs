/**  版本信息模板在安装目录下，可自行修改。
* ArticleComment.cs
*
* 功 能： N/A
* 类 名： ArticleComment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:58   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　   　│
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 扩展属性表
	/// </summary>
	[Serializable]
	public partial class ArticleComment
	{
		public ArticleComment(){}

		private int _id;
		private int _channelid=0;
		private int _articleid=0;
		private int _parentid=0;
		private int _userid=0;
		private string _username="";
		private string _userip;
		private string _content;
		private int _islock=0;
		private DateTime _createtime= DateTime.Now;
		private int _isreply=0;
		private string _replycontent;
		private DateTime _replytime;

		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 频道ID
		/// </summary>
		public int ChannelID
		{
			set{ _channelid=value;}
			get{return _channelid;}
		}
		/// <summary>
		/// 主表ID
		/// </summary>
		public int ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 父评论ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户IP
		/// </summary>
		public string UserIP
		{
			set{ _userip=value;}
			get{return _userip;}
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
		/// 是否锁定
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 发表时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 是否已答复
		/// </summary>
		public int IsReply
		{
			set{ _isreply=value;}
			get{return _isreply;}
		}
		/// <summary>
		/// 答复内容
		/// </summary>
		public string ReplyContent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime ReplyTime
		{
			set{ _replytime=value;}
			get{return _replytime;}
		}
	}
}

