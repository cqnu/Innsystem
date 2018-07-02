using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Laboratory
{
    public partial class LaboratoryEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private HN863Soft.ISS.Model.Laboratory labModel;//重点实验室实体对象
        private HN863Soft.ISS.BLL.Laboratory labBll;//重点实验室处理对象

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
                if (!new HN863Soft.ISS.BLL.Laboratory().Exists(this.id))
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
                if (!new HN863Soft.ISS.BLL.Laboratory().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                TreeBind();

                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                if (action == EnumsHelper.ActionEnum.View.ToString()) //查看
                {
                    labName.Enabled = false;//重点实验室名称
                    labLocation.Enabled = false;//重点实验室地址
                    tbUserName.Enabled = false;
                    tbMobile.Enabled = false;
                    tbChargingStandard.Enabled = false;
                    tbUserEmail.Enabled = false;
                    txtContent.Disabled = true;
                    linkMan.Enabled = true;
                    tbLabIntro.Disabled = true;
                    tbLabShow.Disabled = true;
                    tbLabWeiXin.Enabled = false;
                    this.btnSubmit.Visible = false;

                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void TreeBind()
        {
            //this.ddlLabType.Items.Clear();
            //this.ddlLabType.Items.Add(new ListItem("所有类型", "0"));
            //this.ddlLabType.Items.Add(new ListItem("专家", "1"));
            //this.ddlLabType.Items.Add(new ListItem("机构", "2"));
            //this.ddlLabType.Items.Add(new ListItem("企业", "3"));
            //this.ddlLabType.Items.Add(new ListItem("其它", "4"));
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            labBll = new HN863Soft.ISS.BLL.Laboratory();//重点实验室处理对象
            labModel = new HN863Soft.ISS.Model.Laboratory();//重点实验室实体对象
            labModel = labBll.GetModel(id);//获取对应Id的服务信息实体对象

            //for (int i = 0; i < ddlOrganizationType.Items.Count; i++)
            //{
            //    string[] fieldIdArr = ddlOrganizationType.Items[i].Value.Split(','); //分解出ID值
            //    if (fieldIdArr != null)
            //    {
            //        foreach (var item in fieldIdArr)
            //        {
            //            if (item == labModel.OrgType.ToString())
            //            {
            //                ddlOrganizationType.Items[i].Selected = true;
            //            }
            //        }
            //    }
            //}

            labName.Text = labModel.LabName;//重点实验室名称
            labLocation.Text = labModel.LabLocation;//重点实验室地址
            tbUserName.Text = labModel.Owner;
            linkMan.Text = labModel.LinkMan;
            tbMobile.Text = labModel.Phone;
            tbChargingStandard.Text = labModel.ChargingStandard;
            tbUserEmail.Text = labModel.Email;
            txtContent.InnerText = labModel.Remark;
            Evidence.InnerText = labModel.Evidence;
            tbLabIntro.InnerText = labModel.LabIntro;
            tbLabShow.InnerText = labModel.LabExhibit;
            tbLabWeiXin.Text = labModel.WeiXin;

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {

            labBll = new BLL.Laboratory();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息

            //实例化服务信息对象
            labModel = new HN863Soft.ISS.Model.Laboratory
            {
                UserID = model.ID,  //用户ID
                LabName = labName.Text,//重点实验室名称
                LabLocation = labLocation.Text,//重点实验室地址
                //OrgType = Utils.StrToInt(ddlOrganizationType.SelectedValue, 2),//重点实验室类型
                Owner = tbUserName.Text,
                LinkMan = linkMan.Text,
                Phone = tbMobile.Text,
                ChargingStandard = tbChargingStandard.Text,
                Email = tbUserEmail.Text,
                CreateTime = DateTime.Now,//创建时间
                Evidence = Evidence.InnerText,  //重点实验室证明文件
                LabExhibit = tbLabShow.InnerText,    //重点实验室展示
                LabIntro = tbLabIntro.InnerText,  //重点实验室简介
                WeiXin = tbLabWeiXin.Text,    //微信
                //Remark = txtContent.InnerText,   //备注
                State = 1 //审核状态：1、未审核，2、审核未通过，3、审核通过
            };
            int result = labBll.Add(labModel);//插入并返回主ID值
            if (result != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加重点实验室信息:" + labModel.LabName); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            labBll = new HN863Soft.ISS.BLL.Laboratory();//实例化服务信息处理对象
            Manager model = GetManageInfo(); //取得管理员信息
            labModel = new HN863Soft.ISS.Model.Laboratory//实例化服务信息实体对象并赋予值
            {
                ID = Convert.ToInt32(Request["Id"]),
                LabName = labName.Text,//重点实验室名称
                LabLocation = labLocation.Text,//重点实验室地址
                //OrgType = Utils.StrToInt(ddlOrganizationType.SelectedValue, 2),//重点实验室类型
                Owner = tbUserName.Text,
                LinkMan = linkMan.Text,
                Phone = tbMobile.Text,
                ChargingStandard = tbChargingStandard.Text,
                CreateTime = DateTime.Now,//创建时间
                Email = tbUserEmail.Text,
                Evidence = Evidence.InnerText,  //重点实验室证明文件
                LabExhibit = tbLabShow.InnerText,    //重点实验室展示
                LabIntro = tbLabIntro.InnerText,  //重点实验室简介
                WeiXin = tbLabWeiXin.Text,    //微信
                Remark = model.RoleType < 3 ? txtContent.InnerText : "",   //审核不通过的原因
                State = 1 //审核状态：1、未审核，2、审核未通过，3、审核通过
            };

            //管理员审核不通过
            if (model.RoleType < 3 && !string.IsNullOrEmpty(labModel.Remark))
            {
                labModel.State = 2;
            }

            //是否更新成功
            if (labBll.Update(labModel)) //更新服务信息数据
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改重点实验室信息:" + labModel.LabName); //记录日志
                return true;
            }

            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Manager model = GetManageInfo(); //取得管理员信息

            if (string.IsNullOrEmpty(labName.Text.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('实验室名称不能为空！');setTimeout(Back, 3000);");
                return;
            }
            if (string.IsNullOrEmpty(labLocation.Text.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('重点实验室位置不能为空！');setTimeout(Back, 3000);");
                return;
            }
            //if (string.IsNullOrEmpty(ddlLabType.SelectedValue))
            //{
            //    ShowMsgHelper.ShowScript("showWarningMsg('请选择实验室类型！');setTimeout(Back, 3000);");
            //    return;
            //}
            if (string.IsNullOrEmpty(Evidence.InnerText.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('实验室证明文件不能为空！');setTimeout(Back, 3000);");
                return;
            }
            if (string.IsNullOrEmpty(tbLabIntro.InnerText.Trim()))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('实验室简介不能为空！');setTimeout(Back, 3000);");
                return;
            }
            if ((!string.IsNullOrEmpty(txtContent.InnerText.Trim())) && model.RoleType > 2)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您不能填写审核不通过信息！');setTimeout(Back, 3000);");
                return;
            }

            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Laboratory/LaboratoryList.aspx';");
            }
            else //添加
            {
                //ChkManageLevel("channel_Laboratory_list", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Laboratory/LaboratoryList.aspx';");
            }
        }
    }
}