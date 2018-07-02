/**  版本信息模板在安装目录下，可自行修改。
* ChannelField.cs
*
* 功 能： N/A
* 类 名： ChannelField
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:59   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　　   │
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 频道属性表
	/// </summary>
	[Serializable]
	public partial class ChannelField
	{
		public ChannelField(){}

		private int _id;
		private int _channelid;
		private int _fieldid;

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
		/// 字段ID
		/// </summary>
		public int FieldID
		{
			set{ _fieldid=value;}
			get{return _fieldid;}
		}
	}
}

