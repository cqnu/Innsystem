using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：FinancingService_Add.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑发布的内容
// 创建日期（Create Date）：2017/02/27
//*****************************
namespace HN863Soft.ISS.Web.Manage.FinancingService
{
    public partial class FinancingService_Add : ManagePage
    {

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion


        #region 事件

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
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

            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            HN863Soft.ISS.Model.FinancingService model = new HN863Soft.ISS.Model.FinancingService();
            model.UserId = Mmodel.ID;
            model.Title = txtTitle.Text;
            model.Content = container.Text;
            model.datatime = System.DateTime.Now;
            model.hits = 0;
            model.State = 0;
            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            if (bll.Add(model) > 0)
            {

                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加投融资服务"); //记录日志

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