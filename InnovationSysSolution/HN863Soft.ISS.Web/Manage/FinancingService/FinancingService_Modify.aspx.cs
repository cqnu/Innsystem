using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：FinancingService_Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑投融资服务
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.Web.Manage.FinancingService
{
    public partial class FinancingService_Modify : ManagePage
    {

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ViewState["id"] = Request.Params["id"];
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            HN863Soft.ISS.Model.FinancingService model = bll.GetModel(ID);
            this.txtTitle.Text = model.Title;
            this.container.Text = model.Content;
        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "主题内容不能为空！\\n";
            }
            if (this.container.Text.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }


            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');setTimeout(OpenClose, 3000);");
                return;
            }

            HN863Soft.ISS.Model.FinancingService model = new HN863Soft.ISS.Model.FinancingService();
            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = this.container.Text.Trim().ToString();
            model.State = 0;
            model.Describe = "";
            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            if (bll.Update(model))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功" + "');setTimeout(OpenClose, 3000);");
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改投融资服务"); //记录日志
                Response.Redirect("FinancingService_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }
        }

        #endregion
    }
}