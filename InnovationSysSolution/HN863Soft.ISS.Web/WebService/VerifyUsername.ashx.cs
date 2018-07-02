using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// VerifyUsername 的摘要说明
    /// </summary>
    public class VerifyUsername : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = context.Request["name"];
            HN863Soft.ISS.BLL.Users bll = new BLL.Users();//普通用户对象

            int uRowsNum = bll.GetList("UserName='" + name + "'").Tables[0].Rows.Count;//查询是否存在该账户

            if (uRowsNum == 0)
            {
                context.Response.Write("true");
            }
            else
            {

                context.Response.Write("false");
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