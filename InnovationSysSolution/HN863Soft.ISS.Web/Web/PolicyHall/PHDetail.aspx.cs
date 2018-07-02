using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Web.PolicyHall
{
    public partial class PHDetail : System.Web.UI.Page
    {
        #region 函数

        protected HN863Soft.ISS.Model.CrawlerInfo crawlerModel;//问题信息实体
        private HN863Soft.ISS.BLL.CrawlerInfo crawlerBll;//问题信息处理对象

        #endregion

        #region 页面初始化

        protected void Page_Load(object sender, EventArgs e)
        {

            string infoId = RequestHelper.GetQueryString("Id");

            if (!Page.IsPostBack)
            {
                GetData(infoId);
            }
        }
        #endregion

        #region 数据绑定=================================

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="id">问题信息Id</param>
        private void GetData(string id)
        {
            crawlerBll = new HN863Soft.ISS.BLL.CrawlerInfo();//实例化问题信息处理对象
            if (string.IsNullOrEmpty(id) || id == "0")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('参数不正确！');history.go(-1);", true);
                return;
            }
            crawlerModel = crawlerBll.GetModel(int.Parse(id));
            this.DContent.InnerHtml = crawlerModel.CrawContent;
            //sType.InnerHtml = EnumsHelper.FetchDescription((EnumsHelper.ForumCategory)Enum.Parse(typeof(EnumsHelper.ForumCategory), crawlerModel.Type.ToString()));
            pTitle.InnerHtml = crawlerModel.Title;
            sCreateTime.InnerHtml = (DateTime.Parse(crawlerModel.CrawDate.ToString())).ToString("yyyy.MM.dd  hh:mm");
            DAddress.InnerHtml = "链接：<a target='_blank' href=\"" + crawlerModel.Url + "\">" + crawlerModel.Url + "</a>";
        }

        #endregion
    }
}