using HN863Soft.ISS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
     /// <summary>
    /// 管理日志
    /// </summary>
    public partial class ManagerLog
    {
         private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly DAL.ManagerLog dal;
        public ManagerLog()
        {
            dal = new DAL.ManagerLog();
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加管理日志
        /// </summary>
        /// <param name="用户id"></param>
        /// <param name="用户名"></param>
        /// <param name="操作类型"></param>
        /// <param name="备注"></param>
        /// <returns></returns>
        public int Add(int userID, string userName, string actionType, string remark)
        {
            Model.ManagerLog manager_log_model = new Model.ManagerLog();
            manager_log_model.UserID = userID;
            manager_log_model.UserName = userName;
            manager_log_model.ActionType = actionType;
            manager_log_model.Remark = remark;
            manager_log_model.UserIP = RequestHelper.GetIP();
            return dal.Add(manager_log_model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ManagerLog model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除几天的日志数据
        /// </summary>
        public bool Delete(int dayCount)
        {
            return dal.Delete(dayCount);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ManagerLog GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.ManagerLog GetModel(string userName, int topNum, string actionType)
        {
            return dal.GetModel(userName, topNum, actionType);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion
    }
}
