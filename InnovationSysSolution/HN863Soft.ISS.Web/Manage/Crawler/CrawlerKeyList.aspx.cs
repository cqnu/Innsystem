using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Crawler
{
    public partial class CrawlerKeyList : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int _id;
        protected string keywords = string.Empty;
        Manager manage = new HN863Soft.ISS.Model.Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            string keyType = RequestHelper.GetQueryString("KeyType");
            manage = GetManageInfo();
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelCrawlerKeyList", EnumsHelper.ActionEnum.View.ToString()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (string.IsNullOrEmpty(keyType))
                {
                    RptBind(CombSqlTxt(keywords), " ID desc");
                }
                else
                {
                    RptBind(" KeyType = " + keyType + CombSqlTxt(keywords), " ID desc");
                }
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.CrawlerKeys bll = new HN863Soft.ISS.BLL.CrawlerKeys();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("CrawlerKeyList.aspx", "ID={0}&keywords={1}&page={2}", this._id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Keys like  '%" + _keywords + "%' or KeyName like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("CrawlerKey_page_size", "ISSPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("CrawlerKeyList.aspx", "ID={0}&keywords={1}", this._id.ToString(), txtKeywords.Text));
        }

        //筛选类型
        protected void ddlCrawlerKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("CrawlerKeyList.aspx", "keywords={1}", this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("CrawlerKey_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("CrawlerKeyList.aspx", "ID={0}&keywords={1}", this._id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelCrawlerKeyList", EnumsHelper.ActionEnum.Delete.ToString()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;
            int errorCount = 0;
            HN863Soft.ISS.BLL.CrawlerKeys bll = new HN863Soft.ISS.BLL.CrawlerKeys();
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
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除关键字成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerKeyList.aspx';");
        }
    }
}