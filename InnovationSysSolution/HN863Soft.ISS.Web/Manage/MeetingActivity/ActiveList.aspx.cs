﻿using System;
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
//****************************
//* 文件名：ActiveList.cs
//* 作者：雷登辉
//* 功能：展示难题吐槽信息并提供删除、审核功能
//* 创建时间：2017/3/1
//****************************
namespace HN863Soft.ISS.Web.Manage.MeetingActivity
{
    public partial class ActiveList : ManagePage
    {
        #region 函数

        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        //HN863Soft.ISS.Model.MeetingActivity meetingModel;//服务信息实体对象 
        #endregion

        #region 页面初始化

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
                if (!ChkManageLevel("ChannelActiveList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();
                Manager model = GetManageInfo(); //取得当前用户信息
                BLL.Users uBll = new BLL.Users();
                Users uModel = uBll.GetUserModel(model.ID);
                if (uModel != null)
                {
                    string stWhere = "";
                    if (!ChkManageType())
                    {
                        stWhere = "1=1 and CreatorId=" + uModel.ID;
                    }
                    RptBind(stWhere + CombSqlTxt(keywords), "CreateTime desc,ID desc");
                }
            }
        } 
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.MeetingActivity bll = new HN863Soft.ISS.BLL.MeetingActivity();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ActiveList.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 绑定信息类型

        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.ForumCategory item in Enum.GetValues(typeof(EnumsHelper.ForumCategory)))
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
                strTemp.Append(" and (Title like  '%" + _keywords + "%' or RealName like '%" + _keywords + "%' or Content like '%" + _keywords + "%')");
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
            if (int.TryParse(Utils.GetCookie("ActiveList_page_size", "ISSPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("ActiveList.aspx", "keywords={0}", txtKeywords.Text));
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
                    Utils.WriteCookie("ActiveList_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ActiveList.aspx", "keywords={0}", this.keywords));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelActiveList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0;//记录删除成功数量
            int errorCount = 0;//记录删除失败数量
            HN863Soft.ISS.BLL.MeetingActivity bll = new HN863Soft.ISS.BLL.MeetingActivity();
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
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除活动信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            //ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("ActiveList.aspx", "keywords={0}", this.keywords));
            //ShowMsgHelper.ShowScript("删除成功" + sucCount + "条，失败" + errorCount + "条！");
            ShowMsgHelper.ShowScript("location.href='/Manage/MeetingActivity/ActiveList.aspx';");
        }
        #endregion

        #region 检索相应类型信息

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Manager model = GetManageInfo(); //取得当前用户信息
            RptBind("CreatorId=" + model.ID + CombSqlTxt(keywords), "CreateTime asc,ID desc");
        }
        #endregion
    }
}