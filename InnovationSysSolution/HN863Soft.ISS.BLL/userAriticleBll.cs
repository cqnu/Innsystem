using System;
using System.Data;
using System.Collections.Generic;
using HN863Soft.ISS.Model;
//*****************************
// 文件名（File Name）：userAriticleBll.cs
// 作者（Author）：邹峰
// 功能（Function）：发布、编辑、删除技术资源信息
// 创建日期（Create Date）：2017/02/14
namespace HN863Soft.ISS.BLL
{
    /// <summary>
    /// userAriticle
    /// </summary>
    public partial class userAriticle
    {
        private readonly HN863Soft.ISS.DAL.userAriticle dal = new HN863Soft.ISS.DAL.userAriticle();
        public userAriticle()
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.userAriticle model)
        {
            return dal.Add(model);
        }

        public int AddAriticleClass(HN863Soft.ISS.Model.userAriticle model)
        {
            return dal.AddAriticleClass(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.userAriticle model)
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

        public int AddHits(int id)
        {
            return dal.AddHits(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.userAriticle GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public HN863Soft.ISS.Model.userAriticle GetModelByCache(int ID)
        //{

        //    string CacheKey = "userAriticleModel-" + ID;
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
        //    return (HN863Soft.ISS.Model.userAriticle)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, order, out recordCount);
        }

        public DataSet ShowToptie(int id)
        {
            return dal.ShowToptie(id);
        }

        public DataSet ShowAriticleClass(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            return dal.ShowAriticleClass(pageSize, pageIndex, strWhere, out recordCount);
        }

        public DataSet ShowAriticleClassInfo(string strWhere)
        {
            return dal.ShowAriticleClassInfo(strWhere);
        }

        public int SelAriticleClassCid(int id)
        {
            return dal.SelAriticleClassCid(id);
        }

        public DataSet GetName(int id)
        {
            return dal.GetName(id);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.userAriticle> DataTableToList(DataTable dt)
        {
            List<HN863Soft.ISS.Model.userAriticle> modelList = new List<HN863Soft.ISS.Model.userAriticle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HN863Soft.ISS.Model.userAriticle model;
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



        public bool UpdateComment(int id)
        {
            return dal.UpdateComment(id);
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

