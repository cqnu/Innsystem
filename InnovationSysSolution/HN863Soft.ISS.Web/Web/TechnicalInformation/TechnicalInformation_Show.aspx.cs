using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Show.cs
// 作者（Author）：邹峰
// 功能（Function）：显示详细技术信息资源
// 创建日期（Create Date）：2017/02/16
//*****************************
namespace HN863Soft.ISS.Web.TechnicalInformation
{
    public partial class Show : Page
    {
        #region 变量

        public string strid = "";
        public string stra;
        public string strInstitutionalDisplay;

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int ID = (Convert.ToInt32(strid));
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();
            HN863Soft.ISS.Model.TechnicalInformation model = bll.GetModel(ID);
            //插入浏览次数
            bll.AddHits(ID);
            this.lblEntryName.InnerText = model.EntryName;
            this.lblKeyword.InnerText = model.Keyword;
            stra = model.DetailedContent;
            strInstitutionalDisplay = model.Institutionaldisplay;
            if (strInstitutionalDisplay != "")
            {
                //strInstitutionalDisplay = strInstitutionalDisplay.Replace("<img title=", "<img  width='600px' height='300px' ");
                strInstitutionalDisplay = strInstitutionalDisplay.Replace("alt=", "");
                strInstitutionalDisplay = strInstitutionalDisplay.Replace("title=", "");
                strInstitutionalDisplay = strInstitutionalDisplay.Replace("<p>", "");
                strInstitutionalDisplay = strInstitutionalDisplay.Replace("</p>", "");
            }
        }

        #endregion

    }
}
