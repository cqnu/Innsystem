using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// DownloadHandler 的摘要说明
    /// </summary>
    public class DownloadHandler : IHttpHandler, IRequiresSessionState
    {
        SiteConfig siteConfig = new HN863Soft.ISS.BLL.SiteConfig().loadConfig(); //系统配置
        public void ProcessRequest(HttpContext context)
        {
            string sitepath = RequestHelper.GetQueryString("site");
            int id = RequestHelper.GetQueryInt("id");
            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("出错了，站点传输参数不正确！");
                return;
            }
            //获得下载ID
            if (id < 1)
            {
                context.Response.Redirect(new BasePage().getlink(sitepath,
                    new BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("出错了，文件参数传值不正确！"))));
                return;
            }
            //检查下载记录是否存在
            HN863Soft.ISS.BLL.ArticleAttach bll = new HN863Soft.ISS.BLL.ArticleAttach();
            if (!bll.Exists(id))
            {
                context.Response.Redirect(new BasePage().getlink(sitepath,
                    new BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您要下载的文件不存在或已经被删除！"))));
                return;
            }
            ArticleAttach model = bll.GetModel(id);
            //检查积分是否足够
            if (model.Point > 0)
            {
                //检查用户是否登录
                Users userModel = new BasePage().GetUserInfo();
                if (userModel == null)
                {
                    //自动跳转URL
                    HttpContext.Current.Response.Redirect(new BasePage().getlink(sitepath, new BasePage().linkurl("login")));
                }
            }
            //下载次数+1
            bll.UpdateField(id, "DownNum=DownNum+1");
            //检查文件本地还是远程
            if (model.FilePath.ToLower().StartsWith("http://"))
            {
                context.Response.Redirect(model.FilePath);
                return;
            }
            else
            {
                //取得文件物理路径
                string fullFileName = Utils.GetMapPath(model.FilePath);
                if (!File.Exists(fullFileName))
                {
                    context.Response.Redirect(new BasePage().getlink(sitepath,
                        new BasePage().linkurl("error", "?msg=" + Utils.UrlEncode("出错了，您要下载的文件不存在或已经被删除！"))));
                    return;
                }
                FileInfo file = new FileInfo(fullFileName);//路径
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(model.FileName)); //解决中文文件名乱码    
                context.Response.AddHeader("Content-length", file.Length.ToString());
                context.Response.ContentType = "application/pdf";
                context.Response.WriteFile(file.FullName);
                context.Response.End();
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