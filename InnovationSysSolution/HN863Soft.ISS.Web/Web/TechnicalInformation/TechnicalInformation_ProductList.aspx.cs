using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
//*****************************
// 文件名（File Name）：ProductList.cs
// 作者（Author）：邹峰
// 功能（Function）：查询、显示技术信息资源 用户前台
// 创建日期（Create Date）：2017/02/16
//*****************************
namespace _863soft.ISS.Web.TechnicalInformation
{
    public partial class ProductList : System.Web.UI.Page
    {

        HN863Soft.ISS.BLL.TechnicalInformation bll = new HN863Soft.ISS.BLL.TechnicalInformation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ViewState["pageindex"] = "0";
                Bind();
            }


        }

        protected void Bind()
        {


            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {

                strWhere.AppendFormat("t.EntryName like '%{0}%' or t.Keyword like '%{0}%' ", txtKeyword.Text.Trim());
            }
            //ds = bll.GetList(strWhere.ToString());
            ds.Tables[0].Columns.Add("url");
            ds.Tables[0].Columns.Add("picurl");
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                mDr["url"] = "Show.aspx?id=" + mDr["ID"].ToString();
                mDr["picurl"] = "http://www.efuhua.cn/data/upload/avatar/90.png";
            }

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                DataView dv = ds.Tables[0].DefaultView;

                PagedDataSource dvPds = new PagedDataSource();

                dvPds.DataSource = dv;

                dvPds.AllowPaging = true;

                dvPds.PageSize = 6;

                dvPds.CurrentPageIndex = int.Parse(ViewState["pageindex"].ToString());



                DataList1.DataSource = dvPds;

                DataList1.DataBind();

                int curpage = Convert.ToInt32(this.labpage.Text);

                PagedDataSource ps = new PagedDataSource();   //定义PagedDataSource对象

                ps.DataSource = dv;  //取出数据到datatable中，赋给PagedDataSource对象

                ps.AllowPaging = true;  //是否可以分页

                ps.PageSize = 6; //显示的数量

                ps.CurrentPageIndex = curpage - 1; //取得当前页的页码，PagedDataSource的CurrentPageIndex是从0开始

                this.linkbtnone.Enabled = true;

                this.linkbtnpre.Enabled = true;

                this.linkbtnnext.Enabled = true;

                this.linkbtnlast.Enabled = true;

                if (curpage == 1)
                {

                    this.linkbtnone.Enabled = false;

                    this.linkbtnpre.Enabled = false;

                }

                if (curpage == ps.PageCount)
                {

                    this.linkbtnnext.Enabled = false;

                    this.linkbtnlast.Enabled = false;

                }

                this.labtp.Text = Convert.ToString(ps.PageCount);  //显示分页数量

                this.DataList1.DataSource = ps;   //绑定DataList控件

                this.DataList1.DataKeyField = "id";

                this.DataList1.DataBind();

            }

        }

        protected void IndexChanging(object sender, EventArgs e)
        {

            string strCommand = ((LinkButton)sender).CommandArgument.ToString();

            int pageindex = int.Parse(ViewState["pageindex"].ToString());

            if (strCommand == "pre")
            {

                pageindex = pageindex - 1;

            }

            else
            {

                pageindex = pageindex + 1;

            }

            ViewState["pageindex"] = pageindex;

            Bind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.location='Add.aspx'</script>");
        }

        protected void linkbtnone_Click(object sender, EventArgs e)
        {
            this.labpage.Text = "1";
            Bind();
        }

        protected void linkbtnpre_Click(object sender, EventArgs e)
        {
            this.labpage.Text = Convert.ToString(Convert.ToInt32(this.labpage.Text) - 1);
            Bind();
        }

        protected void linkbtnnext_Click(object sender, EventArgs e)
        {
            this.labpage.Text = Convert.ToString(Convert.ToInt32(this.labpage.Text) + 1);
            Bind();
        }

        protected void linkbtnlast_Click(object sender, EventArgs e)
        {
            this.labpage.Text = this.labtp.Text;
            Bind();
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            if (this.txtgo.Text.Trim().ToString() != "")
            {

                if (IsNumberic(this.txtgo.Text))
                {
                    if (int.Parse(this.txtgo.Text) <= int.Parse(labtp.Text))
                    {
                        this.labpage.Text = this.txtgo.Text;

                        Bind();
                    }
                    else
                    {
                        txtgo.Text = "";
                    }
                }
                else
                {
                    txtgo.Text = "";
                }
            }
            else
            {
                txtgo.Text = "";
            }
        }

        private bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

    }
}