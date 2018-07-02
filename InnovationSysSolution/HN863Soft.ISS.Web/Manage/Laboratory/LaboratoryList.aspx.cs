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

namespace HN863Soft.ISS.Web.Manage.Laboratory
{
    public partial class LaboratoryList : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int lab_id;
        protected string keywords = string.Empty;
        Manager manage = new HN863Soft.ISS.Model.Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lab_id = RequestHelper.GetQueryInt("labID");
            this.keywords = RequestHelper.GetQueryString("keywords");
            manage = GetManageInfo();
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                if (manage.RoleType < 3)
                {
                    RptBind("ID>0" + CombSqlTxt(lab_id, keywords), " ID desc");
                }
                else
                {
                    RptBind(" UserID = " + manage.ID + " and ID>0" + CombSqlTxt(lab_id, keywords), " ID desc");
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            //this.ddlOrganizationType.Items.Clear();
            //this.ddlOrganizationType.Items.Add(new ListItem("所有类型", ""));
            //this.ddlOrganizationType.Items.Add(new ListItem("专家", "1"));
            //this.ddlOrganizationType.Items.Add(new ListItem("机构", "2"));
            //this.ddlOrganizationType.Items.Add(new ListItem("企业", "3"));
            //this.ddlOrganizationType.Items.Add(new ListItem("其它", "4"));
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            //ddlOrganizationType.SelectedValue = this.org_id.ToString();
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.Laboratory bll = new HN863Soft.ISS.BLL.Laboratory();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();

            if (manage.RoleType < 3)
            {
                string pageUrl = Utils.CombUrlTxt("LaboratoryList.aspx", "labID={0}&keywords={1}&page={2}", this.lab_id.ToString(), this.keywords, "__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
            else
            {
                string pageUrl = Utils.CombUrlTxt("LaboratoryList.aspx", "labID={0}&keywords={1}&page={2}&UserID={3}", this.lab_id.ToString(), this.keywords, "__id__", manage.ID.ToString());
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int labID, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (labID > 0)
            {
                strTemp.Append(" and LabType=" + labID);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (LabName like  '%" + _keywords + "%' or LabLocation like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("laboratory_page_size", "ISSPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("LaboratoryList.aspx", "labID={0}&keywords={1}", this.lab_id.ToString(), txtKeywords.Text));
        }

        ////筛选类型
        //protected void ddlOrganizationType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(Utils.CombUrlTxt("OrganizationList.aspx", "orgID={0}&keywords={1}", ddlOrganizationType.SelectedValue, this.keywords));
        //}

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("laboratory_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("LaboratoryList.aspx", "labID={0}&keywords={1}", this.lab_id.ToString(), this.keywords));
        }

        //批量审核
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.Audit.ToString()); //检查权限
            HN863Soft.ISS.BLL.Laboratory bll = new HN863Soft.ISS.BLL.Laboratory();
            var manager = GetManageInfo();
            Manager writer;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int userID = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidUserID")).Value);
                writer = new HN863Soft.ISS.BLL.Manager().GetModel(userID);
                HN863Soft.ISS.Model.Laboratory tempModel = bll.GetModel(id);;
                if (writer == null)
                {
                    if (tempModel != null)
                    {
                        writer = new HN863Soft.ISS.BLL.Manager().GetModel(tempModel.ID);
                    }
                }

                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateState(id, 3);

                    //发送邮件
                    //取得邮件模板内容
                    Model.MailTemplate mailModel = new BLL.MailTemplate().GetModel("AuditNotice");
                    if (mailModel != null)
                    {
                        //替换标签
                        string mailTitle = mailModel.MaillTitle;
                        string result = "已通过审核"; //根据值来确定审核结果
                        mailTitle = mailTitle.Replace("{username}", writer.UserName);
                        string mailContent = mailModel.Content;
                        mailContent = mailContent.Replace("{webname}", tempModel.LabName);
                        mailContent = mailContent.Replace("{webfax}", result);
                        mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                        mailContent = mailContent.Replace("{username}", writer.UserName);
                        //发送邮件
                        MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                            siteConfig.emailfrom, writer.Email, mailTitle, mailContent);
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核重点实验室信息"); //记录日志
            //ShowScriptMsg("保存排序成功！", Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Laboratory/LaboratoryList.aspx';");
        }
        
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.Delete.ToString()); //检查权限
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
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除重点实验室成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
            //Utils.CombUrlTxt("ChannelList.aspx", "SiteID={0}&keywords={1}", this.site_id.ToString(), this.keywords), "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Laboratory/LaboratoryList.aspx';");
        }
    }
}