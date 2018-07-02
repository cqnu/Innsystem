using HN863Soft.ISS.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class TempletFileEdit : ManagePage
    {
        protected string filePath; //文件路径
        protected string pathName; //模板目录
        protected string fileName; //文件名称

        protected void Page_Load(object sender, EventArgs e)
        {
            pathName = RequestHelper.GetQueryString("path");
            fileName = RequestHelper.GetQueryString("fileName");
            if (string.IsNullOrEmpty(pathName) || string.IsNullOrEmpty(fileName))
            {
                JscriptMsg("传输参数不正确！", "back");
                return;
            }
            filePath = Utils.GetMapPath(@"../../templates/" + pathName.Replace(".", "") + "/" + fileName.Replace("/", ""));
            if (!File.Exists(filePath))
            {
                JscriptMsg("该文件不存在！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("SysSiteTemplet", EnumsHelper.ActionEnum.View.ToString()); //检查权限
                ShowInfo(filePath);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _path)
        {
            using (StreamReader objReader = new StreamReader(_path, Encoding.UTF8))
            {
                txtContent.Text = objReader.ReadToEnd();
                objReader.Close();
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("SysSiteTemplet", EnumsHelper.ActionEnum.Edit.ToString()); //检查权限
            using (FileStream fs = new FileStream(this.filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Byte[] info = Encoding.UTF8.GetBytes(txtContent.Text);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            AddAdminLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改模板文件:" + this.fileName);//记录日志
            JscriptMsg("模板保存成功！", Utils.CombUrlTxt("TempletFileList.aspx", "skin={0}", this.pathName));
        }
    }
}