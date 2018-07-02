using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑技术信息资源
// 创建日期（Create Date）：2017/02/16
//*****************************
namespace HN863Soft.ISS.Web.TechnicalInformation
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
                    ViewState["category"] = Request.Params["category"];
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();
            HN863Soft.ISS.Model.TechnicalInformation model = bll.GetModel(ID);

            this.txtEntryName.Text = model.EntryName;
            this.container.InnerText = model.DetailedContent;
            this.container2.InnerText = model.Institutionaldisplay;
            this.txtKeyword.Text = model.Keyword;
        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {

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
                ShowMsgHelper.ShowScript("showWarningMsg('"+ strErr +"');setTimeout(OpenClose, 3000);");
                return;
            }

            string EntryName = this.txtEntryName.Text;
            string DetailedContent = this.container.InnerText;

            HN863Soft.ISS.Model.TechnicalInformation model = new HN863Soft.ISS.Model.TechnicalInformation();

            model.EntryName = EntryName;
            model.DetailedContent = DetailedContent;
            model.Keyword = this.txtKeyword.Text;
            model.Institutionaldisplay = container2.InnerText;
            model.ID = int.Parse(ViewState["id"].ToString());
            model.State = 0;
            model.Describe = "";
            HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();


            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改技术信息资源"); //记录日志
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功！" + "');setTimeout(OpenClose, 3000);");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }

            if (ViewState["category"].ToString() == "1")
            {
                Response.Redirect("TechnicalInformation_List.aspx");
            }
            else
            {
                Response.Redirect("TechnicalInformation_List.aspx");
            }

        }

        #endregion
    }
}
