using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Channel
{
    public partial class ChannelEdit : ManagePage
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
                if (!new HN863Soft.ISS.BLL.Channel().Exists(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已删除！');");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                TreeBind(); //绑定类别
                FieldBind(); //绑定扩展字段
                if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    txtName.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=channel_name_validate");
                }
            }
        }

        #region 返回页面的类型===========================
        protected string GetPageTypeTxt(string type_name)
        {
            string result = "";
            switch (type_name)
            {
                case "index":
                    result = "首页";
                    break;
                case "category":
                    result = "栏目页";
                    break;
                case "list":
                    result = "列表页";
                    break;
                case "detail":
                    result = "详细页";
                    break;
            }
            return result;
        }
        #endregion

        #region 返回页面继承类===========================
        private string GetInherit(string page_type)
        {
            string result = "";
            switch (page_type)
            {
                case "index":
                    result = "HN863Soft.ISS.Web.UI.Page.Article";
                    break;
                case "category":
                    result = "HN863Soft.ISS.Web.UI.Page.Category";
                    break;
                case "list":
                    result = "HN863Soft.ISS.Web.UI.Page.ArticleList";
                    break;
                case "detail":
                    result = "HN863Soft.ISS.Web.UI.Page.ArticleShow";
                    break;
            }
            return result;
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind()
        {
            HN863Soft.ISS.BLL.ChannelSite bll = new HN863Soft.ISS.BLL.ChannelSite();
            DataTable dt = bll.GetList(0, "", "SortID asc,ID desc").Tables[0];

            this.ddlSiteId.Items.Clear();
            this.ddlSiteId.Items.Add(new ListItem("请选择站点...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlSiteId.Items.Add(new ListItem(dr["Title"].ToString(), dr["ID"].ToString()));
            }
        }
        #endregion

        #region 绑定扩展字段=============================
        private void FieldBind()
        {
            HN863Soft.ISS.BLL.ArticleAttributeField bll = new HN863Soft.ISS.BLL.ArticleAttributeField();
            DataTable dt = bll.GetList(0, "", "SortID asc,ID desc").Tables[0];

            this.cblAttributeField.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.cblAttributeField.Items.Add(new ListItem(dr["Title"].ToString(), dr["Name"].ToString() + "," + dr["ID"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            var model = bll.GetModel(_id);

            txtTitle.Text = model.Title;
            txtName.Text = model.Name;
            txtName.Focus(); //设置焦点，防止JS无法提交
            txtName.Attributes.Add("ajaxurl", "../../WebService/ManageAjaxHandler.ashx?action=channel_name_validate&old_channel_name=" + Utils.UrlEncode(model.Name));
            ddlSiteId.SelectedValue = model.SiteID.ToString();
            //if (model.IsAlbums == 1)
            //{
            //    cbIsAlbums.Checked = true;
            //}
            //if (model.IsAttach == 1)
            //{
            //    cbIsAttach.Checked = true;
            //}
            //if (model.IsSpec == 1)
            //{
            //    cbIsSpec.Checked = true;
            //}
            txtSortId.Text = model.SortID.ToString();

            //赋值扩展字段
            if (model.ChannelFields != null)
            {
                for (int i = 0; i < cblAttributeField.Items.Count; i++)
                {
                    string[] fieldIdArr = cblAttributeField.Items[i].Value.Split(','); //分解出ID值
                    ChannelField modelt = model.ChannelFields.Find(p => p.FieldID == int.Parse(fieldIdArr[1])); //查找对应的字段ID
                    if (modelt != null)
                    {
                        cblAttributeField.Items[i].Selected = true;
                    }
                }
            }

            //绑定URL配置列表
            rptList.DataSource = new HN863Soft.ISS.BLL.UrlRewrite().GetList(model.Name);
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            var model = new HN863Soft.ISS.Model.Channel();
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();

            model.SiteID = Utils.StrToInt(ddlSiteId.SelectedValue, 0);
            model.Name = txtName.Text.Trim();
            model.Title = txtTitle.Text.Trim();
            model.IsAlbums = 0;
            model.IsAttach = 0;
            model.IsSpec = 0;
            //if (cbIsAlbums.Checked == true)
            //{
            //    model.IsAlbums = 1;
            //}
            //if (cbIsAttach.Checked == true)
            //{
            //    model.IsAttach = 1;
            //}
            //if (cbIsSpec.Checked == true)
            //{
            //    model.IsSpec = 1;
            //}
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            //添加频道扩展字段
            List<ChannelField> ls = new List<ChannelField>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    string[] fieldIdArr = cblAttributeField.Items[i].Value.Split(','); //分解出ID值
                    ls.Add(new ChannelField { FieldID = Utils.StrToInt(fieldIdArr[1], 0) });
                }
            }
            model.ChannelFields = ls;

            if (bll.Add(model) < 1)
            {
                return false;
            }

            #region 保存URL配置
            HN863Soft.ISS.BLL.UrlRewrite urlBll = new HN863Soft.ISS.BLL.UrlRewrite();
            urlBll.Remove("channel", model.Name); //先删除
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemPageSizeArr = Request.Form.GetValues("item_pagesize");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemPageSizeArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length) && (itemPageArr.Length == itemTempletArr.Length)
                    && (itemTempletArr.Length == itemPageSizeArr.Length) && (itemPageSizeArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        UrlRewrite urlModel = new UrlRewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        if (Utils.StrToInt(itemPageSizeArr[i].Trim(), 0) > 0)
                        {
                            urlModel.pagesize = itemPageSizeArr[i].Trim();
                        }
                        urlModel.channel = model.Name;

                        List<UrlRewriteItem> itemLs = new List<UrlRewriteItem>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new UrlRewriteItem { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.UrlRewriteItems = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加频道" + model.Title); //记录日志
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            HN863Soft.ISS.BLL.Channel bll = new HN863Soft.ISS.BLL.Channel();
            var model = bll.GetModel(_id);

            string old_name = model.Name;
            model.SiteID = Utils.StrToInt(ddlSiteId.SelectedValue, 0);
            model.Name = txtName.Text.Trim();
            model.Title = txtTitle.Text.Trim();
            model.IsAlbums = 0;
            model.IsAttach = 0;
            model.IsSpec = 0;
            //if (cbIsAlbums.Checked == true)
            //{
            //    model.IsAlbums = 1;
            //}
            //if (cbIsAttach.Checked == true)
            //{
            //    model.IsAttach = 1;
            //}
            //if (cbIsSpec.Checked == true)
            //{
            //    model.IsSpec = 1;
            //}
            model.SortID = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            //添加频道扩展字段
            List<ChannelField> ls = new List<ChannelField>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    string[] fieldIdArr = cblAttributeField.Items[i].Value.Split(','); //分解出ID值
                    ls.Add(new ChannelField { ChannelID = model.ID, FieldID = Utils.StrToInt(fieldIdArr[1], 0) });
                }
            }
            model.ChannelFields = ls;

            if (!bll.Update(model))
            {
                return false;
            }

            #region 保存URL配置
            HN863Soft.ISS.BLL.UrlRewrite urlBll = new HN863Soft.ISS.BLL.UrlRewrite();
            urlBll.Remove("channel", old_name); //先删除旧的
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemPageSizeArr = Request.Form.GetValues("item_pagesize");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemPageSizeArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length) && (itemPageArr.Length == itemTempletArr.Length)
                    && (itemTempletArr.Length == itemPageSizeArr.Length) && (itemPageSizeArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        UrlRewrite urlModel = new UrlRewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        if (Utils.StrToInt(itemPageSizeArr[i].Trim(), 0) > 0)
                        {
                            urlModel.pagesize = itemPageSizeArr[i].Trim();
                        }
                        urlModel.channel = model.Name;

                        List<UrlRewriteItem> itemLs = new List<UrlRewriteItem>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new UrlRewriteItem { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.UrlRewriteItems = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改频道" + model.Title); //记录日志
            return true;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == EnumsHelper.ActionEnum.Edit.ToString()) //修改
            {
                if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/ChannelList.aspx';");
            }
            else //添加
            {
                if (!ChkManageLevel("sys_channel_manage", EnumsHelper.ActionEnum.Add.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');");
                    return;
                }

                //ShowMsgHelper.ShowScript("showWarningMsg('添加频道成功！');setTimeout(back, 3000);parent.location.href='/Manage/Channel/ChannelList.aspx'");
                ShowMsgHelper.ShowScript("location.href='/Manage/Channel/ChannelList.aspx';");
            }
        }
    }
}