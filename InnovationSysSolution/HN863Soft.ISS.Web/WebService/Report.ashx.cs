using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// Report 的摘要说明
    /// </summary>
    public class Report : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strType = RequestHelper.GetQueryString("state");

            if (strType == "0")
            {
                Repor(context);
            }
            if (strType == "1")
            {
                ProcessingReport(context);
            }
            if (strType == "2")
            {
                PushMessage(context);
            }
            if (strType == "3")
            {
                JoinPromotion(context);
            }
            if (strType == "4")
            {
                CancelPromotion(context);
            }
        }

        public void Repor(HttpContext context)
        {

            string reason = context.Request["reason"];
            string url = context.Request["url"];
            string title = context.Request["title"];

            if (context.Session[KeysHelper.ForegroundUser] != null)
            {
                Users model = new Users();
                model = context.Session[KeysHelper.ForegroundUser] as Users;

                HN863Soft.ISS.Model.Report rModel = new Model.Report();
                rModel.uId = model.ID;
                rModel.Titile = title;
                rModel.Url = url;
                rModel.Reason = reason;
                rModel.Time = System.DateTime.Now;
                rModel.State = 0;
                HN863Soft.ISS.BLL.ReportBll bll = new BLL.ReportBll();
                int r = bll.Add(rModel);

                if (r > 0)
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }

            }


        }

        public void ProcessingReport(HttpContext context)
        {

            string state = context.Request["ustate"];
            string url = context.Request["url"];
            string table = context.Request["table"];
            string id = context.Request["id"];
            HN863Soft.ISS.Model.Report Model = new Model.Report();
            HN863Soft.ISS.BLL.ReportBll bll = new BLL.ReportBll();

            Model.State = int.Parse(state);
            Model.Url = url;

            if (bll.UpdateState(Model, table, int.Parse(id)) > 0)
            {
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }

        }

        public void PushMessage(HttpContext context)
        {
            HN863Soft.ISS.BLL.ReportBll bll = new BLL.ReportBll();
            context.Response.Write(GetJsonByDataset(bll.GetMessageInfo()));


        }

        public void JoinPromotion(HttpContext context)
        {
            HN863Soft.ISS.Web.Core.ManagePage m = new Core.ManagePage();
            if (m.ChkManageType())
            {

                string url = context.Request["url"];
                string title = context.Request["title"];

                HN863Soft.ISS.BLL.ReportBll bll = new BLL.ReportBll();

                if (bll.AddExtension(title,url) > 0)
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }

            }
            else
            {
                context.Response.Write("0");
            }
        }

        public void CancelPromotion(HttpContext context)
        {
            HN863Soft.ISS.Web.Core.ManagePage m = new Core.ManagePage();
            if (m.ChkManageType())
            {

                string url = context.Request["url"];

                HN863Soft.ISS.BLL.ReportBll bll = new BLL.ReportBll();

                if (bll.DelExtension(url))
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }

            }
            else
            {
                context.Response.Write("0");
            }
        }


        public static string GetJsonByDataset(DataSet ds)
        {
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                //如果查询到的数据为空则返回标记ok:false
                return "{\"ok\":false}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"ok\":" + "true" + ",");
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(string.Format("\"{0}\":[", dt.TableName));

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\",", dr.Table.Columns[i].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'"), ObjToStr(dr[i]).Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("},");
                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("],");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("}");
            return sb.ToString();
        }

        public static string ObjToStr(object ob)
        {
            if (ob == null)
            {
                return string.Empty;
            }
            else
                return ob.ToString();
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