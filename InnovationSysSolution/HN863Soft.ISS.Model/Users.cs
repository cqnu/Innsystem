/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:01   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　　   │
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 会员主表
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users(){}

		private int _id;
		private int _groupid;
		private string _username;
		private string _salt;
		private string _password;
		private string _mobile="";
		private string _email="";
		private string _avatar="";
		private string _nickname="";
		private string _sex="";
		private DateTime _birthday;
		private string _telphone="";
		private string _area="";
		private string _address="";
		private string _qq="";
		private string _msn="";
		private decimal _amount=0M;
		private int _point=0;
		private int _exp=0;
		private int _status=0;
		private DateTime _regtime= DateTime.Now;
		private string _regip;
        private int _mId;

        /// <summary>
        /// 管理员Id
        /// </summary>
        public int MId
        {
            get { return _mId; }
            set { _mId = value; }
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
		/// 用户组ID
		/// </summary>
		public int GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
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
		/// 6位随机字符串,加密用到
		/// </summary>
		public string Salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		/// 用户头像
		/// </summary>
		public string Avatar
		{
			set{ _avatar=value;}
			get{return _avatar;}
		}
		/// <summary>
		/// 用户昵称
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 所属地区逗号分隔
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 详情地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// QQ号码
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// MSN号码
		/// </summary>
		public string Msn
		{
			set{ _msn=value;}
			get{return _msn;}
		}
		/// <summary>
		/// 账户余额
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 账户积分
		/// </summary>
		public int Point
		{
			set{ _point=value;}
			get{return _point;}
		}
		/// <summary>
		/// 升级经验值
		/// </summary>
		public int Exp
		{
			set{ _exp=value;}
			get{return _exp;}
		}
		/// <summary>
		/// 账户状态,0正常,1待验证,2待审核,3锁定
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 注册IP
		/// </summary>
		public string RegIP
		{
			set{ _regip=value;}
			get{return _regip;}
		}
	}
}

