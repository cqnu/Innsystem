using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _863soft.ISS.Web.Core
{
    public class SessionUser
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public string UserAccount { get; set; }
        public string UserOAID { get; set; }

        public SessionUser(string userId, string userAccount, string userPwd, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserPwd = userPwd;
            this.UserAccount = UserAccount;
        }

        public SessionUser(string userId, string userAccount, string userPwd, string userName, string userOAID)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserPwd = userPwd;
            this.UserAccount = UserAccount;
            this.UserOAID = userOAID;
        }

        public SessionUser()
        {
        }
    }
}
