using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.TalentService
{
    public partial class TalentServiceAuditList : ManagePage
    {
        #region 变量定义

        HN863Soft.ISS.BLL.TalentServiceBll bll = new HN863Soft.ISS.BLL.TalentServiceBll();
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
                if (!ChkManageLevel("ChannelTalentServiceAuditList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();
                this.keywords = RequestHelper.GetQueryString("keywords");
                this.pageSize = GetPageSize(10); //每页数量
                BindData();
            }
        }

        #endregion

        #region 方法

        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("talentservice_audit_page_size", "ISSPage"), out _pagesize))
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

            if (txtKeywords.Text.Trim() != "")
            {
                strWhere.AppendFormat(" and  a.Title like '%" + txtKeywords.Text.Trim() + "%'");
            }
            //判断类型检索
            if (ddlType.SelectedValue != "-1")
            {
                strWhere.Append(" and a.Type= " + ddlType.SelectedValue);
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
            string pageUrl = Utils.CombUrlTxt("TalentServiceAuditList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 绑定信息类型

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.TalentServiceType item in Enum.GetValues(typeof(EnumsHelper.TalentServiceType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion

        #region 事件

        #region 审核

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelTalentServiceAuditList", EnumsHelper.ActionEnum.Audit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            bll = new BLL.TalentServiceBll();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                //审核选中的服务信息
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.TalentService tsModel = bll.GetModel(id);
                    if (tsModel == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败：没有找到这条消息');");
                        return;
                    }

                    tsModel.ID = id;
                    tsModel.State = int.Parse(hidState.Value);
                    tsModel.Describe = hidDescribe.Value;

                    if (bll.Update(tsModel))
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核人才服务成功"); //记录日志
                        ShowMsgHelper.ShowScript("location.href='/Manage/TalentService/TalentServiceAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('路演审核失败！');");
                        return;
                    }
                }
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TalentServiceAuditList.aspx", "keywords={0}", txtKeywords.Text));
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelTalentServiceAuditList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
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

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除人才服务"); //记录日志
            ShowMsgHelper.ShowScript("location.href='/Manage/TalentService/TalentServiceAuditList.aspx';");

            BindData();
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("talentservice_audit_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("TalentServiceAuditList.aspx", "keywords={0}", this.keywords));
        }

        #endregion

        /// <summary>
        /// 检索相应类型信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnJurisdiction_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.TalentService model = new HN863Soft.ISS.BLL.TalentServiceBll().GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('修改失败：没有找到这条消息');");
                        return;
                    }

                    HN863Soft.ISS.BLL.ProjectFinancingBll pBll = new BLL.ProjectFinancingBll();

                    if (pBll.UpdateJurisdiction("Talent", id, int.Parse(hidState.Value)))
                    {

                        if (int.Parse(hidState.Value) == 2)
                        {

                            HN863Soft.ISS.Model.TalentService umodel = bll.GetModel(id);
                            HN863Soft.ISS.Model.Users userModel = new Model.Users();

                            HN863Soft.ISS.Model.Integral integralModel = new Model.Integral();
                            integralModel.Userid = int.Parse(umodel.UserId.ToString());
                            integralModel.Projectid = id;
                            integralModel.Projectname = "Talent";

                            userModel.ID = int.Parse(umodel.UserId.ToString());
                            userModel.Point = 10;
                            HN863Soft.ISS.BLL.Manager mbll = new BLL.Manager();

                            if (!mbll.GetIntegralList(integralModel))
                            {

                                //插入积分
                                mbll.UpdateIntegral(userModel, integralModel);
                            }
                        }

                        AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改人才服务用户查看权限"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/TalentService/TalentServiceAuditList.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('人才服务权限修改失败！');");
                        return;
                    }
                }
            }
        }
    }
}