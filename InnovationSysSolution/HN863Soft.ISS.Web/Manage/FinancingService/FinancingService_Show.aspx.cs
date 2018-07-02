using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// 文件名（File Name）：FinancingService_Modify.cs
// 作者（Author）：邹峰
// 功能（Function）：查看投融资服务
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.Web.Manage.FinancingService
{
    public partial class FinancingService_Show : ManagePage
    {
        #region 变量定义

        public string strid = "";
        protected string keywords = string.Empty;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        #endregion

        #region 页面初期

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    this.keywords = RequestHelper.GetQueryString("keywords");
                    ViewState["id"] = Request.Params["id"];
                    this.pageSize = GetPageSize(2); //每页数量
                    ShowInfo();
                }
            }
        }

        #endregion

        #region 方法



        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        private void ShowInfo()
        {

            this.page = RequestHelper.GetQueryInt("page", 1);
            int ID = int.Parse(ViewState["id"].ToString());

            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            HN863Soft.ISS.Model.FinancingService model = bll.GetModel(ID);

            //插入浏览次数
            bll.AddHits(ID);

            int id = int.Parse(ViewState["id"].ToString());
            DataSet ds = new DataSet();
            ds = bll.ShowToptie(id);

            //获取发布人ID
            hid1.Value = ds.Tables[0].Rows[0]["UserId"].ToString();
            ds.Tables[0].Rows[0]["content"] = ds.Tables[0].Rows[0]["content"].ToString().Replace("<p>", "");
            ds.Tables[0].Rows[0]["content"] = ds.Tables[0].Rows[0]["content"].ToString().Replace("</p>", "");
            ds.Tables[0].Rows[0]["content"] = ds.Tables[0].Rows[0]["content"].ToString().Replace("alt=", "");
            ds.Tables[0].Rows[0]["content"] = ds.Tables[0].Rows[0]["content"].ToString().Replace("title=", "");

            datalist1.DataSource = ds;
            datalist1.DataBind();

            Model.Manager Mmodel = Session[KeysHelper.SESSION_MANAGE_INFO] as Model.Manager;
            StringBuilder strWhere = new StringBuilder();
            //int BeID = 0;
            strWhere.Append("and a.Financingid =" + id);
            if (Mmodel.RoleType == 3)
            {
                //BeID = //当前登录人ID
                //如果当前登录人与发布人不一致，只能查看自己的评论与发布人回复自己的评论

                if (int.Parse(hid1.Value.ToString()) != Mmodel.ID)
                {
                    strWhere.Append("and a.UserId= " + int.Parse(hid1.Value.ToString()));
                    strWhere.Append("and a.BeReplyId=" + Mmodel.ID);

                    strWhere.Append("or a.UserId= " + Mmodel.ID);
                    strWhere.Append("and a.BeReplyId= " + int.Parse(hid1.Value.ToString()));
                }
            }

            DataSet dt = new DataSet();
            dt = bll.ShowFinancingClass(this.pageSize, this.page, strWhere.ToString(), out this.totalCount);

            DataSet dtL = new DataSet();
            dtL = bll.ShowFinancingClassInfo(strWhere.ToString());
            dt.Tables[0].Columns.Add(new DataColumn("flg"));
            //if (Mmodel.RoleType == 6)
            //{
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                if (row["LId"].ToString() != "0")
                {
                    row["title"] = get(dtL.Tables[0], row["BeReplyId"].ToString(), row["LId"].ToString());
                }
                else
                {
                    row["title"] = "";
                }
                row["content"] = row["content"].ToString().Replace("<p>", "");
                row["content"] = row["content"].ToString().Replace("</p>", "");
                row["content"] = row["content"].ToString().Replace("alt=", "");
                row["content"] = row["content"].ToString().Replace("title=", "");
                //如果是发布人 切评论为被删除 页面删除评论按钮可用
                if (row["DeletedState"].ToString() == "1")
                {
                    row["flg"] = "n";
                }
                else
                {
                    //如果是系统用户 切发布人与登录人一直 删除按钮显示可用
                    if (Mmodel.RoleType == 3 && int.Parse(hid1.Value.ToString()) == Mmodel.ID)
                    {
                        row["flg"] = "y";
                    }
                    //管理员用户删除按钮可用
                    else if (Mmodel.RoleType < 3)
                    {
                        row["flg"] = "y";
                    }
                    else
                    {
                        row["flg"] = "n";
                    }
                }
            }

            this.datalist2.DataSource = dt;   //绑定DataList控件
            this.datalist2.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("FinancingService_Show.aspx?id=" + ViewState["id"] + "&", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

        }

        private string get(DataTable dt, string bid, string lid)
        {
            string ti = "";

            foreach (DataRow row in dt.Rows)
            {
                if (row["UserId"].ToString() == bid && row["id"].ToString() == lid)
                {
                    HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
                    DataTable dname = bll.GetName(int.Parse(bid)).Tables[0];
                    ti = "回复：" + row["rowid"].ToString() + "楼 " + dname.Rows[0]["UserName"];
                    break;
                }
            }

            return ti;

        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id"></param>
        private void UpdateComment(int id)
        {
            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            bool flg = bll.UpdateComment(id);
            if (flg)
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "删除成功！" + "');setTimeout(OpenClose, 3000);");
                ShowInfo();
            }
            else
            {
                ShowMsgHelper.ShowScript("showWarningMsg('" + "删除失败，请重试！" + "');setTimeout(OpenClose, 3000);");
            }
        }

        #endregion

        #region 事件

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("FinancingService_Show.aspx?id=" + ViewState["id"] + "&", "keywords={0}", this.keywords));
        }

        protected void ButTure_Click(object sender, EventArgs e)
        {
            HN863Soft.ISS.BLL.FinancingServiceBll bll = new HN863Soft.ISS.BLL.FinancingServiceBll();
            HN863Soft.ISS.Model.FinancingService model = new Model.FinancingService();
            HN863Soft.ISS.Model.Manager Mmodel = GetManageInfo();
            //string a = hid2.Value;
            if (container.InnerText.Trim() == "")
            {
                return;
            }
            if (hid2.Value != "")
            {
                model.Lid = int.Parse(hid2.Value);
            }
            else
            {
                model.Lid = 0;
            }
            model.Ariticleid = int.Parse(Request["id"].ToString());
            model.UserId = Mmodel.ID;
            model.BeReplyId = int.Parse(hid1.Value);//被回复人ID
            model.Title = hid.Value;
            model.Content = container.InnerText;
            model.datatime = System.DateTime.Now;
            bll.AddFinancingClass(model);

            ShowInfo();
            container.InnerText = "";
            hid.Value = "";
            hid2.Value = "";

        }

        protected void datalist2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton dele = (LinkButton)e.Item.FindControl("linkdel");
            if (dele != null)
            {
                dele.Attributes.Add("Onclick ", "return confirm( '确定删除吗? ')");

            }
        }

        protected void linkdel_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;

            int id = Convert.ToInt32(lb.ValidationGroup); //主键id

            UpdateComment(id);
        }

        #endregion
    }
}