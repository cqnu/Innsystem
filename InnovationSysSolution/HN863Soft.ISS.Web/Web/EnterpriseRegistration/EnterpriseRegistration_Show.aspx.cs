using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.EnterpriseRegistration
{
    public partial class EnterpriseRegistration_Show : System.Web.UI.Page
    {

        public HN863Soft.ISS.Model.EnterpriseRegistration model = new Model.EnterpriseRegistration();


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
            HN863Soft.ISS.BLL.EnterpriseRegistrationBll bll = new HN863Soft.ISS.BLL.EnterpriseRegistrationBll();
            model = bll.GetModel(ID);

            img1.Src = model.Cover;


        }
    }
}