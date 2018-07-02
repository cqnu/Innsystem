using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.LinkPatent
{
    public partial class LinkPatent_Add : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion


        #region 事件

        protected void btnSave_Click(object sender, EventArgs e)
        {


            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            HN863Soft.ISS.Model.LinkPatent model = new HN863Soft.ISS.Model.LinkPatent();
            string savePath="";
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

            model.UserId = Mmodel.ID;
            model.SiteName = txtSiteName.Text.Trim();
            model.SiteUrl = txtSiteUrl.Text.Trim();
            model.SiteDescription = txtSiteDescription.Text.Trim();
            model.hits = 0;
            model.LogUrl = savePath;
            HN863Soft.ISS.BLL.LinkPatentBll bll = new HN863Soft.ISS.BLL.LinkPatentBll();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加链接专利、商标查询网站"); //记录日志

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