using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Settings
{
    public partial class MailTemplateEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new BLL.MailTemplate().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("mail_template_settings", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.MailTemplate bll = new BLL.MailTemplate();
            Model.MailTemplate model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtCallIndex.Text = model.CallIndex;
            txtMailTitle.Text = model.MaillTitle;
            txtContent.Value = model.Content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.MailTemplate model = new Model.MailTemplate();
            BLL.MailTemplate bll = new BLL.MailTemplate();

            model.Title = txtTitle.Text.Trim();
            model.CallIndex = txtCallIndex.Text.Trim();
            model.MaillTitle = txtMailTitle.Text.Trim();
            model.Content = txtContent.Value;

            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加邮件模板:" + model.Title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.MailTemplate bll = new BLL.MailTemplate();
            Model.MailTemplate model = bll.GetModel(_id);

            model.Title = txtTitle.Text.Trim();
            model.CallIndex = txtCallIndex.Text.Trim();
            model.MaillTitle = txtMailTitle.Text.Trim();
            model.Content = txtContent.Value;

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改邮件模板:" + model.Title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("mail_template_settings", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
               
                ShowMsgHelper.ShowScript("location.href='/Manage/Settings/MailTemplateList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("mail_template_settings", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                
                ShowMsgHelper.ShowScript("location.href='/Manage/Settings/MailTemplateList.aspx';");
            }
        }

    }
}