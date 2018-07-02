using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
//****************************
//* 文件名：Detail.cs
//* 作者： 雷登辉
//* 功能：回复评论信息的添加、以及删除
//* 创建时间：2017/2/24
//****************************

namespace HN863Soft.ISS.Web.Manage.Inspection
{
    public partial class Detail : ManagePage
    {
        #region 函数

        protected static HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体
        private HN863Soft.ISS.Model.ReplyInfo replyModel;//评论信息实体对象
        private HN863Soft.ISS.BLL.Users userBll;//前台用户处理对象
        private HN863Soft.ISS.Model.Users userModel;//前台用户实体对象
        private HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象
        private HN863Soft.ISS.BLL.ReplyInfo replyBll;//评论处理对象

        private int sId = 0;//服务信息Id
        private int uId = 0;//前台用户对象Id
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        #endregion

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.sId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    Response.Redirect("List.aspx");
                    return;
                }
                Manager model = GetManageInfo(); //取得管理员信息
                userBll = new BLL.Users();//实例化前台用户处理对象
                userModel = userBll.GetUserModel(model.ID);//获取前台用户信息
                uId = userModel.ID;//获取前台用户Id

                if (!new HN863Soft.ISS.BLL.ServiceInfo().Exists(this.sId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    Response.Redirect("List.aspx");
                    return;
                }
            }
            if (!IsPostBack)
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.View.ToString()); //检查权限
               
                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    GetData();
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ShowMsgHelper.Alert_Error("先说点什么吧！");
                return;
            }
            if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = sId.ToString();//服务信息Id
                ShowMsgHelper.ShowScript("showWarningMsg('发表信息成功！');setTimeout(Back, 3000);");
                Response.Redirect(Utils.CombUrlTxt("Detail.aspx", "action={0}&id={1}", keys));
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
                    IsVis = 0,   //是否隐藏：0，是；1，否。
                    Id = id     //评论信息ID
                };
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = id.ToString();//服务信息Id
                if (replyBll.UpdateReplyInfo(replyModel))//删除对应Id的回复信息
                {
                    AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除评论"); //记录日志
                    ShowMsgHelper.ShowScript("showWarningMsg('删除信息成功！');setTimeout(Back, 3000);");
                    Response.Redirect(Utils.CombUrlTxt("Detail.aspx", "action={0}&id={1}", keys));
                }
            }
        }

        #region 数据绑定=================================

        //AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除管理员" + sucCount + "条，失败" + errorCount + "条"); //记录日志
        //   ShowScriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("List.aspx", "keywords={0}", this.keywords));

        /// <summary>
        /// 获取服务评论信息
        /// </summary>
        private DataTable GetRePlyInfo()
        {
            replyBll = new BLL.ReplyInfo();//实例化评论信息处理对象IsVis=1 and
            //判断处理显示全部、局部 GetListInfo(服务信息Id,普通用户Id)
            DataTable replyDt = replyBll.GetListInfo(sId).Tables[0];//
            return replyDt;
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="id">服务信息Id</param>
        private void GetData()
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();//实例化服务信息处理对象
            userBll = new BLL.Users();//实例化前台用户处理对象
            serviceModel = serviceBll.GetModel(sId);
            dlReplyInfo.DataSource = GetRePlyInfo();
            dlReplyInfo.DataBind();
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            replyModel = new Model.ReplyInfo//实例化评论信息实体对象
            {
                Content = txtContent.InnerText,//评论内容
                ResponderId = uId,//评论人
                IsVis = 1,//是否被隐藏：0，是；1，否。
                SId = Convert.ToInt32(Request["Id"]),//服务Id
                Time = DateTime.Now,//评论时间
                CommentId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id

            };
            replyBll = new BLL.ReplyInfo();//实例化评论信息处理对象
            //添加评论信息
            if (replyBll.AddComment(replyModel) != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加评论:" + serviceModel.Title); //记录日志
                txtContent.InnerText = string.Empty;//赋空值
                txtId.Value = string.Empty;
                return true;

            }

            return false;
        }



        #endregion

    }
}