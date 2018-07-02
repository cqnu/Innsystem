using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// RetrievePassword 的摘要说明
    /// </summary>
    public class RetrievePassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = RequestHelper.GetQueryString("action");
            switch (action)
            {
                case "ValidationInformation": //验证用户名和邮箱
                    ValidationInformation(context);
                    break;
                case "SendMail": //发送邮件
                    SendMail(context);
                    break;
                case "ValidationMail": //验证是否被注册

                    ValidationMail(context);
                    break;
            }

        }

        public void ValidationInformation(HttpContext context)
        {
            string name = context.Request["rname"];
            string password = context.Request["password"];
            string email = context.Request["email"];

            HN863Soft.ISS.BLL.Users users = new BLL.Users();
            int reust = 0;
            if (users.ValidationInformation(name, email))
            {
                //context.Response.Write("0");
                reust = 0;

            }
            else
            {
                //context.Response.Write("1");
                reust = 1;

            }

            Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig();
            if (reust == 0)
            {
                Model.MailTemplate mailModel = new BLL.MailTemplate().GetModel("ResetKeyNotice");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.MaillTitle;
                    mailTitle = mailTitle.Replace("{username}", name);
                    string mailContent = mailModel.Content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);

                    mailContent = mailContent.Replace("{username}", name);

                    string url = EncryptionHelper.Encrypt("&pwd=" + password + "&name=" + name);

                    HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
                    var model = bll.loadConfig();
                    mailContent = mailContent.Replace("{linkurl}", model.weburl + "/WebService/Activation.ashx?activation=password" + url);
                    mailContent = mailContent.Replace("{valid}", "30");
                    //发送邮件
                    //MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                    //    siteConfig.emailfrom, model.Email, mailTitle, mailContent);

                    try
                    {

                        MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, "@wbcWBC_34@", siteConfig.emailnickname,
                           siteConfig.emailfrom, email, mailTitle, mailContent);
                        context.Response.Write("0");
                    }
                    catch
                    {
                        context.Response.Write("-1");
                    }
                }
            }
            else
            {
                context.Response.Write("1");
            }



        }

        public void ValidationMail(HttpContext context)
        {
            string email = context.Request["email"];

            HN863Soft.ISS.BLL.Users bll = new BLL.Users();

            if (bll.ValidationMail(email))
            {
                context.Response.Write("false");

            }
            else
            {
                context.Response.Write("true");


            }
        }

        public void SendMail(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["rname"];
            string password = context.Request["password"];
            string email = context.Request["email"];




        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}