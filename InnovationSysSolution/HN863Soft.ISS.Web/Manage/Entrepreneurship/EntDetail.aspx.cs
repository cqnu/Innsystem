using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HN863Soft.ISS.Web.Core;
using System.Data;
//***************************
//* 文件名：EntDetail.cs
//* 作者： 雷登辉
//* 功能：问题解答
//* 创建时间：2017/2/27
//***************************
namespace HN863Soft.ISS.Web.Manage.Entrepreneurship
{
    public partial class EntDetail : ManagePage
    {
        #region 函数

        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected static HN863Soft.ISS.Model.ConductInfo conductModel;//问题信息实体
        private HN863Soft.ISS.Model.ConductReply conReplyModel;//问题回复信息实体对象
        private HN863Soft.ISS.BLL.Users userBll;//前台用户处理对象
        private HN863Soft.ISS.Model.Users userModel;//前台用户实体对象
        private HN863Soft.ISS.BLL.ConductInfo conductBll;//问题信息处理对象
        private HN863Soft.ISS.BLL.ConductReply conReplyBll;//问题回复信息处理对象

        private int cId = 0;//问题信息Id
        private int uId = 0;//前台用户对象Id
        private string action = EnumsHelper.ActionEnum.Add.ToString(); //操作类型



        #endregion

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            string _action = RequestHelper.GetQueryString("action");

            this.pageSize = GetPageSize(10);

            if (!string.IsNullOrEmpty(_action) && _action == EnumsHelper.ActionEnum.View.ToString())
            {
                this.action = EnumsHelper.ActionEnum.View.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.cId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('传输参数不正确！');");
                    return;
                }
                Manager model = GetManageInfo(); //取得管理员信息
                userBll = new BLL.Users();//实例化前台用户处理对象
                userModel = userBll.GetUserModel(model.ID);//获取前台用户信息
                uId = userModel.ID;//获取前台用户Id

                if (!new HN863Soft.ISS.BLL.ConductInfo().Exists(this.cId))
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('记录不存在或已被删除！');");
                    return;
                }
            }
            if (!IsPostBack)
            {
                //ChkManageLevel("EntList", EnumsHelper.ActionEnum.View.ToString()); //检查权限

                //RoleBind(ddlRoleId, model.RoleType);
                if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
                {
                    GetData();
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.InnerText.Trim()))
            {
                ShowMsgHelper.Alert_Error("先说点什么吧！");
                return;
            }
            if (action == EnumsHelper.ActionEnum.View.ToString()) //修改
            {
                //ChkManageLevel("EntList", EnumsHelper.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    ShowMsgHelper.ShowScript("showWarningMsg('保存过程中发生错误！');setTimeout(Back, 3000);");
                    return;
                }
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = cId.ToString();//问题信息Id
                ShowMsgHelper.ShowScript("showWarningMsg('发表信息成功！');setTimeout(Back, 3000);");
                Response.Redirect(Utils.CombUrlTxt("EntDetail.aspx", "action={0}&id={1}", keys));
            }
        }


        /// <summary>
        /// 回复信息删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dlReplyInfo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = int.Parse(dlReplyInfo.DataKeys[e.Item.ItemIndex].ToString());//获取回复信息Id
                conReplyBll = new BLL.ConductReply();//实例化问题回复信息处理对象
                conReplyModel = new Model.ConductReply
                {
                    IsVis = 0,   //是否隐藏：0，是；1，否。
                    Id = id     //评论信息ID
                };
                string[] keys = new string[2];
                keys[0] = action;//提交方式
                keys[1] = id.ToString();//问题信息Id
                if (conReplyBll.UpdateReplyInfo(conReplyModel))//删除对应Id的回复信息
                {
                    AddManageLog(EnumsHelper.ActionEnum.Delete.ToString(), "删除评论"); //记录日志
                    ShowMsgHelper.ShowScript("showWarningMsg('删除信息成功！');setTimeout(Back, 3000);");
                    Response.Redirect(Utils.CombUrlTxt("EntDetail.aspx", "action={0}&id={1}", keys));
                }
            }
        }

        /// <summary>
        /// 设置分页数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("EntDetail_page_size", "ISSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("EntDetail.aspx", "action={0}&id={1}", "View",this.cId.ToString()));
        }

        #region 数据绑定=================================

        /// <summary>
        /// 获取问题回复信息
        /// </summary>
        private DataTable GetRePlyInfo()
        {
            conReplyBll = new BLL.ConductReply();//实例化问题回复信息处理对象IsVis=1 and
            //判断处理显示全部、局部 GetListInfo(问题信息Id,普通用户Id)
            DataTable replyDt = conReplyBll.GetList(this.pageSize, this.page, cId, "Id asc", out this.totalCount).Tables[0];//获取数据库分页数据
            return replyDt;
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="id">问题信息Id</param>
        private void GetData()
        {
            this.page = RequestHelper.GetQueryInt("page", 1);
            conductBll = new HN863Soft.ISS.BLL.ConductInfo();//实例化问题信息处理对象
            userBll = new BLL.Users();//实例化前台用户处理对象
            conductModel = conductBll.GetModel(cId);
            dlReplyInfo.DataSource = GetRePlyInfo();
            dlReplyInfo.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("EntDetail.aspx", "action={0}&Id={1}&page={2}", "View", this.cId.ToString(), "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            conReplyModel = new Model.ConductReply//实例化问题回复信息实体对象
            {
                Content = txtContent.InnerText,//评论内容
                UId = uId,//评论人
                IsVis = 1,//是否被隐藏：0，是；1，否。
                CId = Convert.ToInt32(Request["Id"]),//服务Id
                Time = DateTime.Now,//评论时间
                RId = Convert.ToInt32(string.IsNullOrEmpty(txtId.Value) ? null : txtId.Value) == 0 ? null : (int?)Convert.ToInt32(txtId.Value),//评论信息Id

            };
            conReplyBll = new BLL.ConductReply();//实例化问题回复信息处理对象
            //添加评论信息
            if (conReplyBll.Add(conReplyModel) != -1)
            {
                AddManageLog(EnumsHelper.ActionEnum.Add.ToString(), "添加评论:" + conductModel.Title); //记录日志
                txtContent.InnerText = string.Empty;//赋空值
                txtId.Value = string.Empty;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取每页数量
        /// </summary>
        /// <param name="_default_size"></param>
        /// <returns></returns>
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("EntDetail_page_size", "ISSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        #endregion
    }
}