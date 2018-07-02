using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//****************************
//* 文件名： Login.cs
//* 作者： 雷登辉
//* 功能：前台登录界面
//* 创建时间：2017/2/17
//****************************
namespace HN863Soft.ISS.Web.User
{
    public partial class Login : System.Web.UI.Page
    {
        //HN863Soft.ISS.Common.KeyHandle keyHandle;//实例化密匙处理对象
        //HN863Soft.ISS.BLL.Manager managerBll;//实例化管理员处理对象
        HN863Soft.ISS.BLL.Users userBll;//实例化普通用户对象

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
            string userId = txtUserId.Text.Trim();//用户名
            string passWord = txtPassWord.Text.Trim();//密码
            //managerBll = new BLL.Manager();
            userBll = new BLL.Users();
            DataTable userDt = userBll.GetList("UserName='" + userId + "'").Tables[0];
            //DataTable managerDt = managerBll.GetList("UserName='" + userId + "'").Tables[0];
            //是否有该用户信息 managerDt.Rows.Count == 0 &&
            if ( userDt.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('没有该用户')", true);
                return;
            }
            DataRow userDr = userDt.Rows[0];
            //DataRow dr = managerDt.Rows[0];
            //解密并判断密码是否相同
            string strSalt = Convert.ToString(userDr["Salt"]);//随机key
            string strDes = Convert.ToString(userDr["Password"]);//密匙
            string strPassWord = HN863Soft.ISS.Common.EncryptionHelper.Decrypt(strDes, strSalt);
            if (strPassWord == passWord)
            {
                //写入Cookies
                Utils.WriteCookie("RememberName", userId, 14400);
                Utils.WriteCookie("manageName", "ISS", userId);
                Utils.WriteCookie("managePwd", "ISS", strDes);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('登陆成功')", true);
            }
        }
    }
}