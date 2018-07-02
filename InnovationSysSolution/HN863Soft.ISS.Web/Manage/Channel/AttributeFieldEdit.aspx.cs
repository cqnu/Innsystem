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

namespace _863soft.ISS.Web.Manage.Channel
{
    public partial class AttributeFieldEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型
                this.id = RequestHelper.GetQueryInt("id");
                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                if (!new HN863Soft.ISS.BLL.ArticleAttributeField().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("sys_channel_field", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                dlIsPassWord.Visible = dlIsHtml.Visible = dlEditorType.Visible = dlDataType.Visible
                    = dlDataLength.Visible = dlDataPlace.Visible = dlItemOption.Visible = false; //隐藏相应控件
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            HN863Soft.ISS.BLL.ArticleAttributeField bll = new HN863Soft.ISS.BLL.ArticleAttributeField();
            ArticleAttributeField model = bll.GetModel(id);

            txtName.Enabled = false;
            txtName.Attributes.Remove("ajaxurl");
            txtName.Attributes.Remove("datatype");
            ddlControlType.SelectedValue = model.ControlType;
            showControlHtml(model.ControlType); //显示对应的HTML
            txtSortId.Text = model.SortID.ToString();
            txtName.Text = model.Name;
            txtTitle.Text = model.Title;
            if (model.IsRequired == 1)
            {
                cbIsRequired.Checked = true;
            }
            else
            {
                cbIsRequired.Checked = false;
            }
            if (model.IsPassword == 1)
            {
                cbIsPassword.Checked = true;
            }
            else
            {
                cbIsPassword.Checked = false;
            }
            if (model.IsHtml == 1)
            {
                cbIsHtml.Checked = true;
            }
            else
            {
                cbIsHtml.Checked = false;
            }
            rblEditorType.SelectedValue = model.EditorType.ToString();
            rblDataType.SelectedValue = model.DataType;
            txtDataLength.Text = model.DataLength.ToString();
            ddlDataPlace.SelectedValue = model.DataPlace.ToString();
            txtItemOption.Text = model.ItemOption;
            txtDefaultValue.Text = model.DefaultValue;
            txtValidPattern.Text = model.ValidPattern;
            txtValidTipMsg.Text = model.ValidTipMsg;
            txtValidErrorMsg.Text = model.ValidErrorMsg;
            if (model.IsSys == 1)
            {
                ddlControlType.Enabled = false;
            }

        }
        #endregion

        #region 显示对应的控件===========================
        private void showControlHtml(string control_type)
        {
            dlIsPassWord.Visible = dlIsHtml.Visible = dlEditorType.Visible = dlDataType.Visible
                    = dlDataLength.Visible = dlDataPlace.Visible = dlItemOption.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = false; //隐藏相应控件
            switch (control_type)
            {
                case "single-text": //单行文本
                    dlIsPassWord.Visible = dlDataLength.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "multi-text": //多行文本
                    dlIsHtml.Visible = dlDataLength.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "editor": //编辑器
                    dlEditorType.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "images": //图片上传
                    dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "video": //视频上传
                    dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "number": //数字
                    dlDataPlace.Visible = dlValidPattern.Visible = dlValidErrorMsg.Visible = true;
                    break;
                case "checkbox": //复选框
                    break;
                case "multi-radio": //多项单选
                    dlDataType.Visible = dlDataLength.Visible = dlItemOption.Visible = true;
                    break;
                case "multi-checkbox": //多项多选
                    dlDataLength.Visible = dlItemOption.Visible = true;
                    break;
            }

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            ArticleAttributeField model = new ArticleAttributeField();
            HN863Soft.ISS.BLL.ArticleAttributeField bll = new HN863Soft.ISS.BLL.ArticleAttributeField();

            model.ControlType = ddlControlType.SelectedValue;
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.Name = txtName.Text.Trim();
            model.Title = txtTitle.Text;
            if (cbIsRequired.Checked == true)
            {
                model.IsRequired = 1;
            }
            else
            {
                model.IsRequired = 0;
            }
            if (cbIsPassword.Checked == true)
            {
                model.IsPassword = 1;
            }
            else
            {
                model.IsPassword = 0;
            }
            if (cbIsHtml.Checked == true)
            {
                model.IsHtml = 1;
            }
            else
            {
                model.IsHtml = 0;
            }
            model.EditorType = Utils.StrToInt(rblEditorType.SelectedValue, 0);
            model.DataLength = Utils.StrToInt(txtDataLength.Text.Trim(), 0);
            model.DataPlace = Utils.StrToInt(ddlDataPlace.SelectedValue, 0);
            model.DataType = rblDataType.SelectedValue;
            model.ItemOption = txtItemOption.Text.Trim();
            model.DefaultValue = txtDefaultValue.Text.Trim();
            model.ValidPattern = txtValidPattern.Text.Trim();
            model.ValidTipMsg = txtValidTipMsg.Text.Trim();
            model.ValidErrorMsg = txtValidErrorMsg.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加扩展字段:" + model.Title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int id)
        {
            bool result = false;
            HN863Soft.ISS.BLL.ArticleAttributeField bll = new HN863Soft.ISS.BLL.ArticleAttributeField();
            ArticleAttributeField model = bll.GetModel(id);

            if (model.IsSys == 0)
            {
                model.ControlType = ddlControlType.SelectedValue;
                model.DataLength = Utils.StrToInt(txtDataLength.Text.Trim(), 0);
                model.DataPlace = Utils.StrToInt(ddlDataPlace.SelectedValue, 0);
                model.DataType = rblDataType.SelectedValue;
            }
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.Title = txtTitle.Text;
            if (cbIsRequired.Checked == true)
            {
                model.IsRequired = 1;
            }
            else
            {
                model.IsRequired = 0;
            }
            if (cbIsPassword.Checked == true)
            {
                model.IsPassword = 1;
            }
            else
            {
                model.IsPassword = 0;
            }
            if (cbIsHtml.Checked == true)
            {
                model.IsHtml = 1;
            }
            else
            {
                model.IsHtml = 0;
            }
            model.EditorType = Utils.StrToInt(rblEditorType.SelectedValue, 0);
            model.ItemOption = txtItemOption.Text.Trim();
            model.DefaultValue = txtDefaultValue.Text.Trim();
            model.ValidPattern = txtValidPattern.Text.Trim();
            model.ValidTipMsg = txtValidTipMsg.Text.Trim();
            model.ValidErrorMsg = txtValidErrorMsg.Text.Trim();

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "修改扩展字段:" + model.Title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //根据选择的控件类型显示相应部分
        protected void ddlControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            showControlHtml(ddlControlType.SelectedValue);
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("sys_channel_field", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(OpenClose, 3000);");
                    return;
                }
                //JscriptMsg("！", "AttributeFieldEdit.aspx");
                //ShowMsgHelper.ShowScript("showWarningMsg('修改扩展字段成功！');setTimeout(OpenClose, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/AttributeFieldEdit.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("sys_channel_field", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(OpenClose, 3000);");
                    return;
                }
                //JscriptMsg("添加扩展字段成功！", "AttributeFieldEdit.aspx");
                //ShowMsgHelper.ShowScript("showWarningMsg('添加扩展字段成功！');setTimeout(Back, 3000);");
                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/AttributeFieldEdit.aspx';");
            }
        }
    }
}