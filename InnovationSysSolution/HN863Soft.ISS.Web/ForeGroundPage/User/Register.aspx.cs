using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System.Web.UI.WebControls;
//*****************************
//* 文件名：Register.cs
//* 作者：雷登辉
//* 功能：用户分类注册
//* 创建日期：2017/2/14 
//* ***************************
namespace HN863Soft.ISS.Web.ForeGroundPage.User
{
    public partial class Register : Page
    {
        #region 方法

        /// <summary>
        /// 页面初始化绑定数据
        /// </summary>
        private void InitBindData()
        {
            ddlRoleType.DataTextField = "RoleName";
            ddlRoleType.DataValueField = "RoleType";
            //ddlRoleType.DataSource=
        }
        
        #endregion

        #region 事件
        /// <summary>
        /// 画面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        /// <summary>
        /// 用户类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Page_Load(sender, e);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string decPassWord = KeyHandle.Decrypt(txtPassWordChar.Text.Trim());//加密并赋值给“decPassWord”
            //选择组织：“0”或者个人：“1”
            if (rblUserType.SelectedValue == "0")
            {
                Manager manager = new Manager//实例化管理员对象并赋值
                {
                    UserName = txtUserName.Text.Trim(),//用户名
                    //Password = decPassWord,//密码
                    Email = txtEMail.Text.Trim(),//邮箱
                    IsLock = 0,//是否上锁：0：否；1：是.
                    RealName = txtRealName.Text.Trim(),//真实姓名
                    RoleID = 1,//角色类型Id
                    RoleType = 2,//角色类型
                    Telephone = txtPhone.Text.Trim(),//联系电话
                    CreateTime = DateTime.Now,//创建时间
                     //Salt=//6位随机字符串,加密用到
                };
            }
            else
            {
                Users user = new Users//实例化普通用户对象并赋值
                {
                    Address = txtAddress.Text.Trim(),//地址
                    //Amount=,//账户余额
                    Area = txtArea.Text.Trim(),//区域
                    //Avatar=,//用户头像
                    //Birthday=,//出生日期
                    Email = txtEMail.Text.Trim(),//邮箱
                    //Exp=,//升级经验
                    //GroupID=,//用户组ID
                    //Mobile=,//手机号码
                    Msn = txtMSN.Text.Trim(),//msn
                    NickName = txtNickName.Text.Trim(),//昵称
                    //Password = decPassWord,//密码
                    //Point=,//账户积分
                    QQ = txtQQ.Text.Trim(),//QQ号码
                    RegIP=System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString(),//注册Ip
                    //RegTime=,//注册时间
                    //Salt=,//6位随机字符串
                    Sex = rblSex.SelectedValue == "0" ? "男" : "女",
                    //Status=,//账户状态,0正常,1待验证,2待审核,3锁定
                    Telphone = txtPhone.Text.Trim(),//电话
                    UserName = txtUserName.Text.Trim(),//账号
                };
            }

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('注册成功！')", true);//注册成功

        } 
        #endregion
    }
}