using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace HN863Soft.ISS.Web.Notice
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		HN863Soft.ISS.BLL.Notice bll=new HN863Soft.ISS.BLL.Notice();
		HN863Soft.ISS.Model.Notice model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtReleaseTime.Text=model.ReleaseTime.ToString();
		this.txtPublishContent.Text=model.PublishContent;
		this.txtRemarks.Text=model.Remarks;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtReleaseTime.Text))
			{
				strErr+="发布时间格式错误！\\n";	
			}
			if(this.txtPublishContent.Text.Trim().Length==0)
			{
				strErr+="发布内容不能为空！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			DateTime ReleaseTime=DateTime.Parse(this.txtReleaseTime.Text);
			string PublishContent=this.txtPublishContent.Text;
			string Remarks=this.txtRemarks.Text;


			HN863Soft.ISS.Model.Notice model=new HN863Soft.ISS.Model.Notice();
			model.ID=ID;
			model.ReleaseTime=ReleaseTime;
			model.PublishContent=PublishContent;
			model.Remarks=Remarks;

			HN863Soft.ISS.BLL.Notice bll=new HN863Soft.ISS.BLL.Notice();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
