using System;
using System.Web.UI;
//*****************************
// 文件名（File Name）：Show.cs
// 作者（Author）：邹峰
// 功能（Function）：显示详细通知公告
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.Web.Notice
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		HN863Soft.ISS.BLL.Notice bll=new HN863Soft.ISS.BLL.Notice();
		HN863Soft.ISS.Model.Notice model=bll.GetModel(ID);
        this.txtName.Text = model.Username;
        this.txtTime.Text = model.ReleaseTime.ToString();
        this.txtPublishContent.Text = model.PublishContent;
        this.txtRemarks.Text = model.Remarks;
       
	}


    }
}
