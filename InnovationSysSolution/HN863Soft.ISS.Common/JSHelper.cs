using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class JSHelper
    {
        public static string GetJSAlertStr(string alertMessage)
        {
            return "<script language=\"javascript\" type=\"text/javascript\">alert(\"" + alertMessage + "\");</script>";
        }

        public static string GetJSStr(string jsContent)
        {
            return "<script language=\"javascript\" type=\"text/javascript\">" + jsContent + "</script>";
        }
    }
}
