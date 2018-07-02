/**  版本信息模板在安装目录下，可自行修改。
* Navigation.cs
*
* 功 能： N/A
* 类 名： Navigation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:00   N/A    初版
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
	/// 系统导航菜单
	/// </summary>
	[Serializable]
	public partial class Navigation
	{
		public Navigation(){}

		private int _id;
		private int _parentid=0;
		private int _channelid=0;
		private string _navtype="";
		private string _name="";
		private string _title="";
		private string _subtitle="";
		private string _iconurl;
		private string _linkurl="";
		private int _sortid=99;
		private int _islock=0;
		private string _remark="";
		private string _actiontype="";
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
		/// 所属父导航ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 所属频道ID
		/// </summary>
		public int ChannelID
		{
			set{ _channelid=value;}
			get{return _channelid;}
		}
		/// <summary>
		/// 导航类别
		/// </summary>
		public string NavType
		{
			set{ _navtype=value;}
			get{return _navtype;}
		}
		/// <summary>
		/// 导航ID
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 副标题
		/// </summary>
		public string SubTitle
		{
			set{ _subtitle=value;}
			get{return _subtitle;}
		}
		/// <summary>
		/// 图标地址
		/// </summary>
		public string IconUrl
		{
			set{ _iconurl=value;}
			get{return _iconurl;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 是否隐藏0显示1隐藏
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 权限资源
		/// </summary>
		public string ActionType
		{
			set{ _actiontype=value;}
			get{return _actiontype;}
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

