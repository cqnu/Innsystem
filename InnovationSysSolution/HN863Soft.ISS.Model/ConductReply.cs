/**  版本信息模板在安装目录下，可自行修改。
* ConductReply.cs
*
* 功 能： N/A
* 类 名： ConductReply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/27 16:30:41   N/A    初版
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
	/// ConductReply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConductReply
	{
		public ConductReply()
		{}
		#region Model
		private int _id;
		private int? _cid;
		private int? _uid;
		private string _content;
		private int? _isvis;
		private int? _rid;
		private DateTime? _time;
		/// <summary>
		/// 自标识主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 问题Id
		/// </summary>
		public int? CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 用户Id
		/// </summary>
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
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
		/// 是否显示：0显示；1隐藏。
		/// </summary>
		public int? IsVis
		{
			set{ _isvis=value;}
			get{return _isvis;}
		}
		/// <summary>
		/// 回复信息ID
		/// </summary>
		public int? RId
		{
			set{ _rid=value;}
			get{return _rid;}
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

