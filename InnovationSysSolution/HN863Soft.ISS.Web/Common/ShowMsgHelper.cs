using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HN863Soft.ISS.Web.Common
{
    public class ShowMsgHelper
    {
        public static void Alert(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showTipsMsg('{0}','2500','4');", message));
        }

        public static void AlertMsg(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("parent.showTipsMsg('{0}','2500','4');parent.windowload();OpenClose();", message));
        }

        public static void ParmAlertMsg(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showTipsMsg('{0}','2500','4');parent.windowload();OpenClose();", message));
        }

        public static void Alert_Error(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showTipsMsg('{0}','5000','5');", message));
        }

        public static void Alert_Wern(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showTipsMsg('{0}','3000','3');", message));
        }

        public static void showFaceMsg(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showFaceMsg('{0}');", message));
        }

        public static void showWarningMsg(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showWarningMsg('{0}');", message));
        }

        public static void ShowScript(string strobj)
        {
            Page p = HttpContext.Current.Handler as Page;
            p.ClientScript.RegisterStartupScript(p.ClientScript.GetType(), Guid.NewGuid().ToString(), "<script>" + strobj + "</script>");
        }

        public static void ExecuteScript(string scriptBody)
        {
            Page p = HttpContext.Current.Handler as Page;
            p.ClientScript.RegisterStartupScript(typeof(string), Guid.NewGuid().ToString(), scriptBody, true);
        }

        public static void ShowFaceMsgAndCloseWindow(string message)
        {
            ShowMsgHelper.ExecuteScript(string.Format("showTipsMsg('{0}','2500','4');setTimeout(OpenClose, 2500);", message));
        }
    }
}