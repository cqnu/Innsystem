using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.TechnicalService
{
    public partial class TechnicalServiceAuditModify : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelTechnicalServiceAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ViewState["id"] = Request.Params["id"];
                    TreeBind();
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        private void TreeBind()
        {
            ddlType.Items.Clear();
            this.ddlType.Items.Add(new ListItem("请选择类型...", ""));
            this.ddlType.Items.Add(new ListItem("登记", "1"));
            this.ddlType.Items.Add(new ListItem("认证", "2"));
            this.ddlType.Items.Add(new ListItem("检索", "3"));
            this.ddlType.Items.Add(new ListItem("转让", "4"));
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.TechnicalServiceBll bll = new HN863Soft.ISS.BLL.TechnicalServiceBll();
            HN863Soft.ISS.Model.TechnicalService model = bll.GetModel(ID);
            this.txtTitle.Text = model.Title;
            this.tarContent.InnerHtml = model.Content;
            ddlType.SelectedIndex = model.ActiveState;
        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelTechnicalServiceAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            string strErr = "";

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "主题内容不能为空！\\n";
            }
            if (this.tarContent.InnerHtml.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }

            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');");
                return;
            }

            HN863Soft.ISS.Model.TechnicalService model = new HN863Soft.ISS.Model.TechnicalService();
            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = this.tarContent.InnerText.Trim().ToString();
            model.State = 0;
            model.Describe = "";
            model.ActiveState = ddlType.SelectedIndex;
            HN863Soft.ISS.BLL.TechnicalServiceBll bll = new HN863Soft.ISS.BLL.TechnicalServiceBll();
            if (bll.Update(model))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功" + "');");
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改技术服务"); //记录日志
                Response.Redirect("TechnicalServiceAuditList.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}