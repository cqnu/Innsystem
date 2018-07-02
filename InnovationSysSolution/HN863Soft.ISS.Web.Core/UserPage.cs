using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HN863Soft.ISS.Web.Core
{
    public partial class UserPage : BasePage
    {
        protected Model.Users userModel;
        protected Model.user_groups groupModel;

        /// <summary>
        /// 重写父类的虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            this.Init += new EventHandler(UserPage_Init); //加入IInit事件
        }

        /// <summary>
        /// OnInit事件,检查用户是否登录
        /// </summary>
        void UserPage_Init(object sender, EventArgs e)
        {
            if (!IsUserLogin())
            {
                //跳转URL
                HttpContext.Current.Response.Redirect(linkurl("login"));
                return;
            }
            //获得登录用户信息
            userModel = GetUserInfo();
            groupModel = new BLL.user_groups().GetModel(userModel.group_id);
            if (groupModel == null)
            {
                groupModel = new Model.user_groups();
            }
            InitPage();
        }

        /// <summary>
        /// 构建一个虚方法，供子类重写
        /// </summary>
        protected virtual void InitPage()
        {
            //无任何代码
        }
    }
}
