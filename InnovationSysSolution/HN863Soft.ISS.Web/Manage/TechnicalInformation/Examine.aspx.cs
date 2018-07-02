using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.TechnicalInformation
{
    public partial class Examine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Params["id"]);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();

            //string str = traDescribe.InnerText;
            //int id = int.Parse(Request.Params["id"]);
            //if (RadioButtonList1.SelectedValue == "Yes")
            //{
            //    bll.UpdateState(id, 1, str);
            //    //Response.Write("<script>window.dialogArguments.location.reload();</script>");
            //}
            //if (RadioButtonList1.SelectedValue == "No")
            //{
            //    bll.UpdateState(id, 2, str);
            //}
            Response.Write("<script language='javascript'>window.dialogArguments.window.location = window.dialogArguments.window.location;</script>");
            Response.Write("<script>self.close();</script>");
        }
    }
}