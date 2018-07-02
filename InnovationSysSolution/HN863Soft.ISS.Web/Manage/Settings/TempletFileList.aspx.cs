using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class TempletFileList : ManagePage
    {
        protected string skinName = string.Empty; //模板目录

        protected void Page_Load(object sender, EventArgs e)
        {
            skinName = RequestHelper.GetQueryString("skin");
            if (string.IsNullOrEmpty(skinName))
            {
                ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');setTimeout(back, 3000);");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("SysSiteTemplet", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                RptBind(skinName);
            }
        }

        #region 数据绑定=================================
        private void RptBind(string skin_name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("skinName", Type.GetType("System.String"));
            dt.Columns.Add("creationTime", Type.GetType("System.String"));
            dt.Columns.Add("updateTime", Type.GetType("System.String"));

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(@"../../templates/" + skin_name));
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (file.Name != "about.xml" && file.Name != "about.png")
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = file.Name;
                    dr["skinName"] = skin_name;
                    dr["creationTime"] = file.CreationTime;
                    dr["updateTime"] = file.LastWriteTime;
                    dt.Rows.Add(dr);
                }
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion

        //删除文件
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("SysSiteTemplet", EnumsHelper.ActionEnum.Delete.ToString()); //检查权限
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string fileName = ((HiddenField)rptList.Items[i].FindControl("hideName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Utils.DeleteFile("../../templates/" + this.skinName + "/" + fileName);
                }
            }
            AddAdminLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除模板文件，模板:" + this.skinName);//记录日志
            JscriptMsg("文件删除成功！", Utils.CombUrlTxt("TempletFileList.aspx", "skin={0}", this.skinName));
        }
    }
}