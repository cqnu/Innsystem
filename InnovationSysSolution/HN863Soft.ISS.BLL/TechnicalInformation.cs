using System;
using System.Data;
using System.Collections.Generic;
using HN863Soft.ISS.Model;
//*****************************
// 文件名（File Name）：TechnicalInformation.cs
// 作者（Author）：邹峰
// 功能（Function）：发布、编辑、删除工业设计
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.BLL
{
    /// <summary>
    /// TechnicalInformation
    /// </summary>
    public partial class TechnicalInformation
    {
        private readonly HN863Soft.ISS.DAL.TechnicalInformation dal = new HN863Soft.ISS.DAL.TechnicalInformation();
        public TechnicalInformation()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        public int AddHits(int id)
        {
            return dal.AddHits(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.TechnicalInformation model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.TechnicalInformation model)
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

        public bool UpdateState(int id, int istate, string str,string strTable)
        {
            return dal.UpdateState(id, istate, str, strTable);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.TechnicalInformation GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public HN863Soft.ISS.Model.TechnicalInformation GetModelByCache(int ID)
        //{

        //    string CacheKey = "TechnicalInformationModel-" + ID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (HN863Soft.ISS.Model.TechnicalInformation)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, out recordCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.TechnicalInformation> DataTableToList(DataTable dt)
        {
            List<HN863Soft.ISS.Model.TechnicalInformation> modelList = new List<HN863Soft.ISS.Model.TechnicalInformation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HN863Soft.ISS.Model.TechnicalInformation model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
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


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

