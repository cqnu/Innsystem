using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.ProjectFinancing
{
    public partial class ProjectFinancingShowPublish : System.Web.UI.Page
    {
         #region 变量

        private readonly HN863Soft.ISS.BLL.ProjectFinancingBll bll = new BLL.ProjectFinancingBll();

        /// <summary>
        /// 视频地址
        /// </summary>
        public string strSrc = "";

        /// <summary>
        /// 文本编辑器里的内容
        /// </summary>
        public string strContent = "";

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string strid = Request.Params["id"];
                    int ID = (Convert.ToInt32(strid));
                    //ActionTypeBind();
                    BindType();
                    BindDdl();
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定省
        /// </summary>
        private void BindDdl()
        {
            DataSet ds = new DataSet();
            ds = bll.GetProvince();
            this.ddlProvince.DataTextField = ds.Tables[0].Columns["Name"].ToString();
            this.ddlProvince.DataValueField = ds.Tables[0].Columns["ProvinceID"].ToString();
            this.ddlProvince.DataSource = ds.Tables[0];
            this.ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, "");
            ddlCity.Items.Insert(0, "");
        }


        /// <summary>
        /// 绑定操作权限类型
        /// </summary>
        //private void ActionTypeBind()
        //{
        //    cblActionType.Items.Clear();

        //    cblActionType.Items.Add(new ListItem("普通用户", "1"));
        //    cblActionType.Items.Add(new ListItem("会员用户", "2"));

        //}

        /// <summary>
        /// 绑定众筹类型
        /// </summary>
        private void BindType()
        {
            this.ddlType.Items.Clear();
            this.ddlType.Items.Add(new ListItem("众筹项目", "1"));
            this.ddlType.Items.Add(new ListItem("股权融资项目", "2"));
            this.ddlType.Items.Add(new ListItem("综合合作项目", "3"));

        }

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.ProjectFinancingBll bll = new HN863Soft.ISS.BLL.ProjectFinancingBll();
            HN863Soft.ISS.Model.ProjectFinancing model = bll.GetModel(ID);

            //判断权限是否被选中
            //if (model.Jurisdiction == 1)
            //{
            //    cblActionType.Items[0].Selected = true;
            //}

            //if (model.Jurisdiction == 2)
            //{
            //    cblActionType.Items[1].Selected = true;
            //}

            //if (model.Jurisdiction == 3)
            //{
            //    cblActionType.Items[0].Selected = true;
            //    cblActionType.Items[1].Selected = true;
            //}
            //cblActionType.Enabled = false;

            ddlType.SelectedValue = model.Type.ToString();
            ddlType.Enabled = false;

            //截取地址 数据库中为 省-市 存储
            string[] array = model.Place.ToString().Split('-');

            //默认选中对应的省
            ddlProvince.Items.FindByValue(array[0]).Selected = true;
            ddlProvince.Enabled = false;

            //绑定对应的市级
            DataSet ds = new DataSet();
            ds = bll.GetCity(array[0]);
            ddlCity.DataTextField = ds.Tables[0].Columns["Name"].ToString();
            ddlCity.DataValueField = ds.Tables[0].Columns["CityID"].ToString();
            ddlCity.DataSource = ds.Tables[0];
            ddlCity.DataBind();

            //默认选中对应的市
            ddlCity.Items.FindByValue(array[1]).Selected = true;
            ddlCity.Enabled = false;

            strSrc = model.PromotionalVideo;

            txtTitle.Text = model.Title;
            txtTitle.Enabled = false;

            txtKeyWord.Text = model.KeyWord;
            txtKeyWord.Enabled = false;

            txtObjective.Text = model.Objective;
            txtObjective.Enabled = false;

            startDate.Value = Convert.ToDateTime(model.StartTime).ToString("yyyy-MM-dd");

            endDate.Value = Convert.ToDateTime(model.EndTime).ToString("yyyy-MM-dd");

            Image1.ImageUrl = model.Cover;

            strContent = model.Content;
        }

        #endregion
    }
}