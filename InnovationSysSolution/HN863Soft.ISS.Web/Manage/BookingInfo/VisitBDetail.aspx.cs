using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Model;
//*****************************
//* 文件名：VisitBDetail.cs
//* 作者：雷登辉
//* 功能：预约详情查看
//* 创建时间：2017/3/6
//*****************************
namespace HN863Soft.ISS.Web.Manage.BookingInfo
{
    public partial class VisitBDetail : ManagePage
    {
        #region 函数

        protected static HN863Soft.ISS.Model.VisitBooking visitBModel;//参观预约信息实体
        private HN863Soft.ISS.BLL.VisitBooking visitBBll;//服务信息处理对象
        private int sId = 0;//服务信息Id
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
                    Response.Redirect("VisitBList.aspx");
                    return;
                }
                Manager model = GetManageInfo(); //取得管理员信息

                if (!new HN863Soft.ISS.BLL.VisitBooking().Exists(this.sId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    Response.Redirect("VisitBList.aspx");
                    return;
                }
            }
            if (!IsPostBack)
            {
                if (!ChkManageLevel("ChannelVisitBDList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    GetData(this.sId);
                }
            }
        }

        #region 数据绑定=================================

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="id">服务信息Id</param>
        private void GetData(int id)
        {
            visitBBll = new HN863Soft.ISS.BLL.VisitBooking();//实例化服务信息处理对象
           
            visitBModel = visitBBll.GetModel(sId);

            txtName.Text = visitBModel.Name;//姓名
            txtName.Enabled = false;
            txtNum.Text = visitBModel.VisitNum.ToString();//人数
            txtNum.Enabled = false;
            txtPhone.Text = visitBModel.Phone;//联系电话
            txtPhone.Enabled = false;
            txtExp.Text = visitBModel.Remark;//简介
            txtExp.Enabled = false;
            txtEmail.Text = visitBModel.Email;//邮箱
            txtEmail.Enabled = false;
            txtVisDate.Text = DateTime.Parse(visitBModel.VisitDate.ToString()).ToString("yyyy年MM月dd日");//参观日期
            txtVisDate.Enabled = false;
        }
       
        #endregion
    }
}