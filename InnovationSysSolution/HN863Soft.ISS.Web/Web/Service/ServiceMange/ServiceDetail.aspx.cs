using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//******************************
//*文件名：ServiceDetail.cs
//*作者：雷登辉
//*功能：服务信息详情展示
//*创建时间：2017/2/16
//******************************

namespace HN863Soft.ISS.Web.Service.ServiceMange
{
    public partial class ServiceDetail : System.Web.UI.Page
    {
        #region 函数

        protected static HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体
        private HN863Soft.ISS.Model.ReplyInfo replyModel;//评论信息实体对象
        private HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象
        private HN863Soft.ISS.BLL.ReplyInfo replyBll;//评论处理对象

        #endregion

        #region 方法

        /// <summary>
        /// 绑定信息到页面
        /// </summary>
        protected void BindData()
        {
            dlReplyInfo.DataSource = GetRePlyInfo();
            dlReplyInfo.DataBind();
        }

        /// <summary>
        /// 获取服务评论信息
        /// </summary>
        private DataTable GetRePlyInfo()
        {
            replyBll = new BLL.ReplyInfo();//实例化评论信息处理对象IsVis=1 and
            int sId = Convert.ToInt32(Request["Id"]);//服务信息Id
            //判断处理显示全部、局部 GetListInfo(服务信息Id,普通用户Id)
            DataTable replyDt = replyBll.GetListInfo(sId).Tables[0];//
            return replyDt;
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="id">服务信息Id</param>
        private void GetData(int id)
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();
            serviceModel = serviceBll.GetModel(id);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 画面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Convert.ToInt32(Request["Id"]);//获取服务详情Id
                GetData(id);//获取服务信息
                BindData();
            }
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReply_Click(object sender, EventArgs e)
        {
            //评论内容为空时，提醒用户！
            if (string.IsNullOrEmpty(txtContent.InnerText))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Marning", "alert('先说点什么吧！')", true);
                return;
            }
            replyModel = new Model.ReplyInfo//实例化评论信息实体对象
            {
                Content = txtContent.InnerText,//评论内容
                ResponderId = 2,//评论人
                IsVis = 1,//是否被隐藏：0，是；1，否。
                SId = Convert.ToInt32(Request["Id"]),//服务Id
                Time = DateTime.Now,//评论时间
                CommentId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id

            };
            replyBll = new BLL.ReplyInfo();//实例化评论信息处理对象
            //添加评论信息
            if (replyBll.AddComment(replyModel) == -1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('服务器异常！')", true);
                return;
            }
            txtContent.InnerText = string.Empty;//赋空值
            txtId.Value = string.Empty;
            BindData();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('发表成功')", true);
        }

        /// <summary>
        /// 页面错误反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                Response.Redirect("Default.aspx");
                Server.ClearError();
            }
        }

        /// <summary>
        /// 回复信息删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlReplyInfo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = int.Parse(dlReplyInfo.DataKeys[e.Item.ItemIndex].ToString());//获取回复信息Id
                replyBll = new BLL.ReplyInfo();//实例化信息处理对象
                replyModel = new Model.ReplyInfo
                {
                     IsVis=0,   //是否隐藏：0，是；1，否。
                      Id=id     //评论信息ID
                };
                if (!replyBll.UpdateReplyInfo(replyModel))//删除对应Id的回复信息
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('服务器异常')", true);
                    return;
                }
                BindData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('删除成功')", true);
            }
        }
        #endregion

    }
}