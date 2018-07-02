using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public partial class UserCode
    {
        public UserCode() { }

        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly DAL.UserCode dal = new DAL.UserCode();

        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string type, string userName)
        {
            return dal.Exists(type, userName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserCode model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.UserCode model)
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
        /// 根据条件批量删除
        /// </summary>
        public bool Delete(string strWhere)
        {
            return dal.Delete(strWhere);
        }

        /// <summary>
        /// 根据生成码得到一个对象实体
        /// </summary>
        public Model.UserCode GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据生成码得到一个对象实体
        /// </summary>
        public Model.UserCode GetModel(string strCode)
        {
            return dal.GetModel(strCode);
        }

        /// <summary>
        /// 根据用户名得到一个对象实体
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="codeType">验证码类型</param>
        /// <param name="datepart">日期格式,d(天)hh(小时)n(分钟)s秒</param>
        /// <returns></returns>
        public Model.UserCode GetModel(string userName, string codeType, string datepart)
        {
            return dal.GetModel(userName, codeType, datepart);
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

        #region 扩展方法================================
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        #endregion
    }
}
