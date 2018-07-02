using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Management
{
    public partial class Management_List : ManagePage
    {
        #region 变量定义

        HN863Soft.ISS.BLL.ManagementBll bll = new HN863Soft.ISS.BLL.ManagementBll();
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
                if (!ChkManageLevel("ChannelManagementList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                this.keywords = RequestHelper.GetQueryString("keywords");
                this.pageSize = GetPageSize(10); //每页数量

                BindData();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 返回每页数量
        /// </summary>
        /// <param name="_default_size"></param>
        /// <returns></returns>
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
        /// 绑定数据方法
        /// </summary>
        public void BindData()
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.Model.Manager model = GetManageInfo(); //取得当前用户信息

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeywords.Text.Trim() != "")
            {
                //查询条件
                strWhere.AppendFormat(" and  a.Title like '%{0}%'", txtKeywords.Text.Trim());
            }
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), out this.totalCount);
            ds.Tables[0].Columns.Add("Eject");
            //if (model.RoleType == 3)
            //{
            //    liAdd.Visible = false;
            //    lidel.Visible = false;

            //    ych.Value = "n";

            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        ds.Tables[0].Rows[i]["Eject"] = "1";
            //    }
            //}

            if (!ChkManageType())
            {
                liAdd.Visible = false;
                lidel.Visible = false;

                ych.Value = "n";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["Eject"] = "1";
                }
            }

            rptList.DataSource = ds;
            rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("Management_List.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 检索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Management_List.aspx", "keywords={0}", txtKeywords.Text));
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelManagementList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            BindData();

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除通知公告"); //记录日志
            //ShowScriptMsg("删除数据成功！", "Management_List.aspx", "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Management/Management_List.aspx';");
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

            Response.Redirect(Utils.CombUrlTxt("Management_List.aspx", "keywords={0}", this.keywords));

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                HN863Soft.ISS.Model.Manager model = GetManageInfo(); //取得当前用户信息

                //if (model.RoleType == 3)
                //{
                //    HtmlTableCell tdxz = e.Item.FindControl("tdid") as HtmlTableCell;
                //    tdxz.Visible = false;
                //}

                if (!ChkManageType())
                {
                    HtmlTableCell tdxz = e.Item.FindControl("tdid") as HtmlTableCell;
                    tdxz.Visible = false;
                }
            }
        }

        #endregion
    }
}