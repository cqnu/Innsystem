using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.EnterpriseRegistration
{
    public partial class EnterpriseRegistration_List : System.Web.UI.Page
    {

        HN863Soft.ISS.BLL.EnterpriseRegistrationBll bll = new HN863Soft.ISS.BLL.EnterpriseRegistrationBll();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int iType = -1;
        protected int ddl_id;

        protected static string type = string.Empty;
        protected static string sort = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.keywords = RequestHelper.GetQueryString("keywords");

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
            //ddlType.SelectedValue = this.ddl_id.ToString();
            txtKeywords.Text = this.keywords;

            //HN863Soft.ISS.Model.Manager model = GetManageInfo(); //取得当前管理员信息

            StringBuilder strWhere = new StringBuilder();

            ////判断是管理员还是系统用户 系统用户只差对应id
            //if (model.RoleType == 3)
            //{
            //    strWhere.Append(" and  u.id = " + model.ID);
            //    liAu.Visible = false;
            //}

            strWhere.AppendFormat(" and  a.State = " + "1" + "");

            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  a.Title like '%" + txtKeywords.Text.Trim() + "%'");

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

                string url = ds.Tables[0].Rows[i]["Cover"].ToString();

                url = url.TrimStart('~');
                url = url.Replace("\\", "/");
                url = "../.." + url;

                ds.Tables[0].Rows[i]["Cover"] = url;
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
            string pageUrl = Utils.CombUrlTxt("EnterpriseRegistration_List.aspx", "keywords={0}&sort={1}&page={2}", this.keywords, sort, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }


        protected void Default_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("EnterpriseRegistration_List.aspx", "keywords={0}&sort={1}", txtKeywords.Text, "0"));
        }

        protected void Reverse_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("EnterpriseRegistration_List.aspx", "keywords={0}&sort={1}", txtKeywords.Text, "1"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect(Utils.CombUrlTxt("EnterpriseRegistration_List.aspx", "keywords={0}&sort={1}", txtKeywords.Text, sort));
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

            Response.Redirect(Utils.CombUrlTxt("EnterpriseRegistration_List.aspx", "keywords={0}&sort={1}", txtKeywords.Text, sort));
        }
    }
}