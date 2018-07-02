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
// 文件名（File Name）：HSECEdit.cs
// 作者(Author):  雷登辉
// 功能描述(Description): 高企认定咨询服务信息编辑：修改、新增功能
// 日期(Create Date):2017/3/10
//*****************************
namespace HN863Soft.ISS.Web.Manage.HSEConsulting
{
    public partial class HSECEdit : ManagePage
    {
        #region 函数
        BLL.HSEConsulting hseConsultingBll;
        Model.HSEConsulting hseConsultingModel;

        private string action = EnumsHelper.ActionEnum.Add.ToString();//默认添加
        private static int id = 0;


        #endregion

        #region 初始化界面

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                //该信息是否存在
                if (!new HN863Soft.ISS.BLL.HSEConsulting().Exists(id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }

            if (!IsPostBack)
            {
                if (!ChkManageLevel("ChannelSCSList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                Manager model = GetManageInfo(); //取得用户信息

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    FileUpload1.Attributes.Remove("datatype");
                    BindData();
                }
            }
        }
        #endregion

        #region 绑定初始数据

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            hseConsultingBll = new BLL.HSEConsulting();
            hseConsultingModel = hseConsultingBll.GetModel(id);
            if (hseConsultingModel != null)
            {
                txtTitle.Text = hseConsultingModel.SName;//服务名称
                txtContent.InnerHtml = hseConsultingModel.SIntroduction;//服务名称
                txaExample.InnerHtml = hseConsultingModel.Example;//成功案例
                txtPhone.Text = hseConsultingModel.Phone;//联系电话
                txaIntroduction.InnerHtml = hseConsultingModel.TeamIntroduction;//团队介绍
                Image1.ImageUrl = hseConsultingModel.LogImg;//Log路径
                txtIntroduce.Text = hseConsultingModel.Introduce;//简介
                txtKeyWord.Text = hseConsultingModel.KeyWord;//关键词
            }
        }

        #endregion

        #region 上传图片

        private string UploadImg()
        {
            string savePath = "";
            if (FileUpload1.HasFile)
            {
                savePath = Server.MapPath("~/SoftWareService/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\SoftWareService\\" + FileName;
            }
            return savePath;
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            string strImgUrl = UploadImg();
            Model.Manager mangerModel=GetManageInfo();
            hseConsultingBll = new BLL.HSEConsulting();
            hseConsultingModel = new Model.HSEConsulting
            {
                CreateDate = DateTime.Now,
                Example = txaExample.InnerText,
                Phone = txtPhone.Text.Trim(),
                SIntroduction = txtContent.InnerText,
                SName = txtTitle.Text.Trim(),
                TeamIntroduction = txaIntroduction.InnerText,
                IsVis = 0,
                Type = 0,
                Introduce = txtIntroduce.Text,//简介
                KeyWord = txtKeyWord.Text,//关键词
                LogImg = strImgUrl,//Log路径
                CreatorId = mangerModel.ID//用户Id
            };

            int result = hseConsultingBll.Add(hseConsultingModel);//插入并返回主ID值
            if (result != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加高企认定咨询信息:" + hseConsultingModel.SName); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            string strImgUrl = "";
            hseConsultingBll = new BLL.HSEConsulting();
            if (!FileUpload1.HasFile)
            {
                strImgUrl = hseConsultingBll.GetModel(_id).LogImg;
            }
            else
            {
                strImgUrl = UploadImg();
            }
            hseConsultingModel = new Model.HSEConsulting
            {
                Id = _id,
                Example = txaExample.InnerText,
                Phone = txtPhone.Text.Trim(),
                SIntroduction = txtContent.InnerText,
                SName = txtTitle.Text.Trim(),
                TeamIntroduction = txaIntroduction.InnerText,
                IsVis=0,
                Type = 0,
                Introduce = txtIntroduce.Text,//简介
                KeyWord = txtKeyWord.Text,//关键词
                LogImg = strImgUrl//Log路径
            };

            //插入并返回主ID值
            if (hseConsultingBll.Update(hseConsultingModel))//更新需要更改
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "更新高企认定咨询信息:" + hseConsultingModel.SName); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 保存按钮

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("ChannelHSECList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('修改高企认定咨询信息成功！');");
                ShowMsgHelper.ShowScript("location.href='/Manage/HSEConsulting/HSECList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("ChannelHSECList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }
                if (!FileUpload1.HasFile)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('请选择双软Logo图片！');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("showWarningMsg('添加高企认定咨询信息成功！');");
                ShowMsgHelper.ShowScript("location.href='/Manage/HSEConsulting/HSECList.aspx';");
            }
        }
        #endregion
    }
}