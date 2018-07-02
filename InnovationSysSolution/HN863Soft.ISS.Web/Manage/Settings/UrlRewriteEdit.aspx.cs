using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
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
    public partial class UrlRewriteEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private string urlName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                this.urlName = RequestHelper.GetQueryString("name");
                if (string.IsNullOrEmpty(this.urlName))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("SysUrlRewrite", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定频道
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(urlName);
                }
                else
                {
                    txtName.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=urlrewrite_name_validate");
                }
            }
        }

        #region 绑定频道=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            DataTable dt = bll.GetList(0, "", "SortID asc,ID desc").Tables[0];

            this.ddlChannel.Items.Clear();
            this.ddlChannel.Items.Add(new ListItem("不属于频道", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlChannel.Items.Add(new ListItem(dr["Title"].ToString(), dr["Name"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(string _urlName)
        {
            HN863Soft.ISS.BLL.UrlRewrite bll = new HN863Soft.ISS.BLL.UrlRewrite();
            var model = bll.GetInfo(_urlName);

            txtName.Text = model.name;
            txtName.ReadOnly = true;
            ddlType.SelectedValue = model.type;
            ddlChannel.SelectedValue = model.channel;
            txtPage.Text = model.page;
            txtInherit.Text = model.inherit;
            txtTemplet.Text = model.templet;
            txtPageSize.Text = model.pagesize;
            //绑定URL配置列表
            rptList.DataSource = model.UrlRewriteItems;
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            HN863Soft.ISS.BLL.UrlRewrite bll = new HN863Soft.ISS.BLL.UrlRewrite();
            UrlRewrite model = new UrlRewrite();

            model.name = txtName.Text.Trim();
            model.type = ddlType.SelectedValue;
            model.channel = ddlChannel.SelectedValue;
            model.page = txtPage.Text.Trim();
            model.inherit = txtInherit.Text.Trim();
            model.templet = txtTemplet.Text.Trim();
            if (!string.IsNullOrEmpty(txtPageSize.Text.Trim()))
            {
                model.pagesize = txtPageSize.Text.Trim();
            }
            //添加URL重写节点
            List<UrlRewriteItem> items = new List<UrlRewriteItem>();
            string[] itemPathArr = Request.Form.GetValues("itemPath");
            string[] itemPatternArr = Request.Form.GetValues("itemPattern");
            string[] itemQuerystringArr = Request.Form.GetValues("itemQuerystring");
            if (itemPathArr != null && itemPatternArr != null && itemQuerystringArr != null)
            {
                for (int i = 0; i < itemPathArr.Length; i++)
                {
                    items.Add(new UrlRewriteItem { path = itemPathArr[i], pattern = itemPatternArr[i], querystring = itemQuerystringArr[i] });
                }
            }
            model.UrlRewriteItems = items;

            if (bll.Add(model))
            {
                AddAdminLog(EnumsHelper.ActionEnum.Add.ToString(), "添加URL配置信息:" + model.name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(string _urlName)
        {
            HN863Soft.ISS.BLL.UrlRewrite bll = new HN863Soft.ISS.BLL.UrlRewrite();
            UrlRewrite model = bll.GetInfo(_urlName);

            model.type = ddlType.SelectedValue;
            model.channel = ddlChannel.SelectedValue;
            model.page = txtPage.Text.Trim();
            model.inherit = txtInherit.Text.Trim();
            model.templet = txtTemplet.Text.Trim();
            if (!string.IsNullOrEmpty(txtPageSize.Text.Trim()))
            {
                model.pagesize = txtPageSize.Text.Trim();
            }
            //添加URL重写节点
            List<UrlRewriteItem> items = new List<UrlRewriteItem>();
            string[] itemPathArr = Request.Form.GetValues("itemPath");
            string[] itemPatternArr = Request.Form.GetValues("itemPattern");
            string[] itemQuerystringArr = Request.Form.GetValues("itemQuerystring");
            if (itemPathArr != null && itemPatternArr != null && itemQuerystringArr != null)
            {
                for (int i = 0; i < itemPathArr.Length; i++)
                {
                    items.Add(new UrlRewriteItem { path = itemPathArr[i], pattern = itemPatternArr[i], querystring = itemQuerystringArr[i] });
                }
            }
            model.UrlRewriteItems = items;

            if (bll.Edit(model))
            {
                AddAdminLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改URL配置信息:" + model.name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("SysUrlRewrite", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.urlName))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改配置成功！", "UrlRewriteList.aspx");
            }
            else //添加
            {
                ChkAdminLevel("SysUrlRewrite", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加配置成功！", "UrlRewriteList.aspx");
            }
        }
    }
}