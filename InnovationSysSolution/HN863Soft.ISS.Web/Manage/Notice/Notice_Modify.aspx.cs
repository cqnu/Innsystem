using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑通知公告
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.Web.Notice
{
    public partial class Modify : ManagePage
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
            HN863Soft.ISS.BLL.Notice bll = new HN863Soft.ISS.BLL.Notice();
            HN863Soft.ISS.Model.Notice model = bll.GetModel(ID);
            this.txtPublishContent.Text = model.PublishContent;
            this.txtRemarks.Text = model.Remarks;

        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";

            if (this.txtPublishContent.Text.Trim().Length == 0)
            {
                strErr += "发布内容不能为空！\\n";
            }

            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');setTimeout(OpenClose, 3000);");
                return;
            }

            string PublishContent = this.txtPublishContent.Text;
            string Remarks = this.txtRemarks.Text;


            HN863Soft.ISS.Model.Notice model = new HN863Soft.ISS.Model.Notice();
            model.ID = int.Parse(ViewState["id"].ToString());
            model.PublishContent = PublishContent;
            model.Remarks = Remarks;

            HN863Soft.ISS.BLL.Notice bll = new HN863Soft.ISS.BLL.Notice();

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改通知公告"); //记录日志
                Response.Redirect("Notice_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }

        }

        #endregion
    }
}
