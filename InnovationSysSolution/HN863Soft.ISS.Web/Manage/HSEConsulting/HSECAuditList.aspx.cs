using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.HSEConsulting
{
    public partial class HSECAuditList : ManagePage
    {
        #region 函数

        private HN863Soft.ISS.BLL.HSEConsulting hseConsultingBll;//软件服务信息处理对象
        private HN863Soft.ISS.Model.HSEConsulting hseConsultingModel;//软件服务信息实体对象

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
                if (!ChkManageLevel("ChannelHSECAuditList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                Manager model = GetManageInfo(); //取得当前用户信息
                RptBind(CombSqlTxt(keywords), "ID desc");
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            hseConsultingBll = new BLL.HSEConsulting();
            this.rptList.DataSource = hseConsultingBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("HSECAuditList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
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

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("HSECAuditList_page_size", "ISSPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("HSECAuditList.aspx", "keywords={0}", txtKeywords.Text));
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
                    Utils.WriteCookie("HSECAuditList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("HSECAuditList.aspx", "keywords={0}", this.keywords));
        }
        #endregion

        #region 审核

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelHSECAuditList", EnumsHelper.ActionEnum.Audit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                //审核选中的服务信息
                if (cb.Checked)
                {
                    hseConsultingBll = new BLL.HSEConsulting();
                    hseConsultingModel = hseConsultingBll.GetModel(id);
                    if(hseConsultingModel == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败：没有找到这条消息');");
                        return;
                    }

                    hseConsultingModel.Id = id;
                    hseConsultingModel.IsVis = int.Parse(hidState.Value);
                    hseConsultingModel.Describe = hidDescribe.Value;
                    if (hseConsultingBll.UpdateIsVis(hseConsultingModel))
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核高企认定咨询信息成功"); //记录日志
                        ShowMsgHelper.ShowScript("location.href='/Manage/HSEConsulting/HSECAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败，请稍后再试');");
                        return;
                    }
                }
            }
        }
        #endregion

        #region 批量删除

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelHSECAuditList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;//记录删除成功数量
            int errorCount = 0;//记录删除失败数量
            hseConsultingBll = new BLL.HSEConsulting();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (hseConsultingBll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除高企认定咨询信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("HSECList.aspx", "keywords={0}", this.keywords));
            ShowMsgHelper.ShowScript("location.href='/Manage/HSEConsulting/HSECAuditList.aspx';");
        }
        #endregion

        protected void btnJurisdiction_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.HSEConsulting model = new HN863Soft.ISS.BLL.HSEConsulting().GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('修改失败：没有找到这条消息');");
                        return;
                    }

                    HN863Soft.ISS.BLL.ProjectFinancingBll pBll = new BLL.ProjectFinancingBll();

                    if (pBll.UpdateJurisdiction("HSEConsulting", id, int.Parse(hidState.Value)))
                    {

                        if (int.Parse(hidState.Value) == 2)
                        {

                            HN863Soft.ISS.Model.HSEConsulting umodel = new HN863Soft.ISS.BLL.HSEConsulting().GetModel(id);
                            HN863Soft.ISS.Model.Users userModel = new Model.Users();

                            HN863Soft.ISS.Model.Integral integralModel = new Model.Integral();
                            integralModel.Userid = int.Parse(umodel.CreatorId.ToString());
                            integralModel.Projectid = id;
                            integralModel.Projectname = "HSEConsulting";

                            userModel.ID = int.Parse(umodel.CreatorId.ToString());
                            userModel.Point = 10;
                            HN863Soft.ISS.BLL.Manager mbll = new BLL.Manager();

                            if (!mbll.GetIntegralList(integralModel))
                            {

                                //插入积分
                                mbll.UpdateIntegral(userModel, integralModel);
                            }
                        }

                        AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改高企认定咨询用户查看权限"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/HSEConsulting/HSECAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('高企认定咨询权限修改失败！');");
                        return;
                    }
                }
            }
        }
    }
}