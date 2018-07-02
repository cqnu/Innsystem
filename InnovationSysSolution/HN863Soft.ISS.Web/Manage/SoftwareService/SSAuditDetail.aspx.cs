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

namespace HN863Soft.ISS.Web.Manage.SoftwareService
{
    public partial class SSAuditDetail : ManagePage
    {
        #region 函数
        BLL.SoftwareS softsBll;
        Model.SoftwareS softsModel;

        private string action = EnumsHelper.ActionEnum.Add.ToString();//默认添加
        private static int id = 0;


        #endregion

        #region 初始化界面

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                //该信息是否存在
                if (!new HN863Soft.ISS.BLL.SoftwareS().Exists(id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }

            if (!IsPostBack)
            {
                if (!ChkManageLevel("ChannelSSAuditList", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindType();
                Manager model = GetManageInfo(); //取得用户信息
                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    BindData();
                }
            }
        }
        #endregion

        #region 绑定初始数据

        /// <summary>
        /// 绑定服务类型
        /// </summary>
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            foreach (EnumsHelper.SoftwareServiceType item in Enum.GetValues(typeof(EnumsHelper.SoftwareServiceType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            softsBll = new BLL.SoftwareS();
            softsModel = softsBll.GetModel(id);
            if (softsModel != null)
            {
                ddlType.SelectedValue = softsModel.Type.ToString();//服务类型
                ddlType.Enabled = false;
                txtTitle.Text = softsModel.SName;//服务名称
                txtTitle.Enabled = false;
                txtContent.InnerHtml = softsModel.SIntroduction;//服务名称
                txtContent.Disabled = true;
                txaExample.InnerHtml = softsModel.Example;//成功案例
                txaExample.Disabled = true;
                txtPhone.Text = softsModel.Phone;//联系电话
                txtPhone.Enabled = false;
                txaIntroduction.InnerHtml = softsModel.TeamIntroduction;//团队介绍
                txaIntroduction.Disabled = true;
                Image1.ImageUrl = softsModel.LogImg;//图片路径
                txtIntroduce.Text = softsModel.Introduce;//简介
                txtKeyWord.Text = softsModel.KeyWord;//关键词
            }
        }

        #endregion
    }
}