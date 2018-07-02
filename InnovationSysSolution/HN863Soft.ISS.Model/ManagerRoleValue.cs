/**  版本信息模板在安装目录下，可自行修改。
* ManagerRoleValue.cs
*
* 功 能： N/A
* 类 名： ManagerRoleValue
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:00   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　　   　│
*└──────────────────────────────────┘
*/
using System;
namespace HN863Soft.ISS.Model
{
	/// <summary>
	/// 管理角色权限表
	/// </summary>
	[Serializable]
	public partial class ManagerRoleValue
	{
		public ManagerRoleValue(){}

		private int _id;
		private int _roleid;
		private string _navname;
		private string _actiontype;

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
		/// 导航名称
		/// </summary>
		public string NavName
		{
			set{ _navname=value;}
			get{return _navname;}
		}
		/// <summary>
		/// 权限类型
		/// </summary>
		public string ActionType
		{
			set{ _actiontype=value;}
			get{return _actiontype;}
		}
	}
}

