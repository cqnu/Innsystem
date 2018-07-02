using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace HN863Soft.ISS.Web.Manage.Policy
{
    public partial class Policy_Show : System.Web.UI.Page
    {

        public string strTitle;
        public string strContent;
        public string strUrl;
        HN863Soft.ISS.BLL.PolicyBll bll = new HN863Soft.ISS.BLL.PolicyBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(ID);
            }
        }

        private void ShowInfo(int ID)
        {
            DataTable dt = bll.GetInfo(ID);
            strTitle = dt.Rows[0]["Title"].ToString();
            strContent = dt.Rows[0]["CrawContent"].ToString();
            strUrl = dt.Rows[0]["Url"].ToString();
        }
    }
}