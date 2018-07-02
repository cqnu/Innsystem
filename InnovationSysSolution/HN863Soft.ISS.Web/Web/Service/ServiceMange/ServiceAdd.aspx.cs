using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Common;
//******************************
//*文件名：ServiceAdd.cs
//*作者：雷登辉
//*功能：提供服务信息添加功能
//*创建时间：2017/2/16
//******************************
namespace HN863Soft.ISS.Web.Service.ServiceMange
{
    public partial class ServiceAdd : System.Web.UI.Page
    {
        #region 函数
        HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体对象
        HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象
        
        #endregion

        #region 方法
        
        #endregion

        #region 事件

        /// <summary>
        /// 画面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            serviceBll = new BLL.ServiceInfo();//实例化服务信息处理对象
            //实例化服务信息对象
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo
            {
                Content = txtContent.InnerText,//服务内容
                //PublisherId=Request[],//登陆者Id
                CreatTime = DateTime.Now,//创建时间
                Remarks = "新建服务",//备注
                Title = txtTitle.InnerText,//标题
                Visite = 1//是否隐藏：0：是，1：否
            };
            int result = serviceBll.Add(serviceModel);//插入并返回主ID值
            if (result == -1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('新增异常')", true);
                return;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('添加成功'); window.location.href='ServiceMange.aspx'", true);//添加成功跳转页面
        } 
        #endregion
    }
}