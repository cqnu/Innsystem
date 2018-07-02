using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*******************************
// 文件名（File Name）：ShowDetail.cs
// 作者(Author):  雷登辉
// 功能描述(Description): 专业技术详细信息展示
// 日期(Create Date):2017/3/13
//*******************************
namespace HN863Soft.ISS.Web.Web.SoftWareS
{
    public partial class ShowDetail : System.Web.UI.Page
    {

        #region 函数
        private BLL.HSEConsulting hseCBll;//高企认定咨询处理对象
        private BLL.SoftConsultingS softCSBll;//双软认定咨询处理对象
        private BLL.SoftwareS softSBll;//软件服务处理对象
        private Model.userAriticle articleModel;//工业设计实体对象
        private Model.TalentService tsModel;//人才服务实体对象
        private Model.HSEConsulting hseCModel;//高企认定咨询实体对象
        private Model.SoftConsultingS softCSModel;//双软认定咨询实体对象
        private Model.SoftwareS softSModel;//软件服务实体对象 
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                int id = int.Parse(Request["Id"]);
                string strType = Request["TypeName"];
                BindData(id, strType);



            }
        }
        #endregion

        #region 绑定数据

        public bool BindData(int id, string type)
        {
            List<ListItem> lstItem = new List<ListItem>();
            object model = new object();
            //string strWhere = "";
            switch (type)
            {
                case "SoftwareServiceType":
                    softSBll = new BLL.SoftwareS();
                    model = softSBll.GetModel(id);
                    hidHandle.Value = "SoftwareS";
                    break;
                case "SoftConsulting":
                    softCSBll = new BLL.SoftConsultingS();
                    model = softCSBll.GetModel(id);
                    hidHandle.Value = "SoftConsultingS";
                    break;
                case "HSEConsulting":
                    hseCBll = new BLL.HSEConsulting();
                    model = hseCBll.GetModel(id);
                    hidHandle.Value = "HSEConsulting";
                    break;
                default:
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert(\"参数异常\");javascript:history.back(-1);");
                    return false;
            }
            hseCModel = model as Model.HSEConsulting;
            softCSModel = model as Model.SoftConsultingS;
            softSModel = model as Model.SoftwareS;

            if (hseCModel != null)
            {
                BindData(hseCModel);
                return true;
            }
            if (softCSModel != null)
            {
                BindData(softCSModel);
                return true;
            }
            if (softSModel != null)
            {
                BindData(softSModel);
                return true;
            }
            return false;

        }

        #region 信息绑定

        /// <summary>
        /// 高企认定咨询信息
        /// </summary>
        /// <param name="model"></param>
        private void BindData(Model.HSEConsulting model)
        {
            //TName.InnerText = model.SName;
            txtIntroduction.InnerHtml = model.SIntroduction;
            txtTeamIntroduction.InnerHtml = model.TeamIntroduction;
            txtExample.InnerHtml = model.Example;
            txtPhone.InnerText = model.Phone;
            move.InnerHtml = model.SName;
            hkeys.InnerHtml = "<span class=\"hot-city\" style=\"font-size:14px; margin-left: 40px;\"> <img src=\"../CSS/Show/bq.png\" />" + model.KeyWord + "</span>";
            pIntroduce.InnerHtml = model.Introduce;
            img1.Src = model.LogImg;
        }

        /// <summary>
        /// 双软认定咨询信息
        /// </summary>
        /// <param name="model"></param>
        private void BindData(Model.SoftConsultingS model)
        {
            //TName.InnerText = model.SName;
            txtIntroduction.InnerHtml = model.SIntroduction;
            txtTeamIntroduction.InnerHtml = model.TeamIntroduction;
            txtExample.InnerHtml = model.Example;
            txtPhone.InnerText = model.Phone;
            move.InnerHtml = model.SName;
            hkeys.InnerHtml = "<span class=\"hot-city\" style=\"font-size:14px; margin-left: 40px;\"> <img src=\"../CSS/Show/bq.png\" />" + model.KeyWord + "</span>";
            pIntroduce.InnerHtml = model.Introduce;
            img1.Src = model.LogImg;

        }

        /// <summary>
        /// 软件服务信息
        /// </summary>
        /// <param name="model"></param>
        private void BindData(Model.SoftwareS model)
        {
            //TName.InnerText = model.SName;
            txtIntroduction.InnerHtml = model.SIntroduction;
            txtTeamIntroduction.InnerHtml = model.TeamIntroduction;
            txtExample.InnerHtml = model.Example;
            txtPhone.InnerText = model.Phone;
            move.InnerHtml = model.SName;
            hkeys.InnerHtml = "<span class=\"hot-city\" style=\"font-size:14px; margin-left: 40px;\"> <img src=\"../CSS/Show/bq.png\" />" + model.KeyWord + "</span>";
            pIntroduce.InnerHtml = model.Introduce;
            img1.Src = model.LogImg;

        }

        #endregion

        #endregion
    }
}