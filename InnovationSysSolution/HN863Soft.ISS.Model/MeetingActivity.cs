/**  版本信息模板在安装目录下，可自行修改。
* MeetingActivity.cs
*
* 功 能： N/A
* 类 名： MeetingActivity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 9:32:11   N/A    初版
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
	/// MeetingActivity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MeetingActivity
	{
		public MeetingActivity()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime? _createtime;
		private int? _creatorid;
		private int? _isvis;
        private int? _type;
        private int? _reward;
        private string _keyWord;
        private string _describe;

        /// <summary>
        /// 审核备注
        /// </summary>
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord
        {
            get { return _keyWord; }
            set { _keyWord = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public int? Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 悬赏积分
        /// </summary>
        public int? Reward
        {
            get { return _reward; }
            set { _reward = value; }
        }
		/// <summary>
		/// 自标识主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 发布内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 活动发布人
		/// </summary>
		public int? CreatorId
		{
			set{ _creatorid=value;}
			get{return _creatorid;}
		}
		/// <summary>
		/// 是否审核：0 未审核；1：正常
		/// </summary>
		public int? IsVis
		{
			set{ _isvis=value;}
			get{return _isvis;}
		}
		#endregion Model

	}
}

