using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HN863Soft.ISS.Web.Manage.Crawler
{
    public partial class CrawlerKeyEdit : ManagePage
    {
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = RequestHelper.GetQueryString("action");
            this.id = RequestHelper.GetQueryInt("ID");

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.Edit.ToString())
            {
                this.action = EnumsHelper.ActionEnum.Edit.ToString();//修改类型

                if (this.id == 0)
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');setTimeout(Back, 3000);");
                    return;
                }
                if (!new BLL.CrawlerKeys().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');setTimeout(Back, 3000);");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkManageLevel("ChannelCrawlerKeyList", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                BindType();
                if (_action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (_action == EnumsHelper.ActionEnum.View.ToString()) //查看
                {
                    ShowInfo(this.id);

                    this.txtKeys.Enabled = false;
                    this.txtURLKey.Enabled = false;
                    this.txtKeyName.Enabled = false;

                    this.btnSubmit.Visible = false;
                }
            }
        }

        #region 绑定关键词分类

        /// <summary>
        /// 绑定关键词分类
        /// </summary>
        private void BindType()
        {
            List<ListItem> lstItem = new List<ListItem>();
            foreach (EnumsHelper.CrawlerKeyType item in Enum.GetValues(typeof(EnumsHelper.CrawlerKeyType)))
            {
                lstItem.Add(new ListItem(EnumsHelper.FetchDescription(item), item.GetValue().ToString()));
            }

            ddlType.DataSource = lstItem;
            ddlType.DataTextField = "text";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.CrawlerKeys bll = new BLL.CrawlerKeys();
            Model.CrawlerKeys model = bll.GetModel(_id);

            txtKeys.Text = model.Keys;
            ddlType.SelectedValue = model.KeyType.ToString();
            txtURLKey.Text = model.UrlKey;
            txtKeyName.Text = model.KeyName;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.CrawlerKeys model = new Model.CrawlerKeys();
            BLL.CrawlerKeys bll = new BLL.CrawlerKeys();

            model.Keys = txtKeys.Text.Trim();
            model.KeyType = int.Parse(ddlType.SelectedValue);
            model.UrlKey = txtURLKey.Text;
            model.KeyName = txtKeyName.Text;

            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加关键字:" + model.Keys); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.CrawlerKeys bll = new BLL.CrawlerKeys();
            Model.CrawlerKeys model = bll.GetModel(_id);

            model.Keys = txtKeys.Text.Trim();
            model.KeyType = int.Parse(ddlType.SelectedValue);
            model.UrlKey = txtURLKey.Text;
            model.KeyName = txtKeyName.Text;

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改关键字:" + model.Keys); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                //ChkManageLevel("ChannelCrawlerKeyList", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerKeyList.aspx';");
            }
            else //添加
            {
                //ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerKeyList.aspx';");
            }
        }

    }
}