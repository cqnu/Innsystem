using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// Regist 的摘要说明
    /// </summary>
    public class Regist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            string password = context.Request["password"];
            string email = context.Request["email"];
            string company = context.Request["company"];
            string type = context.Request["type"];
            string strSalt = HN863Soft.ISS.Common.Utils.GetCheckCode(6);//随机生成的字符串key
            string decPassWord = HN863Soft.ISS.Common.EncryptionHelper.Encrypt(password, strSalt);//密码加密并赋值给“decPassWord”
            int result = 0;

            HN863Soft.ISS.BLL.Users users = new BLL.Users();
            if (type == "1")
            {
                HN863Soft.ISS.Model.Manager managerModel = new HN863Soft.ISS.Model.Manager();//实例化管理员对象并赋值
                //{
                    managerModel.UserName = name;//用户名
                    managerModel.Password = decPassWord;//密码
                    managerModel.Email = email;//邮箱
                    managerModel.IsLock = 0;//是否上锁：0：否；1：是.
                    managerModel.RealName = company;//真实姓名
                    managerModel.RoleType = int.Parse(users.RowTypeId("待认证").Tables[0].Rows[0]["ID"].ToString());//角色类型Id

                    managerModel.RoleID = int.Parse(users.RowId( managerModel.RoleType).Tables[0].Rows[0]["ID"].ToString());//角色类型Id

                   
                    //RoleType = 4,//角色类型
                    //Telephone = txtPhone.Text.Trim(),//联系电话
                    managerModel.CreateTime = DateTime.Now;//创建时间
                    managerModel.Salt = strSalt;//7位随机字符串,加密用到
                //};

                //DateTime dt = DateTime.ParseExact(date1.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);//转为日期类型
                HN863Soft.ISS.Model.Users userModel = new HN863Soft.ISS.Model.Users//实例化普通用户对象并赋值
                {
                    //Address = txtAddress.Text.Trim(),//地址
                    Amount = 0,//账户余额
                    //Area = txtArea.Text.Trim(),//区域
                    //Avatar=,//用户头像
                    Birthday = DateTime.Now,
                    Email = email,//邮箱
                    Exp = 0,//升级经验
                    //GroupID=,//用户组ID
                    //Mobile=,//手机号码

                    NickName = company,//昵称
                    Password = decPassWord,//密码
                    Point = 0,//账户积分

                    RegIP = System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString(),//注册Ip
                    RegTime = DateTime.Now,//注册时间
                    Salt = strSalt,//随机字符串

                    Status = 0,//账户状态,0正常,1待验证,2待审核,3锁定
                    //Telphone = txtPhone.Text.Trim(),//电话
                    UserName = name,//账号
                };

                result = users.Add(userModel, managerModel);//添加


            }
            else
            {

                HN863Soft.ISS.Model.Users userModel = new HN863Soft.ISS.Model.Users//实例化普通用户对象并赋值
                {

                    //Address = txtAddress.Text.Trim(),//地址
                    Amount = 0,//账户余额
                    //Area = txtArea.Text.Trim(),//区域
                    //Avatar=,//用户头像
                    Birthday = DateTime.Now,
                    Email = email,//邮箱
                    Exp = 0,//升级经验
                    //GroupID=,//用户组ID
                    //Mobile=,//手机号码

                    NickName = company,//昵称
                    Password = decPassWord,//密码
                    Point = 0,//账户积分

                    RegIP = System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString(),//注册Ip
                    RegTime = DateTime.Now,//注册时间
                    Salt = strSalt,//随机字符串

                    Status = 0,//账户状态,0正常,1待验证,2待审核,3锁定
                    //Telphone = txtPhone.Text.Trim(),//电话
                    UserName = name,//账号
                };
                result = users.Add(userModel);//添加
            }

            Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig();
            if (result > 0)
            {
                Model.MailTemplate mailModel = new BLL.MailTemplate().GetModel("RegisterActivateNotice");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.MaillTitle;
                    mailTitle = mailTitle.Replace("{username}", name);
                    string mailContent = mailModel.Content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);

                    mailContent = mailContent.Replace("{username}", name);

                    string url = EncryptionHelper.Encrypt("&name=" + name + "&type=" + type);
                    HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
                    var model = bll.loadConfig();


                    mailContent = mailContent.Replace("{linkurl}", model.weburl+"/WebService/Activation.ashx?activation=register" + url);
                    mailContent = mailContent.Replace("{valid}", "30");
                    //发送邮件
                    //MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                    //    siteConfig.emailfrom, model.Email, mailTitle, mailContent);

                    MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailusername, "@wbcWBC_34@", siteConfig.emailnickname,
                       siteConfig.emailfrom, email, mailTitle, mailContent);
                }
            }

            context.Response.Write(result.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}