using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：TechnicalService_Show.cs
// 作者（Author）：邹峰
// 功能（Function）：添加技术服务
// 创建日期（Create Date）：2017/03/01
//*****************************
namespace HN863Soft.ISS.Web.Manage.TechnicalService
{
    public partial class TechnicalService_Show : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelTechnicalServiceList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ViewState["id"] = Request.Params["id"];

                    ShowInfo(ID);
                }
                else
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您无权访问该页面');");
                    return;
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
            txtTitle.Enabled = false;
            this.tarContent.InnerHtml = model.Content;
            tarContent.Disabled = true;
            ddlType.SelectedIndex = model.ActiveState;
            ddlType.Enabled = false;
        }

        #endregion
    }
}