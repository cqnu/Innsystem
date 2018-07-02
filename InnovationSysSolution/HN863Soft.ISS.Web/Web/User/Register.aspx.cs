using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*****************************
//* 文件名：Register.cs
//* 作者： 雷登辉
//* 功能：普通用户、会员用户账号注册
//* 创建时间：2017/2/18
//*****************************
namespace HN863Soft.ISS.Web.User
{
    public partial class Register : System.Web.UI.Page
    {
        #region 函数

        HN863Soft.ISS.BLL.Manager manager;//管理员对象
        HN863Soft.ISS.BLL.Users users;//普通用户对象

        #endregion

        #region 方法

        /// <summary>
        /// 页面初始化绑定数据
        /// </summary>
        private void InitBindData()
        {
            ddlRoleType.DataTextField = "RoleName";//绑定显示字段“角色名称”
            ddlRoleType.DataValueField = "RoleType";//绑定管理员类型
            HN863Soft.ISS.BLL.ManagerRole roleList = new HN863Soft.ISS.BLL.ManagerRole();
            ddlRoleType.DataSource = roleList.GetList("");//绑定数据列表
            ddlRoleType.DataBind();
        }

        ///// <summary>
        ///// 随机生成6位字符串
        ///// </summary>
        ///// <returns></returns>
        //private string GenerateChar()
        //{
        //    Random rd = new Random();
        //    string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    string result = "";
        //    for (int i = 0; i < 6; i++)
        //    {
        //        result += str[rd.Next(str.Length)];
        //    }
        //    return result;
        //}

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
                InitBindData();
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
            int result = 0;
            //string str = GenerateChar();//随机字符串长度6位
            manager = new HN863Soft.ISS.BLL.Manager();//实例化管理员对象
            users = new HN863Soft.ISS.BLL.Users();//实例化普通用户对象
            string strSalt=HN863Soft.ISS.Common.Utils.GetCheckCode(6);//随机生成的字符串key
            string decPassWord = HN863Soft.ISS.Common.EncryptionHelper.Encrypt(txtPassWordChar.Text.Trim(), strSalt);//密码加密并赋值给“decPassWord”

            int mRowsNum = manager.GetList("UserName='" + txtUserName.Text.Trim() + "'").Tables[0].Rows.Count;//查询是否存在该账户
            int uRowsNum = users.GetList("UserName='" + txtUserName.Text.Trim() + "'").Tables[0].Rows.Count;//查询是否存在该账户
            //判断用户名是否存在
            if (mRowsNum > 0 || uRowsNum > 0)
            {
                txtUserName.Text = string.Empty;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('用户名已存在！')", true);
                return;
            }
            
            //选择组织：“0”或者个人：“1”
            if (rblUserType.SelectedValue == "0")
            {
                HN863Soft.ISS.Model.Manager managerModel = new HN863Soft.ISS.Model.Manager//实例化管理员对象并赋值
                {
                    UserName = txtUserName.Text.Trim(),//用户名
                    Password = decPassWord,//密码
                    Email = txtEMail.Text.Trim(),//邮箱
                    IsLock = 0,//是否上锁：0：否；1：是.
                    RealName = txtRealName.Text.Trim(),//真实姓名
                    RoleID = 1,//角色类型Id
                    RoleType = 2,//角色类型
                    Telephone = txtPhone.Text.Trim(),//联系电话
                    CreateTime = DateTime.Now,//创建时间
                    Salt = strSalt//7位随机字符串,加密用到
                };

                //DateTime dt = DateTime.ParseExact(date1.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);//转为日期类型
                HN863Soft.ISS.Model.Users userModel = new HN863Soft.ISS.Model.Users//实例化普通用户对象并赋值
                {
                    //Address = txtAddress.Text.Trim(),//地址
                    ////Amount=,//账户余额
                    //Area = txtArea.Text.Trim(),//区域
                    //Avatar=,//用户头像
                    Birthday = DateTime.Now,//出生日期
                    Email = txtEMail.Text.Trim(),//邮箱
                    Exp = 0,//升级经验
                    //GroupID=,//用户组ID
                    //Mobile=,//手机号码
                    Msn = txtMSN.Text.Trim(),//msn
                    NickName = txtRealName.Text.Trim(),//昵称
                    Password = decPassWord,//密码
                    Point = 0,//账户积分
                    //QQ = txtQQ.Text.Trim(),//QQ号码
                    RegIP = System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString(),//注册Ip
                    RegTime = DateTime.Now,//注册时间
                    Salt = strSalt,//随机字符串
                    //Sex = rblSex.SelectedValue == "0" ? "男" : "女",
                    Status = 0,//账户状态,0正常,1待验证,2待审核,3锁定
                    Telphone = txtPhone.Text.Trim(),//电话
                    UserName = txtUserName.Text.Trim(),//账号
                };

                result = users.Add(userModel,managerModel);//添加
              
            }
            else
            {
                DateTime dt = DateTime.ParseExact(date1.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);//转为日期类型
                HN863Soft.ISS.Model.Users userModel = new HN863Soft.ISS.Model.Users//实例化普通用户对象并赋值
                {
                    Address = txtAddress.Text.Trim(),//地址
                    //Amount=,//账户余额
                    Area = txtArea.Text.Trim(),//区域
                    //Avatar=,//用户头像
                    Birthday = dt,//出生日期
                    Email = txtEMail.Text.Trim(),//邮箱
                    Exp=0,//升级经验
                    //GroupID=,//用户组ID
                    //Mobile=,//手机号码
                    Msn = txtMSN.Text.Trim(),//msn
                    NickName = txtNickName.Text.Trim(),//昵称
                    Password = decPassWord,//密码
                    Point=0,//账户积分
                    QQ = txtQQ.Text.Trim(),//QQ号码
                    RegIP = System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString(),//注册Ip
                    RegTime=DateTime.Now,//注册时间
                    Salt = strSalt,//随机字符串
                    Sex = rblSex.SelectedValue == "0" ? "男" : "女",
                    Status=0,//账户状态,0正常,1待验证,2待审核,3锁定
                    Telphone = txtPhone.Text.Trim(),//电话
                    UserName = txtUserName.Text.Trim(),//账号
                };
                result = users.Add(userModel);//添加
            }
            //添加是否异常
            if (result == -1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('注册异常！')", true);
                return;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('注册成功！');window.location.href='Login.aspx'", true);//注册成功

        }
        #endregion
    }
}