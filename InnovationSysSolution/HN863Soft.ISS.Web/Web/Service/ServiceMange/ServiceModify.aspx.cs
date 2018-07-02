using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//********************************
//*文件名：ServiceModify.cs
//*作者：雷登辉
//*功能：修改服务信息
//*创建时间：2017/2/17
//********************************
namespace _863soft.ISS.Web.Service.ServiceMange
{
    public partial class ServiceModify : System.Web.UI.Page
    {
        #region 函数

        private HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象
        private HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体对象 
        #endregion

        #region 方法

        /// <summary>
        /// 获取服务信息实体对象信息
        /// </summary>
        /// <param name="id"></param>
        private void GetServiceModel(int id)
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();//实例化服务信息处理对象
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo();//实例化服务信息实体对象
            serviceModel = serviceBll.GetModel(id);//获取对应Id的服务信息实体对象
            txtContent.InnerText = serviceModel.Content;//服务内容
            txtTitle.InnerText = serviceModel.Title;//服务标题
        } 
        #endregion

        #region 事件
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取服务信息Id
                GetServiceModel(Convert.ToInt32(Request["Id"]));
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();//实例化服务信息处理对象
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo//实例化服务信息实体对象并赋予值
            {
                Id = Convert.ToInt32(Request["Id"]),
                Content = txtContent.InnerText,//服务内容
                //CreatTime=,//发布时间
                //PublisherId=,//发布人
                //Remarks=,//备注
                Title = txtTitle.InnerText,//服务信息标题
                Visite = 1, //是否显示
            };
            //是否更新成功
            if (!serviceBll.UpdateCondition(serviceModel)) //更新服务信息数据
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('更新异常')", true);
                return;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('更新成功');window.location.href='ServiceMange.aspx'", true);

        } 
        #endregion
    }
}