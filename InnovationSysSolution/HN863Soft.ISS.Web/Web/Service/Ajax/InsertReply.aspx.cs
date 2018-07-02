using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Service.Ajax
{
    public partial class InsertReply : System.Web.UI.Page
    {
        HN863Soft.ISS.BLL.ReplyInfo replyBLl;//评论信息处理对象
        HN863Soft.ISS.Model.ReplyInfo replyModel;//评论信息实体对象

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsertInfo();
            }
        }

        private string InsertInfo()
        {
            string strContext = Request["content"].ToString();//content: content, sId: sId, responserId: responserId, commentId: commentId 
            int? sId = Convert.ToInt32(Request["sId"]);//服务信息ID
            int? reponserId = Convert.ToInt32(Request["responserId"]);//评论者Id
            int? commentId = string.IsNullOrEmpty(Request["commentId"]) ? null : (int?)Convert.ToInt32(Request["commentId"]);//评论对象Id
            DateTime date = DateTime.Now;//评论时间
            replyModel = new Model.ReplyInfo
            {
                Content = strContext,
                CommentId = commentId,
                SId = sId,
                ResponderId = reponserId,
                Time = date
            };
            replyBLl = new BLL.ReplyInfo();
            int result = replyBLl.AddComment(replyModel);//添加一条评论信息
            if (result == -1)
            {
                Response.Write("服务器异常！");

            }
            else
            {
                Response.Write("发表成功");
            }
            return "1";
        }
    }
}