using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// JudgeSess 的摘要说明
    /// </summary>
    public class JudgeSess : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strType = RequestHelper.GetQueryString("state");

            if (strType == "0")
            {
                Login(context);
            }
            else if (strType == "1")
            {
                Cancellation(context);
            }
            else if (strType == "2")
            {
                Manage(context);
            }
            else
            {
                GetName(context);
            }




        }

        public void Login(HttpContext context)
        {
            string msg = "";
            if (context.Session[KeysHelper.ForegroundUser] != null)
            {
                Users model = (Users)context.Session[KeysHelper.ForegroundUser];
                msg = model.UserName;

            }
            else
            {
                msg = "";
            }
            context.Response.Write(msg);
        }

        public void Cancellation(HttpContext context)
        {
            if (context.Session[KeysHelper.ForegroundUser] != null)
            {

                context.Session[KeysHelper.ForegroundUser] = null;
                if (context.Session[KeysHelper.SESSION_MANAGE_INFO] != null)
                {
                    context.Session[KeysHelper.SESSION_MANAGE_INFO] = null;
                }



                context.Response.Write("0");
            }
        }

        public void Manage(HttpContext context)
        {
            string msg = "";
            if (context.Session[KeysHelper.SESSION_MANAGE_INFO] != null)
            {
                Manager model = (Manager)context.Session[KeysHelper.SESSION_MANAGE_INFO];
                msg = model.UserName;

            }
            else
            {
                msg = "";
            }
            context.Response.Write(msg);
        }


        public void GetName(HttpContext context)
        {
            if (context.Session[KeysHelper.ForegroundUser] != null)
            {

                Users model = (Users)context.Session[KeysHelper.ForegroundUser];
                context.Response.Write(model.UserName);
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