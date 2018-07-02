using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HN863Soft.ISS.BLL
{
    public class FiscalBll
    {
        private readonly HN863Soft.ISS.DAL.FiscalDal dal = new HN863Soft.ISS.DAL.FiscalDal();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Fiscal model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Fiscal model)
        {
            return dal.Update(model);
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
        public bool UpdateState(HN863Soft.ISS.Model.Fiscal model)
        {
            return dal.UpdateState(model);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, order, out recordCount);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Fiscal GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
    }
}
