/**  版本信息模板在安装目录下，可自行修改。
* ServiceInfo.cs
*
* 功 能： N/A
* 类 名： ServiceInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/16 14:13:42   N/A    初版
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
	/// ServiceInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServiceInfo
	{
		public ServiceInfo()
		{}
		#region Model
		private int _id;
		private int? _publisherid;
		private string _title;
		private string _content;
		private DateTime? _creattime;
		private int? _visite;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 发布人Id
		/// </summary>
		public int? PublisherId
		{
			set{ _publisherid=value;}
			get{return _publisherid;}
		}
		/// <summary>
		/// 服务标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 发布内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? CreatTime
		{
			set{ _creattime=value;}
			get{return _creattime;}
		}
		/// <summary>
		/// 该信息是否显示：0：不显示；1：显示
		/// </summary>
		public int? Visite
		{
			set{ _visite=value;}
			get{return _visite;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

