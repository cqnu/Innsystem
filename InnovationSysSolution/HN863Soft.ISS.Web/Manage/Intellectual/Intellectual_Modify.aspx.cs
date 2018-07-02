using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Web.UI;
// 文件名（File Name）：Intellectual_Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑知识产权信息
// 创建日期（Create Date）：2017/03/14
//*****************************
namespace HN863Soft.ISS.Web.Manage.Intellectual
{
    public partial class Intellectual_Modify : ManagePage
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.IntellectualBll bll = new BLL.IntellectualBll();

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelIntellectualList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string strid = Request.Params["id"];
                    ViewState["id"] = strid;
                    int ID = (Convert.ToInt32(strid));

                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {

            HN863Soft.ISS.Model.Intellectual model = bll.GetModel(ID);

            txtTitle.Text = model.Title;
            txtKeyWord.Text = model.KeyWord;
            Image1.ImageUrl = model.Cover;
            container.Text = model.Content;
            txtIntroduce.Text = model.Introduce;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelIntellectualList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.Model.Intellectual model = new Model.Intellectual();

            string savePath = Image1.ImageUrl;
            if (FileUpload1.HasFile)
            {
                savePath = Server.MapPath("~/EnterpriseRegistrationImg/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\EnterpriseRegistrationImg\\" + FileName;
            }

            model.ID = int.Parse(ViewState["id"].ToString());
            model.Title = txtTitle.Text.Trim().ToString();
            model.KeyWord = txtKeyWord.Text.Trim().ToString();
            model.Cover = savePath;
            model.Content = container.Text;
            model.State = 0;
            model.Describe = "";
            model.Introduce = txtIntroduce.Text.Trim().ToString();
            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改知识产权"); //记录日志

                Response.Redirect("Intellectual_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}