using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
     /// <summary>
    /// 邮件配置信息
    /// </summary>
    [Serializable]
    public class MailConfig
    {
        public MailConfig() { }

        private string _mailTitle;  //邮件标题
        private string _registerActivateCallIndex = ""; //注册激活邮件
        private string _resetKeyCallIndex = ""; //重置密码邮件
        private string _welcomeMsgCallIndex = "";   //新用户注册欢迎邮件
        private string _auditCallIndex = "";    //审核通知邮件
        private string _identificationCallIndex = "";    //身份认证通知邮件

        public string MailTitle
        {
            get { return _mailTitle; }
            set { _mailTitle = value; }
        }

        public string RegisterActivateCallIndex
        {
            get { return _registerActivateCallIndex; }
            set { _registerActivateCallIndex = value; }
        }

        public string ResetKeyCallIndex
        {
            get { return _resetKeyCallIndex; }
            set { _resetKeyCallIndex = value; }
        }

        public string WelcomeMsgCallIndex
        {
            get { return _welcomeMsgCallIndex; }
            set { _welcomeMsgCallIndex = value; }
        }

        public string AuditCallIndex
        {
            get { return _auditCallIndex; }
            set { _auditCallIndex = value; }
        }

        public string IdentificationCallIndex
        {
            get { return _identificationCallIndex; }
            set { _identificationCallIndex = value; }
        }
    }
}
