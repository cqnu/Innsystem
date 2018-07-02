using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// SubmitAjaxHandler 的摘要说明
    /// </summary>
    public class SubmitAjaxHandler : IHttpHandler, IRequiresSessionState
    {
        SiteConfig siteConfig = new HN863Soft.ISS.BLL.SiteConfig().loadConfig();
        UserConfig userConfig = new HN863Soft.ISS.BLL.UserConfig().loadConfig();

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = RequestHelper.GetQueryString("action");

            switch (action)
            {
                //case "comment_add": //提交评论
                //    comment_add(context);
                //    break;
                //case "comment_list": //评论列表
                //    comment_list(context);
                //    break;
                case "validate_username": //验证用户名
                    validate_username(context);
                    break;
                case "user_login": //用户登录
                    user_login(context);
                    break;
                case "user_check_login": //检查用户是否登录
                    user_check_login(context);
                    break;
                case "user_register": //用户注册
                    user_register(context);
                    break;
                case "user_verify_email": //发送注册验证邮件
                    user_verify_email(context);
                    break;
                case "user_info_edit": //修改用户资料
                    user_info_edit(context);
                    break;
                case "user_avatar_crop": //确认裁剪用户头像
                    user_avatar_crop(context);
                    break;
                case "user_password_edit": //修改密码
                    user_password_edit(context);
                    break;
                case "user_getpassword": //用户取回密码
                    user_getpassword(context);
                    break;
                case "user_repassword": //用户重设密码
                    user_repassword(context);
                    break;
                //case "user_invite_code": //申请邀请码
                //    user_invite_code(context);
                //    break;
                //case "user_point_convert": //用户兑换积分
                //    user_point_convert(context);
                //    break;
                //case "user_message_add": //发布站内短消息
                //    user_message_add(context);
                //    break;
                //case "view_article_click": //统计及输出阅读次数
                //    view_article_click(context);
                //    break;
                //case "view_comment_count": //输出评论总数
                //    view_comment_count(context);
                //    break;
                //case "view_attach_count": //输出附件下载总数
                //    view_attach_count(context);
                //    break;
                case "VisitBookingSubmit":
                    VisitBookingSubmit(context);//参观预约提交申请
                    break;
                case "RepplySubmit":
                    RepplySubmit(context);//商业计划书上传
                    break;
                case "RepplySubmits":
                    RepplySubmits(context);//入孵预约提交申请
                    break;
                case "UploadImg":
                    UploadImg(context);
                    break;
            }
        }

        //#region 提交评论的处理方法===========================
        //private void comment_add(HttpContext context)
        //{
        //    StringBuilder strTxt = new StringBuilder();
        //    HN863Soft.ISS.BLL.ArticleComment bll = new HN863Soft.ISS.BLL.ArticleComment();
        //    ArticleComment model = new ArticleComment();

        //    string code = RequestHelper.GetFormString("txtcode");
        //    int articleID = RequestHelper.GetQueryInt("articleid");
        //    string content = RequestHelper.GetFormString("txtcontent");
        //    //校检验证码
        //    string result = verify_code(context, code);
        //    if (result != "success")
        //    {
        //        context.Response.Write(result);
        //        return;
        //    }
        //    if (articleID == 0)
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"对不起，参数传输有误！\"}");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(content))
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入评论的内容！\"}");
        //        return;
        //    }
        //    //检查该文章是否存在
        //    Article artModel = new HN863Soft.ISS.BLL.Article().GetModel(articleID);
        //    if (artModel == null)
        //    {
        //        context.Response.Write("{\"status\": 0, \"msg\": \"对不起，主题不存在或已删除！\"}");
        //        return;
        //    }
        //    //检查用户是否登录
        //    int user_id = 0;
        //    string userName = "匿名用户";
        //    Users userModel = new BasePage().GetUserInfo();
        //    if (userModel != null)
        //    {
        //        user_id = userModel.ID;
        //        userName = userModel.UserName;
        //    }
        //    model.ChannelID = artModel.ChannelID;
        //    model.ArticleID = artModel.ID;
        //    model.Content = Utils.ToHtml(content);
        //    model.UserID = user_id;
        //    model.UserName = userName;
        //    model.UserIP = RequestHelper.GetIP();
        //    model.IsLock = siteConfig.commentstatus; //审核开关
        //    model.CreateTime = DateTime.Now;
        //    model.IsReply = 0;
        //    if (bll.Add(model) > 0)
        //    {
        //        context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，留言提交成功！\"}");
        //        return;
        //    }
        //    context.Response.Write("{\"status\": 0, \"msg\": \"对不起，保存过程中发生错误！\"}");
        //    return;
        //}
        //#endregion

        //#region 取得评论列表方法=============================
        //private void comment_list(HttpContext context)
        //{
        //    int article_id = RequestHelper.GetQueryInt("articleid");
        //    int page_index = RequestHelper.GetQueryInt("page_index");
        //    int page_size = RequestHelper.GetQueryInt("page_size");
        //    int totalcount;
        //    StringBuilder strTxt = new StringBuilder();

        //    if (article_id == 0 || page_size == 0)
        //    {
        //        context.Response.Write("获取失败，传输参数有误！");
        //        return;
        //    }

        //    HN863Soft.ISS.BLL.ArticleComment bll = new HN863Soft.ISS.BLL.ArticleComment();
        //    DataSet ds = bll.GetList(page_size, page_index, string.Format("IsLock=0 and ArticleID={0}", article_id.ToString()), "CreateTime asc", out totalcount);
        //    //如果记录存在
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        strTxt.Append("[");
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            DataRow dr = ds.Tables[0].Rows[i];
        //            strTxt.Append("{");
        //            strTxt.Append("\"UserID\":" + dr["UserID"]);
        //            strTxt.Append(",\"UserName\":\"" + dr["UserName"] + "\"");
        //            if (Convert.ToInt32(dr["UserID"]) > 0)
        //            {
        //                Users userModel = new HN863Soft.ISS.BLL.Users().GetModel(Convert.ToInt32(dr["UserID"]));
        //                if (userModel != null)
        //                {
        //                    strTxt.Append(",\"Avatar\":\"" + userModel.Avatar + "\"");
        //                }
        //            }
        //            strTxt.Append("");
        //            strTxt.Append(",\"Content\":\"" + Microsoft.JScript.GlobalObject.escape(dr["Content"]) + "\"");
        //            strTxt.Append(",\"CreateTime\":\"" + dr["CreateTime"] + "\"");
        //            strTxt.Append(",\"IsReply\":" + dr["IsReply"]);
        //            if (Convert.ToInt32(dr["IsReply"]) == 1)
        //            {
        //                strTxt.Append(",\"ReplyContent\":\"" + Microsoft.JScript.GlobalObject.escape(dr["ReplyContent"]) + "\"");
        //                strTxt.Append(",\"ReplyTime\":\"" + dr["ReplyTime"] + "\"");
        //            }
        //            strTxt.Append("}");
        //            //是否加逗号
        //            if (i < ds.Tables[0].Rows.Count - 1)
        //            {
        //                strTxt.Append(",");
        //            }

        //        }
        //        strTxt.Append("]");
        //    }
        //    context.Response.Write(strTxt.ToString());
        //}
        //#endregion

        #region 验证用户名是否可用===========================
        private void validate_username(HttpContext context)
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

        #region 用户登录=====================================
        private void user_login(HttpContext context)
        {
            string sitepath = RequestHelper.GetQueryString("site");
            string username = RequestHelper.GetFormString("txtUserName");
            string password = RequestHelper.GetFormString("txtPassword");
            string remember = RequestHelper.GetFormString("chkRemember");
            //检查站点目录
            if (string.IsNullOrEmpty(sitepath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：站点传输参数不正确！\"}");
                return;
            }
            //检查用户名密码
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"温馨提示：请输入用户名或密码！\"}");
                return;
            }

            HN863Soft.ISS.BLL.Users bll = new HN863Soft.ISS.BLL.Users();
            Users model = bll.GetModel(username, password,  true);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：用户名或密码错误，请重试！\"}");
                return;
            }
            //检查用户是否通过验证
            if (model.Status == 1) //待验证
            {
                if (userConfig.regverify == 1)
                {
                    context.Response.Write("{\"status\":1, \"url\":\""
                        + new BasePage().getlink(sitepath, new BasePage().linkurl("register", "?action=sendmail&username=" + Utils.UrlEncode(model.UserName))) + "\", \"msg\":\"会员尚未通过验证！\"}");
                }
                else
                {
                    context.Response.Write("{\"status\":1, \"url\":\"" +
                        new BasePage().getlink(sitepath, new BasePage().linkurl("register", "?action=sendsms&username=" + Utils.UrlEncode(model.UserName))) + "\", \"msg\":\"会员尚未通过验证！\"}");
                }
                return;
            }
            else if (model.Status == 2) //待审核
            {
                context.Response.Write("{\"status\":1, \"url\":\""
                    + new BasePage().getlink(sitepath, new BasePage().linkurl("register", "?action=verify&username=" + Utils.UrlEncode(model.UserName))) + "\", \"msg\":\"会员尚未通过审核！\"}");
                return;
            }

            context.Session[KeysHelper.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态下次自动登录
            if (remember.ToLower() == "true")
            {
                Utils.WriteCookie(KeysHelper.COOKIE_USER_NAME_REMEMBER, "ISS", model.UserName, 43200);
                Utils.WriteCookie(KeysHelper.COOKIE_USER_PWD_REMEMBER, "ISS", model.Password, 43200);
            }
            else
            {
                //防止Session提前过期
                Utils.WriteCookie(KeysHelper.COOKIE_USER_NAME_REMEMBER, "ISS", model.UserName);
                Utils.WriteCookie(KeysHelper.COOKIE_USER_PWD_REMEMBER, "ISS", model.Password);
            }

            ////写入登录日志
            //new HN863Soft.ISS.BLL.user_login_log().Add(model.id, model.UserName, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 检查用户是否登录=============================
        private void user_check_login(HttpContext context)
        {
            //检查用户是否登录
            Users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"username\":\"匿名用户\"}");
                return;
            }
            context.Response.Write("{\"status\":1, \"username\":\"" + model.UserName + "\"}");
        }
        #endregion

        #region 用户注册=====================================
        private void user_register(HttpContext context)
        {
            string site = RequestHelper.GetQueryString("site").Trim(); //当前站点
            string code = RequestHelper.GetFormString("txtCode").Trim();
            string username = Utils.ToHtml(RequestHelper.GetFormString("txtUserName").Trim());
            string password = RequestHelper.GetFormString("txtPassword").Trim();
            string email = Utils.ToHtml(RequestHelper.GetFormString("txtEmail").Trim());
            string mobile = Utils.ToHtml(RequestHelper.GetFormString("txtMobile").Trim());
            string userip = RequestHelper.GetIP();

            #region 验证各种参数信息
            //检查站点目录是否正确
            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站传输参数有误！\"}");
                return;
            }
            //检查是否开启会员功能
            if (siteConfig.memberstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，会员功能已关闭，无法注册！\"}");
                return;
            }
            if (userConfig.regstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统暂不允许注册新用户！\"}");
                return;
            }
            //检查用户输入信息是否为空
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户名和密码不能为空！\"}");
                return;
            }
            //如果开启手机注册则要验证手机
            if (userConfig.regstatus == 2 && string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误：手机号码不能为空！\"}");
                return;
            }
            //如果开启邮箱注册则要验证邮箱
            if (userConfig.regstatus == 3 && string.IsNullOrEmpty(email))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，电子邮箱不能为空！\"}");
                return;
            }
            //检查用户名
            HN863Soft.ISS.BLL.Users bll = new HN863Soft.ISS.BLL.Users();
            if (bll.Exists(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户名已经存在！\"}");
                return;
            }
            //如果开启手机登录要验证手机
            if (userConfig.mobilelogin == 1 && !string.IsNullOrEmpty(mobile))
            {
                if (bll.ExistsMobile(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被使用！\"}");
                    return;
                }
            }
            //如果开启邮箱登录要验证邮箱
            if (userConfig.emaillogin == 1 && !string.IsNullOrEmpty(email))
            {
                if (bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该电子邮箱已被使用！\"}");
                    return;
                }
            }
            //检查同一IP注册时隔
            if (userConfig.regctrl > 0)
            {
                if (bll.Exists(userip, userConfig.regctrl))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，同IP在" + userConfig.regctrl + "小时内禁止重复注册！\"}");
                    return;
                }
            }
            //检查验证码是否正确
            switch (userConfig.regstatus)
            {
                case 1: //验证网页验证码
                    string result1 = verify_code(context, code);
                    if (result1 != "success")
                    {
                        context.Response.Write(result1);
                        return;
                    }
                    break;
                case 2: //验证手机验证码
                    string result2 = verify_sms_code(context, code);
                    if (result2 != "success")
                    {
                        context.Response.Write(result2);
                        return;
                    }
                    break;

            }
            #endregion

            #region 保存用户注册信息
            Users model = new Users();
            model.GroupID = 1;
            model.UserName = username;
            model.Salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            model.Password = EncryptionHelper.Encrypt(password, model.Salt);
            model.Email = email;
            model.Mobile = mobile;
            model.RegIP = userip;
            model.RegTime = DateTime.Now;
            //设置用户状态
            if (userConfig.regstatus == 3)
            {
                model.Status = 1; //待验证
            }
            else if (userConfig.regverify == 1)
            {
                model.Status = 2; //待审核
            }
            else
            {
                model.Status = 0; //正常
            }
            //开始写入数据库
            model.ID = bll.Add(model);
            if (model.ID < 1)
            {
                context.Response.Write("{\"Status\":0, \"msg\":\"系统故障，请联系网站管理员！\"}");
                return;
            }
            #endregion
        }
        #endregion

        #region 发送注册验证邮件=============================
        private void user_verify_email(HttpContext context)
        {
            string site = RequestHelper.GetString("site");
            string username = Utils.ToHtml(RequestHelper.GetFormString("username"));

            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"网站传输参数有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请检查用户名是否正确！\"}");
                return;
            }
            //检查邮件是否过快
            string cookie = Utils.GetCookie(KeysHelper.COOKIE_USER_EMAIL);
            if (cookie == username)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件发送间隔为二十分钟，请稍候再提交吧！\"}");
                return;
            }
            Users model = new HN863Soft.ISS.BLL.Users().GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不存在或已删除！\"}");
                return;
            }
            if (model.Status != 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不需要邮箱验证！\"}");
                return;
            }
            string result = SendVerifyEmail(site, model);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            context.Response.Write("{\"status\":1, \"msg\":\"邮件已发送，请进入邮箱查看！\"}");
            Utils.WriteCookie(KeysHelper.COOKIE_USER_EMAIL, username, 20); //20分钟内无重复发送
            return;
        }
        #endregion

        #region 修改用户信息=================================
        private void user_info_edit(HttpContext context)
        {
            //检查用户是否登录
            Users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string nick_name = Utils.ToHtml(RequestHelper.GetFormString("txtNickName"));
            string sex = RequestHelper.GetFormString("rblSex");
            string birthday = RequestHelper.GetFormString("txtBirthday");
            string email = Utils.ToHtml(RequestHelper.GetFormString("txtEmail"));
            string mobile = Utils.ToHtml(RequestHelper.GetFormString("txtMobile"));
            string telphone = Utils.ToHtml(RequestHelper.GetFormString("txtTelphone"));
            string qq = Utils.ToHtml(RequestHelper.GetFormString("txtQQ"));
            string msn = Utils.ToHtml(RequestHelper.GetFormString("txtMsn"));
            string province = Utils.ToHtml(RequestHelper.GetFormString("txtProvince"));
            string city = Utils.ToHtml(RequestHelper.GetFormString("txtCity"));
            string area = Utils.ToHtml(RequestHelper.GetFormString("txtArea"));
            string address = Utils.ToHtml(context.Request.Form["txtAddress"]);
            //检查昵称
            if (string.IsNullOrEmpty(nick_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的姓名昵称！\"}");
                return;
            }
            //检查省市区
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(area))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择您所在的省市区！\"}");
                return;
            }
            HN863Soft.ISS.BLL.Users bll = new HN863Soft.ISS.BLL.Users();
            //检查手机，如开启手机注册或使用手机登录需要检查
            if (userConfig.regstatus == 2 || userConfig.mobilelogin == 1)
            {
                if (string.IsNullOrEmpty(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的手机号码！\"}");
                    return;
                }
                if (model.Mobile != mobile && bll.ExistsMobile(mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被使用！\"}");
                    return;
                }
            }
            //检查邮箱，如开启邮箱注册或使用邮箱登录需要检查
            if (userConfig.regstatus == 3 || userConfig.emaillogin == 1)
            {
                if (string.IsNullOrEmpty(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的电子邮箱！\"}");
                    return;
                }
                if (model.Email != email && bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该电子邮箱已被使用！\"}");
                    return;
                }
            }

            //开始写入数据库
            model.NickName = nick_name;
            model.Sex = sex;
            DateTime _birthday;
            if (DateTime.TryParse(birthday, out _birthday))
            {
                model.Birthday = _birthday;
            }
            model.Email = email;
            model.Mobile = mobile;
            model.Telphone = telphone;
            model.QQ = qq;
            model.Msn = msn;
            model.Area = province + "," + city + "," + area;
            model.Address = address;

            bll.Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"账户资料已修改成功！\"}");
            return;
        }
        #endregion

        #region 确认裁剪用户头像=============================
        private void user_avatar_crop(HttpContext context)
        {
            //检查用户是否登录
            Users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string fileName = RequestHelper.GetFormString("hideFileName");
            int x1 = RequestHelper.GetFormInt("hideX1");
            int y1 = RequestHelper.GetFormInt("hideY1");
            int w = RequestHelper.GetFormInt("hideWidth");
            int h = RequestHelper.GetFormInt("hideHeight");
            //检查是否图片

            //检查参数
            if (!Utils.FileExists(fileName) || w == 0 || h == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请先上传一张图片！\"}");
                return;
            }
            //取得保存的新文件名
            UpLoad upFiles = new UpLoad();
            bool result = upFiles.cropSaveAs(fileName, fileName, 180, 180, w, h, x1, y1);
            if (!result)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"图片裁剪过程中发生意外错误！\"}");
                return;
            }
            //删除原用户头像
            Utils.DeleteFile(model.Avatar);
            model.Avatar = fileName;
            //修改用户头像
            new HN863Soft.ISS.BLL.Users().UpdateField(model.ID, "avatar='" + model.Avatar + "'");
            context.Response.Write("{\"status\": 1, \"msg\": \"头像上传成功！\", \"avatar\": \"" + model.Avatar + "\"}");
            return;
        }
        #endregion

        #region 修改登录密码=================================
        private void user_password_edit(HttpContext context)
        {
            //检查用户是否登录
            Users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int user_id = model.ID;
            string oldpassword = RequestHelper.GetFormString("txtOldPassword");
            string password = RequestHelper.GetFormString("txtPassword");
            //检查输入的旧密码
            if (string.IsNullOrEmpty(oldpassword))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的旧登录密码！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的新登录密码！\"}");
                return;
            }
            //旧密码是否正确
            if (model.Password != EncryptionHelper.Encrypt(oldpassword, model.Salt))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的旧密码不正确！\"}");
                return;
            }
            //执行修改操作
            model.Password = EncryptionHelper.Encrypt(password, model.Salt);
            new HN863Soft.ISS.BLL.Users().Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"您的密码已修改成功，请记住新密码！\"}");
            return;
        }
        #endregion

        #region 用户取回密码=================================
        private void user_getpassword(HttpContext context)
        {
            string site = RequestHelper.GetQueryString("site");
            string code = RequestHelper.GetFormString("txtCode");
            string type = RequestHelper.GetFormString("txtType");
            string username = RequestHelper.GetFormString("txtUserName").Trim();
            //检查站点目录
            if (string.IsNullOrEmpty(site))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站传输参数有误！\"}");
                return;
            }
            //检查用户名
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户名不可为空！\"}");
                return;
            }
            //检查取回密码类型
            if (string.IsNullOrEmpty(type))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择取回密码类型！\"}");
                return;
            }
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查用户信息
            HN863Soft.ISS.BLL.Users bll = new HN863Soft.ISS.BLL.Users();
            Users model = bll.GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的用户名不存在！\"}");
                return;
            }
            //发送取回密码的短信或邮件
            if (type.ToLower() == "mobile") //使用手机取回密码
            {
                #region 发送短信==================
                if (string.IsNullOrEmpty(model.Mobile))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"您尚未绑定手机号码，无法取回密码！\"}");
                    return;
                }
                SmsTemplate smsModel = new HN863Soft.ISS.BLL.SmsTemplate().GetModel("usercode"); //取得短信内容
                if (smsModel == null)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"发送失败，短信模板不存在，请联系管理员！\"}");
                }
                string strcode = Utils.Number(4); //随机验证码
                //检查是否重复提交
                HN863Soft.ISS.BLL.UserCode codeBll = new HN863Soft.ISS.BLL.UserCode();
                UserCode codeModel;
                codeModel = codeBll.GetModel(username, EnumsHelper.CodeEnum.RegVerify.ToString(), "d");
                if (codeModel == null)
                {
                    codeModel = new UserCode();
                    //写入数据库
                    codeModel.UserID = model.ID;
                    codeModel.UserName = model.UserName;
                    codeModel.Type = EnumsHelper.CodeEnum.Password.ToString();
                    codeModel.StrCode = strcode;
                    codeModel.EffTime = DateTime.Now.AddMinutes(userConfig.regsmsexpired);
                    codeModel.CreateTime = DateTime.Now;
                    codeBll.Add(codeModel);
                }
                //替换标签
                string msgContent = smsModel.Content;
                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
                msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
                msgContent = msgContent.Replace("{code}", codeModel.StrCode);
                msgContent = msgContent.Replace("{valid}", userConfig.regsmsexpired.ToString());

                #endregion
            }
            else if (type.ToLower() == "email") //使用邮箱取回密码
            {
                #region 发送邮件==================
                if (string.IsNullOrEmpty(model.Email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"您尚未绑定邮箱，无法取回密码！\"}");
                    return;
                }
                //生成随机码
                string strcode = Utils.GetCheckCode(20);
                //获得邮件内容
                MailTemplate mailModel = new HN863Soft.ISS.BLL.MailTemplate().GetModel("getpassword");
                if (mailModel == null)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}");
                    return;
                }

                //检查是否重复提交
                HN863Soft.ISS.BLL.UserCode codeBll = new HN863Soft.ISS.BLL.UserCode();
                UserCode codeModel;
                codeModel = codeBll.GetModel(username, EnumsHelper.CodeEnum.RegVerify.ToString(), "d");
                if (codeModel == null)
                {
                    codeModel = new UserCode();
                    //写入数据库
                    codeModel.UserID = model.ID;
                    codeModel.UserName = model.UserName;
                    codeModel.Type = EnumsHelper.CodeEnum.Password.ToString();
                    codeModel.StrCode = strcode;
                    codeModel.EffTime = DateTime.Now.AddMinutes(userConfig.regsmsexpired);
                    codeModel.CreateTime = DateTime.Now;
                    codeBll.Add(codeModel);
                }
                //替换模板内容
                string titletxt = mailModel.MaillTitle;
                string bodytxt = mailModel.Content;
                titletxt = titletxt.Replace("{webname}", siteConfig.webname);
                titletxt = titletxt.Replace("{username}", model.UserName);
                bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
                bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
                bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
                bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
                bodytxt = bodytxt.Replace("{username}", model.UserName);
                bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower()
                    + new BasePage().getlink(site, new BasePage().linkurl("repassword", "?action=email&code=" + codeModel.StrCode)));

                //发送邮件
                try
                {
                    MailHelper.sendMail(siteConfig.emailsmtp,
                        siteConfig.emailssl,
                        siteConfig.emailusername,
                        EncryptionHelper.Decrypt(siteConfig.emailpassword),
                        siteConfig.emailnickname,
                        siteConfig.emailfrom,
                        model.Email,
                        titletxt, bodytxt);
                }
                catch
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}");
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"邮件发送成功，请登录邮箱查看邮件！\"}");
                return;
                #endregion
            }
            context.Response.Write("{\"status\":0, \"msg\":\"发生未知错误，请检查参数是否正确！\"}");
            return;
        }
        #endregion

        #region 用户重设密码=================================
        private void user_repassword(HttpContext context)
        {
            string strcode = RequestHelper.GetFormString("hideCode"); //取回密码字符串
            string password = RequestHelper.GetFormString("txtPassword"); //重设后的密码

            //检查验证字符串
            if (string.IsNullOrEmpty(strcode))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，校检码字符串不能为空！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的新密码！\"}");
                return;
            }

            HN863Soft.ISS.BLL.UserCode codeBll = new HN863Soft.ISS.BLL.UserCode();
            UserCode codeModel = codeBll.GetModel(strcode);
            if (codeModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，校检码不存在或已过期！\"}");
                return;
            }
            //验证用户是否存在
            HN863Soft.ISS.BLL.Users userBll = new HN863Soft.ISS.BLL.Users();
            if (!userBll.Exists(codeModel.UserID))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户不存在或已被删除！\"}");
                return;
            }
            Users userModel = userBll.GetModel(codeModel.UserID);
            //执行修改操作
            userModel.Password = EncryptionHelper.Encrypt(password, userModel.Salt);
            userBll.Update(userModel);
            //更改验证字符串状态
            codeModel.Count = 1;
            codeModel.Status = 1;
            codeBll.Update(codeModel);
            context.Response.Write("{\"status\":1, \"msg\":\"修改密码成功，请记住新密码！\"}");
            return;
        }
        #endregion

        //#region 申请邀请码===================================
        //private void user_invite_code(HttpContext context)
        //{
        //    //检查用户是否登录
        //    Users model = new BasePage().GetUserInfo();
        //    if (model == null)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
        //        return;
        //    }
        //    //检查是否开启邀请注册
        //    if (userConfig.regstatus != 4)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统不允许通过邀请注册！\"}");
        //        return;
        //    }
        //    HN863Soft.ISS.BLL.UserCode codeBll = new HN863Soft.ISS.BLL.UserCode();
        //    //检查申请是否超过限制
        //    if (userConfig.invitecodenum > 0)
        //    {
        //        int result = codeBll.GetCount("UserName='" + model.UserName + "' and Type='" + EnumsHelper.CodeEnum.Register.ToString() + "' and datediff(d,CreateTime,getdate())=0");
        //        if (result >= userConfig.invitecodenum)
        //        {
        //            context.Response.Write("{\"status\":0, \"msg\":\"对不起，您申请邀请码的数量已超过每天限制！\"}");
        //            return;
        //        }
        //    }
        //    //删除过期的邀请码
        //    codeBll.Delete("Type='" + EnumsHelper.CodeEnum.Register.ToString() + "' and Status=1 or datediff(d,EffTime,getdate())>0");
        //    //随机取得邀请码
        //    string str_code = Utils.GetCheckCode(8);
        //    UserCode codeModel = new UserCode();
        //    codeModel.UserID = model.ID;
        //    codeModel.UserName = model.UserName;
        //    codeModel.Type = EnumsHelper.CodeEnum.Register.ToString();
        //    codeModel.StrCode = str_code;
        //    codeModel.UserIP = RequestHelper.GetIP();
        //    if (userConfig.invitecodeexpired > 0)
        //    {
        //        codeModel.EffTime = DateTime.Now.AddDays(userConfig.invitecodeexpired);
        //    }
        //    else
        //    {
        //        codeModel.EffTime = DateTime.Now.AddDays(1);
        //    }
        //    codeBll.Add(codeModel);
        //    context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，申请邀请码已成功！\"}");
        //    return;
        //}
        //#endregion

        //#region 用户兑换积分=================================
        //private void user_point_convert(HttpContext context)
        //{
        //    //检查系统是否启用兑换积分功能
        //    if (userConfig.pointcashrate == 0)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站未开启兑换积分功能！\"}");
        //        return;
        //    }
        //    //检查用户是否登录
        //    Users model = new BasePage().GetUserInfo();
        //    if (model == null)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
        //        return;
        //    }

        //    string password = RequestHelper.GetFormString("txtPassword");
        //    if (password == "")
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您账户的密码！\"}");
        //        return;
        //    }
        //    //验证密码
        //    if (EncryptionHelper.Encrypt(password, model.Salt) != model.Password)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的密码不正确！\"}");
        //        return;
        //    }

        //    return;
        //}
        //#endregion

        //#region 发布站内短消息===============================
        //private void user_message_add(HttpContext context)
        //{
        //    //检查用户是否登录
        //    Users model = new BasePage().GetUserInfo();
        //    if (model == null)
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
        //        return;
        //    }
        //    string code = context.Request.Form["txtCode"];
        //    string sendSave = RequestHelper.GetFormString("sendSave");
        //    string userName = Utils.ToHtml(RequestHelper.GetFormString("txtUserName"));
        //    string title = Utils.ToHtml(RequestHelper.GetFormString("txtTitle"));
        //    string content = Utils.ToHtml(RequestHelper.GetFormString("txtContent"));
        //    //校检验证码
        //    string result = verify_code(context, code);
        //    if (result != "success")
        //    {
        //        context.Response.Write(result);
        //        return;
        //    }
        //    //检查用户名
        //    if (string.IsNullOrEmpty(userName) || !new HN863Soft.ISS.BLL.Users().Exists(userName))
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户不存在或已删除！\"}");
        //        return;
        //    }
        //    //检查标题
        //    if (string.IsNullOrEmpty(title))
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息标题！\"}");
        //        return;
        //    }
        //    //检查内容
        //    if (string.IsNullOrEmpty(content))
        //    {
        //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息内容！\"}");
        //        return;
        //    }

        //    return;
        //}
        //#endregion

        //#region 统计及输出阅读次数===========================
        //private void view_article_click(HttpContext context)
        //{
        //    int article_id = RequestHelper.GetInt("id", 0);
        //    int click = RequestHelper.GetInt("click", 0);
        //    int hide = RequestHelper.GetInt("hide", 0);
        //    int count = 0;
        //    if (article_id > 0)
        //    {
        //        HN863Soft.ISS.BLL.Article bll = new HN863Soft.ISS.BLL.Article();
        //        count = bll.GetClick(article_id);
        //        if (click > 0)
        //        {
        //            bll.UpdateField(article_id, "click=click+1");
        //        }
        //    }
        //    if (hide == 0)
        //    {
        //        context.Response.Write("document.write('" + count + "');");
        //    }
        //}
        //#endregion

        //#region 输出评论总数=================================
        //private void view_comment_count(HttpContext context)
        //{
        //    int article_id = RequestHelper.GetInt("id", 0);
        //    int count = 0;
        //    if (article_id > 0)
        //    {
        //        count = new HN863Soft.ISS.BLL.ArticleComment().GetCount("IsLock=0 and ArticleID=" + article_id);
        //    }
        //    context.Response.Write("document.write('" + count + "');");
        //}
        //#endregion

        //#region 输出附件下载总数=============================
        //private void view_attach_count(HttpContext context)
        //{
        //    int id = RequestHelper.GetInt("id", 0);
        //    string view = RequestHelper.GetString("view");
        //    int count = 0;
        //    if (id > 0)
        //    {
        //        if (view.ToLower() == "count")
        //        {
        //            count = new HN863Soft.ISS.BLL.ArticleAttach().GetCountNum(id);
        //        }
        //        else
        //        {
        //            count = new HN863Soft.ISS.BLL.ArticleAttach().GetDownNum(id);
        //        }
        //    }
        //    context.Response.Write("document.write('" + count + "');");
        //}
        //#endregion

        #region 插入参观预约信息
        private void VisitBookingSubmit(HttpContext context)
        {
            Model.VisitBooking visBModel = new VisitBooking();
            visBModel.CreateTime = DateTime.Now;
            visBModel.Creator = Convert.ToInt32(RequestHelper.GetString("Creator"));
            visBModel.EId = Convert.ToInt32(RequestHelper.GetString("EId"));
            visBModel.Email = RequestHelper.GetString("Email");
            visBModel.IsVis = 0;
            visBModel.Name = RequestHelper.GetString("Name");
            visBModel.Phone = RequestHelper.GetString("Phone");
            visBModel.Remark = RequestHelper.GetString("Remark");
            visBModel.VisitDate = Convert.ToDateTime(RequestHelper.GetString("VisitDate"));
            visBModel.VisitNum = Convert.ToInt32(RequestHelper.GetString("VisitNum"));
            BLL.VisitBooking visBookingBll = new BLL.VisitBooking();
            if (visBModel != null)
            {
                if (visBookingBll.Add(visBModel) == -1)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，保存中出现异常！\"}");
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"保存成功！\"}");
            }


        }
        #endregion


        #region 保存商业计划书
        private void RepplySubmit(HttpContext context)
        {
            Model.VisitBooking visBModel = new VisitBooking();

            //允许上传类型
            string[] fileType = { ".pptx", ".ppt", ".docx", ".doc", ".pdf" };
            //根目录路径，相对路径
            String rootPath = "~/uploadFile/" + RequestHelper.GetQueryString("Id") + RequestHelper.GetQueryString("UId") + "/"; //站点目录+上传目录
            HttpPostedFile file = context.Request.Files[0];
            string strName = file.FileName;

            //是否有文件上传
            if (context.Request.Files.Count == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"文件异常！\"}");
                return;
            }
            //获取文件后缀名
            string strExtn = System.IO.Path.GetExtension(file.FileName).ToLower();
            //文件类型判断
            if (!fileType.Contains(strExtn))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"此文件类型在禁止上传之列！ \"}");
                return;
            }

            //文件大小小于50M
            if (file.ContentLength > 1024 * 1024 * 50)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"文件大于50M，请重新上传 \"}");
                return;
            }

            if (Directory.Exists(context.Server.MapPath(rootPath)) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(context.Server.MapPath(rootPath));
            }
          
            strName = strName.Substring(strName.LastIndexOf('\\')+1);
            rootPath += DateTime.Now.ToString("yyMMddhhmmss")+strName;
            //文件是否存在
            if (System.IO.File.Exists(context.Server.MapPath(rootPath)))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，保存中出现异常！\"}");
                return;
            }
            file.SaveAs(context.Server.MapPath(rootPath));
            context.Response.Write("{\"status\":1, \"msg\":\" \",\"filename\":\"" + file.FileName + "\",\"filepath\":\""+rootPath+"\"}");
        }
        #endregion

        #region 图片上传

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="context"></param>
        private void UploadImg(HttpContext context)
        {
            int ids = int.Parse(RequestHelper.GetQueryString("Id"));
            String rootPath = "~/uploadImage/" + RequestHelper.GetQueryString("Id") + "/"; //站点目录+上传目录
            if (context.Request.Files.Count == 0)
            {
                return;
            }
            //遍历文件集
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                HttpPostedFile file = context.Request.Files[0];
                string strName = file.FileName;

                strName = DateTime.Now.ToString("yyMMddhhmmss") + strName.Substring(strName.LastIndexOf('\\') + 1);
                string path = rootPath + strName;
                try
                {

                    //判断文件大小不小于0
                    if (file.ContentLength > 0)
                    {
                        if (Directory.Exists(context.Server.MapPath(rootPath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(context.Server.MapPath(rootPath));
                        }

                        //上传到服务器文件夹内
                        file.SaveAs(context.Server.MapPath(path));
                    }
                }
                catch (Exception Ex)
                {
                    //Label1.Text += "发生错误： " + Ex.Message;
                }
                context.Response.Write(path);
            }
        }
        
        #endregion

        #region 插入申请入驻信息
        private void RepplySubmits(HttpContext context)
        {
            Model.Hatchery visBModel = new Hatchery();
            visBModel.CreateTime = DateTime.Now;
            visBModel.Creator = Convert.ToInt32(RequestHelper.GetString("Creator"));
            visBModel.OrId = Convert.ToInt32(RequestHelper.GetString("OrId"));
            visBModel.Email = RequestHelper.GetString("Email");
            visBModel.IsVis = 0;
            visBModel.Name = RequestHelper.GetString("Name");
            visBModel.Phone = RequestHelper.GetString("Phone");
            visBModel.Remark = RequestHelper.GetString("Remark");
            visBModel.VisitDate = Convert.ToDateTime(RequestHelper.GetString("VisitDate"));
            visBModel.VisitNum = Convert.ToInt32(RequestHelper.GetString("VisitNum"));
            visBModel.FileUrl = Convert.ToString(RequestHelper.GetString("filepath"));
            BLL.Hatchery visBookingBll = new BLL.Hatchery();
            if (visBModel != null)
            {
                if (visBookingBll.Add(visBModel) == -1)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，保存中出现异常！\"}");
                    return;
                }
                context.Response.Write("{\"status\":1, \"msg\":\"保存成功！\"}");
            }
        }
        #endregion

        #region 通用外理方法=================================

        #region 校检网站验证码===============================
        private string verify_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}";
            }
            if (context.Session[KeysHelper.SESSION_CODE] == null)
            {
                return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期！\"}";
            }
            if (strcode.ToLower() != (context.Session[KeysHelper.SESSION_CODE].ToString()).ToLower())
            {
                return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致！\"}";
            }
            context.Session[KeysHelper.SESSION_CODE] = null;
            return "success";
        }
        #endregion

        #region 校检手机验证码===============================
        private string verify_sms_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}";
            }
            if (context.Session[KeysHelper.SESSION_SMS_CODE] == null)
            {
                return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期！\"}";
            }
            if (strcode.ToLower() != (context.Session[KeysHelper.SESSION_SMS_CODE].ToString()).ToLower())
            {
                return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致！\"}";
            }
            context.Session[KeysHelper.SESSION_SMS_CODE] = null;
            return "success";
        }
        #endregion

        #region Email验证发送邮件============================
        private string SendVerifyEmail(string site, Users userModel)
        {
            //生成随机码
            string strcode = Utils.GetCheckCode(20);
            HN863Soft.ISS.BLL.UserCode codeBll = new HN863Soft.ISS.BLL.UserCode();
            UserCode codeModel;
            //检查是否重复提交
            codeModel = codeBll.GetModel(userModel.UserName, EnumsHelper.CodeEnum.RegVerify.ToString(), "d");
            if (codeModel == null)
            {
                codeModel = new UserCode();
                codeModel.UserID = userModel.ID;
                codeModel.UserName = userModel.UserName;
                codeModel.Type = EnumsHelper.CodeEnum.RegVerify.ToString();
                codeModel.StrCode = strcode;
                codeModel.EffTime = DateTime.Now.AddDays(userConfig.regemailexpired);
                codeModel.CreateTime = DateTime.Now;
                new HN863Soft.ISS.BLL.UserCode().Add(codeModel);
            }
            //获得邮件内容
            MailTemplate mailModel = new HN863Soft.ISS.BLL.MailTemplate().GetModel("regverify");
            if (mailModel == null)
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}";
            }
            //替换模板内容
            string titletxt = mailModel.MaillTitle;
            string bodytxt = mailModel.Content;
            titletxt = titletxt.Replace("{webname}", siteConfig.webname);
            titletxt = titletxt.Replace("{username}", userModel.UserName);
            bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
            bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
            bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
            bodytxt = bodytxt.Replace("{username}", userModel.UserName);
            bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
            bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower()
                + new BasePage().getlink(site, new BasePage().linkurl("register", "?action=checkmail&code=" + codeModel.StrCode)));
            //发送邮件
            try
            {
                MailHelper.sendMail(siteConfig.emailsmtp, siteConfig.emailssl,
                    siteConfig.emailusername,
                    EncryptionHelper.Decrypt(siteConfig.emailpassword),
                    siteConfig.emailnickname,
                    siteConfig.emailfrom,
                    userModel.Email,
                    titletxt, bodytxt);
            }
            catch
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}";
            }
            return "success";
        }
        #endregion

        #endregion END通用方法===============================

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}