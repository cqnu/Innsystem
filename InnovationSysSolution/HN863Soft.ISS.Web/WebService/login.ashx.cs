using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = context.Request["name"];
            string password = context.Request["password"];



            HN863Soft.ISS.BLL.Users userBll = new BLL.Users();
            Users model = userBll.GetModel(name, password, true);

            HN863Soft.ISS.BLL.Manager mBll = new BLL.Manager();
            Manager mModel = mBll.GetModel(name, password, true);

            //DataTable managerDt = managerBll.GetList("UserName='" + userId + "'").Tables[0];
            //是否有该用户信息 managerDt.Rows.Count == 0 &&
            if (model == null)
            {

                context.Response.Write("0");
            }
            else
            {

                context.Response.Write("1");

                context.Session[KeysHelper.ForegroundUser] = model;


                if (mModel != null)
                {
                    context.Session[KeysHelper.SESSION_MANAGE_INFO] = mModel;
                }

                context.Session.Timeout = 45;


                //Utils.WriteCookie("Name", model.UserName, 14400);
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