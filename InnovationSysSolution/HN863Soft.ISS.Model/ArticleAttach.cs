/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttach.cs
*
* 功 能： N/A
* 类 名： ArticleAttach
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:57   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　   　　│
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 附件表
	/// </summary>
	[Serializable]
	public partial class ArticleAttach
	{
		public ArticleAttach(){}

		private int _id;
		private int _articleid=0;
		private string _filename="";
		private string _filepath="";
		private int _filesize=0;
		private string _fileext="";
		private int _downnum=0;
		private int _point=0;
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
		/// 文件名
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件路径
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 文件大小(字节)
		/// </summary>
		public int FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// 文件扩展名
		/// </summary>
		public string FileExt
		{
			set{ _fileext=value;}
			get{return _fileext;}
		}
		/// <summary>
		/// 下载次数
		/// </summary>
		public int DownNum
		{
			set{ _downnum=value;}
			get{return _downnum;}
		}
		/// <summary>
		/// 积分(正赠送负消费)
		/// </summary>
		public int Point
		{
			set{ _point=value;}
			get{return _point;}
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

