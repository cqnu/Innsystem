using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class MailHelper
    {
        #region 发送电子邮件
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpServer">SMTP服务器</param>
        /// <param name="enableSSL">是否启用SSL加密</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人昵称</param>
        /// <param name="mailFrom">发件人</param>
        /// <param name="mailTo">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void sendMail(string smtpServer, int enableSSL, string userName, string pwd, string nickName, string mailFrom, string mailTo, string sub, string bodys)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpServer;//指定SMTP服务器
            string password = "tdbqtznezvzzbcfd";
            //_smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, password);//用户名和密码
            if (enableSSL == 1)
            {
                _smtpClient.EnableSsl = true;
            }

            MailAddress _from = new MailAddress(mailFrom, nickName);
            MailAddress _to = new MailAddress(mailTo);
            MailMessage _mailMessage = new MailMessage(_from, _to);
            _mailMessage.Subject = sub;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.Normal;//优先级
            _smtpClient.Send(_mailMessage);
        }
        #endregion
    }
}
