/**  版本信息模板在安装目录下，可自行修改。
* Notice.cs
*
* 功 能： N/A
* 类 名： Notice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/14 11:35:15   N/A    初版
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
	/// Notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Notice
	{
		public Notice()
		{}
		#region Model
		private int _id;
		private DateTime? _releasetime;
		private string _publishcontent;
		private string _remarks;
        private string _username;
        private int _publisherid;

        /// <summary>
        /// 发布人id
        /// </summary>
        public int Publisherid
        {
            get { return _publisherid; }
            set { _publisherid = value; }
        }

        /// <summary>
        /// 发布人姓名
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
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
		/// 发布时间
		/// </summary>
		public DateTime? ReleaseTime
		{
			set{ _releasetime=value;}
			get{return _releasetime;}
		}
		/// <summary>
		/// 发布内容
		/// </summary>
		public string PublishContent
		{
			set{ _publishcontent=value;}
			get{return _publishcontent;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

