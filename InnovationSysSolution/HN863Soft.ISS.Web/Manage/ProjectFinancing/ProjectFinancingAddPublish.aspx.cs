using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：ProjectFinancing_Add.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑众筹信息
// 创建日期（Create Date）：2017/03/08
//*****************************
namespace HN863Soft.ISS.Web.Manage.ProjectFinancing
{
    public partial class ProjectFinancing_Add : ManagePage
    {
        #region 变量
        private readonly HN863Soft.ISS.BLL.ProjectFinancingBll bll = new BLL.ProjectFinancingBll();

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelProjectFinancingPublishList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                BindDdl();
                BindType();
                //ActionTypeBind(); //绑定操作权限类型

                //绑定模版
                DataSet ds = bll.GetTemplate();
                traContent.InnerText = ds.Tables[0].Rows[0]["Content"].ToString();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定省
        /// </summary>
        private void BindDdl()
        {
            DataSet ds = new DataSet();
            ds = bll.GetProvince();
            this.ddlProvince.DataTextField = ds.Tables[0].Columns["Name"].ToString();
            this.ddlProvince.DataValueField = ds.Tables[0].Columns["ProvinceID"].ToString();
            this.ddlProvince.DataSource = ds.Tables[0];
            this.ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, "");
            ddlCity.Items.Insert(0, "");
        }

        /// <summary>
        /// 绑定操作权限类型
        /// </summary>
        //private void ActionTypeBind()
        //{
        //    cblActionType.Items.Clear();

        //    cblActionType.Items.Add(new ListItem("普通用户", "1"));
        //    cblActionType.Items.Add(new ListItem("会员用户", "2"));
        //    for (int i = 0; i < cblActionType.Items.Count; i++)
        //    {
        //        cblActionType.Items[i].Selected = true;
        //    } 
        //}

        /// <summary>
        /// 绑定众筹类型
        /// </summary>
        private void BindType()
        {
            this.ddlType.Items.Clear();
            this.ddlType.Items.Add(new ListItem("众筹项目", "1"));
            this.ddlType.Items.Add(new ListItem("股权融资项目", "2"));
            this.ddlType.Items.Add(new ListItem("综合合作项目", "3"));
        }

        #endregion

        #region 事件

        /// <summary>
        ///省市连动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvince.SelectedIndex != 0)
            {
                string str = this.ddlProvince.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = bll.GetCity(str);
                this.ddlCity.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                this.ddlCity.DataValueField = ds.Tables[0].Columns["CityID"].ToString();
                this.ddlCity.DataSource = ds.Tables[0];
                this.ddlCity.DataBind();
            }
            else
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Insert(0, "");
            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ChannelProjectFinancingPublishList", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.Model.ProjectFinancing model = new Model.ProjectFinancing();

            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();

            string savePath = "";
            if (FileUpload1.HasFile)
            {

                savePath = Server.MapPath("~/CoverImg/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + this.FileUpload1.FileName;

                savePath = savePath + "\\" + FileName;
                FileUpload1.SaveAs(savePath);

                savePath = "~\\CoverImg\\" + FileName;
            }

            int s = 0;

            //判断所选的权限
            //foreach (ListItem li in cblActionType.Items)
            //{
            //    if (li.Selected)
            //    {
            //        s += int.Parse(li.Value);
            //    }
            //}

            //if (s == 0)
            //{
            //    ShowMsgHelper.ShowScript("showWarningMsg('" + "请至少选择一个权限" + "');");
            //    return;
            //}

            model.UserId = Mmodel.ID;//发布人id
            model.Cover = savePath;
            model.Jurisdiction = s;//查看权限
            model.Type = int.Parse(ddlType.SelectedItem.Value);//众筹类型
            model.Title = txtTitle.Text.Trim().ToString();//标题
            model.KeyWord = txtKeyWord.Text.Trim().ToString();//关键词
            model.Objective = txtObjective.Text.Trim().ToString();//目的
            model.Place = ddlProvince.SelectedItem.Value + "-" + ddlCity.SelectedItem.Value;//地点
            model.StartTime = Convert.ToDateTime(startDate.Value);//开始时间
            model.EndTime = Convert.ToDateTime(endDate.Value);//结束时间
            model.State = 0;
            if (hid.Value != "")
            {
                model.PromotionalVideo = hid.Value;
            }
            model.Content = traContent.InnerText;

            HN863Soft.ISS.BLL.ProjectFinancingBll bll = new HN863Soft.ISS.BLL.ProjectFinancingBll();
            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加众筹"); //记录日志

                Response.Redirect("ProjectFinancingListPublish.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion 
    }
}