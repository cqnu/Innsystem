using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
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

namespace _863soft.ISS.Web.Manage.SysManage
{
    public partial class RoleList : ManagePage
    {
        protected string keywords = string.Empty;
        List<HN863Soft.ISS.Model.ManagerRole> models = new List<ManagerRole>();
        List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = RequestHelper.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                if (!ChkManageLevel("ManagerRole", EnumsHelper.ActionEnum.View.ToString())) //检查权限
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                    return;
                }

                Manager model = GetManageInfo(); //取得当前用户信息

                HN863Soft.ISS.BLL.ManagerRole managerRoleBll = new HN863Soft.ISS.BLL.ManagerRole();
                DataSet ds = managerRoleBll.GetTypeList("");
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
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

                                managerTypeList.Add(managerType);
                            }
                        }
                    }
                } 

                RptBind(CombSqlTxt(this.keywords));
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere)
        {
            this.txtKeywords.Text = this.keywords;
            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            this.rptList.DataSource = bll.GetList(_strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and RoleName like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回角色类型名称=========================
        protected string GetTypeName(int roleType)
        {
            if (managerTypeList.Count <= 0)
            {
                HN863Soft.ISS.BLL.ManagerRole managerRoleBll = new HN863Soft.ISS.BLL.ManagerRole();
                DataSet ds = managerRoleBll.GetTypeList("");
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                HN863Soft.ISS.Model.ManagerType model = new ManagerType();

                                model.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                                model.TypeName = dt.Rows[i]["TypeName"].ToString();
                                model.IsSys = int.Parse(dt.Rows[i]["IsSys"].ToString());

                                managerTypeList.Add(model);
                            }
                        }
                    }
                }
            }

            var tempModel = managerTypeList.FirstOrDefault(x => x.ID == roleType);
            if (tempModel == null)
            {
                tempModel.TypeName = "待认证";
                tempModel.ID = roleType;
            }

            return tempModel.TypeName;
        }
        #endregion

        //查询操作
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("RoleList.aspx", "keywords={0}", txtKeywords.Text.Trim()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ChkManageLevel("ManagerRole", EnumsHelper.ActionEnum.Delete.ToString())) //检查权限
            {
                ShowMsgHelper.ShowScript("showWarningMsg('您没有管理该页面的权限');");
                return;
            }

            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量

            HN863Soft.ISS.BLL.ManagerRole bll = new HN863Soft.ISS.BLL.ManagerRole();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //判断改角色是否存在用户，存在，就提示先删除用户
                    HN863Soft.ISS.BLL.Manager managerBll = new HN863Soft.ISS.BLL.Manager();

                    if (managerBll.ExistRole(id))
                    {
                        ShowMsgHelper.ShowScript("showWarningMsg('该角色存在用户，请先删除用户信息！');");
                        return;
                    }

                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除用户角色" + sucCount + "条，失败" + errorCount + "条"); //记录日志

            ShowMsgHelper.ShowScript("showWarningMsg('删除成功" + sucCount + "条，失败" + errorCount + "条！');");
            ShowMsgHelper.ShowScript("location.href='/Manage/SysManage/RoleList.aspx';");
            
        }
    }
}