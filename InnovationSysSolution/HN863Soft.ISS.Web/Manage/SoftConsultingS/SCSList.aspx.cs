using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System.Text;
using HN863Soft.ISS.Web.Common;
//*****************************
// 文件名（File Name）：SCSList.cs
// 作者(Author):  雷登辉
// 功能描述(Description): 双软认定咨询服务信息列表：提供删除、审核、批量删除、批量审核功能
// 日期(Create Date):2017/3/10
//*****************************
namespace HN863Soft.ISS.Web.Manage.SoftConsultingS
{
    public partial class SCSList : ManagePage
    {
        #region 函数

        private HN863Soft.ISS.BLL.SoftConsultingS sConsultingBll;//软件服务信息处理对象
        //private HN863Soft.ISS.Model.SoftConsultingS sConsultingModel;//软件服务信息实体对象

        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        #endregion

        #region 页面初始化

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelSCSList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();
                Manager model = GetManageInfo(); //取得当前用户信息
                if (model != null)
                {
                    string stWhere = "";
                    if (!ChkManageType())
                    {
                        stWhere = " and CreatorId=" + model.ID;
                    }
                    RptBind(stWhere + CombSqlTxt(keywords), "ID desc");
                }
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            sConsultingBll = new BLL.SoftConsultingS();
            this.rptList.DataSource = sConsultingBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("SCSList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 绑定信息类型

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.SoftConsulting item in Enum.GetValues(typeof(EnumsHelper.SoftConsulting)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (SName like  '%" + _keywords + "%' or SIntroduction like '%" + _keywords + "%' or TeamIntroduction like '%" + _keywords + "%')");
            }
            if (ddlType.SelectedValue != "-1")
            {
                strTemp.Append(" and Type= " + ddlType.SelectedValue);
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("SCSList_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 关健字查询

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SCSList.aspx", "keywords={0}", txtKeywords.Text));
        }
        #endregion

        #region 设置分页数量

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("SCSList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("SCSList.aspx", "keywords={0}", this.keywords));
        }
        #endregion

        #region 检索相应类型信息

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RptBind(CombSqlTxt(keywords), "ID desc");
        }
        #endregion

        #region 批量删除

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelSCSList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;//记录删除成功数量
            int errorCount = 0;//记录删除失败数量
            sConsultingBll = new BLL.SoftConsultingS();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (sConsultingBll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除双软认定咨询信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("SCSList.aspx", "keywords={0}", this.keywords));
            ShowMsgHelper.ShowScript("location.href='/Manage/SoftConsultingS/SCSList.aspx';");
        }
        #endregion

    }
}