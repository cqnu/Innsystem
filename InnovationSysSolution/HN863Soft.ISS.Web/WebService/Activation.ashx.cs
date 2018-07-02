using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// Activation 的摘要说明
    /// </summary>
    public class Activation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = RequestHelper.GetQueryString("activation").Substring(0, 8);
            switch (action)
            {
                case "register": //注册
                    Register(context);
                    break;
                case "password": //重置密码
                    Password(context);
                    break;
            }
        }

        public void Password(HttpContext context)
        {
            HN863Soft.ISS.BLL.Users users = new BLL.Users();

            string url = RequestHelper.GetQueryString("activation").Replace("password", "");

            url = EncryptionHelper.Decrypt(url);//解密

            string[] sArray1 = url.Split('&');//分割字符

            int result = 0;
            string pwd = sArray1[1].Replace("pwd=", "");
            string name = sArray1[2].Replace("name=", "");

            string strSalt = HN863Soft.ISS.Common.Utils.GetCheckCode(6);//随机生成的字符串key




            string decPassWord = EncryptionHelper.Encrypt(pwd, strSalt);


            result = users.UpdatePwd(name, decPassWord, strSalt);//修改

            HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
            var model = bll.loadConfig();


            context.Response.Redirect(model.weburl + "/web/index.html", true);
        }

        public void Register(HttpContext context)
        {
            HN863Soft.ISS.BLL.Users users = new BLL.Users();

            string url = RequestHelper.GetQueryString("activation").Replace("register", "");

            url = EncryptionHelper.Decrypt(url);//解密

            string[] sArray1 = url.Split('&');//分割字符

            int result = 0;
            string type = sArray1[2].Replace("type=", "");
            string name = sArray1[1].Replace("name=", "");

            result = users.Update(name, type);//修改

            HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
            var model = bll.loadConfig();

            context.Response.Redirect(model.weburl+"/web/index.html", true);


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