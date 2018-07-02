using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _863soft.ISS.Web.Core
{
    public class RequestSession
    {
        private static string SESSION_USER = "SESSION_USER";

        public static string LOGIN_USER = "loginUser";

        public static void AddSessionUser(SessionUser user)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[RequestSession.SESSION_USER] = user;
        }

        public static SessionUser GetSessionUser()
        {
            HttpContext rq = HttpContext.Current;
            return (SessionUser)rq.Session[RequestSession.SESSION_USER];
        }

        public static SessionUser GetLoginUser()
        {
            SessionUser user = null;
            HttpContext rq = HttpContext.Current;
            user = rq.Session[RequestSession.LOGIN_USER] as SessionUser;
            return user;
        }
    }
}
