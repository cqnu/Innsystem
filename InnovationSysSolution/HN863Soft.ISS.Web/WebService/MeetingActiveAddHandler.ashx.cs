using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace HN863Soft.ISS.Web.WebService
{
    /// <summary>
    /// MeetingActiveAddHandler 的摘要说明
    /// </summary>
    public class MeetingActiveAddHandler : IHttpHandler, IRequiresSessionState
    {
        HN863Soft.ISS.Model.MeetingActivity meetingAcModel = new Model.MeetingActivity();
        HN863Soft.ISS.Model.Users model = new Users();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session[KeysHelper.ForegroundUser] != null)
            {
                model = (Users)context.Session[KeysHelper.ForegroundUser];
            }
            else
            {
                //context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }

            context.Response.ContentType = "text/plain";

            int type = int.Parse(context.Request["ddlType"]);   //吐槽类型
            int reword = int.Parse(context.Request["txtReword"]);     //悬赏积分
            string title = context.Request["txtTitle"];       //标题
            string keyword = context.Request["txtKeyWord"];    //关键字
            string content = context.Request["txtContent"];      //吐槽内容

            if (model.Point < reword)
            {
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                //context.Response.Write("{\"status\": 0, \"msg\": \"标题、内容不能为空！\"}");
                return;
            }

           DoAdd(type,reword,title,keyword,content);

           context.Response.Redirect("/web/MeetingActivity/MeetingActiveList.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 增加操作=================================
        private bool DoAdd(int type, int reword, string title, string keyword, string content)
        {
            HN863Soft.ISS.BLL.MeetingActivity meetingAcBll = new BLL.MeetingActivity();//实例化服务信息处理对象
            BLL.Users userBll = new BLL.Users();//用户信息处理对象

            //实例化服务信息对象
            meetingAcModel = new HN863Soft.ISS.Model.MeetingActivity
            {
                Content = content,//服务内容
                CreatorId = model.ID,//登陆者Id
                CreateTime = DateTime.Now,//创建时间
                //Remarks = "新建服务",//备注
                Title = title,//标题
                IsVis = 0,//是否通过：0，不通过；1，通过
                Type = type,//任务类型
                Reward = reword,//悬赏积分
                KeyWord = keyword,
            };
            int result = meetingAcBll.Add(meetingAcModel);//插入并返回主ID值
            if (result != -1)
            {
                //更新经验值
                if (userBll.UpLevel(model.ID, EnumsHelper.UserUpLevel.QuestionRelease))
                {
                    userBll.UpPoint(model.ID, EnumsHelper.ActionEnum.Reduce, (int)meetingAcModel.Reward);
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}