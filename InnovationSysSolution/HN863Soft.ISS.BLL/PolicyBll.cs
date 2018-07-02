using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class PolicyBll
    {


        private readonly HN863Soft.ISS.DAL.PolicyDal dal = new HN863Soft.ISS.DAL.PolicyDal();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, out recordCount);
        }

        public DataTable GetInfo(int id)
        {
            return dal.GetInfo(id);
        }
    }
}
