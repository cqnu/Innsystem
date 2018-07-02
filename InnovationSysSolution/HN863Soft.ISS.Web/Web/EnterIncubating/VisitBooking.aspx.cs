using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.BLL;
using HN863Soft.ISS.Model;
//**************************
//* 文件名：VisitBooking.cs
//* 作者：雷登辉
//* 功能：参观预约信息添加
//* 创建时间 ：2017/3/6
//**************************
namespace HN863Soft.ISS.Web.Web.EnterIncubating
{
    public partial class VisitBooking : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request["Id"]);
                txtinput.Value = id.ToString();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.VisitBooking visBookingModel = new Model.VisitBooking
            {
                CreateTime = DateTime.Now,
                EId = 3,//孵化器Id
                Creator = 1,//用户Id
                Email = txtEmail.Text.Trim(),
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                VisitDate=Convert.ToDateTime(txtVisDate.Text),//来访日期
                VisitNum = Convert.ToInt32(txtNum.Text)
            };
            BLL.VisitBooking visBookingBll = new BLL.VisitBooking();
            if (visBookingModel != null)
            {
                if (visBookingBll.Add(visBookingModel) == -1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "submitForm();", true);
                    return;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Succes", "submitForm();", true);
            }
        }
    }
}