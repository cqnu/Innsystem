using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;

namespace HN863Soft.ISS.Web.WebService
{
    public partial class IsLoginAjax : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLoginto();
            }
        }


        private void IsLoginto()
        {
           Model.Users user= GetUserInfoF();
            if (user!=null)
            {
                Response.Write("{\"returnValue\":\"1\",\"UserId\":\""+user.ID+"\"}");
                return;
            }
            else
            {
                Response.Write("{\"returnValue\":\"0\"}");
                return;
            }
        }
    }
}