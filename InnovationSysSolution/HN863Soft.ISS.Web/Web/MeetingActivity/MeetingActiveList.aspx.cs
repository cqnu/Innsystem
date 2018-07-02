using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bll = HN863Soft.ISS.BLL;
using model = HN863Soft.ISS.Model;
using HN863Soft.ISS.Common;
using System.Text;
using HN863Soft.ISS.Model;
//*****************************
//* 文件名：MeetingActiveList.cs
//* 作者雷登辉
//* 功能：提供会议活动的浏览、检索功能
//* 创建时间：2017/3/1
//*****************************
namespace HN863Soft.ISS.Web.Web.MeetingActivity
{
    public partial class MeetingActiveList : System.Web.UI.Page
    {

        HN863Soft.ISS.BLL.MeetingActivity bll = new HN863Soft.ISS.BLL.MeetingActivity();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int iType = -1;
        protected int ddl_id;

        protected static string type = string.Empty;
        protected static string sort = string.Empty;
        private static string typeValue = "";
        private static int userID;
        public static HN863Soft.ISS.Model.Users model = new model.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session[KeysHelper.ForegroundUser] != null)
                {
                    model = (Users)Session[KeysHelper.ForegroundUser];
                }
                else
                {
                    AddNew.Visible = false;
                }

                this.keywords = RequestHelper.GetQueryString("KeyWords");

                typeValue = RequestHelper.GetQueryString("Type");
                sort = RequestHelper.GetQueryString("sort");
                var item = RequestHelper.GetQueryString("userID");
                if (!string.IsNullOrEmpty(RequestHelper.GetQueryString("userID")))
                {
                    userID = int.Parse(RequestHelper.GetQueryString("userID"));
                }
                
                BindType();
                this.pageSize = GetPageSize(10); //每页数量

                BindData();
                SetClass(typeValue);
            }
        }



        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("MeetingActiveList_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("不限", "-1"));
            foreach (EnumsHelper.ForumCategory items in Enum.GetValues(typeof(EnumsHelper.ForumCategory)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(items), items.GetValue().ToString() == "0" ? "00" : items.GetValue().ToString()));
            }
            rptTypeList.DataSource = lstItem;
            rptTypeList.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {

            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;

            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1 and IsVis=1 ");
            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  Title like '%" + txtKeywords.Text.Trim() + "%'");

            }

            string order = string.Empty;

            if (sort != "00"&&(!string.IsNullOrEmpty(sort)))
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
            if (typeValue != "-1" && (!string.IsNullOrEmpty(typeValue)))
            {
                strWhere.Append(" and Type=  " + typeValue);
            }

            if (userID > 0)
            {
                strWhere.Clear();

                strWhere.Append(" 1=1 and CreatorId=" + userID);
            }

            DataSet ds = new DataSet();
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), order, out this.totalCount);

            HN863Soft.ISS.BLL.Users userBll = new bll.Users();

            rptList.DataSource = ds;
            rptList.DataBind();

            //绑定页码KeyWords={0}&Type={1}&TypeName={2}", txtKeywords.Text, typeValue, strType));keywords={0}&sort={1}&Type={2}", txtKeywords.Text, "00", typeValue)
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}&page={3}", txtKeywords.Text, sort, typeValue, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }


        /// <summary>
        /// 类型检索
        /// </summary>
        /// <param name="value"></param>
        private void SetClass(string value)
        {
            if (!string.IsNullOrEmpty(value) && value != "-1")
            {
                foreach (RepeaterItem drv in rptTypeList.Items)
                {
                    LinkButton ltn = drv.FindControl("LinkButton1") as LinkButton;
                    if (ltn is LinkButton)
                    {
                        ltn.CssClass = ltn.CommandArgument.ToString() == value ? "btn_ALink siteIlB_item cur" : "btn_ALink siteIlB_item";
                    }
                }
            }
        }

        /// <summary>
        /// 项绑定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptTypeList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            typeValue = e.CommandArgument.ToString();
            if (e.CommandName == "order")
            {
                Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
            }
        }

        /// <summary>
        /// 默认排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Default_Click(object sender, EventArgs e)
        {
            sort = "00";
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
        }

        /// <summary>
        /// 时间排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Reverse_Click(object sender, EventArgs e)
        {
            sort = "1";
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
        }

        /// <summary>
        /// 所有吐槽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void All_Click(object sender, EventArgs e)
        {
            userID = 0;
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
        }

        /// <summary>
        /// 我要吐槽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveAdd.aspx","",""));
        }

        /// <summary>
        /// 我的吐槽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Mine_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}&userID={3}", txtKeywords.Text, sort, typeValue, model.ID.ToString()));
        }

        /// <summary>
        /// 关键词检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "KeyWords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("MeetingActiveList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("MeetingActiveList.aspx", "keywords={0}&sort={1}&Type={2}", txtKeywords.Text, sort, typeValue));
        }

    }
}