using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.MeetingActivity
{
    public partial class ActiveAuditDetail : ManagePage
    {
        #region 函数

        protected int totalCount;
        protected int page;
        protected int pageSize;

        private HN863Soft.ISS.Model.MeetingActivity meetingModel;//问题信息实体
        private HN863Soft.ISS.Model.ActiveReply activeModel;//问题回复信息实体对象
        private HN863Soft.ISS.BLL.Users userBll;//前台用户处理对象
        private HN863Soft.ISS.Model.Users userModel;//前台用户实体对象
        private HN863Soft.ISS.BLL.MeetingActivity meetingBll;//问题信息处理对象
        private HN863Soft.ISS.BLL.ActiveReply activeBll;//问题回复信息处理对象

        private int cId = 0;//问题信息Id
        private int uId = 0;//前台用户对象Id
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型

        private static int reward = 0;//记录悬赏积分
        private static int mId = 0;//记录难题Id



        #endregion

        #region 页面初始化

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.pageSize = GetPageSize(10);

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.cId))
                {
                    //ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('传输参数不正确');", true);
                    return;
                }
                Manager model = GetManageInfo(); //取得管理员信息
                userBll = new BLL.Users();//实例化前台用户处理对象
                userModel = userBll.GetUserModel(model.ID);//获取前台用户信息
                if (userModel == null)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('传输参数不正确');history.go(-1);", true);
                    return;
                }
                uId = userModel.ID;//获取前台用户Id
                UserAvator.Src = string.IsNullOrEmpty(userModel.Avatar) ? "../../Web/CSS/avatar/239.png" : userModel.Avatar;
                if (!new HN863Soft.ISS.BLL.MeetingActivity().Exists(this.cId))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('记录不存在或已被删除');", true);

                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                BindData();
                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    GetData();
                }
                this.page = RequestHelper.GetQueryInt("page", 1);
                DataTable dtReply = GetRePlyInfo();
                dlReplyInfo.DataSource = dtReply.DefaultView;
                dlReplyInfo.DataBind();
                txtPageNum.Text = this.pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("ActiveAuditDetail.aspx?id=" + this.cId + "&", "action={0}&page={1}", "View", "__id__");
                PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
            }
        }

        #endregion

        #region 保存

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('先说点什么吧');", true);
                return;
            }
            if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
            {
                //ChkManageLevel("ActiveList", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('保存过程中发生错误');", true);
                    return;
                }
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = cId.ToString();//问题信息Id
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('发表信息成功');", true);
                Response.Redirect(Utils.CombUrlTxt("ActiveAuditDetail.aspx", "action={0}&id={1}", keys));
            }
        }

        #endregion

        #region 检索类型绑定
        private void BindData()
        {
            ddlType.Items.Add(new ListItem("所有回复", "-1"));
            ddlType.Items.Add(new ListItem("只显示得分回复", "0"));
            ddlType.DataBind();
        }
        #endregion

        #region 回复信息删除

        protected void dlReplyInfo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int id = int.Parse(dlReplyInfo.DataKeys[e.Item.ItemIndex].ToString());//获取回复信息Id
            activeBll = new BLL.ActiveReply();//实例化问题回复信息处理对象
            TextBox txtbox = e.Item.FindControl("txtReward") as TextBox;
            switch (e.CommandName)
            {
                case "Delete":

                    activeModel = new Model.ActiveReply
                    {
                        IsVis = 0,   //是否隐藏：0，是；1，否。
                        Id = id     //评论信息ID
                    };
                    string[] keys = new string[2];
                    keys[0] = action;//提交方式
                    keys[1] = this.cId.ToString();//问题信息Id
                    if (activeBll.UpdateIsVis(activeModel))//删除对应Id的回复信息
                    {
                        AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除评论"); //记录日志
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('删除信息成功');", true);
                        //ShowMsgHelper.ShowScript("showWarningMsg('删除信息成功！');setTimeout(Back, 3000);");
                        Response.Redirect(Utils.CombUrlTxt("ActiveAuditDetail.aspx", "action={0}&id={1}", keys));
                    }
                    break;
                case "Reward":
                    SetRewardTxtBox(e.Item.ItemIndex);
                    break;
                case "btnOk"://设定积分值
                    int score;
                    if (!int.TryParse(txtbox.Text.Trim(), out score))
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('输入字符格式不正确');", true);
                        return;
                    }
                    string strWhere = "MeetingId=" + mId;
                    if (score + activeBll.GetSum(strWhere) > reward)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('积分设定额已超上限');", true);
                        return;
                    }

                    activeModel = new ActiveReply
                    {
                        Id = id,
                        Score = score
                    };
                    if (!activeBll.UpdateScore(activeModel))
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('保存过程中发生错误');", true);
                        return;
                    }
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "showWarningMsg", "showWarningMsg('设定成功');", true);
                    EventArgs r = new EventArgs();
                    txtPageNum_TextChanged(source, r);
                    break;
                case "btnCancel"://取消
                    Button btnOks = e.Item.FindControl("btnOk") as Button;
                    Button btnCancels = e.Item.FindControl("btnCancel") as Button;
                    txtbox.Visible = false;
                    btnOks.Visible = false;
                    btnCancels.Visible = false;
                    break;
            }
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
                    Utils.WriteCookie("ActiveDetail_audit_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ActiveAuditDetail.aspx", "action={0}&id={1}", "View", this.cId.ToString()));
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
            //string name= Enum.GetName(typeof(EnumsHelper.ForumLevel), 1);
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
            if (meetingModel != null)
            {
                lblPoint.InnerText = meetingModel.Reward.ToString();//悬赏积分
                lblTitle.InnerText=meetingModel.Title;//标题
                Dcontent.InnerHtml = meetingModel.Content;//内容
                reward = (int)(meetingModel.Reward);//悬赏积分
                mId = meetingModel.Id;//难题Id
            }
            txtPageNum.Text = this.pageSize.ToString();
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            activeModel = new Model.ActiveReply//实例化问题回复信息实体对象
            {
                Content = txtContent.InnerText,//评论内容
                UId = uId,//评论人
                IsVis = 1,//是否被隐藏：0，是；1，否。
                MeetingId = Convert.ToInt32(Request["Id"]),//服务Id
                CreateTime = DateTime.Now,//评论时间
                Score = 0,//得分
                ParentId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id

            };
            activeBll = new BLL.ActiveReply();//实例化问题回复信息处理对象
            //添加评论信息
            if (activeBll.Add(activeModel) != -1)
            {
                userBll = new BLL.Users();
                userBll.UpLevel(uId, EnumsHelper.UserUpLevel.CommentExp);//更新用户经验值
                userBll.UpPoint(uId, EnumsHelper.ActionEnum.Add, 2);//回复评论积分更新
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加评论:" + lblTitle.InnerText); //记录日志
                txtContent.InnerText = string.Empty;//赋空值
                txtId.Value = string.Empty;
                return true;
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
            if (int.TryParse(Utils.GetCookie("ActiveDetail_audit_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        /// <summary>
        /// 设置悬赏文本框显示方式
        /// </summary>
        /// <param name="itemIndex"></param>
        private void SetRewardTxtBox(int itemIndex)
        {
            foreach (DataListItem drv in dlReplyInfo.Items)
            {
                TextBox txtbox = drv.FindControl("txtReward") as TextBox;
                Button btnOks = drv.FindControl("btnOk") as Button;
                Button btnCancels = drv.FindControl("btnCancel") as Button;
                if (drv.ItemIndex == itemIndex)
                {

                    btnOks.Visible = true;
                    btnCancels.Visible = true;
                    txtbox.Visible = true;
                }
                else
                {
                    btnOks.Visible = false;
                    btnCancels.Visible = false;
                    txtbox.Visible = false;
                }
            }
        }

        #endregion

        #region 检索

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtReply = GetRePlyInfo();
            dtReply.DefaultView.RowFilter = ddlType.SelectedValue == "-1" ? "" : "Score>0";
            dlReplyInfo.DataSource = dtReply.DefaultView;
            dlReplyInfo.DataBind();
        }
        #endregion
    }
}