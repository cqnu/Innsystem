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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			DateTime ReleaseTime=DateTime.Parse(this.txtReleaseTime.Text);
			string PublishContent=this.txtPublishContent.Text;
			string Remarks=this.txtRemarks.Text;

			HN863Soft.ISS.Model.Notice model=new HN863Soft.ISS.Model.Notice();
			model.ReleaseTime=ReleaseTime;
			model.PublishContent=PublishContent;
			model.Remarks=Remarks;

			HN863Soft.ISS.BLL.Notice bll=new HN863Soft.ISS.BLL.Notice();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
