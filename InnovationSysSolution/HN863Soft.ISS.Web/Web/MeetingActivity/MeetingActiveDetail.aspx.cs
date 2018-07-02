using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Model;
//******************************
//* 文件名：MeetingActiveDetail.cs
//* 作者：雷登辉
//* 功能：对会议活动交流信息的浏览以及回复
//* 创建时间：2017/3/1
//******************************
namespace HN863Soft.ISS.Web.Web.MeetingActivity
{
    public partial class MeetingActiveDetail : BasePage
    {
        #region 函数

        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected HN863Soft.ISS.Model.MeetingActivity meetingModel;//问题信息实体
        private HN863Soft.ISS.Model.ActiveReply activeModel;//问题回复信息实体对象
        private HN863Soft.ISS.BLL.Users userBll;//前台用户处理对象
        private HN863Soft.ISS.BLL.MeetingActivity meetingBll;//问题信息处理对象
        private HN863Soft.ISS.BLL.ActiveReply activeBll;//问题回复信息处理对象
        private static HN863Soft.ISS.Model.Users model = new Model.Users();

        private int cId = 0;//问题信息Id
        private int uId = 0;//前台用户对象Id
        protected static bool isLogin = false;//是否登录
        protected static bool isCreator = false;

        #endregion

        #region 页面初始化

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pageSize = GetPageSize(10);
            int.TryParse(Request.QueryString["id"] as string, out this.cId);

            if (!IsUserLoginF())
            {
                Dreply.Visible = false;
            }
            Model.Users user = GetUserInfoF();
            if (user != null)
            {
                DName.InnerText = user.NickName;
                Dreply.Visible = true;
                isLogin = true;
            }
            else
            {
                isLogin = false;
                Dreply.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                meetingBll = new BLL.MeetingActivity();
                GetPageSize(10);
                isCreator = false;
                if (Session[KeysHelper.ForegroundUser] != null)
                {
                    model = (Users)Session[KeysHelper.ForegroundUser];
                    if (model != null)
                    {
                        meetingModel = meetingBll.GetModel(this.cId);
                        if (meetingModel != null)
                        {
                            isCreator = meetingModel.CreatorId == model.ID ? true : false;
                        }
                    }
                }

                GetData();

                this.page = RequestHelper.GetQueryInt("page", 1);
                BindInfo();

                txtPageNum.Text = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("MeetingActiveDetail.aspx?id=" + this.cId + "&", "page={0}","__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

                //string pageUrl = Utils.CombUrlTxt("MeetingActiveDetail.aspx?id=" + this.cId + "&", "page={0}", "__id__");
                total.InnerHtml = this.totalCount.ToString();
            }
        }

        /// <summary>
        /// 绑定评论信息
        /// </summary>
        private void BindInfo()
        {
            dlReplyInfo.DataSource = GetRePlyInfo();
            dlReplyInfo.DataBind();

        }

        #endregion

        #region 保存

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('先说点什么吧！');");
                return;
            }

            if (!DoAdd())
            {
                ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                return;
            }
            BindInfo();
        }

        #endregion

        #region 设置分页数量

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("MeetingActiveDetail_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("MeetingActiveDetail.aspx", "id={0}", this.cId.ToString()));
        }


        #endregion

        #region 数据绑定=================================

        /// <summary>
        /// 获取问题回复信息
        /// </summary>
        private DataTable GetRePlyInfo()
        {

            activeBll = new BLL.ActiveReply();//实例化问题回复信息处理对象IsVis=1 and
            //判断处理显示全部、局部 GetListInfo(问题信息Id,普通用户Id)
            DataTable replyDt = activeBll.GetList(this.pageSize, this.page, cId, "Id asc", out this.totalCount).Tables[0];//获取数据库分页数据
            return replyDt;
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="id">问题信息Id</param>
        private void GetData()
        {
            meetingBll = new HN863Soft.ISS.BLL.MeetingActivity();//实例化问题信息处理对象
            userBll = new BLL.Users();//实例化前台用户处理对象
            meetingModel = meetingBll.GetModel(cId);
            //this.pTitle.InnerText = meetingModel.Title;
            this.DContent.InnerHtml = meetingModel.Content;
            sType.InnerHtml = EnumsHelper.FetchDescription((EnumsHelper.ForumCategory)Enum.Parse(typeof(EnumsHelper.ForumCategory), meetingModel.Type.ToString()));
            pTitle.InnerHtml = meetingModel.Title + "<br/><span class=\"hot-city\" style=\"font-size: 14px; \"><img src=\"../CSS/Show/bq.png\" />" + meetingModel.KeyWord + "</span>";
            SReward.InnerText = meetingModel.Reward.ToString();
            sCreateTime.InnerHtml = (DateTime.Parse(meetingModel.CreateTime.ToString())).ToString("yyyy.MM.dd.hh.mm");
            authorImg.Src = model.Avatar.Replace("\\", "/").Replace("~", "..") == "" ? "../CSS/avatar/239.png" : model.Avatar.Replace("\\", "/").Replace("~", "..");
            userImg.Src = "../CSS/avatar/239.png";
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            Model.Users user = GetUserInfoF();
            if (user != null)
            {
                activeModel = new Model.ActiveReply//实例化问题回复信息实体对象
                {
                    Content = txtContent.InnerText,//评论内容
                    UId = user.ID,//评论人
                    IsVis = 1,//是否被隐藏：0，是；1，否。
                    MeetingId = Convert.ToInt32(Request["Id"]),//服务Id
                    CreateTime = DateTime.Now,//评论时间
                    ParentId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id
                    Score = 0//初始化得分为：0
                };
                activeBll = new BLL.ActiveReply();//实例化问题回复信息处理对象
                //添加评论信息
                if (activeBll.Add(activeModel) != -1)
                {
                    userBll = new BLL.Users();
                    userBll.UpLevel(user.ID, EnumsHelper.UserUpLevel.CommentExp);//更新用户等级经验
                    userBll.UpPoint(user.ID, EnumsHelper.ActionEnum.Add, 1);//发表回复+1积分
                    txtContent.InnerText = string.Empty;//赋空值
                    txtId.Value = string.Empty;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取每页数量
        /// </summary>
        /// <param name="_default_size"></param>
        /// <returns></returns>
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("MeetingActiveDetail_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }


        #endregion

        #region 评论记录操作

        /// <summary>
        /// 评论记录操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlReplyInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = 0;
            int _pagesize=0;
            activeBll = new BLL.ActiveReply();//实例化问题回复信息处理对象
            TextBox txtbox = e.Item.FindControl("txtReward") as TextBox;
            int reward = int.Parse(SReward.InnerText);
            switch (e.CommandName)
            {
                case "Del":
                    id = int.Parse(e.CommandArgument.ToString());
                    activeModel = new Model.ActiveReply
                    {
                        IsVis = 0,   //是否隐藏：0，是；1，否。
                        Id = id     //评论信息ID
                    };
                    string strId = this.cId.ToString();//问题信息Id
                    if (activeBll.UpdateIsVis(activeModel))//删除对应Id的回复信息
                    {
                        ScriptManager.RegisterClientScriptBlock(datalist, this.GetType(), "showWarningMsg", "alert('删除成功！');", true);
                        this.page = RequestHelper.GetQueryInt("page", 1);
                        BindInfo();
                    }
                    break;
                case "Reward":
                    SetRewardTxtBox(e.Item.ItemIndex);
                    break;
                case "btnOk"://设定积分值
                    int score;
                    id = int.Parse(e.CommandArgument.ToString());
                    if (!int.TryParse(txtbox.Text.Trim(), out score))
                    {
                        ScriptManager.RegisterClientScriptBlock(datalist, this.GetType(), "showWarningMsg", "alert('格式错误!');", true);
                        return;
                    }
                    string strWhere = "MeetingId=" + this.cId.ToString();
                    if (score + activeBll.GetSum(strWhere) > reward)
                    {
                        ScriptManager.RegisterClientScriptBlock(datalist, this.GetType(), "showWarningMsg", "alert('悬赏积分不足!');", true);
                        return;
                    }

                    activeModel = new ActiveReply
                    {
                        Id = id,
                        Score = score
                    };
                    if (!activeBll.UpdateScore(activeModel))
                    {
                        ScriptManager.RegisterClientScriptBlock(datalist, this.GetType(), "showWarningMsg", "alert('保存过程中发生错误');", true);
                        return;
                    }
                    ScriptManager.RegisterClientScriptBlock(datalist, this.GetType(), "showWarningMsg", "alert('设定成功！');", true);
                    this.page = RequestHelper.GetQueryInt("page", 1);
                    BindInfo();
                    break;

            }
        }

        /// <summary>
        /// 设置悬赏文本框显示方式
        /// </summary>
        /// <param name="itemIndex"></param>
        private void SetRewardTxtBox(int itemIndex)
        {
            foreach (RepeaterItem drv in dlReplyInfo.Items)
            {
                Panel Pward = drv.FindControl("PReward") as Panel;
                if (drv.ItemIndex == itemIndex)
                {
                    Pward.Visible = true;
                }
                else
                {
                    Pward.Visible = false;
                }
            }
        } 
        #endregion
    }
}