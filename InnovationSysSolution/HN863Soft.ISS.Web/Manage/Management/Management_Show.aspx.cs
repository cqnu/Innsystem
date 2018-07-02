using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Management
{
    public partial class Management_Show : System.Web.UI.Page
    {

        #region 变量

        private readonly HN863Soft.ISS.BLL.ManagementBll bll = new BLL.ManagementBll();

        public string strTitle;

        public string str;

        public string strRemarks;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string strid = Request.Params["id"];
                    ViewState["id"] = strid;
                    int ID = (Convert.ToInt32(strid));

                    ShowInfo(ID);
                }
            }
        }

        #region 方法

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {

            HN863Soft.ISS.Model.Management model = bll.GetModel(ID);


            strRemarks = model.Remarks;


            str = model.Content;
            strTitle = model.Title;


        }

        #endregion
    }
}