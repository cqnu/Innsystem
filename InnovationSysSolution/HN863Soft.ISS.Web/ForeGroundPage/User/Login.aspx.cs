using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//****************************
//*文件名：Login.cs
//*作者：雷登辉
//*功能：用户登录
//*创建日期：2017/2/14
//****************************
namespace HN863Soft.ISS.Web.ForeGroundPage.User
{
    public partial class Login : System.Web.UI.Page
    {

        /// <summary>
        /// 画面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string passWord = txtPassWord.Text.Trim();//密码
            string userId = txtUserId.Text.Trim();//用户名
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('成功');window.location.href='Register.aspx'", true);
        }

    }
}