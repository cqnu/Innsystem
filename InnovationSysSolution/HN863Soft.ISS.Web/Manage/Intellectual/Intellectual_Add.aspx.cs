using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;

namespace HN863Soft.ISS.Web.Manage.Intellectual
{
    public partial class Intellectual_Add : ManagePage
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.IntellectualBll bll = new BLL.IntellectualBll();

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (!ChkManageLevel("ChannelIntellectualList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.Model.Intellectual model = new Model.Intellectual();

            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();

            string savePath = "";
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

            model.UserId = Mmodel.ID;//发布人id
            model.Cover = savePath;
            model.KeyWord = txtKeyWord.Text.Trim().ToString();
            model.Title = txtTitle.Text.Trim().ToString();
            model.State = 0;
            model.Content = container.Text;
            model.Introduce = txtIntroduce.Text.Trim().ToString();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加知识产权"); //记录日志

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