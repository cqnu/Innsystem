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
    public partial class TypeAdd : ManagePage
    {
        HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (bll.GetTypeNmae(txtRoleName.Text.Trim().ToString()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('该名称已存在，请重新填写！');");
                return;
            }




            if (bll.AddTypeName(txtRoleName.Text.Trim().ToString()))
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加角色类型"); //记录日志
                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/TypeList.aspx';");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('保存失败，请稍后重试！');");
            }

        }
    }
}