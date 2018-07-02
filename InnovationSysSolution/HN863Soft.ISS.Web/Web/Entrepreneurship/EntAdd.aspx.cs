using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.BLL;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Core;
using System.Data;
using HN863Soft.ISS.Web.Common;
//******************************
//* 文件名：EntAdd.cs
//* 作者：雷登辉
//* 功能：问题发布
//* 创建时间：2017/2/28
//******************************
namespace HN863Soft.ISS.Web.Web.Entrepreneurship
{
    public partial class EntAdd : System.Web.UI.Page
    {
        #region 函数

        private HN863Soft.ISS.Model.ConductInfo conductModel;//服务信息实体对象
        private HN863Soft.ISS.BLL.ConductInfo conductBll;//服务信息处理对象


        #endregion

        #region 方法
        /// <summary>
        /// 绑定专家列表
        /// </summary>
        private void BindDDL()
        {
            BLL.Manager manager = new BLL.Manager();
            DataTable conductorDT = manager.GetList("").Tables[0];
            ddlConductor.DataSource = conductorDT;
            ddlConductor.DataTextField = "RealName";
            ddlConductor.DataValueField = "Id";
            ddlConductor.DataBind();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {

            conductBll = new BLL.ConductInfo();//实例化服务信息处理对象
            //Manager model = GetManageInfo(); //取得管理员信息

            //实例化服务信息对象
            conductModel = new HN863Soft.ISS.Model.ConductInfo
            {
                //Content = txtContent.InnerText,//服务内容
                Hot = 0,//新建疑问信息热度
                MId = Convert.ToInt32(ddlConductor.SelectedValue),
                Creator = 5,//登陆者Id
                CreateTime = DateTime.Now,//创建时间
                //Remarks = "新建创业辅导信息",//备注
                Title = txtContent.InnerText.Trim(),//标题
                IsVis = 0//是否通过：0，不通过；1，通过
            };
            int result = conductBll.Add(conductModel);//插入并返回主ID值
            if (result != -1)
            {
                //AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加指导信息:" + conductModel.Title); //记录日志
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
                BindDDL();
            }
        }

        /// <summary>
        /// 信息发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            if (!DoAdd())
            {
                //AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加指导信息:" + conductModel.Title); //记录日志
                ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                return;
            }
            ShowMsgHelper.ShowScript("showWarningMsg('添加成功！');setTimeout(Back, 3000);");
        }
        #endregion
    }
}