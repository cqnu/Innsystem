using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// UpdateHandler 的摘要说明
    /// </summary>
    public class UpdateHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request.Form["id"];//主键id
            string state = context.Request.Form["state"];//状态 1：通过 2：拒绝
            string Describe = context.Request.Form["Describe"];//原因
            string TableName = context.Request.Form["TableName"];//表名
            string PageName = context.Request.Form["PageName"];//页面名称 写Log
            HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();

            if (bll.UpdateState(int.Parse(id), int.Parse(state), Describe, TableName))
            {

                //ManagePage m = new ManagePage();


                //m.AddManageLog(EnumsHelper.ActionEnum.Audit.ToString(), "审核" + PageName); //记录日志

                context.Response.Write("审核成功！");

            }
            else
            {
                context.Response.Write("审核失败！");
            }
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