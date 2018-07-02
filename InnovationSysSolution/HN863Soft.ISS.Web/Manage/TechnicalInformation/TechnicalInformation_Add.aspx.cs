using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Add.cs
// 作者（Author）：邹峰
// 功能（Function）：添加技术信息资源
// 创建日期（Create Date）：2017/02/16
//*****************************
namespace HN863Soft.ISS.Web.TechnicalInformation
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
            string a = container.InnerText;

            string strErr = "";
            if (this.txtEntryName.Text.Trim().Length == 0)
            {
                strErr += "项目名称不能为空！\\n";
            }

            if (this.txtKeyword.Text.Trim().Length == 0)
            {
                strErr += "项目关键字不能为空！\\n";
            }
            if (this.container.InnerText.Trim().Length == 0)
            {
                strErr += "项目内容不能为空！\\n";
            }


            if (strErr != "")
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');setTimeout(OpenClose, 3000);");
                return;
            }
            string EntryName = this.txtEntryName.Text;
            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            HN863Soft.ISS.Model.TechnicalInformation model = new HN863Soft.ISS.Model.TechnicalInformation();
            model.EntryName = EntryName;
            model.Keyword = this.txtKeyword.Text;
            model.UserId = Mmodel.ID;
            model.DetailedContent = container.InnerText;
            model.Institutionaldisplay = container2.InnerText;
            model.Hits = 0;
            model.State = 0;
            HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加技术信息资源"); //记录日志

                Response.Redirect("TechnicalInformation_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }
        }

        #endregion
    }
}
