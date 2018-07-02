using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Intellectual
{
    public partial class IntellectualAuditShow : System.Web.UI.Page
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.IntellectualBll bll = new BLL.IntellectualBll();

        public string str;

        #endregion

        #region 页面初期

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

        #endregion

        #region 方法

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {

            HN863Soft.ISS.Model.Intellectual model = bll.GetModel(ID);

            txtTitle.Text = model.Title;
            txtKeyWord.Text = model.KeyWord;
            Image1.ImageUrl = model.Cover;
            str = model.Content;
            txtIntroduce.Text = model.Introduce;
        }

        #endregion
    }
}