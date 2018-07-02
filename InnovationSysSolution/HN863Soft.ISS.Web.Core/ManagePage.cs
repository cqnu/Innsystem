using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Web.Core
{
    public class ManagePage : System.Web.UI.Page
    {
        protected internal Model.SiteConfig siteConfig;
        public List<HN863Soft.ISS.Model.ManagerType> MTypeList = new List<Model.ManagerType>();     //管理员角色类型集合
        public List<HN863Soft.ISS.Model.ManagerType> TypeList = new List<Model.ManagerType>();     //普通用户角色类型集合

        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            siteConfig = new BLL.SiteConfig().loadConfig();
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判断系统用户是否登录
            if (!IsManageLogin())
            {
                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/index.html'</script>");
                Response.End();
            }
        }

        #region 管理员============================================
        /// <summary>
        /// 判断系统用户是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsManageLogin()
        {
            //如果Session为Null
            if (Session[KeysHelper.SESSION_MANAGE_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string manageName = Utils.GetCookie("ManageName", "ISS");
                string managePassword = Utils.GetCookie("ManagePwd", "ISS");
                if (manageName != "" && managePassword != "")
                {
                    BLL.Manager bll = new BLL.Manager();
                    Model.Manager model = bll.GetModel(manageName, managePassword);
                    if (model != null)
                    {
                        Session[KeysHelper.SESSION_MANAGE_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得系统用户信息
        /// </summary>
        public Model.Manager GetManageInfo()
        {
            if (IsManageLogin())
            {
                Model.Manager model = Session[KeysHelper.SESSION_MANAGE_INFO] as Model.Manager;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 检查用户是否是管理角色：true:是；false:不是
        /// </summary>
        /// <returns></returns>
        public bool ChkManageType()
        {
            HN863Soft.ISS.Model.Manager manager = GetManageInfo();
            if (manager == null)
                return false;

            HN863Soft.ISS.BLL.ManagerRole managerRoleBll = new HN863Soft.ISS.BLL.ManagerRole();
            DataSet dsRoleType = managerRoleBll.GetTypeList("");
            if (dsRoleType != null)
            {
                DataTable dt = dsRoleType.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            HN863Soft.ISS.Model.ManagerType managerType = new ManagerType();

                            managerType.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                            managerType.TypeName = dt.Rows[i]["TypeName"].ToString();
                            managerType.IsSys = int.Parse(dt.Rows[i]["IsSys"].ToString());

                            if (dt.Rows[i]["TypeName"].ToString() == "管理员" || dt.Rows[i]["TypeName"].ToString() == "版主")
                            {
                                MTypeList.Add(managerType);
                            }
                        }
                    }
                }
            }

            var tempRoleType = new HN863Soft.ISS.Model.ManagerType();
            tempRoleType = MTypeList.FirstOrDefault(x => x.ID == manager.RoleType);
            if (tempRoleType == null)
            {
                return false;
            }
            else
            {
                if (tempRoleType.ID >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 检查系统用户权限
        /// </summary>
        /// <param name="navName">菜单名称</param>
        /// <param name="actionType">操作类型</param>
        public bool ChkManageLevel(string navName, string actionType)
        {
            Model.Manager model = GetManageInfo();
            BLL.ManagerRole bll = new BLL.ManagerRole();
            return bll.Exists(model.RoleID, navName, actionType);
        }

        /// <summary>
        /// 写入管理日志
        /// </summary>
        /// <param name="action_type"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool AddManageLog(string actionType, string remark)
        {
            if (siteConfig.logstatus > 0)
            {
                Model.Manager model = GetManageInfo();
                int newId = new BLL.ManagerLog().Add(model.ID, model.UserName, actionType, remark);
                if (newId > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 消息提示============================================
        /// <summary>
        /// 一般提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        protected void ShowScriptMsg(string msgtitle, string url)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
            ClientScript.RegisterStartupScript(Page.GetType(), "JsPrint", msbox, true);
        }
        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="callback">JS回调函数</param>
        protected void ShowScriptMsg(string msgtitle, string url, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
            ClientScript.RegisterStartupScript(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion

    }
}
