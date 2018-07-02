/**  版本信息模板在安装目录下，可自行修改。
* Channel.cs
*
* 功 能： N/A
* 类 名： Channel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:58   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　　   │
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 系统频道表
	/// </summary>
	[Serializable]
	public partial class Channel
	{
		public Channel(){}

		private int _id;
		private int _siteid;
		private string _name="";
		private string _title="";
		private int _isalbums=0;
		private int _isattach=0;
		private int _isspec=0;
		private int _sortid=99;

		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 站点ID
		/// </summary>
		public int SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 频道名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 频道标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 是否开启相册功能
		/// </summary>
		public int IsAlbums
		{
			set{ _isalbums=value;}
			get{return _isalbums;}
		}
		/// <summary>
		/// 是否开启附件功能
		/// </summary>
		public int IsAttach
		{
			set{ _isattach=value;}
			get{return _isattach;}
		}
		/// <summary>
		/// 是否开启规格
		/// </summary>
		public int IsSpec
		{
			set{ _isspec=value;}
			get{return _isspec;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}

        private List<ChannelField> _channelFields;
        /// <summary>
        /// 扩展字段 
        /// </summary>
        public List<ChannelField> ChannelFields
        {
            set { _channelFields = value; }
            get { return _channelFields; }
        }
	}
}

