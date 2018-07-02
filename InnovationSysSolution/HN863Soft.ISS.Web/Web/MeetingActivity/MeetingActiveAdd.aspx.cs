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

namespace HN863Soft.ISS.Web.Web.MeetingActivity
{
    public partial class MeetingActiveAdd : Page
    {
        #region 页面初始化
        public HN863Soft.ISS.Model.Users model = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            
            if (!Page.IsPostBack)
            {
                if (Session[KeysHelper.ForegroundUser] != null)
                {
                    model = (Users)Session[KeysHelper.ForegroundUser];
                }
                
                BindType();
            }
        }
        #endregion

        #region 绑定任务分类

        /// <summary>
        /// 绑定任务分类
        /// </summary>
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            foreach (EnumsHelper.ForumCategory item in Enum.GetValues(typeof(EnumsHelper.ForumCategory)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }

        #endregion
    }
}