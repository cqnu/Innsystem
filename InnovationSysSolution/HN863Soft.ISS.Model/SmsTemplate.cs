/**  版本信息模板在安装目录下，可自行修改。
* SmsTemplate.cs
*
* 功 能： N/A
* 类 名： SmsTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:00   N/A    初版
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
	/// 手机短信模板
	/// </summary>
	[Serializable]
	public partial class SmsTemplate
	{
		public SmsTemplate(){}

		private int _id;
		private string _title="";
		private string _callindex="";
		private string _content="";
		private int _issys=0;

		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 调用别名
		/// </summary>
		public string CallIndex
		{
			set{ _callindex=value;}
			get{return _callindex;}
		}
		/// <summary>
		/// 短信内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 系统默认
		/// </summary>
		public int IsSys
		{
			set{ _issys=value;}
			get{return _issys;}
		}
	}
}

