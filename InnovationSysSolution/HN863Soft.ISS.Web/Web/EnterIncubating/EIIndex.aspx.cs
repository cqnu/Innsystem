using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//**************************
//* 文件名：EIIndex.cs
//* 作者：雷登辉
//* 功能：孵化器列表展示
//* 创建时间 ：2017/3/6
//**************************
namespace HN863Soft.ISS.Web.Web.EnterIncubating
{
    public partial class EIIndex : System.Web.UI.Page
    {

        //private BLL.Organization orBll;//实例化省市处理对象
        HN863Soft.ISS.BLL.Organization bll;
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int iType = -1;
        protected int ddl_id;

        protected static string province = string.Empty;
        protected static string sort = string.Empty;
        protected static string DisplayMode = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.keywords = RequestHelper.GetQueryString("keywords");

                sort = RequestHelper.GetQueryString("sort");
                province = RequestHelper.GetQueryString("Province");
                DisplayMode = RequestHelper.GetQueryString("DisplayMode");

                if (DisplayMode == "1")
                {
                    DataList1.Visible = false;
                    rptList.Visible = true;

                    LkList.CssClass = "cur btn_ALink siteIlB_item";
                    LkForm.CssClass = "btn_ALink siteIlB_item";

                   
                }
                if (DisplayMode == "2")
                {
                    DataList1.Visible = true;
                    rptList.Visible = false;

                    LkList.CssClass = "btn_ALink siteIlB_item";
                    LkForm.CssClass = "cur btn_ALink siteIlB_item";
                }

                this.pageSize = GetPageSize(10); //每页数量
                BindProvince();
                BindData();
                SetClass();
            }
        }

        /// <summary>
        /// 绑定省份
        /// </summary>
        private void BindProvince()
        {
            bll = new BLL.Organization();
            DataTable provinceDt = bll.GetProvice().Tables[0];
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("不限", "-1"));
            foreach (DataRow dr in provinceDt.Rows)
            {
                lstItem.Add(new ListItem(dr["Name"].ToString(), dr["ProvinceID"].ToString()));
            }
            rptTypeList.DataSource = lstItem;
            rptTypeList.DataBind();
        }



        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("EIIndex_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        /// <summary>
        /// 设置选中标签样式
        /// </summary>
        private void SetClass()
        {
            if (province != "-1" && (!string.IsNullOrEmpty(province)))
            {
                foreach (RepeaterItem item in rptTypeList.Items)
                {
                    LinkButton lbtn = item.FindControl("LinkButton1") as LinkButton;
                    if (lbtn is LinkButton)
                    {
                        lbtn.CssClass = lbtn.CommandArgument == province ? "btn_ALink siteIlB_item cur" : "btn_ALink siteIlB_item";
                    }
                }
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            bll = new BLL.Organization();
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

            
            strWhere.Append(" and o.State=3 and o.OrgType=12");
            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  o.OrgName like '%" + txtKeywords.Text.Trim() + "%'");

            }



            string order = string.Empty;

            if (sort == "1")
            {
                order = "o.id asc";

                Reverse.CssClass = "cur btn_ALink siteIlB_item";

                Default.CssClass = "btn_ALink siteIlB_item";
            }
            else
            {
                order = "o.id desc";

                Reverse.CssClass = "btn_ALink siteIlB_item";

                Default.CssClass = "cur btn_ALink siteIlB_item";

            }
            if (province != "-1" && (!string.IsNullOrEmpty(province)))
            {
                strWhere.Append(" and p.ProvinceID =" + province);
            }

            DataSet ds = new DataSet();
            ds = bll.GetHList(this.pageSize, this.page, strWhere.ToString(), order, out this.totalCount);


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string url = ds.Tables[0].Rows[i]["LogImg"].ToString();

                url = url.TrimStart('~');
                url = url.Replace("\\", "/");
                url = "../.." + url;

                ds.Tables[0].Rows[i]["LogImg"] = url;
            }

            DataList1.DataSource = ds;

            DataList1.DataBind();


            rptList.DataSource = ds;

            rptList.DataBind();

            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&page={3}&DisplayMode={4}", this.keywords, sort, province, "__id__",DisplayMode);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }


        protected void Default_Click(object sender, EventArgs e)
        {
            sort = "0";
            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,DisplayMode));
        }

        protected void Reverse_Click(object sender, EventArgs e)
        {
            sort = "1";
            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,DisplayMode));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,DisplayMode));
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("EIIndex_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,DisplayMode));
        }

        protected void rptTypeList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            province = e.CommandArgument.ToString();
            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,DisplayMode));
        }

        protected void LkList_Click(object sender, EventArgs e)
        {
            //DataList1.Visible = false;
            //rptList.Visible = true;
            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province,"1"));
        }

        protected void LkForm_Click(object sender, EventArgs e)
        {

            Response.Redirect(Utils.CombUrlTxt("EIIndex.aspx", "keywords={0}&sort={1}&Province={2}&DisplayMode={3}", txtKeywords.Text, sort, province, "2"));
            //DataList1.Visible = true;
            //rptList.Visible = false;
        }

    }
}