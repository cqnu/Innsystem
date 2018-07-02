using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class IntellectualBll
    {
        private readonly HN863Soft.ISS.DAL.IntellectualDal dal = new HN863Soft.ISS.DAL.IntellectualDal();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Intellectual model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Intellectual model)
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
        public bool UpdateState(HN863Soft.ISS.Model.Intellectual model)
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
        public Intellectual GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
    }
}
