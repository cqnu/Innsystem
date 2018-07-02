using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
// 文件名（File Name）：Ariticle_Add.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑发布的内容
// 创建日期（Create Date）：2017/02/14
// 修改记录(Revision History)：
// R1
// 修改作者：雷登辉
// 修改日期：2017/3/9
// 修改内容：增加工业类型选择、进行工业分类、以便于分类检索
//*****************************
namespace HN863Soft.ISS.Web.userAriticle
{
    public partial class Add : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            BindType();
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

        #region 事件

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelAriticleList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            string strErr = "";

            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
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


            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            HN863Soft.ISS.Model.userAriticle model = new HN863Soft.ISS.Model.userAriticle();
            model.UserId = Mmodel.ID;
            model.Title = txtTitle.Text;
            model.Content = container.Text;
            model.datatime = System.DateTime.Now;
            model.hits = 0;
            model.State = 0;
            model.Type = Convert.ToInt32(ddlType.SelectedValue);//工业类型
            model.Logimg = savePath;//Log路径
            model.Keyword = txtKeyWord.Text;//关键词
            model.Introduce = txtIntroduce.Text;//简介
            HN863Soft.ISS.BLL.userAriticle bll = new HN863Soft.ISS.BLL.userAriticle();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加工业设计"); //记录日志

                Response.Redirect("Ariticle_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}
