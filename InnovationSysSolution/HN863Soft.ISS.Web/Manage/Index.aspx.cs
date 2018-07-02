using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage
{
    public partial class Index : ManagePage
    {
        protected Model.Manager manageInfo; //用户信息

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                manageInfo = GetManageInfo();
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[KeysHelper.SESSION_MANAGE_INFO] = null;
            Session[KeysHelper.ForegroundUser] = null;
            Utils.WriteCookie("ManageName", "ISS", -14400);
            Utils.WriteCookie("ManagePassword", "ISS", -14400);
            Response.Redirect("/Web/index.html");
        }

    }
}