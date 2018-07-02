using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// ManageAjaxHandler 的摘要说明
    /// </summary>
    public class ManageAjaxHandler : IHttpHandler, IRequiresSessionState
    {

        SiteConfig siteConfig = new HN863Soft.ISS.BLL.SiteConfig().loadConfig(); //系统配置信息
        UserConfig userConfig = new HN863Soft.ISS.BLL.UserConfig().loadConfig(); //会员配置信息

        public void ProcessRequest(HttpContext context)
        {
            //检查管理员是否登录
            if (!new ManagePage().IsManageLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }
            //取得处事类型
            string action = RequestHelper.GetQueryString("action");
            switch (action)
            {
                case "username_validate": //验证用户名
                    username_validate(context);
                    break;
                //case "attribute_field_validate": //验证扩展字段是否重复
                //    attribute_field_validate(context);
                //    break;
                //case "channel_name_validate": //验证频道名称是否重复
                //    channel_name_validate(context);
                //    break;
                //case "channel_site_validate": //验证站点目录名是否重复
                //    channel_site_validate(context);
                //    break;
                //case "urlrewrite_name_validate": //验证URL调用名称是否重复
                //    urlrewrite_name_validate(context);
                //    break;
                case "navigation_validate": //验证导航菜单别名是否重复
                    navigation_validate(context);
                    break;
                case "manager_validate": //验证管理员用户名是否重复
                    manager_validate(context);
                    break;
                case "get_navigation_list": //获取后台导航字符串
                    get_navigation_list(context);
                    break;
                //case "get_remote_fileinfo": //获取远程文件的信息
                //    get_remote_fileinfo(context);
                //    break;
                //case "get_builder_urls": //获取要生成静态的地址
                //    get_builder_urls(context);
                //    break;
                //case "get_builder_html": //生成静态页面
                //    get_builder_html(context);
                //    break;
            }
        }

        #region 验证用户名是否可用============================
        private void username_validate(HttpContext context)
        {
            string username = RequestHelper.GetString("param");
            //如果为Null，退出
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{ \"info\":\"用户名不可为空\", \"status\":\"n\" }");
                return;
            }
            //过滤注册用户名字符
            string[] strArray = userConfig.regkeywords.Split(',');
            foreach (string s in strArray)
            {
                if (s.ToLower() == username.ToLower())
                {
                    context.Response.Write("{ \"info\":\"该用户名不可用\", \"status\":\"n\" }");
                    return;
                }
            }
            HN863Soft.ISS.BLL.Users bll = new HN863Soft.ISS.BLL.Users();
            //查询数据库
            if (!bll.Exists(username.Trim()))
            {
                context.Response.Write("{ \"info\":\"该用户名可用\", \"status\":\"y\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该用户名已被注册\", \"status\":\"n\" }");
            return;
        }
        #endregion

        //#region 验证扩展字段是否重复============================
        //private void attribute_field_validate(HttpContext context)
        //{
        //    string column_name = RequestHelper.GetString("param");
        //    if (string.IsNullOrEmpty(column_name))
        //    {
        //        context.Response.Write("{ \"info\":\"名称不可为空\", \"status\":\"n\" }");
        //        return;
        //    }
        //    HN863Soft.ISS.BLL.ArticleAttributeField bll = new HN863Soft.ISS.BLL.ArticleAttributeField();
        //    if (bll.Exists(column_name))
        //    {
        //        context.Response.Write("{ \"info\":\"该名称已被占用，请更换！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        //    return;
        //}
        //#endregion

        //#region 验证频道名称是否是否可用========================
        //private void channel_name_validate(HttpContext context)
        //{
        //    string channel_name = RequestHelper.GetString("param");
        //    string old_channel_name = RequestHelper.GetString("old_channel_name");
        //    if (string.IsNullOrEmpty(channel_name))
        //    {
        //        context.Response.Write("{ \"info\":\"频道名称不可为空！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    if (channel_name.ToLower() == old_channel_name.ToLower())
        //    {
        //        context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        //        return;
        //    }
        //    HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
        //    if (bll.Exists(channel_name))
        //    {
        //        context.Response.Write("{ \"info\":\"该名称已被占用，请更换！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        //    return;
        //}
        //#endregion

        //#region 验证站点目录名是否可用==========================
        //private void channel_site_validate(HttpContext context)
        //{
        //    string build_path = RequestHelper.GetString("param");
        //    string old_build_path = RequestHelper.GetString("old_build_path");
        //    if (string.IsNullOrEmpty(build_path))
        //    {
        //        context.Response.Write("{ \"info\":\"该目录名不可为空！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    if (build_path.ToLower() == old_build_path.ToLower())
        //    {
        //        context.Response.Write("{ \"info\":\"该目录名可使用\", \"status\":\"y\" }");
        //        return;
        //    }
        //    HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();
        //    if (bll.Exists(build_path))
        //    {
        //        context.Response.Write("{ \"info\":\"该目录名已被占用，请更换！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    context.Response.Write("{ \"info\":\"该目录名可使用\", \"status\":\"y\" }");
        //    return;
        //}
        //#endregion

        //#region 验证URL调用名称是否重复=========================
        //private void urlrewrite_name_validate(HttpContext context)
        //{
        //    string new_name = RequestHelper.GetString("param");
        //    string old_name = RequestHelper.GetString("old_name");
        //    if (string.IsNullOrEmpty(new_name))
        //    {
        //        context.Response.Write("{ \"info\":\"名称不可为空！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    if (new_name.ToLower() == old_name.ToLower())
        //    {
        //        context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        //        return;
        //    }
        //    HN863Soft.ISS.BLL.UrlRewrite bll = new HN863Soft.ISS.BLL.UrlRewrite();
        //    if (bll.Exists(new_name))
        //    {
        //        context.Response.Write("{ \"info\":\"该名称已被使用，请更换！\", \"status\":\"n\" }");
        //        return;
        //    }
        //    context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
        //    return;
        //}
        //#endregion

        #region 验证导航菜单别名是否重复========================
        private void navigation_validate(HttpContext context)
        {
            string navname = RequestHelper.GetString("param");
            string old_name = RequestHelper.GetString("old_name");
            if (string.IsNullOrEmpty(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (navname.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
                return;
            }
            //检查保留的名称开头
            if (navname.ToLower().StartsWith("channel_"))
            {
                context.Response.Write("{ \"info\":\"该导航别名系统保留，请更换！\", \"status\":\"n\" }");
                return;
            }
            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            if (bll.Exists(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证管理员用户名是否重复========================
        private void manager_validate(HttpContext context)
        {
            string userName = RequestHelper.GetString("param");
            if (string.IsNullOrEmpty(userName))
            {
                context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
                return;
            }
            HN863Soft.ISS.BLL.Manager bll = new HN863Soft.ISS.BLL.Manager();
            if (bll.Exists(userName))
            {
                context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            if (bll.ExistsReception(userName))
            {
                context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 获取后台导航字符串==============================
        private void get_navigation_list(HttpContext context)
        {
            Manager adminModel = new ManagePage().GetManageInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return;
            }
            ManagerRole roleModel = new HN863Soft.ISS.BLL.ManagerRole().GetModel(adminModel.RoleID); //获得管理角色信息
            if (roleModel == null)
            {
                return;
            }

            //获取角色类型列表
            List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
            DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
            if (dsManagerTypes != null)
            {
                for (int j = 0; j < dsManagerTypes.Tables[0].Rows.Count; j++)
                {
                    managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[j]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[j]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[j]["IsSys"].ToString()) });
                }
            }

            DataTable dt = new HN863Soft.ISS.BLL.Navigation().GetList(0, EnumsHelper.NavigationEnum.System.ToString());
            this.get_navigation_childs(context, dt, 0, roleModel.RoleType, roleModel.ManagerRoleValues,managerTypeList);

        }
        private void get_navigation_childs(HttpContext context, DataTable oldData, int parentID, int roleType, List<ManagerRoleValue> ls,List<HN863Soft.ISS.Model.ManagerType> managerTypeList)
        {
            DataRow[] dr = oldData.Select("ParentID=" + parentID);
            bool isWrite = false; //是否输出开始标签
            for (int i = 0; i < dr.Length; i++)
            {
                //检查是否显示在界面上====================
                bool isActionPass = true;
                if (int.Parse(dr[i]["IsLock"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //检查用户权限==========================
                if (isActionPass && roleType > 1)
                {
                    string[] actionTypeArr = dr[i]["ActionType"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        if (action_type_str == "Show")
                        {
                            var tempManagerType = managerTypeList.FirstOrDefault(x => x.ID == roleType);
                            if (tempManagerType != null)
                            {
                                if (tempManagerType.TypeName == "管理员")
                                { 
                                    isActionPass = true; 
                                }
                                else
                                {
                                    if (ls == null)
                                    {
                                        isActionPass = false;
                                    }
                                    else
                                    {
                                        ManagerRoleValue modelt = ls.Find(p => p.NavName == dr[i]["Name"].ToString() && p.ActionType == "Show");
                                        if (modelt == null)
                                        {
                                            isActionPass = false;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
                //如果没有该权限则不显示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Length - 1) && parentID > 0)
                    {
                        context.Response.Write("</ul>\n");
                    }
                    continue;
                }
                //如果是顶级导航
                if (parentID == 0)
                {
                    context.Response.Write("<div class=\"list-group\">\n");
                    context.Response.Write("<h1 title=\"" + dr[i]["SubTitle"].ToString() + "\">");
                    if (!string.IsNullOrEmpty(dr[i]["IconUrl"].ToString().Trim()))
                    {
                        context.Response.Write("<img src=\"" + dr[i]["IconUrl"].ToString() + "\" />");
                    }
                    context.Response.Write("</h1>\n");
                    context.Response.Write("<div class=\"list-wrap\">\n");
                    context.Response.Write("<h2>" + dr[i]["Title"].ToString() + "<i></i></h2>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["ID"].ToString()), roleType, ls,managerTypeList);
                    context.Response.Write("</div>\n");
                    context.Response.Write("</div>\n");
                }
                else //下级导航
                {
                    if (!isWrite)
                    {
                        isWrite = true;
                        context.Response.Write("<ul>\n");
                    }
                    context.Response.Write("<li>\n");
                    context.Response.Write("<a navid=\"" + dr[i]["Name"].ToString() + "\"");
                    if (!string.IsNullOrEmpty(dr[i]["LinkUrl"].ToString()))
                    {
                        if (int.Parse(dr[i]["ChannelID"].ToString()) > 0)
                        {
                            context.Response.Write(" href=\"" + dr[i]["LinkUrl"].ToString() + "?ChannelID=" + dr[i]["ChannelID"].ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            context.Response.Write(" href=\"" + dr[i]["LinkUrl"].ToString() + "\" target=\"mainframe\"");
                        }
                    }
                    if (!string.IsNullOrEmpty(dr[i]["IconUrl"].ToString()))
                    {
                        context.Response.Write(" icon=\"" + dr[i]["IconUrl"].ToString() + "\"");
                    }
                    context.Response.Write(" target=\"mainframe\">\n");
                    context.Response.Write("<span>" + dr[i]["Title"].ToString() + "</span>\n");
                    context.Response.Write("</a>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["ID"].ToString()), roleType, ls,managerTypeList);
                    context.Response.Write("</li>\n");

                    if (i == (dr.Length - 1))
                    {
                        context.Response.Write("</ul>\n");
                    }
                }
            }
        }
        #endregion

        //#region 获取远程文件的信息==============================
        //private void get_remote_fileinfo(HttpContext context)
        //{
        //    string filePath = RequestHelper.GetFormString("remotepath");
        //    if (string.IsNullOrEmpty(filePath))
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"没有找到远程附件地址！\"}");
        //        return;
        //    }
        //    if (!filePath.ToLower().StartsWith("http://"))
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"不是远程附件地址！\"}");
        //        return;
        //    }
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filePath);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        int fileSize = (int)response.ContentLength;
        //        string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
        //        string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
        //        context.Response.Write("{\"status\": 1, \"msg\": \"获取远程文件成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
        //    }
        //    catch
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"远程文件不存在！\"}");
        //        return;
        //    }
        //}
        //#endregion

        //#region 获取要生成静态的地址============================
        //private void get_builder_urls(HttpContext context)
        //{
        //    int state = get_builder_status();
        //    if (state == 1)
        //        new HtmlBuilder().getpublishsite(context);
        //    else
        //        context.Response.Write(state);
        //}
        //#endregion

        //#region 生成静态页面====================================
        //private void get_builder_html(HttpContext context)
        //{
        //    int state = get_builder_status();
        //    if (state == 1)
        //        new HtmlBuilder().handleHtml(context);
        //    else
        //        context.Response.Write(state);


        //}
        //#endregion

        #region 判断是否登陆以及是否开启静态====================
        private int get_builder_status()
        {
            //取得用户登录信息
            Manager adminInfo = new ManagePage().GetManageInfo();
            if (adminInfo == null)
                return -1;
            else if (!new HN863Soft.ISS.BLL.ManagerRole().Exists(adminInfo.RoleID, "sys_builder_html", EnumsHelper.ActionEnum.Build.ToString()))
                return -2;
            else if (siteConfig.staticstatus != 2)
                return -3;
            else
                return 1;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}