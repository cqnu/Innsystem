using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    /// <summary>
    /// 系统导航菜单
    /// </summary>
    public partial class Navigation
    {
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly DAL.Navigation dal;
        public Navigation()
        {
            dal = new DAL.Navigation();
        }

        #region 基本方法===============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 查询名称是否存在
        /// </summary>
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Navigation model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Navigation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Navigation GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Navigation GetModel(string name)
        {
            return dal.GetModel(name);
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parentID, string navType)
        {
            return dal.GetList(parentID, navType);
        }
        #endregion

        #region 扩展方法===============================
        /// <summary>
        /// 根据导航的名称查询其ID
        /// </summary>
        /// <param name="nav_name">菜单名称</param>
        /// <returns>int</returns>
        public int GetNavID(string navName)
        {
            return dal.GetNavID(navName);
        }

        /// <summary>
        /// 快捷添加系统默认导航
        /// </summary>
        /// <param name="parentName">父导航名称</param>
        /// <param name="navName">导航名称</param>
        /// <param name="title">导航标题</param>
        /// <param name="linkUrl">链接地址</param>
        /// <param name="sortID">排序数字</param>
        /// <param name="channelID">所属频道ID</param>
        /// <param name="actionType">操作权限以英文逗号分隔开</param>
        /// <returns>int</returns>
        public int Add(string parentName, string navName, string title, string linkUrl, int sortID, int channelID, string actionType)
        {
            return dal.Add(parentName, navName, title, linkUrl, sortID, channelID, actionType);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string name, string strValue)
        {
            return dal.UpdateField(name, strValue);
        }
        #endregion
    }
}
