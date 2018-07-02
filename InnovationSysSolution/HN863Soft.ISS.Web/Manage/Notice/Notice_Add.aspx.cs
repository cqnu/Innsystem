using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Add.cs
// 作者（Author）：邹峰
// 功能（Function）：添加通知公告
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.Web.Notice
{
    public partial class Add : ManagePage
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

            if (this.txtPublishContent.Text.Trim().Length == 0)
            {
                strErr += "发布内容不能为空！\\n";
            }

            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');setTimeout(OpenClose, 3000);");
                return;
            }

            //取Session信息
            Model.Manager Mmodel = Session[KeysHelper.SESSION_MANAGE_INFO] as Model.Manager;

            string PublishContent = this.txtPublishContent.Text;
            string Remarks = this.txtRemarks.Text;

            HN863Soft.ISS.Model.Notice model = new HN863Soft.ISS.Model.Notice();
            model.ReleaseTime = System.DateTime.Now;
            model.PublishContent = PublishContent;
            model.Remarks = Remarks;
            model.Publisherid = Mmodel.ID;
            HN863Soft.ISS.BLL.Notice bll = new HN863Soft.ISS.BLL.Notice();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加通知公告"); //记录日志

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
