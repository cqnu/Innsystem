using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Ariticle
{
    public partial class AriticleShow : System.Web.UI.Page
    {
       #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindType();
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ViewState["id"] = Request.Params["id"];
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 绑定工业类型
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            //lstItem.Add(new ListItem("所有类型", "-1"));
            foreach (EnumsHelper.IndustrialType item in Enum.GetValues(typeof(EnumsHelper.IndustrialType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion

        #region 方法

        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.userAriticle bll = new HN863Soft.ISS.BLL.userAriticle();
            HN863Soft.ISS.Model.userAriticle model = bll.GetModel(ID);
            this.txtTitle.Text = model.Title;
            this.txtTitle.Enabled = false; 
            this.container.Text = model.Content;
            this.container.Enabled = false;
            this.ddlType.SelectedValue = model.Type.ToString();//工业类型
            this.ddlType.Enabled = false;
            Image1.ImageUrl = model.Logimg;//Log路径
            txtIntroduce.Text = model.Introduce;//简介
            txtKeyWord.Text = model.Keyword;//关键词
        }

        #endregion
    }
}