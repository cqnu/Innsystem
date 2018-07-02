using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.BLL;
using HN863Soft.ISS.Model;
using System.Data;
//*****************************
//* 文件名：EntShow.cs
//* 作者：雷登辉
//* 功能：问题列表展示
//* 创建时间：2017/2/27
//*****************************
namespace HN863Soft.ISS.Web.Web.Entrepreneurship
{
    public partial class EntShow : System.Web.UI.Page
    {
        #region 方法

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        public void BindData()
        {
            BLL.ConductInfo conductBll = new BLL.ConductInfo();
            DataTable conductDT = conductBll.GetList("MId=7 and IsVis=1").Tables[0];
            dlEntShow.DataSource = conductDT;
            dlEntShow.DataBind();
        } 

        #endregion
        
        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

    }
}