using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Ariticle
{
    public partial class AriticleAuditModify : ManagePage
    {

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelAriticleAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

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

        #region 绑定工业类型
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            //lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.IndustrialType item in Enum.GetValues(typeof(EnumsHelper.IndustrialType)))
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

        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.userAriticle bll = new HN863Soft.ISS.BLL.userAriticle();
            HN863Soft.ISS.Model.userAriticle model = bll.GetModel(ID);
            this.txtTitle.Text = model.Title;
            this.container.Text = model.Content;
            this.ddlType.SelectedValue = model.Type.ToString();//工业类型
            Image1.ImageUrl = model.Logimg;//Log图片
            txtKeyWord.Text = model.Keyword;//关键词
            txtIntroduce.Text = model.Introduce;//简介

        }

        #endregion

        #region 事件

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelAriticleAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

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
                ShowMsgHelper.ShowScript("showWarningMsg('" + strErr + "');");
                return;
            }
            string savePath = "";
            if (FileUpload1.HasFile)
            {
                savePath = Server.MapPath("~/userAriticleLog/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\userAriticleLog\\" + FileName;
            }

            HN863Soft.ISS.Model.userAriticle model = new HN863Soft.ISS.Model.userAriticle();
            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.Content = this.container.Text.Trim().ToString();
            model.State = 0;
            model.Describe = "";
            model.Type = Convert.ToInt32(ddlType.SelectedValue);//工业类型
            model.Logimg = savePath;//Log路径
            model.Keyword = txtKeyWord.Text;//关键词
            model.Introduce = txtIntroduce.Text;//简介
            HN863Soft.ISS.BLL.userAriticle bll = new HN863Soft.ISS.BLL.userAriticle();
            if (bll.Update(model))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存成功" + "');");
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改工业设计"); //记录日志
                Response.Redirect("AriticleAuditList.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}