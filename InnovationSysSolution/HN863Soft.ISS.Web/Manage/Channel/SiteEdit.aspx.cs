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

namespace _863soft.ISS.Web.Manage.Channel
{
    public partial class SiteEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.ChannelSite().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("sys_site_manage", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    txtBuildPath.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=channel_site_validate");
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();
            ChannelSite model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtBuildPath.Text = model.BuildPath;
            txtBuildPath.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=channel_site_validate&old_build_path=" + Utils.UrlEncode(model.BuildPath));
            txtBuildPath.Focus(); //设置焦点，防止JS无法提交
            txtDomain.Text = model.Domain;
            txtSortId.Text = model.SortID.ToString();
            if (model.IsDefault == 1)
            {
                cbIsDefault.Checked = true;
            }
            else
            {
                cbIsDefault.Checked = false;
            }
            txtName.Text = model.Name;
            txtLogo.Text = model.Logo;
            txtCompany.Text = model.Company;
            txtAddress.Text = model.Address;
            txtTel.Text = model.Tel;
            txtFax.Text = model.Fax;
            txtEmail.Text = model.Email;
            txtCrod.Text = model.Crod;
            txtSeoTitle.Text = model.SEOTitle;
            txtSeoKeyword.Text = model.SEOKeyword;
            txtSeoDescription.Text = model.SEODescription;
            txtCopyright.Text = model.Copyright;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            var model = new ChannelSite();
            HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();

            model.Title = txtTitle.Text.Trim();
            model.BuildPath = txtBuildPath.Text.Trim();
            model.Domain = txtDomain.Text.Trim();
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            if (cbIsDefault.Checked == true)
            {
                model.IsDefault = 1;
            }
            else
            {
                model.IsDefault = 0;
            }
            model.Name = txtName.Text.Trim();
            model.Logo = txtLogo.Text.Trim();
            model.Company = txtCompany.Text.Trim();
            model.Address = txtAddress.Text.Trim();
            model.Tel = txtTel.Text.Trim();
            model.Fax = txtFax.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            model.Crod = txtCrod.Text.Trim();
            model.SEOTitle = txtSeoTitle.Text.Trim();
            model.SEOKeyword = txtSeoKeyword.Text.Trim();
            model.SEODescription = Utils.DropHTML(txtSeoDescription.Text);
            model.Copyright = txtCopyright.Text.Trim();

            if (bll.Add(model) > 0)
            {
                //更新一下域名缓存
                CacheHelper.Remove(KeysHelper.CACHE_SITE_HTTP_DOMAIN);
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加站点:" + model.Title); //记录日志
                return true;
            }

            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();
            ChannelSite model = bll.GetModel(_id);

            model.Title = txtTitle.Text.Trim();
            model.BuildPath = txtBuildPath.Text.Trim();
            model.Domain = txtDomain.Text.Trim();
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            if (cbIsDefault.Checked == true)
            {
                model.IsDefault = 1;
            }
            else
            {
                model.IsDefault = 0;
            }
            model.Name = txtName.Text.Trim();
            model.Logo = txtLogo.Text.Trim();
            model.Company = txtCompany.Text.Trim();
            model.Address = txtAddress.Text.Trim();
            model.Tel = txtTel.Text.Trim();
            model.Fax = txtFax.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            model.Crod = txtCrod.Text.Trim();
            model.SEOTitle = txtSeoTitle.Text.Trim();
            model.SEOKeyword = txtSeoKeyword.Text.Trim();
            model.SEODescription = Utils.DropHTML(txtSeoDescription.Text);
            model.Copyright = txtCopyright.Text.Trim();

            if (bll.Update(model))
            {
                //更新一下域名缓存
                CacheHelper.Remove(KeysHelper.CACHE_SITE_HTTP_DOMAIN);
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改站点:" + model.Title); //记录日志
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
                if (!ChkManageLevel("sys_site_manage", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                //ShowScriptMsg("修改站点信息成功！", "SiteList.aspx", "parent.loadMenuTree");
                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/SiteList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("sys_site_manage", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                //ShowScriptMsg("添加站点信息成功！", "SiteList.aspx", "parent.loadMenuTree");
                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/SiteList.aspx';");
            }
        }
    }
}