using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.TalentService
{
    public partial class TalentServiceAuditShow : ManagePage
    {
        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelTalentServiceAuditList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
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
            txtTitle.Enabled = false;
            this.container.Text = model.Content;
            container.Enabled = false;
            this.ddlType.SelectedValue = model.Type.ToString();
            ddlType.Enabled = false;
            Image1.ImageUrl = model.LogImg;//Log路径
            txtIntroduce.Text = model.Introduce;//简介
            txtKeyWord.Text = model.KeyWord;//关键词
        }

        #endregion
    }
}