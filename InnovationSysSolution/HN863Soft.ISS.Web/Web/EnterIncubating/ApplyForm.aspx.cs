using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//**************************
//* 文件名：ApplyForm.cs
//* 作者：雷登辉
//* 功能：入孵申请
//* 创建时间 ：2017/3/6
//**************************
namespace HN863Soft.ISS.Web.Web.EnterIncubating
{
    public partial class ApplyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["Id"]);
                txtinput.Value = id.ToString();
            }
        }
    }
}