using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*************************
//*文件名：ServiceMange.cs
//*作者：雷登辉
//*功能：展示服务信息列表并提供快捷导航
//*创建时间：2017/2/17
//*************************
namespace HN863Soft.ISS.Web.Service.ServiceMange
{
    public partial class ServiceMange : System.Web.UI.Page
    {
        #region 函数

        HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象
        HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体对象 

        #endregion

        #region 方法

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            serviceBll = new BLL.ServiceInfo();
            DataTable dt = serviceBll.GetList("Visite=1").Tables[0];
            dlService.DataSource = dt;
            dlService.DataBind();
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
            //页面第一次加载，绑定初始数据
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 新增服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceAdd.aspx");
        }

        /// <summary>
        /// 删除服务信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlService_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            //删除
            if (e.CommandName == "delete")
            {

                int id = int.Parse(dlService.DataKeys[e.Item.ItemIndex].ToString()); ;//获取服务信息Id
                serviceModel = new Model.ServiceInfo
                {
                    Id = id,
                    Visite = 0,//是否隐藏：0，是；1，否。
                };
                serviceBll = new BLL.ServiceInfo();//实例化服务信息处理对象
                //更新服务信息是否显示
                if (!serviceBll.UpdateInfo(serviceModel))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('服务器异常！')", true);
                    return;
                }
                BindData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('删除成功！')", true);
            }

        }
        #endregion
    }
}