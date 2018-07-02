using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class LinkPatentBll
    {
        private readonly HN863Soft.ISS.DAL.LinkPatentDal dal = new HN863Soft.ISS.DAL.LinkPatentDal();


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, out recordCount);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.LinkPatent GetModel(int ID)
        {

            return dal.GetModel(ID);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.LinkPatent model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.LinkPatent model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
    }
}
