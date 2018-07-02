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

namespace HN863Soft.ISS.Web.Manage.SoftwareService
{
    public partial class SSAuditList : ManagePage
    {
        #region 函数
        private HN863Soft.ISS.BLL.SoftwareS ssBll;//软件服务信息处理对象
        private HN863Soft.ISS.Model.SoftwareS ssModel;//软件服务信息实体对象

        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;

        #endregion

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelSSAuditList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();
                Manager model = GetManageInfo(); //取得当前用户信息
                RptBind(CombSqlTxt(keywords), "ID desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            ssBll = new BLL.SoftwareS();
            this.rptList.DataSource = ssBll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("SSAuditList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }


        #region 绑定信息类型

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.SoftwareServiceType item in Enum.GetValues(typeof(EnumsHelper.SoftwareServiceType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion
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
            if (int.TryParse(Utils.GetCookie("SSAuditList_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 事件

        /// <summary>
        /// 关健字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SSAuditList.aspx", "keywords={0}", txtKeywords.Text));
        }

        /// <summary>
        /// 设置分页数量 
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
                    Utils.WriteCookie("SSAuditList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("SSAuditList.aspx", "keywords={0}", this.keywords));
        }
        #region 审核

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelSSAuditList", EnumsHelper.ActionEnum.Audit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            BLL.SoftwareS bll = new BLL.SoftwareS();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                
                //审核选中的服务信息
                if (cb.Checked)
                {
                    ssModel = bll.GetModel(id);
                    if(ssModel == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败：没有找到这条消息');");
                        return;
                    }

                    ssModel.Id = id;
                    ssModel.IsVis = int.Parse(hidState.Value);
                    ssModel.Describe = hidDescribe.Value;
                    if (bll.UpdateIsVis(ssModel))
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核服务信息成功"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/SoftwareService/SSAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('软件服务审核失败！');");
                        return;
                    }
                }
            }
            
        }
        #endregion

        /// <summary>
        /// 检索相应类型信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RptBind(CombSqlTxt(keywords), "ID desc");
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelSSAuditList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;//记录删除成功数量
            int errorCount = 0;//记录删除失败数量
            ssBll = new BLL.SoftwareS();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (ssBll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删软件服务信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("SSList.aspx", "keywords={0}", this.keywords));
            ShowMsgHelper.ShowScript("location.href='/Manage/SoftwareService/SSAuditList.aspx';");
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
                    HN863Soft.ISS.Model.SoftwareS model = new HN863Soft.ISS.BLL.SoftwareS().GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('修改失败：没有找到这条消息');");
                        return;
                    }

                    HN863Soft.ISS.BLL.ProjectFinancingBll pBll = new BLL.ProjectFinancingBll();

                    if (pBll.UpdateJurisdiction("SoftwareS", id, int.Parse(hidState.Value)))
                    {

                        if (int.Parse(hidState.Value) == 2)
                        {

                            HN863Soft.ISS.Model.SoftwareS umodel = new HN863Soft.ISS.BLL.SoftwareS().GetModel(id);
                            HN863Soft.ISS.Model.Users userModel = new Model.Users();

                            HN863Soft.ISS.Model.Integral integralModel = new Model.Integral();
                            integralModel.Userid = int.Parse(umodel.CreatorId.ToString());
                            integralModel.Projectid = id;
                            integralModel.Projectname = "SoftwareS";

                            userModel.ID = int.Parse(umodel.CreatorId.ToString());
                            userModel.Point = 10;
                            HN863Soft.ISS.BLL.Manager mbll = new BLL.Manager();

                            if (!mbll.GetIntegralList(integralModel))
                            {

                                //插入积分
                                mbll.UpdateIntegral(userModel, integralModel);
                            }
                        }

                        AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改软件服务用户查看权限"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/SoftwareService/SSAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('软件服务权限修改失败！');");
                        return;
                    }
                }
            }
        }
    }
}