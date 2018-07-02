using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
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

namespace HN863Soft.ISS.Web.Manage.Organization
{
    public partial class OrganizationList : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int org_id;
        protected string keywords = string.Empty;
        Manager manage = new HN863Soft.ISS.Model.Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.org_id = RequestHelper.GetQueryInt("orgID");
            this.keywords = RequestHelper.GetQueryString("keywords");
            manage = GetManageInfo();
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelOrganizationAudit", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                TreeBind(); //绑定类别

                //检查是否是管理员角色
                if (ChkManageType())
                {
                    RptBind("and a.ID>0" + CombSqlTxt(org_id, keywords), " a.ID desc");
                }
                else
                {
                    RptBind(" and a.UserID = " + manage.ID + " and a.ID>0" + CombSqlTxt(org_id, keywords), " a.ID desc");
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            DataTable dt = bll.GetList("").Tables[0];

            List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
            DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
            if (dsManagerTypes != null)
            {
                for (int i = 0; i < dsManagerTypes.Tables[0].Rows.Count; i++)
                {
                    if (dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString() == "管理员" || dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString() == "版主")
                    {
                        continue;
                    }
                    managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[i]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[i]["IsSys"].ToString()) });
                }
            }

            ddlOrganizationType.Items.Clear();
            ddlOrganizationType.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                var temp = managerTypeList.FirstOrDefault(x => x.ID == Convert.ToInt32(dr["RoleType"]));
                if (temp != null)
                {
                    ddlOrganizationType.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["ID"].ToString()));
                }
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            ddlOrganizationType.SelectedValue = this.org_id.ToString();
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.Organization bll = new HN863Soft.ISS.BLL.Organization();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();

            if (ChkManageType())
            {
                string pageUrl = Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}&page={2}", this.org_id.ToString(), this.keywords, "__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
            else
            {
                string pageUrl = Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}&page={2}&UserID={3}", this.org_id.ToString(), this.keywords, "__id__", manage.ID.ToString());
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int org_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (org_id > 0)
            {
                strTemp.Append(" and a.OrgType=" + org_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (a.OrgName like  '%" + _keywords + "%' or a.OrgLocation like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("organization_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}", this.org_id.ToString(), txtKeywords.Text));
        }

        //筛选类型
        protected void ddlOrganizationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}", ddlOrganizationType.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("organization_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}", this.org_id.ToString(), this.keywords));
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelOrganizationAudit", EnumsHelper.ActionEnum.Audit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            BLL.Organization bll = new BLL.Organization();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");

                //审核选中的服务信息
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.Organization model = bll.GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败：没有找到这条消息');");
                        return;
                    }

                    model.ID = id;
                    model.State = int.Parse(hidState.Value);
                    model.Remark = hidDescribe.Value;
                    if (bll.Update(model))
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核服务信息成功"); //记录日志

                        if (model.State == 3)
                        {
                            //修改用户的角色
                            HN863Soft.ISS.BLL.Manager managerBll = new BLL.Manager();
                            var tempManager = managerBll.GetModel(model.UserID);

                            if (tempManager == null)
                            {
                                ShowMsgHelper.ShowScript("showWarningMsg('用户不存在，审核失败！');");
                                return;
                            }
                            else
                            {
                                if (!ChkManageType())//检查是否为管理员若为管理员则不更新角色
                                {
                                    HN863Soft.ISS.BLL.ManagerRole managerRoleBll = new BLL.ManagerRole();
                                    HN863Soft.ISS.Model.ManagerRole managerRole = new ManagerRole();
                                    managerRole = managerRoleBll.GetModel(model.OrgType);

                                    tempManager.RoleID = model.OrgType;
                                    tempManager.RoleType = managerRole.RoleType;

                                    Users umodel = new Users();

                                    if (managerBll.Update(tempManager, umodel))
                                    {
                                        ShowMsgHelper.ShowScript("location.href='/Manage/Organization/OrganizationList.aspx';");
                                    }
                                    else
                                    {
                                        ShowMsgHelper.ShowScript("showWarningMsg('更新用户角色失败，请与管理员联系！');");
                                        return;
                                    }
                                }
                                else
                                {
                                    ShowMsgHelper.ShowScript("location.href='/Manage/Organization/OrganizationList.aspx';");
                                }
                            }
                        }
                        else
                        {
                            ShowMsgHelper.ShowScript("location.href='/Manage/Organization/OrganizationList.aspx';");
                        }
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('机构资料审核失败！');");
                        return;
                    }
                }
            }

        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelOrganizationAudit", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;
            int errorCount = 0;
            HN863Soft.ISS.BLL.Organization bll = new HN863Soft.ISS.BLL.Organization();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除机构入驻成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
            //Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Organization/OrganizationList.aspx';");
        }
    }
}