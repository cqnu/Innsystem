using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
   public class RoadshowBll
    {

       private readonly HN863Soft.ISS.DAL.RoadshowDal dal = new HN863Soft.ISS.DAL.RoadshowDal();


        /// <summary>
        /// 获取模版
        /// </summary>
        /// <returns></returns>
        public DataSet GetTemplate()
        {
            return dal.GetTemplate();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Roadshow model)
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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateState(Roadshow model)
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
        public Roadshow GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Roadshow model)
        {
            return dal.Update(model);
        }
    }
}
