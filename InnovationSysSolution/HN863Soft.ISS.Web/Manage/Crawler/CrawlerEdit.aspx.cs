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
    public partial class CrawlerEdit : ManagePage
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
                if (!new BLL.CrawlerInfo().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');setTimeout(Back, 3000);");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.View.ToString()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (_action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (_action == EnumsHelper.ActionEnum.View.ToString()) //查看
                {
                    ShowInfo(this.id);

                    this.txtTitle.Enabled = false;
                    this.txtCrawDate.Enabled = false;
                    this.txtCrawURL.Enabled = false;
                    this.txtContent.Disabled = true;

                    this.btnSubmit.Visible = false;
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.CrawlerInfo bll = new BLL.CrawlerInfo();
            Model.CrawlerInfo model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtCrawDate.Text = model.CrawDate.ToString();
            txtCrawURL.Text = model.Url;
            txtContent.Value = model.CrawContent;
            txtCrawSource.Text = model.Source;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.CrawlerInfo model = new Model.CrawlerInfo();
            BLL.CrawlerInfo bll = new BLL.CrawlerInfo();

            model.Title = txtTitle.Text.Trim();
            model.CrawDate = DateTime.Parse(txtCrawDate.Text);
            model.Url = txtCrawURL.Text;
            model.CrawContent = txtContent.Value;
            model.Source = txtCrawSource.Text;
            model.State = 0;

            if (bll.Add(model) > 0)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加爬取内容:" + model.Title); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.CrawlerInfo bll = new BLL.CrawlerInfo();
            Model.CrawlerInfo model = bll.GetModel(_id);

            model.Title = txtTitle.Text.Trim();
            model.CrawDate = DateTime.Parse(txtCrawDate.Text);
            model.Url = txtCrawURL.Text;
            model.CrawContent = txtContent.Value;
            model.Source = txtCrawSource.Text;

            if (bll.Update(model))
            {
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改爬取内容:" + model.Title); //记录日志
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
                if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.Edit.ToString()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有操作该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("ChannelCrawlerList", EnumsHelper.ActionEnum.Add.ToString()))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有操作该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Crawler/CrawlerList.aspx';");
            }
        }

    }
}