/**  版本信息模板在安装目录下，可自行修改。
* Article.cs
*
* 功 能： N/A
* 类 名： Article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:57   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// Article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Article
	{
		public Article(){}

		private int _id;
		private int _channelid=0;
		private int _categoryid=0;
		private string _callindex="";
		private string _title;
		private string _linkurl="";
		private string _imgurl="";
		private string _seotitle="";
		private string _seokeywords="";
		private string _seodescription="";
		private string _tags;
		private string _digest="";
		private string _articlecontent;
		private int _sortid=99;
		private int _clicknum=0;
		private int _status=0;
		private int _flagcomment=0;
		private int _flagtop=0;
		private int _flagrecommend=0;
		private int _flaghot=0;
		private int _flagslide=0;
		private int _flagadmin=0;
		private string _username;
		private DateTime _createtime= DateTime.Now;
		private DateTime _updatetime;

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
		/// 类别ID
		/// </summary>
		public int CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
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
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 外部链接
		/// </summary>
		public string LinkURL
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string ImgURL
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// <summary>
		/// TAG标签逗号分隔
		/// </summary>
		public string Tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		/// <summary>
		/// 内容摘要
		/// </summary>
		public string Digest
		{
			set{ _digest=value;}
			get{return _digest;}
		}
		/// <summary>
		/// 详细内容
		/// </summary>
		public string ArticleContent
		{
			set{ _articlecontent=value;}
			get{return _articlecontent;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int ClickNum
		{
			set{ _clicknum=value;}
			get{return _clicknum;}
		}
		/// <summary>
		/// 状态0正常1未审核2锁定
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 是否允许评论
		/// </summary>
		public int FlagComment
		{
			set{ _flagcomment=value;}
			get{return _flagcomment;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public int FlagTop
		{
			set{ _flagtop=value;}
			get{return _flagtop;}
		}
		/// <summary>
		/// 是否推荐
		/// </summary>
		public int FlagRecommend
		{
			set{ _flagrecommend=value;}
			get{return _flagrecommend;}
		}
		/// <summary>
		/// 是否热门
		/// </summary>
		public int FlagHot
		{
			set{ _flaghot=value;}
			get{return _flaghot;}
		}
		/// <summary>
		/// 是否幻灯片
		/// </summary>
		public int FlagSlide
		{
			set{ _flagslide=value;}
			get{return _flagslide;}
		}
		/// <summary>
		/// 是否管理员发布0不是1是
		/// </summary>
		public int FlagAdmin
		{
			set{ _flagadmin=value;}
			get{return _flagadmin;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
        /// <summary>
        /// 扩展字段字典
        /// </summary>
        private Dictionary<string, string> _fields;
        public Dictionary<string, string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        /// <summary>
        /// 图片相册
        /// </summary>
        private List<ArticleAlbum> _albums;
        public List<ArticleAlbum> Albums
        {
            set { _albums = value; }
            get { return _albums; }
        }

        /// <summary>
        /// 内容附件
        /// </summary>
        private List<ArticleAttach> _attach;
        public List<ArticleAttach> Attach
        {
            set { _attach = value; }
            get { return _attach; }
        }
	}
}

