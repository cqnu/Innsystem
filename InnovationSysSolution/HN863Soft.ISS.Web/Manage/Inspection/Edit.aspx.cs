using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Model;
//****************************
//* 文件名：Edit.cs
//* 作者： 雷登辉
//* 功能： 对服务信息的创建以及编辑
//* 创建时间：2017/2/23
//****************************
namespace HN863Soft.ISS.Web.Manage.Inspection
{
    public partial class Edit : ManagePage
    {
        //string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private HN863Soft.ISS.Model.ServiceInfo serviceModel;//服务信息实体对象
        private HN863Soft.ISS.BLL.ServiceInfo serviceBll;//服务信息处理对象

        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.ServiceInfo().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                //Manager model = GetManageInfo(); //取得管理员信息
                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        //#region 角色类型=================================
        //private void RoleBind(DropDownList ddl, int roleType)
        //{
        //    HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
        //    DataTable dt = bll.GetList("").Tables[0];

        //    ddl.Items.Clear();
        //    ddl.Items.Add(new ListItem("请选择角色...", ""));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //if (Convert.ToInt32(dr["RoleType"]) >= roleType)
        //        //{
        //        //    ddl.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["ID"].ToString()));
        //        //}
        //        if (Convert.ToInt32(dr["RoleType"]) > roleType)
        //        {
        //            ddl.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["ID"].ToString()));
        //        }
        //    }
        //}
        //#endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();//实例化服务信息处理对象
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo();//实例化服务信息实体对象
            serviceModel = serviceBll.GetModel(id);//获取对应Id的服务信息实体对象
            txtContent.InnerText = serviceModel.Content;//服务内容
            txtTitle.Text = serviceModel.Title;//服务标题
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

            serviceBll = new BLL.ServiceInfo();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            
            //实例化服务信息对象
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo
            {
                Content = txtContent.InnerText,//服务内容
                PublisherId = model.ID,//登陆者Id
                CreatTime = DateTime.Now,//创建时间
                Remarks = "新建服务",//备注
                Title = txtTitle.Text.Trim(),//标题
                Visite = 0//是否通过：0，不通过；1，通过
            };
            int result = serviceBll.Add(serviceModel);//插入并返回主ID值
            if (result != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加服务:" + serviceModel.Title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            serviceBll = new HN863Soft.ISS.BLL.ServiceInfo();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            serviceModel = new HN863Soft.ISS.Model.ServiceInfo//实例化服务信息实体对象并赋予值
            {
                Id = Convert.ToInt32(Request["Id"]),
                Content = txtContent.InnerText,//服务内容
                //CreatTime=,//发布时间
                //PublisherId=,//发布人
                //Remarks=,//备注
                Title = txtTitle.Text,//服务信息标题
                Visite = 1, //是否显示
            };
            //是否更新成功
            if (serviceBll.UpdateCondition(serviceModel)) //更新服务信息数据
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改服务:" + serviceModel.Title); //记录日志
                return true;
            }

            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim())||string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ShowMsgHelper.Alert_Error("服务标题、服务范围不能为空！");
                return;
            }
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('修改用户信息成功！');setTimeout(Back, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Inspection/List.aspx';");
            }
            else //添加
            {
                //ChkManageLevel("List", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('添加用户信息成功！');setTimeout(Back, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Inspection/List.aspx';");
            }
        }
    }
}