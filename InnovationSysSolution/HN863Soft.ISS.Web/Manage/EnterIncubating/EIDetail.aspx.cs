using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using System.IO;
//*****************************
// 文件名：EIDetail.cs
// 作者：雷登辉
// 功能：入孵申请详情查看
// 创建日期：2017/3/2
//*****************************
namespace HN863Soft.ISS.Web.Manage.EnterIncubating
{
    public partial class EIDetail : ManagePage
    {
        #region 函数

        protected static HN863Soft.ISS.Model.Hatchery hatcheryModel;//参观预约信息实体
        private HN863Soft.ISS.BLL.Hatchery hatcheryBll;//服务信息处理对象
        private int sId = 0;//服务信息Id
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        #endregion

        #region 页面初始化

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.sId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    Response.Redirect("VisitBList.aspx");
                    return;
                }
                Manager model = GetManageInfo(); //取得管理员信息

                if (!new HN863Soft.ISS.BLL.Hatchery().Exists(this.sId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    Response.Redirect("VisitBList.aspx");
                    return;
                }
            }
            if (!IsPostBack)
            {
                //ChkManageLevel("VisitBList", EnumsHelper.ActionEnum.View.ToString()); //检查权限

                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    GetData(this.sId);
                }
            }
        } 
        #endregion

        #region 数据绑定=================================

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="id">服务信息Id</param>
        private void GetData(int id)
        {
            hatcheryBll = new HN863Soft.ISS.BLL.Hatchery();//实例化服务信息处理对象

            hatcheryModel = hatcheryBll.GetModel(sId);
            txtName.Text = hatcheryModel.Name;//姓名
            txtNum.Text = hatcheryModel.VisitNum.ToString();//人数
            txtPhone.Text = hatcheryModel.Phone;//联系电话
            txtExp.Text = hatcheryModel.Remark;//简介
            txtEmail.Text = hatcheryModel.Email;//邮箱
            txtVisDate.Text = DateTime.Parse(hatcheryModel.VisitDate.ToString()).ToString("yyyy年MM月dd日");//参观日期
            FilePath.Value = hatcheryModel.FileUrl;//文件保存路径
        }




        #endregion

        #region 文件下载

        public bool DownloadFile(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (!file.Exists)
            {
                return false;
            }
            try
            {
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);///文件名截取
                string filepath = path;//文件服务器路径
                FileInfo fileInfo = new FileInfo(filepath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath.Value))
            {
                string strPath = Server.MapPath(FilePath.Value);
                if (!DownloadFile(strPath))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('文件丢失！');");
                }
            }
        }

        #endregion
       
    }
}