using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.LinkPatent
{
    public partial class LinkPatent_Modify : ManagePage
    {

        public string strUrl;

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

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.LinkPatentBll bll = new HN863Soft.ISS.BLL.LinkPatentBll();
            HN863Soft.ISS.Model.LinkPatent model = bll.GetModel(ID);
            txtSiteName.Text = model.SiteName;
            txtSiteUrl.Text = model.SiteUrl;
            txtSiteDescription.Text = model.SiteDescription;
            //Image1.ImageUrl = model.LogUrl;
            strUrl = model.LogUrl;
            Image1.ImageUrl = model.LogUrl;
        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {


            HN863Soft.ISS.Model.LinkPatent model = new HN863Soft.ISS.Model.LinkPatent();

            string savePath = "";
            if (FileUpload1.HasFile)
            {

                savePath = Server.MapPath("~/img/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\img\\" + FileName;
            }
            model.LogUrl = savePath;

            model.ID = int.Parse(ViewState["id"].ToString());
            model.SiteName = txtSiteName.Text.Trim().ToString();
            model.SiteUrl = txtSiteUrl.Text.Trim().ToString();
            model.SiteDescription = txtSiteDescription.Text.Trim().ToString();

            HN863Soft.ISS.BLL.LinkPatentBll bll = new HN863Soft.ISS.BLL.LinkPatentBll();
            if (bll.Update(model))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功" + "');setTimeout(OpenClose, 3000);");
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改链接专利、商标查询网站"); //记录日志
                Response.Redirect("LinkPatent_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }
        }

        #endregion
    }
}