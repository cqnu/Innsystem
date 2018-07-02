using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.TalentService
{
    public partial class TalentService_List : System.Web.UI.Page
    {
        HN863Soft.ISS.BLL.TalentServiceBll bll = new HN863Soft.ISS.BLL.TalentServiceBll();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;


        protected static string type = string.Empty;
        protected static string sort = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.keywords = RequestHelper.GetQueryString("keywords");

                type = RequestHelper.GetQueryString("type");

                sort = RequestHelper.GetQueryString("sort");


                this.pageSize = GetPageSize(10); //每页数量

                BindData();


            }
        }

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

            StringBuilder strWhere = new StringBuilder();


            strWhere.AppendFormat(" and  a.State = " + "1" + "");


            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  a.Title like '%" + txtKeywords.Text.Trim() + "%'");

            }

            if (type == "")
            {
                Whole.CssClass = "btn_ALink siteIlB_item cur";

                Recruit.CssClass = "btn_ALink siteIlB_item";
                Train.CssClass = "btn_ALink siteIlB_item";
            }

            if (type == "00")
            {

                strWhere.AppendFormat(" and  a.Type = " + 0);

                Recruit.CssClass = "btn_ALink siteIlB_item cur";

                Whole.CssClass = "btn_ALink siteIlB_item";
                Train.CssClass = "btn_ALink siteIlB_item";
            }

            if (type == "1")
            {

                strWhere.AppendFormat(" and  a.Type = " + type);

                Train.CssClass = "btn_ALink siteIlB_item cur";

                Whole.CssClass = "btn_ALink siteIlB_item";
                Recruit.CssClass = "btn_ALink siteIlB_item";
            }



            string order = string.Empty;

            if (sort == "1")
            {
                order = "a.id asc";

                Reverse.CssClass = "cur btn_ALink siteIlB_item";

                Default.CssClass = "btn_ALink siteIlB_item";
            }
            else
            {
                order = "a.id desc";

                Reverse.CssClass = "btn_ALink siteIlB_item";

                Default.CssClass = "cur btn_ALink siteIlB_item";

            }

            DataSet ds = new DataSet();
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), order, out this.totalCount);


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string url = ds.Tables[0].Rows[i]["LogImg"].ToString();

                url = url.TrimStart('~');
                url = url.Replace("\\", "/");
                url = "../.." + url;

                ds.Tables[0].Rows[i]["LogImg"] = url;
            }

            for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                if (ds.Tables[0].Rows[i]["Jurisdiction"].ToString() == "2")
                {
                    if (Session[KeysHelper.ForegroundUser] == null)
                    {
                        ds.Tables[0].Rows[i].Delete();
                    }
                }
            }

            DataList1.DataSource = ds;

            DataList1.DataBind();

            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}&page={3}", type, this.keywords, sort, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", type, txtKeywords.Text, sort));
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

            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", type, txtKeywords.Text, sort));
        }

        protected void Train_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={1}", "1", txtKeywords.Text, sort));
        }

        protected void Default_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", type, txtKeywords.Text, "0"));
        }

        protected void Reverse_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", type, txtKeywords.Text, "1"));
        }

        protected void Recruit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", "00", txtKeywords.Text, sort));
        }

        protected void Whole_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentService_List.aspx", "type={0}&keywords={1}&sort={2}", "", txtKeywords.Text, sort));
        }
    }
}