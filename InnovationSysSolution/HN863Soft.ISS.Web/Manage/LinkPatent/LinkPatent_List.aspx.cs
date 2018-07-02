﻿using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.LinkPatent
{
    public partial class LinkPatent_List : ManagePage
    {
        #region 变量定义

        HN863Soft.ISS.BLL.LinkPatentBll bll = new HN863Soft.ISS.BLL.LinkPatentBll();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.keywords = RequestHelper.GetQueryString("keywords");

                this.pageSize = GetPageSize(10); //每页数量

                BindData();
            }
        }

        #endregion

        #region 方法

        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;

            HN863Soft.ISS.Model.Manager model = GetManageInfo(); //取得当前用户信息

            StringBuilder strWhere = new StringBuilder();

            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  a.SiteName like '%" + txtKeywords.Text.Trim() + "%'");
                strWhere.AppendFormat(" or  a.SiteDescription like '%" + txtKeywords.Text.Trim() + "%'");

            }

            DataSet ds = new DataSet();
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), out this.totalCount);
          
            rptList.DataSource = ds;
            rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("LinkPatent_List.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 事件

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("LinkPatent_List.aspx", "keywords={0}", txtKeywords.Text));
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除链接专利、商标查询网站"); //记录日志

            ShowScriptMsg("删除数据成功！", "LinkPatent_List.aspx", "parent.loadMenuTree");

            BindData();

        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("LinkPatent_List.aspx", "keywords={0}", this.keywords));
        }

        #endregion
    }
}