using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
// 文件名（File Name）：EnterpriseRegistration_Add.cs
// 作者（Author）：邹峰
// 功能（Function）：添加工商注册信息
// 创建日期（Create Date）：2017/03/14
//*****************************
namespace HN863Soft.ISS.Web.Manage.EnterpriseRegistration
{
    public partial class EnterpriseRegistration_Add : ManagePage
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.EnterpriseRegistrationBll bll = new BLL.EnterpriseRegistrationBll();

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
            if (!ChkManageLevel("ChannelEnterpriseRegList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.Model.EnterpriseRegistration model = new Model.EnterpriseRegistration();

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
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "工商注册"); //记录日志

                Response.Redirect("EnterpriseRegistration_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}