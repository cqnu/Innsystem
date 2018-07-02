using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：TalentService_Moify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑人才服务
// 创建日期（Create Date）：2017/03/01
// 修改记录(Revision History)：
// R1
// 修改作者：雷登辉
// 修改日期：2017/3/9
// 修改内容：增加发布信息类型选择、进行发布信息分类、以便于分类检索
//*****************************
namespace HN863Soft.ISS.Web.Manage.TalentService
{
    public partial class TalentService_Moify : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindType();
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ViewState["id"] = Request.Params["id"];
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 绑定信息类型

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            foreach (EnumsHelper.TalentServiceType item in Enum.GetValues(typeof(EnumsHelper.TalentServiceType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion

        #region 方法

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.TalentServiceBll bll = new HN863Soft.ISS.BLL.TalentServiceBll();
            HN863Soft.ISS.Model.TalentService model = bll.GetModel(ID);
            this.txtTitle.Text = model.Title;
            this.container.Text = model.Content;
            this.ddlType.SelectedValue = model.Type.ToString();
            Image1.ImageUrl = model.LogImg;//Log路径
            txtIntroduce.Text = model.Introduce;//简介
            txtKeyWord.Text = model.KeyWord;//关键词
        }

        #endregion

        #region 上传图片

        private string UploadImg()
        {
            string savePath = "";
            if (FileUpload1.HasFile)
            {
                savePath = Server.MapPath("~/SoftWareService/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\SoftWareService\\" + FileName;
            }
            return savePath;
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
            string strImgUrl = UploadImg();
            HN863Soft.ISS.Model.TalentService model = new HN863Soft.ISS.Model.TalentService();
            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = this.container.Text.Trim().ToString();
            model.State = 0;
            model.Describe = "";
            model.Type = int.Parse(ddlType.SelectedValue);
            model.LogImg = strImgUrl;//Log路径
            model.Introduce = txtIntroduce.Text;//简介
            model.KeyWord = txtKeyWord.Text;//关键词
            HN863Soft.ISS.BLL.TalentServiceBll bll = new HN863Soft.ISS.BLL.TalentServiceBll();
            if (bll.Update(model))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功" + "');setTimeout(OpenClose, 3000);");
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改人才服务"); //记录日志
                Response.Redirect("TalentService_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');setTimeout(OpenClose, 3000);");
            }
        }

        #endregion
    }
}