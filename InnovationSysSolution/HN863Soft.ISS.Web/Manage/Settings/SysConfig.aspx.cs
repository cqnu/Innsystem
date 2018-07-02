using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using HN863Soft.ISS.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _863soft.ISS.Web.Manage.Settings
{
    public partial class SysConfig : ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("sys_config", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
            var model = bll.loadConfig();

            webname.Text = model.webname;
            weburl.Text = model.weburl;
            webcompany.Text = model.webcompany;
            webaddress.Text = model.webaddress;
            webtel.Text = model.webtel;
            webfax.Text = model.webfax;
            webmail.Text = model.webmail;
            webcrod.Text = model.webcrod;

            webpath.Text = model.webpath;
            webmanagepath.Text = model.webmanagepath;

            if (model.memberstatus == 1)
            {
                memberstatus.Checked = true;
            }
            else
            {
                memberstatus.Checked = false;
            }
            
            if (model.logstatus == 1)
            {
                logstatus.Checked = true;
            }
            else
            {
                logstatus.Checked = false;
            }
            
            emailsmtp.Text = model.emailsmtp;
            if (model.emailssl == 1)
            {
                emailssl.Checked = true;
            }
            else
            {
                emailssl.Checked = false;
            }
            emailport.Text = model.emailport.ToString();
            emailfrom.Text = model.emailfrom;
            emailusername.Text = model.emailusername;
            if (!string.IsNullOrEmpty(model.emailpassword))
            {
                emailpassword.Attributes["value"] = defaultpassword;
            }
            emailnickname.Text = model.emailnickname;
        }
        #endregion
        
        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("sys_config", EnumsHelper.ActionEnum.Edit.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            HN863Soft.ISS.BLL.SiteConfig bll = new HN863Soft.ISS.BLL.SiteConfig();
            var model = bll.loadConfig();
            try
            {
                model.webname = webname.Text;
                model.weburl = weburl.Text;
                model.webcompany = webcompany.Text;
                model.webaddress = webaddress.Text;
                model.webtel = webtel.Text;
                model.webfax = webfax.Text;
                model.webmail = webmail.Text;
                model.webcrod = webcrod.Text;

                model.webpath = webpath.Text;
                model.webmanagepath = webmanagepath.Text;
                model.staticstatus = 0;
                model.staticextension = "";
                if (memberstatus.Checked == true)
                {
                    model.memberstatus = 1;
                }
                else
                {
                    model.memberstatus = 0;
                }
                
                if (logstatus.Checked == true)
                {
                    model.logstatus = 1;
                }
                else
                {
                    model.logstatus = 0;
                }
                
                model.webclosereason = "";
                model.webcountcode = "";
                model.commentstatus = 0;
                model.webstatus = 0;

                model.smsapiurl = "";
                model.smsusername = "";

                model.emailsmtp = emailsmtp.Text;
                if (emailssl.Checked == true)
                {
                    model.emailssl = 1;
                }
                else
                {
                    model.emailssl = 0;
                }
                model.emailport = Utils.StrToInt(emailport.Text.Trim(), 25);
                model.emailfrom = emailfrom.Text;
                model.emailusername = emailusername.Text;
                //判断密码是否更改
                if (emailpassword.Text.Trim() != defaultpassword)
                {
                    model.emailpassword = EncryptionHelper.Encrypt(emailpassword.Text, model.sysencryptstring);
                }
                model.emailnickname = emailnickname.Text;

                bll.saveConifg(model);
                AddManageLog(EnumsHelper.ActionEnum.Edit.ToString(), "修改系统配置信息"); //记录日志
                ShowMsgHelper.ShowScript("showWarningMsg('修改系统配置成功！');");
            }
            catch
            {
                ShowMsgHelper.ShowScript("showWarningMsg('文件写入失败，请检查文件夹权限！');");
            }
        }
    }
}