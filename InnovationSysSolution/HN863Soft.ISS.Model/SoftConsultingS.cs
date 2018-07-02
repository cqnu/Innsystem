/**  版本信息模板在安装目录下，可自行修改。
* SoftConsultingS.cs
*
* 功 能： N/A
* 类 名： SoftConsultingS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/27 14:33:33   N/A    初版
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
    /// SoftConsultingS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SoftConsultingS
    {
        public SoftConsultingS()
        { }
        #region Model
        private int _id;
        private string _sname;
        private string _sintroduction;
        private string _teamintroduction;
        private string _example;
        private string _phone;
        private int? _type;
        private int? _isvis;
        private DateTime? _createdate;
        private string _logimg;
        private string _keyword;
        private string _introduce;
        private string _describe;

        /// <summary>
        /// 审核备注
        /// </summary>
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        private int _creatorId;
        /// <summary>
        /// 用户Id
        /// </summary>
        public int CreatorId
        {
            get { return _creatorId; }
            set { _creatorId = value; }
        }
        /// <summary>
        /// 自标识主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 服务介绍
        /// </summary>
        public string SIntroduction
        {
            set { _sintroduction = value; }
            get { return _sintroduction; }
        }
        /// <summary>
        /// 团队介绍
        /// </summary>
        public string TeamIntroduction
        {
            set { _teamintroduction = value; }
            get { return _teamintroduction; }
        }
        /// <summary>
        /// 案例
        /// </summary>
        public string Example
        {
            set { _example = value; }
            get { return _example; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 是否审核：0未审核，1已审核
        /// </summary>
        public int? IsVis
        {
            set { _isvis = value; }
            get { return _isvis; }
        }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogImg
        {
            set { _logimg = value; }
            get { return _logimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Introduce
        {
            set { _introduce = value; }
            get { return _introduce; }
        }
        #endregion Model

    }
}

