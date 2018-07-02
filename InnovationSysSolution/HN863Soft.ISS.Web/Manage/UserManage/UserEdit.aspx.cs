using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Settings
{
    public partial class UserEdit : ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = EnumsHelper.ActionEnum.Edit.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.Manager().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("user_list", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                Manager model = GetManageInfo(); //取得用户信息
                RoleBind(model.RoleID, model.RoleType);
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(int roleID, int roleType)
        {
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            DataTable dt = bll.GetList("").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["RoleType"]) == roleType && Convert.ToInt32(dr["ID"]) == roleID)
                {
                    tbUserRole.Text = dr["RoleName"].ToString();
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = bll.GetModel(_id);

            txtUserName.Text = model.UserName;
            txtUserName.ReadOnly = true;
            txtUserName.Attributes.Remove("ajaxurl");
            if (!string.IsNullOrEmpty(model.Password))
            {
                txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
            }
            txtRealName.Text = model.RealName;
            txtTelephone.Text = model.Telephone;
            txtEmail.Text = model.Email;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = bll.GetModel(_id);
            Users umodel = new Users();
            //判断密码是否更改
            if (txtPassword.Text.Trim() != defaultpassword)
            {
                //获取用户已生成的salt作为密钥加密
                model.Password = EncryptionHelper.Encrypt(txtPassword.Text.Trim(), model.Salt);
            }
            umodel.NickName = model.RealName = txtRealName.Text.Trim();
            umodel.Telphone = model.Telephone = txtTelephone.Text.Trim();
            umodel.Email = model.Email = txtEmail.Text.Trim();
            umodel.MId = model.ID;
            umodel.UserName = model.UserName;
            umodel.Salt = model.Salt;
            umodel.Password = model.Password;
            if (bll.Update(model,umodel))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改用户:" + model.UserName); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("user_list", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }





                Response.Redirect("UserList.aspx");
            }
        }
    }
}