using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：Roadshow_List.cs
// 作者（Author）：邹峰
// 功能（Function）：路演信息列表
// 创建日期（Create Date）：2017/03/13
//*****************************
namespace HN863Soft.ISS.Web.Manage.Roadshow
{
    public partial class Roadshow_List : ManagePage
    {
        #region 变量定义

        HN863Soft.ISS.BLL.RoadshowBll bll = new HN863Soft.ISS.BLL.RoadshowBll();
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int iType = -1;
        protected int ddl_id;

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.ddl_id = RequestHelper.GetQueryInt("ddlId");

            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelRoadshowList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                this.pageSize = GetPageSize(10); //每页数量
                TreeBind();
                BindData();
            }
        }

        #endregion

        #region 方法

        private void TreeBind()
        {
            this.ddlType.Items.Clear();
            this.ddlType.Items.Add(new ListItem("所有类型", ""));
            this.ddlType.Items.Add(new ListItem("未审核", "1"));
            this.ddlType.Items.Add(new ListItem("已通过", "2"));
            this.ddlType.Items.Add(new ListItem("未通过", "3"));
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="_default_size"></param>
        /// <returns></returns>
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("roadshow_page_size", "ISSPage"), out _pagesize))
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
            ddlType.SelectedValue = this.ddl_id.ToString();
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

            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  a.Title like '%" + txtKeywords.Text.Trim() + "%'");
            }

            if (ddlType.SelectedValue != "" && int.Parse(ddlType.SelectedValue) > -1)
            {
                strWhere.AppendFormat(" and  a.State =" + (int.Parse(ddlType.SelectedValue) - 1));
            }

            DataSet ds = new DataSet();
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(), "a.id desc", out this.totalCount);
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
                //    ds.Tables[0].Rows[i]["Eject"] = "N";
                //}

                if (!ChkManageType())
                {
                    ds.Tables[0].Rows[i]["Eject"] = "N";
                }
            }
            rptList.DataSource = ds;
            rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("Roadshow_List.aspx", "ddlId={0}&keywords={1}&page={2}", this.ddl_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 事件

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Roadshow_List.aspx", "ddlId={0}&keywords={1}", this.ddl_id.ToString(), txtKeywords.Text));
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelRoadshowList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
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
                    int state = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hids")).Value);
                    if (state == 1)
                    {
                        //ShowScriptMsg("已审核通过无法删除！", "Roadshow_List.aspx", "parent.loadMenuTree");
                        //return;
                        ShowMsgHelper.ShowScript("showWarningMsg('已审核通过无法删除');");
                        return;
                    }
                    bll.Delete(id);
                }
            }

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除路演"); //记录日志

            ShowMsgHelper.ShowScript("location.href='/Manage/Roadshow/Roadshow_List.aspx';");
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("roadshow_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("Roadshow_List.aspx", "ddlId={0}&keywords={1}", this.ddl_id.ToString(), txtKeywords.Text));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Roadshow_List.aspx", "ddlId={0}&keywords={1}", ddlType.SelectedValue, txtKeywords.Text));
        }

        #endregion
    }
}