﻿using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：ProjectFinancing_List.cs
// 作者（Author）：邹峰
// 功能（Function）：众筹管理列表
// 创建日期（Create Date）：2017/03/09
//*****************************
namespace HN863Soft.ISS.Web.Manage.ProjectFinancing
{
    public partial class ProjectFinancing_List : ManagePage
    {
        #region 变量定义

        HN863Soft.ISS.BLL.ProjectFinancingBll bll = new HN863Soft.ISS.BLL.ProjectFinancingBll();
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
                if (!ChkManageLevel("ChannelProjectFinancingList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
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
            if (int.TryParse(Utils.GetCookie("project_financing_page_size", "ISSPage"), out _pagesize))
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
            //    liAu.Visible = false;
            //}

            if (!ChkManageType())
            {
                strWhere.Append(" and  u.id = " + model.ID);
                liAu.Visible = false;
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
            ds = bll.GetList(this.pageSize, this.page, strWhere.ToString(),"a.id desc", out this.totalCount);
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
            string pageUrl = Utils.CombUrlTxt("ProjectFinancing_List.aspx", "ddlId={0}&keywords={1}&page={2}", this.ddl_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #endregion

        #region 事件

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ProjectFinancing_List.aspx", "ddlId={0}&keywords={1}", this.ddl_id.ToString(), txtKeywords.Text));
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelProjectFinancingList", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
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
                        ShowScriptMsg("已审核通过无法删除！", "ProjectFinancing_List.aspx", "parent.loadMenuTree");
                        return;
                    }
                    bll.Delete(id);
                }
            }

            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除众筹"); //记录日志

            ShowMsgHelper.ShowScript("location.href='/Manage/ProjectFinancing/ProjectFinancing_List.aspx';");
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("project_financing_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("ProjectFinancing_List.aspx", "ddlId={0}&keywords={1}", this.ddl_id.ToString(), txtKeywords.Text));
        }

        /// <summary>
        /// 审核按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelProjectFinancingList", EnumsHelper.ActionEnum.Audit.ToString())) //检查权限
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
                    HN863Soft.ISS.Model.ProjectFinancing model = new HN863Soft.ISS.BLL.ProjectFinancingBll().GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('审核失败：没有找到这条消息');");
                        return;
                    }

                    model.ID = id;
                    model.State = int.Parse(hidState.Value);
                    model.Describe = hidDescribe.Value;

                    if (bll.Update(model))
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核众筹成功"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/ProjectFinancing/ProjectFinancing_List.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('众筹审核失败！');");
                        return;
                    }
                }
            }
        }

        #endregion

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ProjectFinancing_List.aspx", "ddlId={0}&keywords={1}", ddlType.SelectedValue, txtKeywords.Text));
        }

        protected void btnJurisdiction_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    HN863Soft.ISS.Model.ProjectFinancing model = new HN863Soft.ISS.BLL.ProjectFinancingBll().GetModel(id);
                    if (model == null)
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('修改失败：没有找到这条消息');");
                        return;
                    }

                    //model.ID = id;
                    //model.State = int.Parse(hidState.Value);
                    //model.Describe = hidDescribe.Value;

                    if (bll.UpdateJurisdiction("ProjectFinancing", id, int.Parse(hidState.Value)))
                    {

                        if (int.Parse(hidState.Value) == 2)
                        {

                            HN863Soft.ISS.Model.ProjectFinancing umodel = bll.GetModel(id);
                            HN863Soft.ISS.Model.Users userModel = new Model.Users();

                            HN863Soft.ISS.Model.Integral integralModel = new Model.Integral();
                            integralModel.Userid = int.Parse(umodel.UserId.ToString());
                            integralModel.Projectid = id;
                            integralModel.Projectname = "ProjectFinancing";

                            userModel.ID = int.Parse(umodel.UserId.ToString());
                            userModel.Point = 10;
                            HN863Soft.ISS.BLL.Manager mbll = new BLL.Manager();

                            if (!mbll.GetIntegralList(integralModel))
                            {

                                //插入积分
                                mbll.UpdateIntegral(userModel, integralModel);
                            }
                        }

                        AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改众筹用户查看权限"); //记录日志

                        ShowMsgHelper.ShowScript("location.href='/Manage/ProjectFinancing/ProjectFinancing_List.aspx';");
                    }
                    else
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('众筹权限修改失败！');");
                        return;
                    }
                }
            }
        }
    }
}