using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Organization
{
    public partial class OrganizationEdit : ManagePage
    {
        protected string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private HN863Soft.ISS.Model.Organization orgModel;//机构实体对象
        private HN863Soft.ISS.BLL.Organization orgBll;//机构处理对象
        //private HN863Soft.ISS.BLL.ProjectFinancingBll pfBll;//全国省份管理对象

        private int id = 0;
        private static int ids = 0;
        public static string strSrc = "";
        public static string oldSrc = "";
        private static DataTable ImgDt;

        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (!new HN863Soft.ISS.BLL.Organization().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.Organization().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(_action) && _action.Contains("Confirm"))  //完善资料
            {
                Manager model = GetManageInfo(); //取得用户信息 
                reBack.Visible = false;
                if (model != null)
                {
                    orgBll = new HN863Soft.ISS.BLL.Organization();
                    orgModel = orgBll.GetModelByUserID(model.ID);

                    if (orgModel != null)
                    {
                        if (orgModel.ID > 0)
                        {
                            this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                            this.id = orgModel.ID;
                        }
                        else
                        {
                            this.action = EnumsHelper.ActionEnum.Add.ToString();//修改类型
                        }
                    }
                    else
                    {
                        this.action = EnumsHelper.ActionEnum.Add.ToString();//修改类型
                    }
                }
            }
            longitude.Attributes.Add("readonly", "true");
            latitude.Attributes.Add("readonly", "true");
            if (!Page.IsPostBack)
            {
                InitData();
                BindData();
                //BindProvince();
                //ChkManageLevel("ChannelOrganizationEdit", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                TreeBind();

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    FileUpload1.Attributes.Remove("datatype");
                    FileUpload2.Attributes.Remove("datatype");
                    FileUpload3.Attributes.Remove("datatype");
                    ids = id;
                    ShowInfo(this.id);
                }
                if (action == EnumsHelper.ActionEnum.View.ToString()) //查看
                {
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    FileUpload3.Visible = false;
                    zyupload.Visible = false;
                    orgName.Enabled = false;//机构名称
                    orgLocation.Enabled = false;//机构地址
                    tbUserName.Enabled = false;
                    tbMobile.Enabled = false;
                    tbUserCard.Enabled = false;
                    tbUserEmail.Enabled = false;
                    //txtContent.Disabled = true;
                    tbOrgFile.Disabled = true;
                    tbOrgIntro.Disabled = true;
                    tbOrgShow.Disabled = true;
                    tbOrgWeiXin.Enabled = false;
                    this.btnSubmit.Visible = false;
                    weburl.Enabled = false;
                    ids = id;
                    ShowInfo(this.id);
                }
                hfCount.Value = dlImg.Items.Count.ToString();

            }
        }

        #region 角色类型=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            DataTable dt = bll.GetList("").Tables[0];

            List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
            DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
            if (dsManagerTypes != null)
            {
                for (int i = 0; i < dsManagerTypes.Tables[0].Rows.Count; i++)
                {
                    if (dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString() == "管理员" || dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString() == "版主")
                    {
                        continue;
                    }
                    managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[i]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[i]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[i]["IsSys"].ToString()) });
                }
            }

            ddlOrganizationType.Items.Clear();
            ddlOrganizationType.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                var temp = managerTypeList.FirstOrDefault(x => x.ID == Convert.ToInt32(dr["RoleType"]));
                if (temp != null)
                {
                    ddlOrganizationType.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["ID"].ToString()));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            orgBll = new HN863Soft.ISS.BLL.Organization();//机构处理对象
            orgModel = orgBll.GetModel(id);//获取对应Id的服务信息实体对象

            for (int i = 0; i < ddlOrganizationType.Items.Count; i++)
            {
                string[] fieldIdArr = ddlOrganizationType.Items[i].Value.Split(','); //分解出ID值
                if (fieldIdArr != null)
                {
                    foreach (var item in fieldIdArr)
                    {
                        if (item == orgModel.OrgType.ToString())
                        {
                            ddlOrganizationType.Items[i].Selected = true;
                        }
                    }
                }
            }

            orgName.Text = orgModel.OrgName;//机构名称
            orgLocation.Text = orgModel.OrgLocation;//机构地址
            tbUserName.Text = orgModel.Proposer;
            tbMobile.Text = orgModel.ProposerMobile;
            tbUserCard.Text = orgModel.ProposerCard;
            tbUserEmail.Text = orgModel.ProposerEmail;
            //txtContent.InnerText = orgModel.Remark;
            tbOrgFile.InnerText = orgModel.Evidence;
            tbOrgIntro.InnerText = orgModel.OrgIntro;
            tbOrgShow.InnerText = orgModel.OrgExhibit;
            tbOrgWeiXin.Text = orgModel.WeiXin;
            txtIntroduce.Text = orgModel.Introduce;
            Image1.ImageUrl = orgModel.LogImg;
            Image2.ImageUrl = orgModel.IdCadrUrlZ;
            Image3.ImageUrl = orgModel.IdCadrUrlF;
            longitude.Text = orgModel.Lng;//经度
            latitude.Text = orgModel.Lat;//纬度
            hid.Value = orgModel.VideoUrl;
            strSrc = orgModel.VideoUrl;
            oldSrc = strSrc;
            weburl.Text = orgModel.Weburl;
            if (orgModel.RegionId.ToString() != "")
            {
                BLL.ProjectFinancingBll pfBll = new BLL.ProjectFinancingBll();
                ddlProvince.SelectedValue = pfBll.GetProvince(orgModel.RegionId.ToString());

                EventArgs e = new EventArgs();
                object send = new object();
                this.ddlProvince_SelectedIndexChanged(send, e);
                ddlCity.SelectedValue = orgModel.RegionId.ToString();
            }
            BingImg();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            ImgDt = null;
            oldSrc = "";
            ids = 0;
        }

        private void BingImg()
        {
            ImgDt = ShowImg().Copy();
            dlImg.DataSource = ImgDt;
            dlImg.DataBind();
        }

        /// <summary>
        /// 绑定图片
        /// </summary>
        private DataTable ShowImg()
        {
            BLL.PictureClip picBll = new BLL.PictureClip();
            DataTable Dt = picBll.GetListImg("ParentId=" + ids).Tables[0];
            return Dt;
        }

        /// <summary>
        /// 绑定省份、市/区
        /// </summary>
        private void BindData()
        {
            HN863Soft.ISS.BLL.ProjectFinancingBll pfBll = new HN863Soft.ISS.BLL.ProjectFinancingBll();

            //绑定省份
            DataTable proDt = pfBll.GetProvince().Tables[0];
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceID";
            ddlProvince.DataSource = proDt;
            ddlProvince.DataBind();

            //绑定市级
            DataTable cityDt = pfBll.GetCity(ddlProvince.SelectedValue).Tables[0];
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataSource = cityDt;
            ddlCity.DataBind();

        }

        #endregion

        #region 图片上传的添加和删除

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="strImgPath"></param>
        private void AddImg(string strImgPath)
        {
            if (ImgDt == null)
            {
                ImgDt = ShowImg().Clone();
            }
            DataRow dr = ImgDt.NewRow();
            if (!string.IsNullOrEmpty(strImgPath))
            {
                dr["ImgUrl"] = strImgPath;
            }
            ImgDt.Rows.Add(dr);
            ImgDt.AcceptChanges();

        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="strImgPath"></param>
        private void DelImg(string strImgPath)
        {
            DataRow[] drs = ImgDt.Select("ImgUrl='" + strImgPath + "'");
            if (drs.Length > 0)
            {
                ImgDt.Rows.Remove(drs[0]);
            }
            ImgDt.AcceptChanges();

            dlImg.DataSource = ImgDt;
            dlImg.DataBind();
        }

        /// <summary>
        /// 删除图片文件
        /// </summary>
        private void DelFileImg()
        {
            string[] arr = Regex.Split(ImgDelPath.Value, @"&&", RegexOptions.IgnorePatternWhitespace);
            foreach (string str in arr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    if (System.IO.File.Exists(Server.MapPath(str)))
                    {
                        System.IO.File.Delete(Server.MapPath(str));
                    }
                }
            }
        }

        /// <summary>
        /// 插入数据库表
        /// </summary>
        /// <param name="parentId"></param>
        private void InsertInto(string parentId)
        {
            BLL.PictureClip picBll = new BLL.PictureClip();
            List<Model.PictureClip> lstPic = new List<PictureClip>();
            if (ImgDt != null && ImgDt.Rows.Count != 0)
            {

                foreach (DataRow dr in ImgDt.Rows)
                {
                    Model.PictureClip modelPic = new PictureClip
                    {
                        ParentId = int.Parse(parentId),
                        ImgUrl = Convert.ToString(dr["ImgUrl"])
                    };
                    lstPic.Add(modelPic);
                }
                picBll.Add(lstPic, int.Parse(parentId));
            }


        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            string strImgUrl = UploadImg(FileUpload1);
            string strImgUrl2 = UploadImg(FileUpload2);
            string strImgUrl3 = UploadImg(FileUpload3);
            orgBll = new BLL.Organization();//实例化服务信息处理对象
            BLL.PictureClip picImg = new BLL.PictureClip();
            Manager model = GetManageInfo(); //取得管理员信息

            //实例化服务信息对象
            orgModel = new HN863Soft.ISS.Model.Organization
            {
                UserID = model.ID,  //用户ID
                OrgName = orgName.Text,//机构名称
                OrgLocation = orgLocation.Text,//机构地址
                OrgType = Utils.StrToInt(ddlOrganizationType.SelectedValue, 2),//机构类型
                Proposer = tbUserName.Text,
                ProposerMobile = tbMobile.Text,
                ProposerCard = tbUserCard.Text,
                ProposerEmail = tbUserEmail.Text,
                CreateTime = DateTime.Now,//创建时间
                Evidence = tbOrgFile.InnerText,  //机构证明文件
                OrgExhibit = tbOrgShow.InnerText,    //机构展示
                OrgIntro = tbOrgIntro.InnerText,  //机构简介
                WeiXin = tbOrgWeiXin.Text,    //微信
                //Remark = txtContent.InnerText,   //备注
                State = 1, //机构状态：1、未审核，2、审核未通过，3、审核通过
                RegionId = int.Parse(ddlCity.SelectedValue),//区域
                Introduce = txtIntroduce.Text,//简介
                LogImg = strImgUrl,
                IdCadrUrlZ = strImgUrl2,
                IdCadrUrlF = strImgUrl3,
                Lng = longitude.Text.Trim(),//经度
                Lat = latitude.Text.Trim(),//纬度
                VideoUrl = hid.Value,
                Weburl = weburl.Text
            };
            int result = orgBll.Add(orgModel);//插入并返回主ID值
            if (result != -1)
            {
                InsertInto(result.ToString());
                DelFileImg();
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加机构入驻信息:" + orgModel.OrgName); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            string strImgUrl = "";
            string strImgUrl2 = "";
            string strImgUr3 = "";
            orgBll = new HN863Soft.ISS.BLL.Organization();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            orgModel = new HN863Soft.ISS.BLL.Organization().GetModel(_id);//实例化服务信息实体对象并赋予值

            if (orgModel == null)
            {
                orgModel = new Model.Organization();
            }

            //是否有文件上传 若没有则还是原来的图片
            if (!FileUpload1.HasFile)
            {
                strImgUrl = orgBll.GetModel(_id).LogImg;
            }
            else
            {
                strImgUrl = UploadImg(FileUpload1);
            }

            if (!FileUpload2.HasFile)
            {
                strImgUrl2 = orgBll.GetModel(_id).IdCadrUrlZ;
            }
            else
            {
                strImgUrl2 = UploadImg(FileUpload2);
            }

            if (!FileUpload3.HasFile)
            {
                strImgUr3 = orgBll.GetModel(_id).IdCadrUrlF;
            }
            else
            {
                strImgUr3 = UploadImg(FileUpload3);
            }

            orgModel.ID = _id;
            orgModel.OrgName = orgName.Text;//机构名称
            orgModel.OrgLocation = orgLocation.Text;//机构地址
            orgModel.OrgType = Utils.StrToInt(ddlOrganizationType.SelectedValue, 2);//机构类型
            orgModel.Proposer = tbUserName.Text;
            orgModel.ProposerMobile = tbMobile.Text;
            orgModel.ProposerCard = tbUserCard.Text;
            orgModel.ProposerEmail = tbUserEmail.Text;
            orgModel.CreateTime = DateTime.Now;//创建时间
            orgModel.Evidence = tbOrgFile.InnerText;  //机构证明文件
            orgModel.OrgExhibit = tbOrgShow.InnerText;    //机构展示
            orgModel.OrgIntro = tbOrgIntro.InnerText;  //机构简介
            orgModel.WeiXin = tbOrgWeiXin.Text;    //微信
            //orgModel.Remark = model.RoleType < 3 ? txtContent.InnerText : "";  //审核不通过的原因
            orgModel.State = 1; //机构状态：1、未审核，2、审核未通过，3、审核通过
            orgModel.RegionId = int.Parse(ddlCity.SelectedValue);
            orgModel.Introduce = txtIntroduce.Text;//简介
            orgModel.LogImg = strImgUrl;
            orgModel.IdCadrUrlZ = strImgUrl2;
            orgModel.IdCadrUrlF = strImgUr3;
            orgModel.Lng = longitude.Text.Trim();//经度
            orgModel.Lat = latitude.Text.Trim();//纬度
            orgModel.VideoUrl = hid.Value;
            orgModel.Weburl = weburl.Text;
            //是否更新成功
            if (orgBll.Update(orgModel)) //更新服务信息数据
            {
                //if (!ChkManageType())
                //{

                    int RoleID = int.Parse(ddlOrganizationType.SelectedValue);
                    int RoleType = new HN863Soft.ISS.BLL.ManagerRole().GetModel(RoleID).RoleType;

                    HN863Soft.ISS.BLL.Manager mBll = new BLL.Manager();
                    mBll.UpdateManagerType(orgModel.UserID, RoleType, RoleID);

                //}
                InsertInto(orgModel.ID.ToString());
                if (oldSrc != hid.Value)
                {
                    if (System.IO.File.Exists(Server.MapPath(oldSrc)))
                    {
                        System.IO.File.Delete(Server.MapPath(oldSrc));
                    }
                }
                DelFileImg();
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改机构入驻信息:" + orgModel.OrgName); //记录日志
                return true;
            }

            return false;
        }
        #endregion



        #region 上传图片

        private string UploadImg(FileUpload f)
        {
            string savePath = "";
            if (f.HasFile)
            {
                savePath = Server.MapPath("~/SoftWareService/");//指定上传文件在服务器上的保存路径

                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssFFFFF") + f.FileName;

                savePath = savePath + "\\" + FileName;
                f.SaveAs(savePath);

                savePath = "~\\SoftWareService\\" + FileName;
            }
            return savePath;
        }

        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Manager model = GetManageInfo(); //取得管理员信息


            if (string.IsNullOrEmpty(orgName.Text.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('机构名称不能为空！');");
                return;
            }
            if (string.IsNullOrEmpty(orgLocation.Text.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('机构位置不能为空！');");
                return;
            }
            if (string.IsNullOrEmpty(ddlOrganizationType.SelectedValue))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('请选择机构类型！');");
                return;
            }
            if (string.IsNullOrEmpty(tbOrgFile.InnerText.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('机构证明文件不能为空！');");
                return;
            }

            //孵化器机构类型
            if (ddlOrganizationType.SelectedValue == "12")
            {
                if (string.IsNullOrEmpty(tbOrgShow.InnerText.Trim()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('入驻标准不能为空！');");
                    return;
                }
                if (string.IsNullOrEmpty(tbOrgIntro.InnerText.Trim()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('特色不能为空！');");
                    return;
                }

            }

            if (action == EnumsHelper.ActionEnum.Add.ToString()) //添加
            {

                if (!FileUpload1.HasFile)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('请选择机构Logo图片！');");
                    return;
                }
                //ChkManageLevel("ChannelOrganizationEdit", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                //ShowMsgHelper.ShowScript("location.href='/Manage/Organization/OrganizationList.aspx';");
                //ShowMsgHelper.ShowScript("showWarningMsg('添加成功！');");
                Response.Redirect("OrganizationList.aspx");
                return;
            }
            else
            {
                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }
                Response.Redirect("OrganizationList.aspx");
                //ShowMsgHelper.ShowScript("showWarningMsg('修改成功！');");
                return;
            }
        }

        /// <summary>
        /// 绑定市级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            HN863Soft.ISS.BLL.ProjectFinancingBll pfBll = new HN863Soft.ISS.BLL.ProjectFinancingBll();
            //绑定市级
            DataTable cityDt = pfBll.GetCity(ddlProvince.SelectedValue).Tables[0];
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataSource = cityDt;
            ddlCity.DataBind();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlImg_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                Image img = e.Item.FindControl("Image1") as Image;
                ImgDelPath.Value += "&&" + img.ImageUrl;
                DelImg(img.ImageUrl);
                hfCount.Value = dlImg.Items.Count.ToString();
            }
        }

        /// <summary>
        /// 绑定上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void b2_CheckedChanged(object sender, EventArgs e)
        {
            string imgurl = ImgAddPaths.Value;
            string[] arr = imgurl.Split('*').ToArray();
            foreach (string strUrl in arr)
            {
                if (!string.IsNullOrEmpty(strUrl))
                {
                    AddImg(strUrl);

                }
            }
            hfCount.Value = dlImg.Items.Count.ToString();
            dlImg.DataSource = ImgDt;
            dlImg.DataBind();
        }
    }
}