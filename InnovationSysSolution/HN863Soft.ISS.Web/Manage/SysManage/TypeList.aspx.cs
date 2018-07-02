using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.SysManage
{
    public partial class TypeList : ManagePage
    {

        protected string keywords = string.Empty;
        List<HN863Soft.ISS.Model.ManagerRole> models = new List<ManagerRole>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ManagerRole", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

             
                RptBind( CombSqlTxt(this.keywords));
            }
        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere)
        {
            this.txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            this.rptList.DataSource = bll.GetTypeList(_strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and TypeName like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        #endregion



        //查询操作
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TypeList.aspx", "keywords={0}", txtKeywords.Text.Trim()));
        }


    }
}