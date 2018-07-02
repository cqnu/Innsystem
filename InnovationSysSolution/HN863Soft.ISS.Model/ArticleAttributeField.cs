/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttributeField.cs
*
* 功 能： N/A
* 类 名： ArticleAttributeField
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
	/// 扩展属性表
	/// </summary>
	[Serializable]
	public partial class ArticleAttributeField
	{
		public ArticleAttributeField(){}

		private int _id;
		private string _name;
		private string _title="";
		private string _controltype;
		private string _datatype;
		private int _datalength=0;
		private int _dataplace=0;
		private string _itemoption="";
		private string _defaultvalue="";
		private int _isrequired=0;
		private int _ispassword=0;
		private int _ishtml=0;
		private int _editortype=0;
		private string _validtipmsg="";
		private string _validerrormsg="";
		private string _validpattern="";
		private int _sortid=99;
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
		/// 列名
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
		/// 控件类型
		/// </summary>
		public string ControlType
		{
			set{ _controltype=value;}
			get{return _controltype;}
		}
		/// <summary>
		/// 字段类型
		/// </summary>
		public string DataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 字段长度
		/// </summary>
		public int DataLength
		{
			set{ _datalength=value;}
			get{return _datalength;}
		}
		/// <summary>
		/// 小数点位数
		/// </summary>
		public int DataPlace
		{
			set{ _dataplace=value;}
			get{return _dataplace;}
		}
		/// <summary>
		/// 选项列表
		/// </summary>
		public string ItemOption
		{
			set{ _itemoption=value;}
			get{return _itemoption;}
		}
		/// <summary>
		/// 默认值
		/// </summary>
		public string DefaultValue
		{
			set{ _defaultvalue=value;}
			get{return _defaultvalue;}
		}
		/// <summary>
		/// 是否必填0非必填1必填
		/// </summary>
		public int IsRequired
		{
			set{ _isrequired=value;}
			get{return _isrequired;}
		}
		/// <summary>
		/// 是否密码框
		/// </summary>
		public int IsPassword
		{
			set{ _ispassword=value;}
			get{return _ispassword;}
		}
		/// <summary>
		/// 是否允许HTML
		/// </summary>
		public int IsHtml
		{
			set{ _ishtml=value;}
			get{return _ishtml;}
		}
		/// <summary>
		/// 编辑器类型0标准型1简洁型
		/// </summary>
		public int EditorType
		{
			set{ _editortype=value;}
			get{return _editortype;}
		}
		/// <summary>
		/// 验证提示信息
		/// </summary>
		public string ValidTipMsg
		{
			set{ _validtipmsg=value;}
			get{return _validtipmsg;}
		}
		/// <summary>
		/// 验证失败提示信息
		/// </summary>
		public string ValidErrorMsg
		{
			set{ _validerrormsg=value;}
			get{return _validerrormsg;}
		}
		/// <summary>
		/// 验证正则表达式
		/// </summary>
		public string ValidPattern
		{
			set{ _validpattern=value;}
			get{return _validpattern;}
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
		/// 系统默认
		/// </summary>
		public int IsSys
		{
			set{ _issys=value;}
			get{return _issys;}
		}
	}
}

