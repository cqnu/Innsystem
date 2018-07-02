using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
  public  class TechnicalServiceBll
    {
      private readonly HN863Soft.ISS.DAL.TechnicalServiceDal dal = new HN863Soft.ISS.DAL.TechnicalServiceDal();

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
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.TechnicalService model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.TechnicalService model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.TechnicalService GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        public int AddHits(int id)
        {
            return dal.AddHits(id);
        }

        public DataSet ShowToptie(int id)
        {
            return dal.ShowToptie(id);
        }

        public DataSet ShowFinancingClass(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.ShowFinancingClass(pageSize, pageIndex, strWhere, out recordCount);
        }

        public DataSet ShowFinancingClassInfo(string strWhere)
        {
            return dal.ShowFinancingClassInfo(strWhere);
        }

        public int AddFinancingClass(HN863Soft.ISS.Model.TechnicalService model)
        {
            return dal.AddFinancingClass(model);
        }

        public bool UpdateComment(int id)
        {
            return dal.UpdateComment(id);
        }

        public DataSet GetName(int id)
        {
            return dal.GetName(id);
        }
    }
}
