using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//**************************
//* 文件名：EIDetail.cs
//* 作者：雷登辉
//* 功能：孵化器详细信息展示
//* 创建时间 ：2017/3/6
//**************************
namespace HN863Soft.ISS.Web.Web.EnterIncubating
{
    public partial class EIDetail : System.Web.UI.Page
    {
        private HN863Soft.ISS.BLL.PictureClip picBll;//图片处理对象
        private BLL.Organization organizationBll;//
        protected static int numImg = 0;//图片的数量
        public string url = "";
        public string qqUrl = "";
        public string title = "";
        public string webUrl = "";

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //获取地址栏
                Uri url = System.Web.HttpContext.Current.Request.Url;
                HN863Soft.ISS.BLL.ReportBll rBll = new BLL.ReportBll();
                HN863Soft.ISS.Web.Core.ManagePage m = new Core.ManagePage();

                string strUrl = url.ToString();


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

                int id = Convert.ToInt32(Request["Id"]);
                GetData(id);

            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GetData(int id)
        {
            //txtinput.Value = id.ToString();
            picBll = new BLL.PictureClip();
            organizationBll = new BLL.Organization();
            Model.Organization hatModel = organizationBll.GetModel(id);
            if (hatModel == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('参数不正确！');history.go(-1);", true);
                return;
            }

            if (hatModel.VideoUrl.ToString() == "")
            {
                xVideo.Visible = false;
            }
            else
            {
                url = hatModel.VideoUrl;
            }

            txtId.Value = id.ToString();

            title = hatModel.OrgName;

            qqUrl = hatModel.ProposerCard;

            webUrl = hatModel.Weburl;
            //sTitle.InnerText = hatModel.OrgName;

            //int titleLength = hatModel.OrgName.Length;

            //if (titleLength <= 5)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-60px;");
            //}
            //else if (titleLength <= 8)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-90px;");
            //}
            //else if (titleLength <= 10)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-110px;");
            //}
            //else if (titleLength <= 12)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-130px;");
            //}
            //else if (titleLength <= 15)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-150px;");
            //}
            //else if (titleLength <= 18)
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-170px;");
            //}
            //else
            //{
            //    sTitle.Attributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "-190px;");
            //}

            //title.InnerText = hatModel.OrgName;
            //lblPhone.InnerText = hatModel.ProposerMobile;
            //lblAddress.InnerText = hatModel.OrgLocation;
            //divContent.InnerHtml = hatModel.OrgIntro;
            Characteristic.InnerHtml = hatModel.OrgIntro;
            Standard.InnerHtml = hatModel.OrgExhibit;
            string strUrl = "../../map/demo/f0_3.htm";
            string strStyle = " style=\"width: 100%; height:480px;\"";

            frame1.InnerHtml = "<iframe src=" + strUrl + "?lng=" + hatModel.Lng + "&lat=" + hatModel.Lat + strStyle + "></iframe>";
            DataTable imgDt = picBll.GetList("ParentId=" + id).Tables[0];
            DataTable dt = imgDt.Clone();
            dt.Clear();
            numImg = imgDt.Rows.Count;
            if (numImg > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    dt.Rows.Add(imgDt.Rows[i].ItemArray);
                }
            }
            else
            {
                for (int i = 0; i < numImg; i++)
                {
                    dt.Rows.Add(imgDt.Rows[i].ItemArray);
                }
            }

            //DataImg(imgDt);
            rptImg.DataSource = imgDt;
            rptImg.DataBind();
            rptList2.DataSource = dt;
            rptList2.DataBind();
        }

        ///// <summary>
        ///// 绑定图片列表
        ///// </summary>
        ///// <param name="dt"></param>
        //private void DataImg(DataTable dt)
        //{
        //    int i = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        i++;
        //        string strImg = dr["ImgUrl"].ToString();
        //        strImg = strImg.Replace("~/", "../../");
        //        lstImg.InnerHtml += " <div><a href='javascript:;'><img class='img-responsive' src='" + strImg + "' /></a></div>";
        //        position.InnerHtml += i != 1 ? "<li class=''></li>" : "<li class='cur'></li>";
        //    }
        //}
    }
}