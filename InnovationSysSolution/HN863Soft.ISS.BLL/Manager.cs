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
    /// 管理用户信息表
    /// </summary>
    public partial class Manager
    {
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly DAL.Manager dal;
        public Manager()
        {
            dal = new DAL.Manager();
        }
        #region 基本方法=============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        public bool ExistsReception(string userName)
        {
            return dal.ExistsReception(userName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistRole(int roleID)
        {
            return dal.ExistRole(roleID);
        }

        /// <summary>
        /// 权限设置为普通游客不可查看时(弥补给发布者相对应的积分，多次设置只加一次分数)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public bool UpdateIntegral(HN863Soft.ISS.Model.Users model, HN863Soft.ISS.Model.Integral imodel)
        {
            return dal.UpdateIntegral(model, imodel);
        }

        public bool GetIntegralList(HN863Soft.ISS.Model.Integral model)
        {
            return dal.GetIntegralList(model);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string userName)
        {
            return dal.GetSalt(userName);
        }

        public string GetIntegral(int id)
        {
            return dal.GetIntegral(id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Manager model)
        {
            return dal.Add(model);
        }

        public int AddUser(HN863Soft.ISS.Model.Users uModel)
        {
            return dal.AddUser(uModel);
        }

        /// <summary>
        /// 更新机构认证信息
        /// </summary>
        public bool Update(Model.Manager model, Model.Users umodel)
        {
            return dal.Update(model, umodel);
        }

        /// <summary>
        /// 更新manager表中用户对于的rowid和rotype
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="roId"></param>
        /// <returns></returns>
        public bool UpdateManagerType(int id, int type, int roId)
        {
            return dal.UpdateManagerType(id, type, roId);
        }

        /// <summary>
        /// 更新认证表中对应的type
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool UpdateOrganizationType(int userId, int type)
        {
            return dal.UpdateOrganizationType(userId, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isUseable"></param>
        /// <returns></returns>
        public bool UpdateIsUseable(int id, int isUseable, int orgType)
        {
            return dal.UpdateIsUseable(id, isUseable, orgType);
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
        public Model.Manager GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.Manager GetModel(string userName, string password)
        {
            return dal.GetModel(userName, password);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.Manager GetModel(string userName, string password, bool isEncrypt)
        {
            //检查一下是否需要加密
            if (isEncrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(userName);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                password = EncryptionHelper.Encrypt(password, salt);
            }
            return dal.GetModel(userName, password);
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


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion
    }
}
