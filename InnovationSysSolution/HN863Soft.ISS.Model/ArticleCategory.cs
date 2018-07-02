/**  版本信息模板在安装目录下，可自行修改。
* ArticleCategory.cs
*
* 功 能： N/A
* 类 名： ArticleCategory
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
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 扩展属性表
	/// </summary>
	[Serializable]
	public partial class ArticleCategory
	{
		public ArticleCategory(){}

		private int _id;
		private int _channelid;
		private string _title;
		private string _callindex="";
		private int _parentid=0;
		private string _classlist;
		private int _classlayer=0;
		private int _sortid=99;
		private string _linkurl="";
		private string _imgurl="";
		private string _content;
		private string _seotitle="";
		private string _seokeywords="";
		private string _seodescription="";

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
		/// 类别标题
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
		/// 父类别ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 类别ID列表(逗号分隔开)
		/// </summary>
		public string ClassList
		{
			set{ _classlist=value;}
			get{return _classlist;}
		}
		/// <summary>
		/// 类别深度
		/// </summary>
		public int ClassLayer
		{
			set{ _classlayer=value;}
			get{return _classlayer;}
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
		/// URL跳转地址
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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
		public string SEOKeywords
		{
			set{ _seokeywords=value;}
			get{return _seokeywords;}
		}
		/// <summary>
		/// SEO描述
		/// </summary>
		public string SEODescription
		{
			set{ _seodescription=value;}
			get{return _seodescription;}
		}
	}
}

