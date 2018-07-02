using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
//*****************************
// 文件名（File Name）：List.cs
// 作者（Author）：邹峰
// 功能（Function）：查询、显示技术信息资源 用户后台
// 创建日期（Create Date）：2017/02/16
//*****************************
namespace HN863Soft.ISS.Web.TechnicalInformation
{
    public partial class List : ManagePage
    {

        #region 变量

        HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();
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
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;

            HN863Soft.ISS.Model.Manager model = GetManageInfo(); //取得当前用户信息

            StringBuilder strWhere = new StringBuilder();

            //判断是管理员还是系统用户 系统用户只差对应id
            //if (model.RoleType == 3)
            //{
            //    strWhere.Append(" and  u.id = " + model.ID);
            //}

            if (!ChkManageType())
            {
                strWhere.Append(" and  u.id = " + model.ID);
            }

            DataSet ds = new DataSet();

            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and t.EntryName like '%{0}%' or t.Keyword like '%{0}%' ", txtKeywords.Text.Trim());
            }
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), out this.totalCount);
            ds.Tables[0].Columns.Add("StateInfo");//判断按钮是否可用
            
            ds.Tables[0].Columns.Add("Eject");//判断只有管理员才有审核权限
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                if (ds.Tables[0].Rows[i]["State"].ToString() == "0")
                {
                    ds.Tables[0].Rows[i]["StateInfo"] = "未审核";
                }
                if (ds.Tables[0].Rows[i]["State"].ToString() == "1")
                {
                    ds.Tables[0].Rows[i]["StateInfo"] = "已通过";
                }
                if (ds.Tables[0].Rows[i]["State"].ToString() == "2")
                {
                    ds.Tables[0].Rows[i]["StateInfo"] = "未通过";
                }

                //if (model.RoleType == 3)
                //{
                //    ds.Tables[0].Rows[i]["State"] = "1";
                //    ds.Tables[0].Rows[i]["Eject"] = "N";
                //}

                if (!ChkManageType())
                {
                    ds.Tables[0].Rows[i]["State"] = "1";
                    ds.Tables[0].Rows[i]["Eject"] = "N";
                }
            }

            rptList.DataSource = ds;
            rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("TechnicalInformation_List.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 事件

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TechnicalInformation_List.aspx", "keywords={0}", txtKeywords.Text));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            //ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.Delete.ToString()); //检查权限
            //HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
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

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除技术管理"); //记录日志
            ShowScriptMsg("删除数据成功！", "List.aspx", "parent.loadMenuTree");

        }

        //设置分页数量
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
            Response.Redirect(Utils.CombUrlTxt("TechnicalInformation_List.aspx", "keywords={0}", this.keywords));
        }

        #endregion

    }
}
