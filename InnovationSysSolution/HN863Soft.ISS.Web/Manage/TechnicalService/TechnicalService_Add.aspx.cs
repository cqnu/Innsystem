using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：TechnicalService_Add.cs
// 作者（Author）：邹峰
// 功能（Function）：添加技术服务
// 创建日期（Create Date）：2017/03/01
//*****************************
namespace HN863Soft.ISS.Web.Manage.TechnicalService
{
    public partial class TechnicalService_Add : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelTechnicalServiceList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                TreeBind();
            }
        }

        #endregion

        #region 事件

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelTechnicalServiceList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            string strErr = "";

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.tarContent.InnerText.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }

            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');");
                return;
            }

            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            HN863Soft.ISS.Model.TechnicalService model = new HN863Soft.ISS.Model.TechnicalService();
            model.UserId = Mmodel.ID;
            model.Title = txtTitle.Text;
            model.Content = tarContent.InnerText;
            model.datatime = System.DateTime.Now;
            model.hits = 0;
            model.State = 0;
            model.ActiveState = ddlType.SelectedIndex;
            HN863Soft.ISS.BLL.TechnicalServiceBll bll = new HN863Soft.ISS.BLL.TechnicalServiceBll();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加技术服务"); //记录日志

                Response.Redirect("TechnicalService_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
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

        #endregion
    }
}