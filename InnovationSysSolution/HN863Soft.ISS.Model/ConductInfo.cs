/**  版本信息模板在安装目录下，可自行修改。
* ConductInfo.cs
*
* 功 能： N/A
* 类 名： ConductInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/27 18:03:54   N/A    初版
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
    /// ConductInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ConductInfo
    {
        public ConductInfo()
        { }
        #region Model
        private int _id;
        private int? _mid;
        private string _title;
        private int? _isvis;
        private int? _creator;
        private int? _hot;
        private DateTime? _createtime;
        /// <summary>
        /// 自标识主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MId
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 是否审核：0：未审核；1：已审核
        /// </summary>
        public int? IsVis
        {
            set { _isvis = value; }
            get { return _isvis; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public int? Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Hot
        {
            set { _hot = value; }
            get { return _hot; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model
    }
}

