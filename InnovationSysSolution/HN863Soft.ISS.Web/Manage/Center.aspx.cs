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

namespace HN863Soft.ISS.Web.Manage
{
    public partial class Center : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.Manager manageInfo = GetManageInfo(); //管理员信息

                HN863Soft.ISS.BLL.Organization orgBll = new BLL.Organization();
                HN863Soft.ISS.Model.Organization orgModel = orgBll.GetModelByUserID(manageInfo.ID);

                StringBuilder sbInfo = new StringBuilder();
                StringBuilder sbFunctions = new StringBuilder();
                //登录信息
                if (manageInfo != null)
                {
                    //非管理用户，没有完善资料
                    if (!ChkManageType())
                    {
                        if (orgModel == null)
                        {
                            sbInfo.Append("<li><span style ='color:red'>您的机构信息未完善，请完善后再来！</span></li>");
                            div_showinfo.InnerHtml = sbInfo.ToString();

                            div_function_manage.Visible = false;
                            div_system_manage.Visible = false;
                        }
                        else
                        {
                            if (orgModel.State == 1)
                            {
                                sbInfo.Append("<li><span style ='color:red'>您的机构信息未审核，请耐心等待！</span></li>");
                                div_showinfo.InnerHtml = sbInfo.ToString();

                                div_function_manage.Visible = false;
                                div_system_manage.Visible = false;
                            }
                            else if (orgModel.State == 2)
                            {
                                sbInfo.Append("<li><span style ='color:red'>您的机构信息审核未通过，请先修改完善您的资料！</span></li>");
                                div_showinfo.InnerHtml = sbInfo.ToString();

                                div_function_manage.Visible = false;
                                div_system_manage.Visible = false;
                            }
                            else if (orgModel.State == 3)
                            {
                                sbInfo.Append("<li><span style ='color:red'>" + manageInfo.RealName + ":欢迎您的光临！</span></li>");
                                div_showinfo.InnerHtml = sbInfo.ToString();

                                //填充菜单
                                ManagerRole roleModel = new HN863Soft.ISS.BLL.ManagerRole().GetModel(manageInfo.RoleID); //获得用户角色信息
                                if (roleModel == null)
                                {
                                    return;
                                }

                                List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
                                DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
                                if (dsManagerTypes != null)
                                {
                                    for (int i = 0; i < dsManagerTypes.Tables[0].Rows.Count; i++)
                                    {
                                        managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[i]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[i]["IsSys"].ToString()) });
                                    }
                                }

                                DataTable dt = new HN863Soft.ISS.BLL.Navigation().GetList(0, EnumsHelper.NavigationEnum.System.ToString());//获取菜单根目录

                                DataRow[] dr = dt.Select("ParentID=0");
                                Dictionary<string, int> dicMenu = new Dictionary<string, int>();
                                ShowMessageInfo info = new ShowMessageInfo();
                                List<ShowMessageInfo> list = new List<ShowMessageInfo>();

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    bool isActionPass = GetMenuInfo(dr[i], manageInfo.RoleType, roleModel, managerTypeList);
                                    
                                    //如果有该权限则添加到字典中
                                    if (isActionPass)
                                    {
                                        DataRow[] tempMenuItem = dt.Select("ParentID=" + dr[i]["ID"]);
                                        for (int j = 0; j < tempMenuItem.Length; j++)
                                        {
                                            bool tempIsActionPass = GetMenuInfo(tempMenuItem[j], manageInfo.RoleType, roleModel, managerTypeList);
                                            if (tempIsActionPass)
                                            {
                                                if (string.IsNullOrEmpty(tempMenuItem[j]["LinkUrl"].ToString()))
                                                {
                                                    dicMenu.Add(tempMenuItem[j]["ID"].ToString(), i);
                                                }
                                                else
                                                {
                                                    info = new ShowMessageInfo();
                                                    string str = tempMenuItem[j]["SubTitle"].ToString();
                                                    info.No = (str == "功能管理" ? 0 : str == "系统管理" ? 1 : 2);
                                                    info.Name = tempMenuItem[j]["Name"].ToString();
                                                    info.Title = tempMenuItem[j]["Title"].ToString();
                                                    info.ImgUrl = tempMenuItem[j]["IconUrl"].ToString();

                                                    list.Add(info);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dr[i]["SubTitle"].ToString() == "个人中心")
                                        {
                                            info = new ShowMessageInfo();
                                            string str = dr[i]["SubTitle"].ToString();
                                            info.No = (str == "功能管理" ? 0 : str == "系统管理" ? 1 : 2);
                                            info.Name = dr[i]["Name"].ToString();
                                            info.Title = dr[i]["Title"].ToString();
                                            info.ImgUrl = dr[i]["IconUrl"].ToString();

                                            list.Add(info);
                                        }
                                    }
                                }

                                //循环展示出来
                                foreach (var item in dicMenu)
                                {
                                    DataRow[] tempDR = dt.Select("ParentID=" + item.Key);

                                    for (int k = 0; k < tempDR.Length; k++)
                                    {
                                        //检查是否显示在界面上====================
                                        bool tempIsActionPass = GetMenuInfo(tempDR[k], manageInfo.RoleType, roleModel, managerTypeList);
                                        //如果有该权限则添加
                                        if (tempIsActionPass)
                                        {
                                            info = new ShowMessageInfo();
                                            string str = tempDR[k]["SubTitle"].ToString();
                                            info.No = (str == "功能管理" ? 0 : str == "系统管理" ? 1 : 2);
                                            info.Name = tempDR[k]["Name"].ToString();
                                            info.Title = tempDR[k]["Title"].ToString();
                                            info.ImgUrl = tempDR[k]["IconUrl"].ToString();

                                            list.Add(info);
                                        }
                                    }
                                }

                                StringBuilder sb0 = new StringBuilder();
                                StringBuilder sb1 = new StringBuilder();
                                StringBuilder sb2 = new StringBuilder();
                                int menu0 = 0;
                                int menu1 = 0;
                                int menu2 = 0;
                                foreach (var tempvalue in list)
                                {
                                    //填充菜单
                                    if (tempvalue.No == 0)
                                    {
                                        menu0++;
                                        sb0.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\"  style='width:100%;background: url(skin/default/" + tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");                                        
                                    }
                                    else if (tempvalue.No == 1)
                                    {
                                        menu1++;
                                        sb1.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\"  style='width:100%;background: url(skin/default/" + tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");                                       
                                    }
                                    else if (tempvalue.No == 2)
                                    {
                                        menu2++;
                                        sb2.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\"  style='width:100%;background: url(skin/default/" + tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");
                                    }
                                }

                                if (menu0 == 0)
                                {
                                    div_function_manage.Visible = false;
                                }

                                if (menu1 == 0)
                                {
                                    div_system_manage.Visible = false;
                                }

                                if (menu2 == 0)
                                {
                                    div_person.Visible = false;
                                }

                                div_firstfunctionlist.InnerHtml = sb0.ToString();
                                div_secondfunctionlist.InnerHtml = sb1.ToString();
                                div_threedfunctionlist.InnerHtml = sb2.ToString();
                            }
                            else
                            {
                                sbInfo.Append("<li><span style ='color:red'>您的机构信息未完善，请完善后再来！</span></li>");
                                div_showinfo.InnerHtml = sbInfo.ToString();
                            }
                        }

                        //填充菜单
                        sbFunctions.Append("<li><a onclick=\"parent.linkMenuTree(true, 'user_list');\" style='width:100%;background: url(skin/default/User.png) no-repeat #fff;' href='javascript:;'></a><span>个人信息</span></li>");
                        sbFunctions.Append("<li><a onclick=\"parent.linkMenuTree(true, 'user_log');\"style='width:100%;background: url(skin/default/Notes.png) no-repeat #fff;' href='javascript:;'></a><span>个人日志</span></li>");
                        sbFunctions.Append("<li><a onclick=\"parent.linkMenuTree(true, 'ChannelOrganizationEdit');\" style='width:100%;background: url(skin/default/Owner.png) no-repeat #fff;' href='javascript:;'></a><span>完善资料</span></li>");
                        div_threedfunctionlist.InnerHtml = sbFunctions.ToString();
                        return;
                    }
                    else
                    {
                        //管理用户
                        sbInfo.Append("<li><span style ='color:red'>" + manageInfo.RealName + ":欢迎您的光临！</span></li>");
                        div_showinfo.InnerHtml = sbInfo.ToString();

                        //填充菜单

                        //填充菜单
                                ManagerRole roleModel = new HN863Soft.ISS.BLL.ManagerRole().GetModel(manageInfo.RoleID); //获得用户角色信息
                                if (roleModel == null)
                                {
                                    return;
                                }

                                List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
                                DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
                                if (dsManagerTypes != null)
                                {
                                    for (int i = 0; i < dsManagerTypes.Tables[0].Rows.Count; i++)
                                    {
                                        managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[i]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[i]["IsSys"].ToString()) });
                                    }
                                }
                                
                                DataTable dt = new HN863Soft.ISS.BLL.Navigation().GetList(0, EnumsHelper.NavigationEnum.System.ToString());//获取菜单根目录

                                DataRow[] dr = dt.Select("ParentID=0");
                                Dictionary<string, int> dicMenu = new Dictionary<string, int>();
                                ShowMessageInfo info = new ShowMessageInfo();
                                List<ShowMessageInfo> list = new List<ShowMessageInfo>();

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    bool isActionPass = GetMenuInfo(dr[i], manageInfo.RoleType, roleModel, managerTypeList);
                                    
                                    //如果有该权限则添加到字典中
                                    if (isActionPass)
                                    {

                                        DataRow[] tempMenuItem = dt.Select("ParentID=" + dr[i]["ID"]);
                                        for (int j = 0; j < tempMenuItem.Length; j++)
                                        {
                                            bool tempIsActionPass = GetMenuInfo(tempMenuItem[j], manageInfo.RoleType, roleModel, managerTypeList);
                                            if (tempIsActionPass)
                                            {
                                                if (string.IsNullOrEmpty(tempMenuItem[j]["LinkUrl"].ToString()))
                                                {
                                                    dicMenu.Add(tempMenuItem[j]["ID"].ToString(),i);
                                                }
                                                else
                                                {
                                                    info = new ShowMessageInfo();
                                                    string str = tempMenuItem[j]["SubTitle"].ToString();
                                                    info.No = (str == "功能管理" ? 0 : str == "系统管理" ? 1 : 2);
                                                    info.Name = tempMenuItem[j]["Name"].ToString();
                                                    info.Title = tempMenuItem[j]["Title"].ToString();
                                                    info.ImgUrl = tempMenuItem[j]["IconUrl"].ToString();

                                                    list.Add(info);
                                                }
                                            }
                                        }
                                    }
                                }

                                //循环展示出来
                                foreach (var item in dicMenu)
                                {
                                    DataRow[] tempDR = dt.Select("ParentID=" + item.Key);

                                    for (int k = 0; k < tempDR.Length; k++)
                                    {
                                        //检查是否显示在界面上====================
                                        bool tempIsActionPass = GetMenuInfo(tempDR[k], manageInfo.RoleType, roleModel, managerTypeList);
                                        //如果有该权限则添加
                                        if (tempIsActionPass)
                                        {
                                            info = new ShowMessageInfo();
                                            info.No = item.Value;
                                            info.Name = tempDR[k]["Name"].ToString();
                                            info.Title = tempDR[k]["Title"].ToString();
                                            info.ImgUrl = tempDR[k]["IconUrl"].ToString();

                                            list.Add(info);
                                        }
                                    }
                                }

                                StringBuilder sb0 = new StringBuilder();
                                StringBuilder sb1 = new StringBuilder();
                                StringBuilder sb2 = new StringBuilder();
                                foreach (var tempvalue in list)
                                {
                                    //填充菜单
                                    if (tempvalue.No == 0)
                                    {
                                        sb0.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\" style='width:100%;background: url(skin/default/" +  tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");
                                    }
                                    else if (tempvalue.No == 1)
                                    {
                                        sb1.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\" style='width:100%;background: url(skin/default/" + tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");
                                    }
                                    else if (tempvalue.No == 2)
                                    {
                                        sb2.Append("<li><a onclick=\"parent.linkMenuTree(true, '" + tempvalue.Name + "');\" style='width:100%;background: url(skin/default/" + tempvalue.ImgUrl + ") no-repeat #fff;' href='javascript:;'></a><span>" + tempvalue.Title + "</span></li>");
                                    }
                                }
                                div_firstfunctionlist.InnerHtml = sb0.ToString();
                                div_secondfunctionlist.InnerHtml = sb1.ToString();
                                div_threedfunctionlist.InnerHtml = sb2.ToString();
                    }
                }
                else
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('登录无效，请重新登录！');");
                    ShowMsgHelper.ShowScript("location.href='/Manage/Login.aspx';");
                }
            }
        }

        //菜单是否显示
        private bool GetMenuInfo(DataRow dr,int roleType,ManagerRole roleModel,List<HN863Soft.ISS.Model.ManagerType> list)
        {
            //检查是否显示在界面上====================
            bool isActionPass = true;

            var tempManagerType = list.FirstOrDefault(x => x.ID == roleType);
            if (tempManagerType != null)
            {
                if (tempManagerType.TypeName == "管理员" || tempManagerType.TypeName == "版主")
                {
                    return true;
                }

                if (tempManagerType.TypeName == "待认证")
                {
                    return false;
                }

                if (int.Parse(dr["IsLock"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //检查用户权限==========================
                if (isActionPass && roleType > 0)
                {
                    string[] actionTypeArr = dr["ActionType"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        if (action_type_str == "Show")
                        {
                            ManagerRoleValue modelt = roleModel.ManagerRoleValues.Find(p => p.NavName == dr["Name"].ToString() && p.ActionType == "Show");
                            if (modelt == null)
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
            }

            return isActionPass;
        }
    }

    public class ShowMessageInfo
    {
        private int _no;

        public int No
        {
            get { return _no; }
            set { _no = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _imgUrl;

        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
    }
}