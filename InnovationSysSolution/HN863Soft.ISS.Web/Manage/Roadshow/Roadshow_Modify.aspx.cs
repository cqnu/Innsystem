using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：Roadshow_Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：编辑路演信息
// 创建日期（Create Date）：2017/03/13
//*****************************
namespace HN863Soft.ISS.Web.Manage.Roadshow
{
    public partial class Roadshow_Modify : ManagePage
    {
        #region 变量

        private readonly HN863Soft.ISS.BLL.RoadshowBll bll = new BLL.RoadshowBll();

        /// <summary>
        /// 视频地址
        /// </summary>
        public string strSrc = "";

        /// <summary>
        /// 旧视频地址
        /// </summary>
        public static string oldSrc = "";

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelRoadshowList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string strid = Request.Params["id"];
                    ViewState["id"] = strid;
                    int ID = (Convert.ToInt32(strid));
                    //ActionTypeBind();
                    BindDdl();
                    ShowInfo(ID);
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 绑定省
        /// </summary>
        private void BindDdl()
        {
            HN863Soft.ISS.BLL.ProjectFinancingBll fbll = new BLL.ProjectFinancingBll();

            DataSet ds = new DataSet();
            ds = fbll.GetProvince();
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

        //}

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        /// <param name="ID"></param>
        private void ShowInfo(int ID)
        {
            HN863Soft.ISS.BLL.RoadshowBll bll = new HN863Soft.ISS.BLL.RoadshowBll();
            HN863Soft.ISS.Model.Roadshow model = bll.GetModel(ID);

            //判断权限是否被选中
            //if (model.Jurisdiction == 1)
            //{
            //    cblActionType.Items[0].Selected = true;
            //}

            //if (model.Jurisdiction == 2)
            //{
            //    cblActionType.Items[1].Selected = true;
            //}

            //if (model.Jurisdiction == 3)
            //{
            //    cblActionType.Items[0].Selected = true;
            //    cblActionType.Items[1].Selected = true;
            //}

            strSrc = model.Video;
            oldSrc = model.Video;
            txtTitle.Text = model.Title;
            txtKeyWord.Text = model.KeyWord;
            txtObjective.Text = model.Objective;
            startDate.Value = Convert.ToDateTime(model.StartTime).ToString("yyyy-MM-dd HH:mm");
            endDate.Value = Convert.ToDateTime(model.EndTime).ToString("yyyy-MM-dd HH:mm");
            txtOrganizationName.Text = model.OrganizationName;
            txtSpeaker.Text = model.Speaker;
            Image1.ImageUrl = model.Cover;
            traContent.InnerText = model.Content;
            hid.Value = model.Video;


            HN863Soft.ISS.BLL.ProjectFinancingBll fbll = new BLL.ProjectFinancingBll();

            //截取地址 数据库中为 省-市 存储
            string[] array = model.Place.ToString().Split('-');

            //默认选中对应的省
            ddlProvince.Items.FindByValue(array[0]).Selected = true;

            //绑定对应的市级
            DataSet ds = new DataSet();
            ds = fbll.GetCity(array[0]);
            ddlCity.DataTextField = ds.Tables[0].Columns["Name"].ToString();
            ddlCity.DataValueField = ds.Tables[0].Columns["CityID"].ToString();
            ddlCity.DataSource = ds.Tables[0];
            ddlCity.DataBind();

            //默认选中对应的市
            ddlCity.Items.FindByValue(array[1]).Selected = true;


        }

        #endregion

        #region 事件

        /// <summary>
        /// 省市二级联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvince.SelectedIndex != 0)
            {
                HN863Soft.ISS.BLL.ProjectFinancingBll fbll = new HN863Soft.ISS.BLL.ProjectFinancingBll();

                string str = this.ddlProvince.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = fbll.GetCity(str);
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
            if (!ChkManageLevel("ChannelRoadshowList", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.Model.Roadshow model = new Model.Roadshow();
            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();

            string savePath = Image1.ImageUrl;
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

            model.ID = int.Parse(ViewState["id"].ToString());
            model.UserId = Mmodel.ID;//发布人id
            model.Cover = savePath;
            model.Jurisdiction = s;//查看权限
            model.Speaker = txtSpeaker.Text.Trim().ToString();//主讲人
            model.Title = txtTitle.Text.Trim().ToString();//标题
            model.KeyWord = txtKeyWord.Text.Trim().ToString();//关键词
            model.Objective = txtObjective.Text.Trim().ToString();//目的
            model.OrganizationName = txtOrganizationName.Text.Trim().ToString();//机构名称
            model.StartTime = Convert.ToDateTime(startDate.Value);//开始时间
            model.EndTime = Convert.ToDateTime(endDate.Value);//结束时间
            model.State = 0;
            model.Describe = "";
            model.Place = ddlProvince.SelectedItem.Value + "-" + ddlCity.SelectedItem.Value;//地点
            if (hid.Value != "")
            {
                model.Video = hid.Value;
            }
            model.Content = traContent.InnerText;

            HN863Soft.ISS.BLL.RoadshowBll bll = new HN863Soft.ISS.BLL.RoadshowBll();
            if (bll.Update(model))
            {

                //删除旧的视频
                if (oldSrc != hid.Value)
                {
                    if (System.IO.File.Exists(Server.MapPath(oldSrc)))
                    {
                        System.IO.File.Delete(Server.MapPath(oldSrc));
                    }
                }

                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改路演"); //记录日志

                Response.Redirect("Roadshow_List.aspx");
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "保存失败！请稍后再试" + "');");
            }
        }

        #endregion
    }
}