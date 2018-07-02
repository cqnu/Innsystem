/**  版本信息模板在安装目录下，可自行修改。
* ArticleAlbum.cs
*
* 功 能： N/A
* 类 名： ArticleAlbum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:57   N/A    初版
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
	/// 图片相册
	/// </summary>
	[Serializable]
	public partial class ArticleAlbum
	{
		public ArticleAlbum(){}

		private int _id;
		private int _articleid=0;
		private string _thumbpath="";
		private string _originalpath="";
		private string _remark="";
		private DateTime _createtime= DateTime.Now;

		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文章ID
		/// </summary>
		public int ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 缩略图地址
		/// </summary>
		public string ThumbPath
		{
			set{ _thumbpath=value;}
			get{return _thumbpath;}
		}
		/// <summary>
		/// 原图地址
		/// </summary>
		public string OriginalPath
		{
			set{ _originalpath=value;}
			get{return _originalpath;}
		}
		/// <summary>
		/// 图片描述
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
	}
}

