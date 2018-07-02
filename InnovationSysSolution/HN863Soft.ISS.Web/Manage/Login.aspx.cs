using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbUserName.Text = Utils.GetCookie("RememberName");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim();
            string userPwd = tbPassword.Text.Trim();
            string checkCode = tbCode.Text.Trim();

            //防暴力破解，最多6次登录失败后必须重新启动浏览器
            if (Session["LoginSum"] == null)
            {
                Session["LoginSum"] = 1;
            }
            else
            {
                Session["LoginSum"] = Convert.ToInt32(Session["LoginSum"]) + 1;
            }

            //判断登录错误次数
            if (Session["LoginSum"] != null && Convert.ToInt32(Session["LoginSum"]) > 6)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('错误次数超过6次，请关闭浏览器重新登录！');");
                return;
            }

            if (userName.Equals("") || userPwd.Equals(""))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('请输入用户名或密码！');");
                return;
            }
            string str = Session["yzmCode"].ToString().Trim().ToLower();
            if (string.IsNullOrWhiteSpace(checkCode))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('验证码不能为空！');");
                return;
            }
            if (Session["yzmCode"] == null || string.IsNullOrWhiteSpace(Session["yzmCode"].ToString()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('验证码出现异常，请刷新！');changeYZM();");
                return;
            }
            if (Session["yzmCode"].ToString().Trim().ToLower() != checkCode.Trim().ToLower())
            {
                ShowMsgHelper.ShowScript("showWarningMsg('验证码错误！');changeYZM();");
                return;
            }

            //登录成功后重置登录次数
            Session["LoginSum"] = 1;

            BLL.Manager bll = new BLL.Manager();
            Model.Manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('用户名或密码有误，请重试！');");
                return;
            }

            Session[KeysHelper.SESSION_MANAGE_INFO] = model;
            Session.Timeout = 45;

            //写入登录日志
            Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.ManagerLog().Add(model.ID, model.UserName, EnumsHelper.ActionEnum.Login.ToString(), "用户登录");
            }
            
            ////测试邮件
            ////发送邮件
            ////取得邮件模板内容
            //Model.MailTemplate mailModel = new BLL.MailTemplate().GetModel("AuditNotice");
            //if (mailModel != null)
            //{
            //    //替换标签
            //    string mailTitle = mailModel.MaillTitle;
            //    mailTitle = mailTitle.Replace("{username}", model.UserName);
            //    string mailContent = mailModel.Content;
            //    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
            //    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
            //    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel); 
            //    mailContent = mailContent.Replace("{username}", model.UserName);
            //    //发送邮件
            //    //MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
            //    //    siteConfig.emailfrom, model.Email, mailTitle, mailContent);

            //    MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.smspassword, siteConfig.emailnickname,
            //       siteConfig.emailfrom, model.Email, mailTitle, mailContent);
            //}

            //写入Cookies
            Utils.WriteCookie("RememberName", model.UserName, 14400);
            Utils.WriteCookie("manageName", "ISS", model.UserName);
            Utils.WriteCookie("managePwd", "ISS", model.Password);
            Response.Redirect("Index.aspx");
            return;
        }
    }
}