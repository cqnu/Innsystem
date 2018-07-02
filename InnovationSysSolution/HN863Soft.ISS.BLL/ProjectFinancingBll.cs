using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    public class ProjectFinancingBll
    {
        private readonly HN863Soft.ISS.DAL.ProjectFinancingDal dal = new HN863Soft.ISS.DAL.ProjectFinancingDal();

        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public DataSet GetProvince()
        {
            return dal.GetProvince();
        }

        public DataSet GetS(string ProvinceID)
        {
            return dal.GetS(ProvinceID);
        }

        /// <summary>
        /// 获取市
        /// </summary>
        /// <param name="strProvinceID"></param>
        /// <returns></returns>
        public DataSet GetCity(string strProvinceID)
        {
            return dal.GetCity(strProvinceID);
        }

        public DataSet GetShi(string CityId)
        {
            return dal.GetShi(CityId);
        }

        /// <summary>
        /// 获取对应城市的省份
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns></returns>
        public string GetProvince(string cityId)
        {
            return dal.GetProvince(cityId);
        }

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
        public int Add(HN863Soft.ISS.Model.ProjectFinancing model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProjectFinancing model)
        {
            return dal.Update(model);
        }

        public bool UpdateJurisdiction(string strTable,int id,int state)
        {
            return dal.UpdateJurisdiction(strTable, id, state);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateState(ProjectFinancing model)
        {
            return dal.UpdateState(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProjectFinancing GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        //public ProjectFinancing GetShowModel(int ID)
        //{
        //    return dal.GetShowModel(ID);
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, order, out recordCount);
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
