/**  版本信息模板在安装目录下，可自行修改。
* TechnicalInformation.cs
*
* 功 能： N/A
* 类 名： TechnicalInformation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/15 13:51:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// TechnicalInformation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TechnicalInformation
	{
		public TechnicalInformation()
		{}
		#region Model
		private int _id;
		private string _entryname;
		private string _detailedcontent;
		private int _userid;
		private DateTime _time;
        private string _keyword;
        private string _institutionaldisplay;
        private long _hits;
        private int _State;
        private string _describe;

        /// <summary>
        /// 原因
        /// </summary>
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }
        //状态
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public long Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }

        /// <summary>
        /// 机构展示
        /// </summary>
        public string Institutionaldisplay
        {
            get { return _institutionaldisplay; }
            set { _institutionaldisplay = value; }
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string EntryName
		{
			set{ _entryname=value;}
			get{return _entryname;}
		}
		/// <summary>
		/// 项目内容
		/// </summary>
		public string DetailedContent
		{
			set{ _detailedcontent=value;}
			get{return _detailedcontent;}
		}
		/// <summary>
		/// 发布人
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

