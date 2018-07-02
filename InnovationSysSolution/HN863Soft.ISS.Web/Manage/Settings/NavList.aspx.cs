using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class NavList : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                RptBind();
            }
        }

        //数据绑定
        private void RptBind()
        {
            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            DataTable dt = bll.GetList(0, EnumsHelper.NavigationEnum.System.ToString());
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "SortID=" + sortId.ToString());
            }
            AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "保存导航排序"); //记录日志
            //ShowScriptMsg("保存排序成功！", "NavList.aspx");
            ShowMsgHelper.ShowScript("location.href='/Manage/Settings/NavList.aspx';");
        }

        //删除导航
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("SysNavigation", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除导航菜单"); //记录日志
            //ShowScriptMsg("删除数据成功！", "NavList.aspx", "parent.loadMenuTree");
            ShowMsgHelper.ShowScript("location.href='/Manage/Settings/NavList.aspx';");
        }
    }
}