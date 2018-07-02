/**  版本信息模板在安装目录下，可自行修改。
* Manager.cs
*
* 功 能： N/A
* 类 名： Manager
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:59   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 管理员信息表
	/// </summary>
	[Serializable]
	public partial class Manager
	{
		public Manager(){}

		private int _id;
		private int _roleid;
		private int _roletype=2;
		private string _username;
		private string _password;
		private string _salt;
		private string _realname="";
		private string _telephone="";
		private string _email="";
		private int _islock=0;
        private int _isuseable = 0;
		private DateTime _createtime= DateTime.Now;
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 管理员类型1超管2系管
		/// </summary>
		public int RoleType
		{
			set{ _roletype=value;}
			get{return _roletype;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 6位随机字符串,加密用到
		/// </summary>
		public string Salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 用户昵称
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
        /// <summary>
        /// 是否认证
        /// </summary>
        public int IsUseable
        {
            get { return _isuseable; }
            set { _isuseable = value; }
        }
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
	}
}

