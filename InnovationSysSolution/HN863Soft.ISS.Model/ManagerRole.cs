/**  版本信息模板在安装目录下，可自行修改。
* ManagerRole.cs
*
* 功 能： N/A
* 类 名： ManagerRole
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:00   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　　   │
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 管理角色表
	/// </summary>
	[Serializable]
	public partial class ManagerRole
	{
		public ManagerRole(){}

		private int _id;
		private string _rolename;
		private int _roletype;
		private int _issys=0;

		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 角色类型
		/// </summary>
		public int RoleType
		{
			set{ _roletype=value;}
			get{return _roletype;}
		}
		/// <summary>
		/// 是否系统默认0否1是
		/// </summary>
		public int IsSys
		{
			set{ _issys=value;}
			get{return _issys;}
		}

        private List<ManagerRoleValue> _managerRoleValues;
        /// <summary>
        /// 权限子类 
        /// </summary>
        public List<ManagerRoleValue> ManagerRoleValues
        {
            set { _managerRoleValues = value; }
            get { return _managerRoleValues; }
        }
	}
}

