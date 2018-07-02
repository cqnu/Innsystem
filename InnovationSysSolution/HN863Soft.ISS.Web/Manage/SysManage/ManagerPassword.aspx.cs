using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.SysManage
{
    public partial class ManagerPassword : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Manager model = GetManageInfo();
                ShowInfo(model.ID);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = bll.GetModel(id);
            txtUserName.Text = model.UserName;
            txtRealName.Text = model.RealName;
            txtTelephone.Text = model.Telephone;
            txtEmail.Text = model.Email;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = GetManageInfo();

            if (EncryptionHelper.Encrypt(txtOldPassword.Text.Trim(), model.Salt) != model.Password)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('旧密码不正确！');");
                return;
            }
            if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
            {
                ShowMsgHelper.ShowScript("showWarningMsg('两次密码不一致！');");
                return;
            }
            model.Password = EncryptionHelper.Encrypt(txtPassword.Text.Trim(), model.Salt);
            model.RealName = txtRealName.Text.Trim();
            model.Telephone = txtTelephone.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            HN863Soft.ISS.BLL.Users users = new HN863Soft.ISS.BLL.Users();
            if (users.UpdatePwd(model.UserName, model.Password, model.Salt)==0)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                return;
            }
            Session[KeysHelper.SESSION_MANAGE_INFO] = null;

            Session[KeysHelper.ForegroundUser] = null;



      
            Response.Write("<script>window.parent.document.location='/Web/index.html'</script>");



        }
    }
}