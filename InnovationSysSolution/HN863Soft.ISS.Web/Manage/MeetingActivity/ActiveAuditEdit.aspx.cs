using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.MeetingActivity
{
    public partial class ActiveAuditEdit : ManagePage
    {
        #region 函数
        //string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private HN863Soft.ISS.Model.MeetingActivity meetingAcModel;//服务信息实体对象
        private HN863Soft.ISS.BLL.MeetingActivity meetingAcBll;//服务信息处理对象
        private int id = 0;
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    ShowMsgHelper.ShowScript("location.href='/Manage/MeetingActivity/ActiveAuditList.aspx';");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.MeetingActivity().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    ShowMsgHelper.ShowScript("location.href='/Manage/MeetingActivity/ActiveAuditList.aspx';");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelActiveAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    this.txtReword.ReadOnly = true;//只读
                    ShowInfo(this.id);
                }
            }
        }
        #endregion

        #region 绑定任务分类

        /// <summary>
        /// 绑定任务分类
        /// </summary>
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            foreach (EnumsHelper.ForumCategory item in Enum.GetValues(typeof(EnumsHelper.ForumCategory)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }

        #endregion

        #region 上传图片


        #endregion


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            meetingAcBll = new HN863Soft.ISS.BLL.MeetingActivity();//实例化服务信息处理对象
            meetingAcModel = new HN863Soft.ISS.Model.MeetingActivity();//实例化服务信息实体对象
            meetingAcModel = meetingAcBll.GetModel(id);//获取对应Id的服务信息实体对象
            txtContent.InnerText = meetingAcModel.Content;//难题问题描述
            txtTitle.Text = meetingAcModel.Title;//难题问题标题
            ddlType.SelectedValue = meetingAcModel.Type.ToString();//任务类型
            txtReword.Text = meetingAcModel.Reward.ToString();//悬赏积分
            txtKeyWord.Text = meetingAcModel.KeyWord;//关键词
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            meetingAcBll = new BLL.MeetingActivity();//实例化服务信息处理对象
            BLL.Users user = new BLL.Users();//用户信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            Model.Users userModel = user.GetUserModel(model.ID);
            //实例化服务信息对象
            meetingAcModel = new HN863Soft.ISS.Model.MeetingActivity
            {
                Content = txtContent.InnerText,//服务内容
                CreatorId = userModel.ID,//登陆者Id
                CreateTime = DateTime.Now,//创建时间
                //Remarks = "新建服务",//备注
                Title = txtTitle.Text.Trim(),//标题
                IsVis = 0,//是否通过：0，不通过；1，通过
                Type = int.Parse(ddlType.SelectedValue),//任务类型
                Reward = int.Parse(txtReword.Text),//悬赏积分
                KeyWord = txtKeyWord.Text,
            };
            int result = meetingAcBll.Add(meetingAcModel);//插入并返回主ID值
            if (result != -1)
            {
                //更新经验值
                if (user.UpLevel(userModel.ID, EnumsHelper.UserUpLevel.QuestionRelease))
                {
                    user.UpPoint(userModel.ID, EnumsHelper.ActionEnum.Reduce, (int)meetingAcModel.Reward);
                    AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "发帖:" + meetingAcModel.Title + "获得经验值：" + EnumsHelper.UserUpLevel.QuestionRelease.GetValue() + "积分减少：" + meetingAcModel.Reward); //记录日志
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            meetingAcBll = new HN863Soft.ISS.BLL.MeetingActivity();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            meetingAcModel = new HN863Soft.ISS.Model.MeetingActivity//实例化服务信息实体对象并赋予值
            {
                Id = Convert.ToInt32(Request["Id"]),
                Content = txtContent.InnerText,//服务内容
                //CreatTime=,//发布时间
                //PublisherId=,//发布人
                //Remarks=,//备注
                Title = txtTitle.Text,//服务信息标题
                Type = int.Parse(ddlType.SelectedValue),//任务类型
                KeyWord = txtKeyWord.Text
                //Reward = int.Parse(txtReword.Text)//悬赏积分
                //IsVis = 0, //是否显示
            };
            //是否更新成功
            if (meetingAcBll.UpdateInfo(meetingAcModel)) //更新服务信息数据
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改服务:" + meetingAcModel.Title); //记录日志
                return true;
            }

            return false;
        }
        #endregion

        #region 保存按钮
        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()) || string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('标题、内容不能为空');");
                return;
            }

            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("ChannelActiveAuditList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('修改活动信息成功！');");
                ShowMsgHelper.ShowScript("location.href='/Manage/MeetingActivity/ActiveAuditList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("ChannelActiveAuditList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BLL.Users user = new BLL.Users();//用户信息处理对象
                Manager model = GetManageInfo(); //取得管理员信息
                Users userModel = user.GetUserModel(model.ID);

                if (userModel.Point < int.Parse(txtReword.Text))
                {
                    //ShowMsgHelper.ShowScript("showWarningMsg('积分已超出账户余额！余额剩余:" + userModel.Point + " 积分');setTimeout(Back, 3000);");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('添加活动信息成功！');");
                ShowMsgHelper.ShowScript("location.href='/Manage/MeetingActivity/ActiveAuditList.aspx';");
            }
        }
        #endregion
    }
}