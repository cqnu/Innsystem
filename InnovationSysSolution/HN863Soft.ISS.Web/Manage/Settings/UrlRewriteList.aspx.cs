using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class UrlRewriteList : ManagePage
    {
        protected string channel = string.Empty;
        protected string type = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel = RequestHelper.GetQueryString("channel");
            this.type = RequestHelper.GetQueryString("type");

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("SysUrlRewrite", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                TreeBind();
                RptBind(this.channel, this.type);
            }
        }

        #region 绑定频道=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            DataTable dt = bll.GetList(0, "", "SortID asc,ID desc").Tables[0];

            this.ddlChannel.Items.Clear();
            this.ddlChannel.Items.Add(new ListItem("所有频道", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlChannel.Items.Add(new ListItem(dr["Title"].ToString(), dr["Name"].ToString()));
            }
        }
        #endregion

        #region 绑定数据=================================
        private void RptBind(string _channel, string _type)
        {
            if (this.channel != "")
            {
                ddlChannel.SelectedValue = this.channel;
            }
            if (this.type != "")
            {
                ddlPageType.SelectedValue = this.type;
            }
            rptList.DataSource = new HN863Soft.ISS.BLL.UrlRewrite().GetList(_channel, _type);
            rptList.DataBind();
        }
        #endregion

        //筛选频道
        protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("UrlRewriteList.aspx", "channel={0}&type={1}", ddlChannel.SelectedValue, this.type));
        }

        //筛选页面类型
        protected void ddlPageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("UrlRewriteList.aspx", "channel={0}&type={1}", this.channel, ddlPageType.SelectedValue));
        }

        //删除操作
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("SysUrlRewrite", EnumsHelper.ActionEnum.Delete.ToString()); //检查权限
            HN863Soft.ISS.BLL.UrlRewrite bll = new HN863Soft.ISS.BLL.UrlRewrite();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string urlName = ((HiddenField)rptList.Items[i].FindControl("hideName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Remove("name", urlName);
                }
            }
            AddAdminLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除URL配置信息"); //记录日志
            JscriptMsg("URL配置删除成功！", "UrlRewriteList.aspx");
        }

    }
}