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

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class NavEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.Navigation().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('导航不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                TreeBind(EnumsHelper.NavigationEnum.System.ToString()); //绑定导航菜单
                ActionTypeBind(); //绑定操作权限类型
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                    txtName.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=navigation_validate");
                }
            }
        }

        #region 绑定导航菜单=============================
        private void TreeBind(string nav_type)
        {
            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            DataTable dt = bll.GetList(0, nav_type);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级导航", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["ID"].ToString();
                int ClassLayer = int.Parse(dr["ClassLayer"].ToString());
                string Title = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 绑定操作权限类型=========================
        private void ActionTypeBind()
        {
            cblActionType.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in Utils.ActionType())
            {
                cblActionType.Items.Add(new ListItem(kvp.Value + "(" + kvp.Key + ")", kvp.Key));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            var model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.ParentID.ToString();
            txtSortId.Text = model.SortID.ToString();
            if (model.IsLock == 1)
            {
                cbIsLock.Checked = true;
            }
            txtName.Text = model.Name;
            txtName.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=navigation_validate&old_name=" + Utils.UrlEncode(model.Name));
            txtName.Focus(); //设置焦点，防止JS无法提交
            if (model.IsSys == 1)
            {
                ddlParentId.Enabled = false;
                txtName.ReadOnly = true;
            }
            txtTitle.Text = model.Title;
            txtSubTitle.Text = model.SubTitle;
            txtIconUrl.Text = model.IconUrl;
            txtLinkUrl.Text = model.LinkUrl;
            txtRemark.Text = model.Remark;
            //赋值操作权限类型
            string[] actionTypeArr = model.ActionType.Split(',');
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                for (int n = 0; n < actionTypeArr.Length; n++)
                {
                    if (actionTypeArr[n].ToLower() == cblActionType.Items[i].Value.ToLower())
                    {
                        cblActionType.Items[i].Selected = true;
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Navigation model = new Navigation();
                HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();

                model.NavType = EnumsHelper.NavigationEnum.System.ToString();
                model.Name = txtName.Text.Trim();
                model.Title = txtTitle.Text.Trim();
                model.SubTitle = txtSubTitle.Text.Trim();
                model.IconUrl = txtIconUrl.Text.Trim();
                model.LinkUrl = txtLinkUrl.Text.Trim();
                model.SortID = int.Parse(txtSortId.Text.Trim());
                model.IsLock = 0;
                if (cbIsLock.Checked == true)
                {
                    model.IsLock = 1;
                }
                model.Remark = txtRemark.Text.Trim();
                model.ParentID = int.Parse(ddlParentId.SelectedValue);

                //添加操作权限类型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.ActionType = Utils.DelLastComma(action_type_str);

                if (bll.Add(model) > 0)
                {
                    AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加导航菜单:" + model.Title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
                var model = bll.GetModel(_id);

                model.Name = txtName.Text.Trim();
                model.Title = txtTitle.Text.Trim();
                model.SubTitle = txtSubTitle.Text.Trim();
                model.IconUrl = txtIconUrl.Text.Trim();
                model.LinkUrl = txtLinkUrl.Text.Trim();
                model.SortID = int.Parse(txtSortId.Text.Trim());
                model.IsLock = 0;
                if (cbIsLock.Checked == true)
                {
                    model.IsLock = 1;
                }
                model.Remark = txtRemark.Text.Trim();
                if (model.IsSys == 0)
                {
                    int parentId = int.Parse(ddlParentId.SelectedValue);
                    //如果选择的父ID不是自己,则更改
                    if (parentId != model.ID)
                    {
                        model.ParentID = parentId;
                    }
                }

                //添加操作权限类型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.ActionType = Utils.DelLastComma(action_type_str);

                if (bll.Update(model))
                {
                    AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "修改导航菜单:" + model.Title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                //ShowScriptMsg("修改导航菜单成功！", "NavList.aspx", "parent.loadMenuTree");
                ShowMsgHelper.ShowScript("location.href='/Manage/Settings/NavList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                //ShowScriptMsg("添加导航菜单成功！", "NavList.aspx", "parent.loadMenuTree");
                ShowMsgHelper.ShowScript("location.href='/Manage/Settings/NavList.aspx';");
            }
        }
    }
}