using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage
{
    public partial class ChannelList : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int site_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.site_id = RequestHelper.GetQueryInt("SiteID");
            this.keywords = RequestHelper.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                TreeBind(); //绑定类别
                RptBind("ID>0" + CombSqlTxt(site_id, keywords), "SortID asc,ID desc");
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();
            DataTable dt = bll.GetList(0, "", "SortID asc,ID desc").Tables[0];

            this.ddlSiteId.Items.Clear();
            this.ddlSiteId.Items.Add(new ListItem("所有站点", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlSiteId.Items.Add(new ListItem(dr["Title"].ToString(), dr["ID"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            ddlSiteId.SelectedValue = this.site_id.ToString();
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}&page={2}", this.site_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _site_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_site_id > 0)
            {
                strTemp.Append(" and SiteID=" + _site_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Name like  '%" + _keywords + "%' or Title like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("channel_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), txtKeywords.Text));
        }

        //筛选类型
        protected void ddlSiteId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", ddlSiteId.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("channel_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateSort(id, sortId);
            }
            AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "保存频道排序"); //记录日志
            //ShowScriptMsg("保存排序成功！", Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Channel/ChannelList.aspx';");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;
            int errorCount = 0;
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //检查该频道下是否还有文章
                    int articleCount = new HN863Soft.ISS.BLL.Article().GetCount("ChannelID=" + id);
                    if (articleCount > 0)
                    {
                        errorCount += 1;
                        continue;
                    }
                    var model = bll.GetModel(id);
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                        //删除URL配置
                        new HN863Soft.ISS.BLL.UrlRewrite().Remove("channel", model.Name);
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除频道成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                //Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Channel/ChannelList.aspx';");
        }
    }
}