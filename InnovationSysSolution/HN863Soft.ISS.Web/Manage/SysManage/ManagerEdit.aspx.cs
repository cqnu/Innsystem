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

namespace _863soft.ISS.Web.Manage.SysManage
{
    public partial class ManagerEdit : ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
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
                if (!ChkManageLevel("ManagerList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                Manager model = GetManageInfo(); //取得管理员信息
                RoleBind(ddlRoleId, model.RoleID);
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(DropDownList ddl, int roleID)
        {
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            DataTable dt = bll.GetList("").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["ID"]) >= roleID)
                {
                    ddl.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["ID"].ToString()));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {


            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = bll.GetModel(_id);

            ddlRoleId.SelectedValue = model.RoleID.ToString();
            if (model.IsLock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
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
            txtIntegral.Text = bll.GetIntegral(model.ID);
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Manager model = new Manager();
            Users umodel = new Users();

            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            model.RoleID = int.Parse(ddlRoleId.SelectedValue);
            model.RoleType = new HN863Soft.ISS.BLL.ManagerRole().GetModel(model.RoleID).RoleType;
            if (cbIsLock.Checked == true)
            {
                model.IsLock = 0;
            }
            else
            {
                model.IsLock = 1;
            }
            //检测用户名是否重复
            if (bll.Exists(txtUserName.Text.Trim()))
            {
                return false;
            }
            if (bll.ExistsReception(txtUserName.Text.Trim()))
            {
                return false;
            }
            model.UserName = txtUserName.Text.Trim();
            //获得6位的salt加密字符串
            model.Salt = Utils.GetCheckCode(6);
            //以随机生成的6位字符串做为密钥加密
            model.Password = EncryptionHelper.Encrypt(txtPassword.Text.Trim(), model.Salt);
            model.RealName = txtRealName.Text.Trim();
            model.Telephone = txtTelephone.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            model.CreateTime = DateTime.Now;
            model.Status = 1;

            umodel.Email = txtEmail.Text.Trim();
            umodel.NickName = txtRealName.Text.Trim();
            umodel.Salt = model.Salt;
            umodel.Password = model.Password;
            umodel.UserName = txtUserName.Text.Trim();
            umodel.Status = 1;
            umodel.RegTime = DateTime.Now;
            umodel.Birthday = DateTime.Now;
            umodel.Point = int.Parse(txtIntegral.Text);
            HN863Soft.ISS.BLL.Users users = new HN863Soft.ISS.BLL.Users();

            if (bll.Add(model) > 0)
            {
                umodel.MId = bll.GetModel(model.UserName, model.Password).ID;

                if (bll.AddUser(umodel) > 0)
                {

                    HN863Soft.ISS.BLL.Organization orBll = new HN863Soft.ISS.BLL.Organization();
                    HN863Soft.ISS.Model.Organization orModel = new Organization();
                    orModel.UserID = umodel.MId;
                    orModel.CreateTime = DateTime.Now;
                    orModel.State = 1;
                    orModel.OrgType = int.Parse(ddlRoleId.SelectedValue);
                    if (orBll.Add(orModel) > 0)
                    {

                        AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加用户:" + model.UserName); //记录日志
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            Manager model = bll.GetModel(_id);
            Users umodel = new Users();
            model.RoleID = int.Parse(ddlRoleId.SelectedValue);
            model.RoleType = new HN863Soft.ISS.BLL.ManagerRole().GetModel(model.RoleID).RoleType;
            if (cbIsLock.Checked == true)
            {
                model.IsLock = 0;
                umodel.Status = 1;
            }
            else
            {
                model.IsLock = 1;
                umodel.Status = 0;
            }
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
            umodel.Point = int.Parse(txtIntegral.Text);
            if (bll.Update(model, umodel))
            {

                bll.UpdateOrganizationType(model.ID, model.RoleID);



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
                if (!ChkManageLevel("ManagerList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                //ShowMsgHelper.ShowScript("showWarningMsg('修改用户信息成功！');");
                //return;
                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/ManagerList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("ManagerList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                //ShowMsgHelper.ShowScript("showWarningMsg('添加用户信息成功！');");
                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/ManagerList.aspx';");
            }
        }
    }
}