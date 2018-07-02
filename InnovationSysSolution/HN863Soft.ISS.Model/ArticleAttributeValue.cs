/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttributeValue.cs
*
* 功 能： N/A
* 类 名： ArticleAttributeValue
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
	public partial class ArticleAttributeValue
	{
		public ArticleAttributeValue(){}

		private int _articleid;
		private string _subtitle;
		private string _source;
		private string _author;
		private string _goodsno;
		private int _stockquantity=0;
		private decimal _marketprice=0M;
		private decimal _sellprice=0M;
		private int _point=0;
		private string _videosrc;

		/// <summary>
		/// 父表ID
		/// </summary>
		public int ArticleId
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubTitle
		{
			set{ _subtitle=value;}
			get{return _subtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsNo
		{
			set{ _goodsno=value;}
			get{return _goodsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StockQuantity
		{
			set{ _stockquantity=value;}
			get{return _stockquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MarketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SellPrice
		{
			set{ _sellprice=value;}
			get{return _sellprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Point
		{
			set{ _point=value;}
			get{return _point;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoSrc
		{
			set{ _videosrc=value;}
			get{return _videosrc;}
		}
	}
}

