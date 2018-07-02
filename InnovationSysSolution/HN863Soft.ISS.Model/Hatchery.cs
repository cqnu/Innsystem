/**  版本信息模板在安装目录下，可自行修改。
* Hatchery.cs
*
* 功 能： N/A
* 类 名： Hatchery
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/6 18:58:30   N/A    初版
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
    /// Hatchery:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Hatchery
    {
        public Hatchery()
        { }
        #region Model
        private int _id;
        private int? _orid;
        private string _name;
        private string _phone;
        private string _email;
        private int? _visitnum;
        private DateTime? _visitdate;
        private int? _isvis;
        private int? _creator;
        private string _fileUrl;
        private DateTime? _createtime;
        private string _remark;

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileUrl
        {
            get { return _fileUrl; }
            set { _fileUrl = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 机构Id
        /// </summary>
        public int? OrId
        {
            set { _orid = value; }
            get { return _orid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 人数
        /// </summary>
        public int? VisitNum
        {
            set { _visitnum = value; }
            get { return _visitnum; }
        }
        /// <summary>
        /// 参观时间
        /// </summary>
        public DateTime? VisitDate
        {
            set { _visitdate = value; }
            get { return _visitdate; }
        }
        /// <summary>
        /// 是否审核：0未审核；1通过
        /// </summary>
        public int? IsVis
        {
            set { _isvis = value; }
            get { return _isvis; }
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

