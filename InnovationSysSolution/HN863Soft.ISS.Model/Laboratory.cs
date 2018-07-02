using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// Laboratory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Laboratory
    {
        public Laboratory(){ }

        #region Model
        private int _id;
        private int _userid;
        private string _labname;
        private string _lablocation;
        private string _labintro;
        private string _owner;
        private string _chargingstandard;
        private string _linkman;
        private string _phone;
        private string _email;
        private string _weixin;
        private string _evidence;
        private string _labexhibit;
        private int _labtype = 1;
        private int _state = 1;
        private DateTime _createtime;
        private string _remark;

        /// <summary>
        /// 实验室ID，自增
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 实验室名称
        /// </summary>
        public string LabName
        {
            set { _labname = value; }
            get { return _labname; }
        }
        /// <summary>
        /// 实验室地址
        /// </summary>
        public string LabLocation
        {
            set { _lablocation = value; }
            get { return _lablocation; }
        }
        /// <summary>
        /// 实验室简介
        /// </summary>
        public string LabIntro
        {
            set { _labintro = value; }
            get { return _labintro; }
        }
        /// <summary>
        /// 拥有者
        /// </summary>
        public string Owner
        {
            set { _owner = value; }
            get { return _owner; }
        }
        /// <summary>
        /// 收费标准
        /// </summary>
        public string ChargingStandard
        {
            set { _chargingstandard = value; }
            get { return _chargingstandard; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
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
        /// 联系人Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXin
        {
            set { _weixin = value; }
            get { return _weixin; }
        }
        /// <summary>
        /// 实验室证明文件
        /// </summary>
        public string Evidence
        {
            set { _evidence = value; }
            get { return _evidence; }
        }
        /// <summary>
        /// 实验室展示
        /// </summary>
        public string LabExhibit
        {
            set { _labexhibit = value; }
            get { return _labexhibit; }
        }
        /// <summary>
        /// 实验室类型：1、普通，2、特殊
        /// </summary>
        public int LabType
        {
            set { _labtype = value; }
            get { return _labtype; }
        }
        /// <summary>
        /// 审核状态 1、未审核，2、审核不通过，3、审核通过
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
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
