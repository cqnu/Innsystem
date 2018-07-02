using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*****************************
//* 文件名：EntDetail.cs
//* 作者： 雷登辉
//* 功能：查看详细问题解答，并提供回复功能
//* 创建时间：2017/2/27
//*****************************
namespace HN863Soft.ISS.Web.Web.Entrepreneurship
{
    public partial class EntDetail : System.Web.UI.Page
    {
        #region 函数
        private HN863Soft.ISS.BLL.ConductInfo conductBll;
        private BLL.Users userBll;
        private BLL.ConductReply conReplyBll;
        protected static Model.ConductInfo conductModel;
        private Model.ConductReply conReplyModel;
        private static int cId = 0;
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型 
        #endregion

        #region 方法
        /// <summary>
        /// 获取问题回复信息
        /// </summary>
        private DataTable GetRePlyInfo()
        {
            conReplyBll = new BLL.ConductReply();//实例化问题回复信息处理对象IsVis=1 and
            //判断处理显示全部、局部 GetListInfo(问题信息Id,普通用户Id)
            DataTable replyDt = conReplyBll.GetAllList(cId).Tables[0];//
            return replyDt;
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="id">问题信息Id</param>
        private void GetData()
        {
            conductBll = new HN863Soft.ISS.BLL.ConductInfo();//实例化问题信息处理对象
            userBll = new BLL.Users();//实例化前台用户处理对象
            conductModel = conductBll.GetModel(cId);
            dlReplyInfo.DataSource = GetRePlyInfo();
            dlReplyInfo.DataBind();
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            conReplyModel = new Model.ConductReply//实例化问题回复信息实体对象
            {
                Content = txtContent.InnerText,//评论内容
                //UId = uId,//评论人
                IsVis = 1,//是否被隐藏：0，是；1，否。
                CId = Convert.ToInt32(Request["Id"]),//服务Id
                Time = DateTime.Now,//评论时间
                RId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id

            };
            conReplyBll = new BLL.ConductReply();//实例化问题回复信息处理对象
            //添加评论信息
            if (conReplyBll.Add(conReplyModel) != -1)
            {
                //AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加评论:" + conductModel.Title); //记录日志
                txtContent.InnerText = string.Empty;//赋空值
                txtId.Value = string.Empty;
                return true;
            }

            return false;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cId = Convert.ToInt32(Request["Id"]);
                GetData();

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
            if (action == EnumsHelper.ActionEnum.Add.ToString()) //修改
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = cId.ToString();//服务信息Id
                ShowMsgHelper.ShowScript("showWarningMsg('发表信息成功！');setTimeout(Back, 3000);");
                Response.Redirect(Utils.CombUrlTxt("EntDetail.aspx", "action={0}&id={1}", keys));
            }
        } 
        #endregion
        
    }
}