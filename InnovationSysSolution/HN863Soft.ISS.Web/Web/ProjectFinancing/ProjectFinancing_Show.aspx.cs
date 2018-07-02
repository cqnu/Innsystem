using HN863Soft.ISS.BLL;
using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.ProjectFinancing
{
    public partial class ProjectFinancing_Show1 : System.Web.UI.Page
    {
        private readonly HN863Soft.ISS.BLL.ProjectFinancingBll bll = new BLL.ProjectFinancingBll();

        public HN863Soft.ISS.Model.ProjectFinancing model = new Model.ProjectFinancing();

        public string strType = "";

        public string strAddress = "";

        public string url = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    //获取地址栏
                    Uri url = System.Web.HttpContext.Current.Request.Url;
                    HN863Soft.ISS.BLL.ReportBll rBll = new BLL.ReportBll();
                    HN863Soft.ISS.Web.Core.ManagePage m = new Core.ManagePage();

                    string strUrl = url.ToString();

                    //判断举报按钮是否可用
                    if (Session[KeysHelper.ForegroundUser] != null)
                    {

                        HN863Soft.ISS.Model.Users umodel = new Model.Users();



                        umodel = Session[KeysHelper.ForegroundUser] as HN863Soft.ISS.Model.Users;

                        //判断用户是否已举报过
                        if (rBll.Hide(umodel.ID, strUrl))
                        {
                            btnComplaint.Disabled = true;
                            btnComplaint.Value = "已举报";


                            if (m.ChkManageType())
                            {
                                btnHandle.Visible = true;
                            }
                        }
                    }

                    //判断添加推广按钮或取消推广按钮显示/隐藏
                    if (m.ChkManageType())
                    {
                        if (rBll.GetExtension(strUrl))
                        {
                            btnDel.Visible = true;
                        }
                        else
                        {
                            btnAdd.Visible = true;
                        }
                    }

                    string strid = Request.Params["id"];
                    int ID = (Convert.ToInt32(strid));
                    ShowInfo(ID);
                }
            }
        }

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.ProjectFinancingBll bll = new HN863Soft.ISS.BLL.ProjectFinancingBll();
            model = bll.GetModel(ID);

            if (model.Type == 1)
            {
                strType = "众筹项目";
            }
            if (model.Type == 2)
            {
                strType = "股权融资项目";
            }
            if (model.Type == 3)
            {
                strType = "综合合作项目";
            }

            img1.Src = model.Cover;
            url = model.PromotionalVideo;

            string strPlace = model.Place.ToString();
            string[] array = strPlace.ToString().Split('-');
            DataSet dcity = new DataSet();
            ProjectFinancingBll fbll = new BLL.ProjectFinancingBll();
            strAddress = fbll.GetS(array[0]).Tables[0].Rows[0]["Name"].ToString().Trim() + " " + fbll.GetShi(array[1]).Tables[0].Rows[0]["Name"].ToString().Trim() + " ";


            if (url.ToString() == "")
            {
                divVideo.Visible = false;
            }
            else
            {
                //url = url.Replace("http://localhost:10414", "");
                //url = "../.." + url;
            }



        }
    }
}