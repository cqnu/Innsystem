using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// ModifyPassword 的摘要说明
    /// </summary>
    public class ModifyPassword : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            string action = RequestHelper.GetQueryString("action");
            switch (action)
            {
                case "ValidationPwd": //验证用户名和邮箱
                    ValidationPwd(context);
                    break;
                case "NewVerification": //发送邮件
                    NewVerification(context);
                    break;
                case "UpdatePwd": //验证是否被注册

                    UpdatePwd(context);
                    break;
            }


        }

        public void UpdatePwd(HttpContext context)
        {
            HN863Soft.ISS.BLL.Users users = new BLL.Users();

            //string url = RequestHelper.GetQueryString("action").Replace("UpdatePwd", "");

            //url = EncryptionHelper.Decrypt(url);//解密

            //string[] sArray1 = url.Split('&');//分割字符

            int result = 0;
            string pwd = context.Request["NewPwd"];
            string name = context.Request["name"];

            string strSalt = HN863Soft.ISS.Common.Utils.GetCheckCode(6);//随机生成的字符串key




            string decPassWord = EncryptionHelper.Encrypt(pwd, strSalt);


            result = users.UpdatePwd(name, decPassWord, strSalt);//修改
            if (result > 0)
            {

                context.Session[KeysHelper.ForegroundUser] = null;

                context.Response.Cookies["username"].Expires = System.DateTime.Now.AddMonths(-1);
                context.Response.Cookies["password"].Expires = System.DateTime.Now.AddMonths(-1);
                context.Response.Cookies["checkr"].Expires = System.DateTime.Now.AddMonths(-1); 

                context.Response.Write("0");


                //context.Response.Redirect("www.baidu.com", true);
            }
            else
            {
                context.Response.Write("-1");
            }

        }

        public void NewVerification(HttpContext context)
        {
            string NewPwd = context.Request["NewPwd"];
            string OldPwd = context.Request["OldPwd"];
            if (NewPwd == OldPwd)
            {
                context.Response.Write("false");
            }
            else
            {
                context.Response.Write("true");
            }
        }


        public void ValidationPwd(HttpContext context)
        {
            string name = context.Request["name"];
            string password = context.Request["OldPwd"];
            BLL.Users bll = new BLL.Users();
            Model.Users model = bll.GetModel(name, password, true);
            if (model == null)
            {
                context.Response.Write("false");
            }
            else
            {
                context.Response.Write("true");
            }
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