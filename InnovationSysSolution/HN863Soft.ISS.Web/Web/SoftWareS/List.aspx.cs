using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//******************************
// 文件名（File Name）：List.cs
// 作者(Author):  雷登辉
// 功能描述(Description): 专业技术服务信息列表：提供分类展示列表；排序列表展示功能
// 日期(Create Date):2017/3/13
//******************************
namespace HN863Soft.ISS.Web.Web.SoftWareS
{
    public partial class List : System.Web.UI.Page
    {
        #region 函数

        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected static string typeValue = "-1";
        protected static string orderTypeValue = "0";
        protected static string strType = "";

        BLL.SoftwareS softWSBll;//软件服务处理对象
        BLL.SoftConsultingS softCSBll;//双软认定咨询服务处理对象
        BLL.HSEConsulting hseCBll;//高企认定咨询服务处理对象
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strType = "SoftwareServiceType";//Request["TypeName"].ToString();
            strType = RequestHelper.GetQueryString("TypeName") == "" ? "SoftwareServiceType" : RequestHelper.GetQueryString("TypeName");
            this.keywords = RequestHelper.GetQueryString("KeyWords");
            orderTypeValue = RequestHelper.GetQueryString("sort");
            typeValue = RequestHelper.GetQueryString("Type");
            this.pageSize = GetPageSize(10); //每页数量
            if (!IsPostBack)
            {
                BindType(strType);
                SetClass(typeValue);
                TypeList(strType, CombSqlTxt(keywords, typeValue, orderTypeValue), orderTypeValue);
            }
        }
        #endregion

        #region 绑定数据类型

        /// <summary>
        /// 绑定类型
        /// </summary>
        /// <param name="typeName"></param>
        private void BindType(string typeName)
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("全部", "-1"));
            switch (typeName)
            {
                case "SoftwareServiceType":
                    foreach (EnumsHelper.SoftwareServiceType items in Enum.GetValues(typeof(EnumsHelper.SoftwareServiceType)))
                    {
                        lstItem.Add(new ListItem(EnumsHelper.FetchDescription(items), items.GetValue().ToString() == "0" ? "00" : items.GetValue().ToString()));
                    }
                    break;
                case "SoftConsulting":

                    foreach (EnumsHelper.SoftConsulting items in Enum.GetValues(typeof(EnumsHelper.SoftConsulting)))
                    {
                        lstItem.Add(new ListItem(EnumsHelper.FetchDescription(items), items.GetValue().ToString() == "0" ? "00" : items.GetValue().ToString()));
                    }
                    break;
                case "HSEConsulting":
                    break;
                default:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert(\"参数异常\");javascript:history.back(-1);");
                    return;
            }
            rptTypeList.DataSource = lstItem;
            rptTypeList.DataBind();

        }
        #endregion

        #region 专业技术服务数据绑定
        public void TypeList(string typeName, string strWhere, string orderType)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            DataTable dt = new DataTable();
            string strOrder = "";
            if (orderType != "00" && (!string.IsNullOrEmpty(orderType)))
            {
                strOrder = " CreateDate desc  ";
                Default.CssClass = "btn_ALink siteIlB_item";
                Reverse.CssClass = "cur btn_ALink siteIlB_item";
            }
            else
            {
                Default.CssClass = "cur btn_ALink siteIlB_item";
                Reverse.CssClass = "btn_ALink siteIlB_item";
            }
            //专业技术服务类型选择
            switch (typeName)
            {
                case "SoftwareServiceType":
                    softWSBll = new BLL.SoftwareS();
                    dt = softWSBll.GetList(pageSize, this.page, strWhere, strOrder == "" ? "Id" : strOrder, out totalCount).Tables[0];
                    break;
                case "SoftConsulting":
                    softCSBll = new BLL.SoftConsultingS();
                    dt = softCSBll.GetList(pageSize, this.page, strWhere, strOrder == "" ? "Id" : strOrder, out totalCount).Tables[0];
                    break;
                case "HSEConsulting":
                    hseCBll = new BLL.HSEConsulting();
                    divType.Visible = false;
                    dt = hseCBll.GetList(pageSize, this.page, strWhere, strOrder == "" ? "Id" : strOrder, out totalCount).Tables[0];
                    break;
                default:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert(\"参数异常\");javascript:history.back(-1);");
                    return;
            }

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["Jurisdiction"].ToString() == "2")
                {
                    if (Session[KeysHelper.ForegroundUser] == null)
                    {
                        dt.Rows[i].Delete();
                    }
                }
            }

            DataList1.DataSource = dt;

            DataList1.DataBind();

            //绑定页码KeyWords={0}&Type={1}&TypeName={2}", txtKeywords.Text, typeValue, strType));&sort={3}
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}&page={4}", this.keywords, typeValue, strType, "00", "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, string type, string orderType)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" and IsVis=1 ");
            txtKeywords.Text = _keywords;
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (SName like  '%" + _keywords + "%' or SIntroduction like '%" + _keywords + "%' or TeamIntroduction like '%" + _keywords + "%')");
            }
            if (type != "-1")
            {
                string strType = !string.IsNullOrEmpty(type) ? " and Type= " + type : "";
                strTemp.Append(strType);
            }

            return strTemp.ToString();
        }
        #endregion

        #region 分类检索


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
                Response.Redirect(Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}", txtKeywords.Text, typeValue, strType, orderTypeValue));
            }
        }
        #endregion

        #region 排序

        /// <summary>
        ///  默认
        /// </summary>
        protected void Default_Click(object sender, EventArgs e)
        {
            orderTypeValue = "00";
            //KeyWords={0}&Type={1}&TypeName={2}&page={4}", this.keywords, typeValue, strType, "__id__");
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}", txtKeywords.Text, typeValue, strType, orderTypeValue));
        }

        /// <summary>
        /// 时间
        /// </summary>
        protected void Reverse_Click(object sender, EventArgs e)
        {
            orderTypeValue = "1";
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}", txtKeywords.Text, typeValue, strType, orderTypeValue));
        }
        #endregion

        /// <summary>
        /// 关键词检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}", txtKeywords.Text, typeValue, strType, orderTypeValue));
        }

        /// <summary>
        /// 关键词检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("List_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "KeyWords={0}&Type={1}&TypeName={2}&sort={3}", txtKeywords.Text, typeValue, strType, orderTypeValue));
        }

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("List_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


    }
}