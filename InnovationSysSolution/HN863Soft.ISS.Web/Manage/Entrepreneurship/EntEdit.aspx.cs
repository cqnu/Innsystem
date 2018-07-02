using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Model;
//*****************************
//* 文件名：EntEdit.cs
//* 作者： 雷登辉
//* 功能：创业指导信息的编辑与修改
//* 创建时间：2017/2/27
//*****************************
namespace HN863Soft.ISS.Web.Manage.Entrepreneurship
{
    public partial class EntEdit : ManagePage
    {
        //string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private HN863Soft.ISS.Model.ConductInfo conductModel;//服务信息实体对象
        private HN863Soft.ISS.BLL.ConductInfo conductBll;//服务信息处理对象

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
                if (!new HN863Soft.ISS.BLL.ConductInfo().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkManageLevel("EntList", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                //Manager model = GetManageInfo(); //取得管理员信息
                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            conductBll = new HN863Soft.ISS.BLL.ConductInfo();//实例化服务信息处理对象
            conductModel = new HN863Soft.ISS.Model.ConductInfo();//实例化服务信息实体对象
            conductModel = conductBll.GetModel(id);//获取对应Id的服务信息实体对象
            txtHot.Text = conductModel.Hot.ToString();//服务内容
            rblStatus.SelectedValue = conductModel.IsVis.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

            conductBll = new BLL.ConductInfo();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息

            //实例化服务信息对象
            conductModel = new HN863Soft.ISS.Model.ConductInfo
            {
                //Content = txtContent.InnerText,//服务内容
                Creator = model.ID,//登陆者Id
                CreateTime = DateTime.Now,//创建时间
                //Remarks = "新建服务",//备注
                //Title = txtTitle.Text.Trim(),//标题
                IsVis = 0//是否通过：0，不通过；1，通过
            };
            int result = conductBll.Add(conductModel);//插入并返回主ID值
            if (result != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加指导信息:" + conductModel.Title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            conductBll = new HN863Soft.ISS.BLL.ConductInfo();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            conductModel = new HN863Soft.ISS.Model.ConductInfo//实例化服务信息实体对象并赋予值
            {
                Id = Convert.ToInt32(Request["Id"]),
                //Content = txtContent.InnerText,//服务内容
                //CreatTime=,//发布时间
                //PublisherId=,//发布人
                //Remarks=,//备注
                //Title = txtTitle.Text,//服务信息标题
                IsVis = rblStatus.SelectedValue == "0" ? 0 : 1, //是否显示
                Hot=Convert.ToInt32(txtHot.Text.Trim())//热度
            };
            //是否更新成功
            if (conductBll.UpdateDIY(conductModel)) //更新服务信息数据
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改指导信息:" + conductModel.Title); //记录日志
                return true;
            }

            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtTitle.Text.Trim()) || string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            //{
            //    ShowMsgHelper.Alert_Error("标题、内容不能为空！");
            //    return;
            //}
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                //ChkManageLevel("EntList", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('修改指导信息成功！');setTimeout(Back, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Entrepreneurship/EntList.aspx';");
            }
            else //添加
            {
                //ChkManageLevel("EntList", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('添加指导信息成功！');setTimeout(Back, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Entrepreneurship/EntList.aspx';");
            }
        }
    }
}