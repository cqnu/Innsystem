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

namespace HN863Soft.ISS.Web.Manage.SysManage
{
    public partial class TypeEdit : ManagePage
    {
        private static string Name = "";

        private static int type=0;

        HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.Params["id"]);
                ViewState["id"] = id;
                ShowInfo(id);
            }
        }

        private void ShowInfo(int id)
        {
          
            
            Name = bll.GetT(id);
            txtRoleName.Text = Name;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Name != txtRoleName.Text.Trim().ToString())
            {
                if (bll.GetTypeNmae(txtRoleName.Text.Trim().ToString()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('该名称已存在，请重新填写！');");
                    return;
                }
            }


            if (bll.UpdateType(int.Parse(ViewState["id"].ToString()), txtRoleName.Text.Trim().ToString()))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改角色类型"); //记录日志
                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/TypeList.aspx';");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('保存失败，请稍后重试！');");
            }

        }
    }
}