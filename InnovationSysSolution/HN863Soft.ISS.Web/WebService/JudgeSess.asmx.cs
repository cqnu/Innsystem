using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// JudgeSess1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class JudgeSess1 : System.Web.Services.WebService
    {

        //[WebMethod]
        [WebMethod(EnableSession = true)]
        public void HelloWorld()
        {
            if (Session[KeysHelper.ForegroundUser] != null)
            {
                Users model = (Users)Session[KeysHelper.ForegroundUser];
                //context.Response.Write("1");

                //context.Response.Write(model.UserName);
                this.Context.Response.Write(model.UserName);

            }
            else
            {
                //return "0";

                this.Context.Response.Write("0");
            }

        }

        [WebMethod(EnableSession = true)]
        public void Cancellation()
        {
            if (Session[KeysHelper.ForegroundUser] != null)
            {

                Session[KeysHelper.ForegroundUser] = null;
                this.Context.Response.Write("0");
            }
        }


        [WebMethod(EnableSession = true)]
        public void GetName()
        {
            if (Session[KeysHelper.ForegroundUser] != null)
            {

                Users model = (Users)Session[KeysHelper.ForegroundUser];
                this.Context.Response.Write(model.UserName);
            }
        }
    }
}
