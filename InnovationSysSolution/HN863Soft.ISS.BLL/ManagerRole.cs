using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{ 
    /// <summary>
    /// 管理角色
    /// </summary>
    public partial class ManagerRole
    {
         private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly DAL.ManagerRole dal;
        public ManagerRole()
        {
            dal = new DAL.ManagerRole();
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
        /// 判断类型名字是否存在
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public bool GetTypeNmae(string RoleName)
        {
            return dal.GetTypeNmae(RoleName);
        }



        /// <summary>
        /// 检查是否有权限
        /// </summary>
        public bool Exists(int roleID, string navName, string actionType)
        {
            Model.ManagerRole model = dal.GetModel(roleID);
            if (model != null)
            {
                //获取角色类型列表
                List<HN863Soft.ISS.Model.ManagerType> managerTypeList = new List<ManagerType>();
                DataSet dsManagerTypes = new HN863Soft.ISS.BLL.ManagerRole().GetTypeList("");
                if (dsManagerTypes != null)
                {
                    for (int j = 0; j < dsManagerTypes.Tables[0].Rows.Count; j++)
                    {
                        managerTypeList.Add(new ManagerType() { ID = int.Parse(dsManagerTypes.Tables[0].Rows[j]["ID"].ToString()), TypeName = dsManagerTypes.Tables[0].Rows[j]["TypeName"].ToString(), IsSys = int.Parse(dsManagerTypes.Tables[0].Rows[j]["IsSys"].ToString()) });
                    }
                }

                var tempManagerType = managerTypeList.FirstOrDefault(x => x.ID == model.RoleType);
                if (tempManagerType == null)
                {
                    return false;
                }
                else
                {
                    if (tempManagerType.TypeName == "管理员")
                    {
                        return true;
                    }
                    else
                    {
                        if (model.ManagerRoleValues == null)
                            return false;
                        Model.ManagerRoleValue modelt = model.ManagerRoleValues.Find(p => p.NavName == navName && p.ActionType == actionType);
                        if (modelt != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 返回角色名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        public int GetType()
        {
            return dal.GetType();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ManagerRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddTypeName(string typeName)
        {
            return dal.AddTypeName(typeName);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ManagerRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateType(int id,string typeName)
        {
            return dal.UpdateType(id, typeName);
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
        public Model.ManagerRole GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         public string GetT(int id)
        {
            return dal.GetT(id);
        }

        /// <summary>
         /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public HN863Soft.ISS.Model.ManagerType GetManagerType(int id)
        {
            return dal.GetManagerType(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        public DataSet GetTypeList(string strWhere)
        {
            return dal.GetTypeList(strWhere);
        }

        #endregion
    }
}
