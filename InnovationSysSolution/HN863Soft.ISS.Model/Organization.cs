using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// Orgnization:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Organization
    {
        public Organization(){ }

        #region Model
        private int _id;
        private int? _hid;
        private int _userid;
        private string _orgname;
        private string _orglocation;
        private string _orgintro;
        private string _proposer;
        private string _proposermobile;
        private string _proposercard;
        private string _proposeremail;
        private string _weixin;
        private int _orgtype;
        private string _evidence;
        private string _orgexhibit;
        private int _state;
        private DateTime? _createtime;
        private string _remark;
        private int? _regionId;
        private string _logImg;
        private string _lat;
        private string _videoUrl;
        private string _weburl;
        private string _idCadrUrlZ;
        private string _idCadrUrlF;

        /// <summary>
        /// 身份证反面
        /// </summary>
        public string IdCadrUrlF
        {
            get { return _idCadrUrlF; }
            set { _idCadrUrlF = value; }
        }

        /// <summary>
        /// 身份证证明
        /// </summary>
        public string IdCadrUrlZ
        {
            get { return _idCadrUrlZ; }
            set { _idCadrUrlZ = value; }
        }

        public string Weburl
        {
            get { return _weburl; }
            set { _weburl = value; }
        }

        /// <summary>
        /// 视频路径
        /// </summary>
        public string VideoUrl
        {
            get { return _videoUrl; }
            set { _videoUrl = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        private string _lng;
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        /// <summary>
        /// Log路径
        /// </summary>
        public string LogImg
        {
            get { return _logImg; }
            set { _logImg = value; }
        }
        private string _introduce;
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduce
        {
            get { return _introduce; }
            set { _introduce = value; }
        }

        /// <summary>
        /// 区域： 市
        /// </summary>
        public int? RegionId
        {
            get { return _regionId; }
            set { _regionId = value; }
        }
        /// <summary>
        /// 机构入驻ID
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
        /// 机构名称
        /// </summary>
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }
        /// <summary>
        /// 机构位置
        /// </summary>
        public string OrgLocation
        {
            set { _orglocation = value; }
            get { return _orglocation; }
        }
        /// <summary>
        /// 机构简介
        /// </summary>
        public string OrgIntro
        {
            set { _orgintro = value; }
            get { return _orgintro; }
        }
        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer
        {
            set { _proposer = value; }
            get { return _proposer; }
        }
        /// <summary>
        /// 申请人电话
        /// </summary>
        public string ProposerMobile
        {
            set { _proposermobile = value; }
            get { return _proposermobile; }
        }
        /// <summary>
        /// 申请人QQ
        /// </summary>
        public string ProposerCard
        {
            set { _proposercard = value; }
            get { return _proposercard; }
        }
        /// <summary>
        /// 申请人电子邮件
        /// </summary>
        public string ProposerEmail
        {
            set { _proposeremail = value; }
            get { return _proposeremail; }
        }
        /// <summary>
        /// 微信
        /// </summary>
        public string WeiXin
        {
            set { _weixin = value; }
            get { return _weixin; }
        }
        /// <summary>
        /// 机构类型 1、专家，2、机构，3、企业，4、其它
        /// </summary>
        public int OrgType
        {
            set { _orgtype = value; }
            get { return _orgtype; }
        }
        /// <summary>
        /// 机构证明文件
        /// </summary>
        public string Evidence
        {
            set { _evidence = value; }
            get { return _evidence; }
        }
        /// <summary>
        /// 机构展示
        /// </summary>
        public string OrgExhibit
        {
            set { _orgexhibit = value; }
            get { return _orgexhibit; }
        }
        /// <summary>
        /// 机构状态 1、未审核，2、审核不通过，3、审核通过
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 申请时间
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
