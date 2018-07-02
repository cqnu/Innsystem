using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Management
{
    public partial class Management_Add : ManagePage
    {

        #region 变量

        private readonly HN863Soft.ISS.BLL.ManagementBll bll = new BLL.ManagementBll();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HN863Soft.ISS.Model.Management model = new Model.Management();

            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();

            model.UserId = Mmodel.ID;//发布人id
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = container.Text;

            model.Remarks = txtRemarks.Text.Trim().ToString();
            model.Time = System.DateTime.Now;


            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加管理制度"); //记录日志

                Response.Redirect("Management_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }
        }
    }
}