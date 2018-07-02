using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.SysManage
{
    public partial class RoleEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.ManagerRole().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('角色不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ManagerRole", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                RoleTypeBind(); //绑定角色类型
                NavBind(); //绑定导航
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleTypeBind()
        {
            Manager manager = GetManageInfo();

            HN863Soft.ISS.BLL.ManagerRole manageRoleBll = new HN863Soft.ISS.BLL.ManagerRole();
            DataSet dsTypes = manageRoleBll.GetTypeList("");

            ddlRoleType.Items.Clear();
            ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
            List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
            if (dsTypes == null)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('请先添加角色类型！');");
                return;
            }
            else
            {
                for (int i = 0; i < dsTypes.Tables[0].Rows.Count; i++)
                {
                    managerTypeList.Add(new ManagerType() { ID = int.Parse(dsTypes.Tables[0].Rows[i]["ID"].ToString()), TypeName = dsTypes.Tables[0].Rows[i]["TypeName"].ToString(), IsSys = int.Parse(dsTypes.Tables[0].Rows[i]["IsSys"].ToString()) });
                }

                var managerTypeItem = managerTypeList.FirstOrDefault(x=>x.ID == manager.RoleType);
                if(managerTypeItem != null)
                {
                    if (managerTypeItem.TypeName == "管理员")
                    {
                        foreach(var item in managerTypeList)
                        {
                            ddlRoleType.Items.Add(new ListItem(item.TypeName, item.ID.ToString()));
                        }
                    }
                    else if (managerTypeItem.TypeName == "版主")
                    {
                        foreach(var item in managerTypeList)
                        {
                            if (item.TypeName == "管理员")
                                continue ;

                            ddlRoleType.Items.Add(new ListItem(item.TypeName, item.ID.ToString()));
                        }
                    }
                    else
                    {
                        foreach(var item in managerTypeList)
                        {
                            if (item.TypeName == "管理员" || item.TypeName == "版主")
                                continue ;

                            ddlRoleType.Items.Add(new ListItem("",""));
                        }
                    }
                }
            }
        }
        #endregion

        #region 导航菜单=================================
        private void NavBind()
        {
            HN863Soft.ISS.BLL.Navigation bll = new HN863Soft.ISS.BLL.Navigation();
            DataTable dt = bll.GetList(0, EnumsHelper.NavigationEnum.System.ToString());
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            ManagerRole model = bll.GetModel(_id);
            txtRoleName.Text = model.RoleName;
            ddlRoleType.SelectedValue = model.RoleType.ToString();
            //管理权限
            if (model.ManagerRoleValues != null)
            {
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                    CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                    for (int n = 0; n < cblActionType.Items.Count; n++)
                    {
                        ManagerRoleValue modelt = model.ManagerRoleValues.Find(p => p.NavName == navName && p.ActionType == cblActionType.Items[n].Value);
                        if (modelt != null)
                        {
                            cblActionType.Items[n].Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            ManagerRole model = new ManagerRole();
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();

            model.RoleName = txtRoleName.Text.Trim();
            model.RoleType = int.Parse(ddlRoleType.SelectedValue);

            //管理权限
            List<ManagerRoleValue> ls = new List<ManagerRoleValue>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    if (cblActionType.Items[n].Selected == true)
                    {
                        ls.Add(new ManagerRoleValue { NavName = navName, ActionType = cblActionType.Items[n].Value });
                    }
                }
            }
            model.ManagerRoleValues = ls;

            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加用户角色:" + model.RoleName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            ManagerRole model = bll.GetModel(_id);

            model.RoleName = txtRoleName.Text.Trim();
            model.RoleType = int.Parse(ddlRoleType.SelectedValue);

            //管理权限
            List<ManagerRoleValue> ls = new List<ManagerRoleValue>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    if (cblActionType.Items[n].Selected == true)
                    {
                        ls.Add(new ManagerRoleValue { RoleID = _id, NavName = navName, ActionType = cblActionType.Items[n].Value });
                    }
                }
            }
            model.ManagerRoleValues = ls;

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改用户角色:" + model.RoleName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //美化导航树结构
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
                //绑定导航权限资源
                string[] actionTypeArr = ((HiddenField)e.Item.FindControl("hidActionType")).Value.Split(',');
                CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
                cblActionType.Items.Clear();
                for (int i = 0; i < actionTypeArr.Length; i++)
                {
                    if (Utils.ActionType().ContainsKey(actionTypeArr[i]))
                    {
                        cblActionType.Items.Add(new ListItem(" " + Utils.ActionType()[actionTypeArr[i]] + " ", actionTypeArr[i]));
                    }
                }
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Manager model = GetManageInfo();
            //获取权限列表
            bool isSys = false;
            HN863Soft.ISS.BLL.ManagerRole manageRoleBll = new HN863Soft.ISS.BLL.ManagerRole();
            var tempData = manageRoleBll.GetList(" ID=" + model.RoleID);
            if (tempData != null)
            {
                DataTable dt = tempData.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][3].ToString() == "1")
                    {
                        isSys = true;
                    }
                }
            }
           
            
            if (model.RoleType < 2)
            {
                if (isSys && id == 1)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('超级管理员权限不能修改！');");
                    return;
                }
            }

            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("manager_role", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/RoleList.aspx';");
            }
            else //添加
            {
                ChkManageLevel("manager_role", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/RoleList.aspx';");
            }
        }
    }
}