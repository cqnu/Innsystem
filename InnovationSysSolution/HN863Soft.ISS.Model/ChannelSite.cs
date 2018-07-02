/**  版本信息模板在安装目录下，可自行修改。
* ChannelSite.cs
*
* 功 能： N/A
* 类 名： ChannelSite
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:59   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 频道分类
	/// </summary>
	[Serializable]
	public partial class ChannelSite
	{
		public ChannelSite(){}

		private int _id;
		private string _title;
		private string _buildpath="";
		private string _templetpath="";
		private string _domain="";
		private string _name;
		private string _logo;
		private string _company;
		private string _address;
		private string _tel;
		private string _fax;
		private string _email;
		private string _crod;
		private string _copyright;
		private string _seotitle;
		private string _seokeyword;
		private string _seodescription;
		private int _isdefault=0;
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
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 生成目录名
		/// </summary>
		public string BuildPath
		{
			set{ _buildpath=value;}
			get{return _buildpath;}
		}
		/// <summary>
		/// 模板目录名
		/// </summary>
		public string TempletPath
		{
			set{ _templetpath=value;}
			get{return _templetpath;}
		}
		/// <summary>
		/// 绑定域名
		/// </summary>
		public string Domain
		{
			set{ _domain=value;}
			get{return _domain;}
		}
		/// <summary>
		/// 网站名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 网站LOGO
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 通讯地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 传真号码
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 备案号
		/// </summary>
		public string Crod
		{
			set{ _crod=value;}
			get{return _crod;}
		}
		/// <summary>
		/// 版权信息
		/// </summary>
		public string Copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// SEO标题
		/// </summary>
		public string SEOTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// SEO关健字
		/// </summary>
		public string SEOKeyword
		{
			set{ _seokeyword=value;}
			get{return _seokeyword;}
		}
		/// <summary>
		/// SEO描述
		/// </summary>
		public string SEODescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public int IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
	}
}

