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

namespace HN863Soft.ISS.Web.Manage.Crawler
{
    public partial class CrawlerList : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int _id;
        protected string keywords = string.Empty;
        Manager manage = new HN863Soft.ISS.Model.Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._id = RequestHelper.GetQueryInt("ID");
            this.keywords = RequestHelper.GetQueryString("keywords");
            manage = GetManageInfo();
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                RptBind(CombSqlTxt(_id, keywords), " ID desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.CrawlerInfo bll = new HN863Soft.ISS.BLL.CrawlerInfo();
            DataSet ds = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
                    {
                        if (ds.Tables[0].Rows[i]["CrawContent"].ToString().Length > 30)
                        {
                            ds.Tables[0].Rows[i]["CrawContent"] = ds.Tables[0].Rows[i]["CrawContent"].ToString().Substring(0, 30);
                        }
                    }
                }
            }
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();

            if (manage.RoleType < 3)
            {
                string pageUrl = Utils.CombUrlTxt("CrawlerList.aspx", "ID={0}&keywords={1}&page={2}", this._id.ToString(), this.keywords, "__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
            else
            {
                string pageUrl = Utils.CombUrlTxt("CrawlerList.aspx", "ID={0}&keywords={1}&page={2}&UserID={3}", this._id.ToString(), this.keywords, "__id__", manage.ID.ToString());
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_id > 0)
            {
                strTemp.Append(" and ID=" + _id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Title like  '%" + _keywords + "%' or Url like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("crawler_page_size", "ISSPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("CrawlerList.aspx", "ID={0}&keywords={1}", this._id.ToString(), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("crawler_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("CrawlerList.aspx", "ID={0}&keywords={1}", this._id.ToString(), this.keywords));
        }

        //批量审核
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.Audit.ToString()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.BLL.CrawlerInfo bll = new HN863Soft.ISS.BLL.CrawlerInfo();
            var manager = GetManageInfo();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.CrawlerInfo model = bll.GetModel(id);
                    model.State = int.Parse(hidState.Value);
                    bll.Update(model);
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核机构入驻信息"); //记录日志
            //ShowScriptMsg("保存排序成功！", Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerList.aspx';");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.Delete.ToString()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;
            int errorCount = 0;
            HN863Soft.ISS.BLL.CrawlerInfo bll = new HN863Soft.ISS.BLL.CrawlerInfo();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除内容成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
            //Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerList.aspx';");
        }
    }
}