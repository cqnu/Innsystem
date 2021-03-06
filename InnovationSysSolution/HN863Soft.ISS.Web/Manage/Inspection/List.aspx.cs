﻿using HN863Soft.ISS.Common;
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
//****************************
//* 文件名：List.cs
//* 作者：  雷登辉
//* 功能：  服务信息的展示  
//* 创建时间： 2017/2/23
//****************************
namespace HN863Soft.ISS.Web.Manage.Inspection
{
    public partial class List : ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体对象

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                Manager model = GetManageInfo(); //取得当前用户信息
                RptBind("RoleType>=" + model.RoleType + CombSqlTxt(keywords), "CreatTime asc,ID desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.ServiceInfo bll = new HN863Soft.ISS.BLL.ServiceInfo();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("List.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and (Title like  '%" + _keywords + "%' or RealName like '%" + _keywords + "%' or Content like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("ServiceInfo_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        /// <summary>
        /// 关健字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "keywords={0}", txtKeywords.Text));
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
                    Utils.WriteCookie("ServiceInfo_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("List.aspx", "keywords={0}", this.keywords));
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            //ChkManageLevel("List", EnumsHelper.ActionEnum.Audit.ToString()); //检查权限
            BLL.ServiceInfo bll = new BLL.ServiceInfo();
            int sucCount = 0;//记录审核成功数量
            int errorCount = 0;//记录审核失败数量
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                serviceModel = new ServiceInfo
                {
                    Id = id, // 服务信息Id
                    Visite = 1//0：未审核；1：已审核。
                };

                //审核选中的服务信息
                if (cb.Checked)
                {
                    if (bll.UpdateInfo(serviceModel))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核服务信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            ShowScriptMsg("审核成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("List.aspx", "keywords={0}", this.keywords));
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkManageLevel("List", EnumsHelper.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;//记录删除成功数量
            int errorCount = 0;//记录删除失败数量
            HN863Soft.ISS.BLL.ServiceInfo bll = new HN863Soft.ISS.BLL.ServiceInfo();
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
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除服务信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("List.aspx", "keywords={0}", this.keywords));
            //ShowMsgHelper.ShowScript("删除成功" + sucCount + "条，失败" + errorCount + "条！");
        }
    }
}