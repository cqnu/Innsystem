using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
  public  class ManagementBll
    {

      private readonly HN863Soft.ISS.DAL.ManagementDal dal = new HN863Soft.ISS.DAL.ManagementDal();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, out recordCount);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Management model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Management GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Management model)
        {
            return dal.Update(model);
        }
    }
}
