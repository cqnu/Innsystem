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
    public partial class Management_Modify : ManagePage
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.ManagementBll bll = new BLL.ManagementBll();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string strid = Request.Params["id"];
                    ViewState["id"] = strid;
                    int ID = (Convert.ToInt32(strid));

                    ShowInfo(ID);
                }
            }
        }

        #region 方法

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {

            HN863Soft.ISS.Model.Management model = bll.GetModel(ID);

            txtTitle.Text = model.Title;

            txtRemarks.Text = model.Remarks;

            container.Text = model.Content;

        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HN863Soft.ISS.Model.Management model = new Model.Management();

            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = container.Text;
            model.Remarks = txtRemarks.Text.Trim().ToString();

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改管理制度"); //记录日志

                Response.Redirect("Management_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }

        }
    }
}