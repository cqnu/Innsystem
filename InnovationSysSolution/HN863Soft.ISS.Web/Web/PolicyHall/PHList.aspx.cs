using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.PolicyHall
{
    public partial class PHList : System.Web.UI.Page
    {
        HN863Soft.ISS.BLL.CrawlerInfo bll = new HN863Soft.ISS.BLL.CrawlerInfo();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int iType = -1;
        protected int ddl_id;

        protected static string sort = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.keywords = RequestHelper.GetQueryString("KeyWords");

                sort = RequestHelper.GetQueryString("sort");

                this.pageSize = GetPageSize(10); //每页数量
                BindData();
            }
        }



        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("PHList_page_size", "ISSPage"), out _pagesize))
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

            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 and State=1 ");
            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and (  Title like '%" + txtKeywords.Text.Trim() + "%' or CrawContent like '%" + txtKeywords.Text.Trim() + "%')");

            }

            string order = string.Empty;

            if (sort != "00" && (!string.IsNullOrEmpty(sort)))
            {
                order = "id desc";
                Default.CssClass = "btn_ALink siteIlB_item";
                Reverse.CssClass = "cur btn_ALink siteIlB_item";
            }
            else
            {
                order = "id asc";
                Default.CssClass = "cur btn_ALink siteIlB_item";
                Reverse.CssClass = "btn_ALink siteIlB_item";
            }

            DataSet ds = new DataSet();
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), order, out this.totalCount);

            rptList.DataSource = ds;
            rptList.DataBind();
            
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("PHList.aspx", "keywords={0}&sort={1}&page={2}", txtKeywords.Text, "00", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        /// <summary>
        /// 默认排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Default_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("PHList.aspx", "keywords={0}&sort={1}", txtKeywords.Text, "00"));
        }

        /// <summary>
        /// 时间排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Reverse_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("PHList.aspx", "keywords={0}&sort={1}", txtKeywords.Text, "1"));
        }

        /// <summary>
        /// 关键词检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("PHList.aspx", "KeyWords={0}&sort={1}", txtKeywords.Text, "00"));
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("PHList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("PHList.aspx", "keywords={0}&sort={1}", txtKeywords.Text, sort));
        }
    }
}