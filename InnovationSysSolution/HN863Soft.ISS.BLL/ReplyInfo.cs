/**  版本信息模板在安装目录下，可自行修改。
* ReplyInfo.cs
*
* 功 能： N/A
* 类 名： ReplyInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/21 10:03:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using HN863Soft.ISS.Common;
using HN863Soft.ISS.Model;
namespace HN863Soft.ISS.BLL
{
	/// <summary>
	/// ReplyInfo
	/// </summary>
	public partial class ReplyInfo
	{
		private readonly HN863Soft.ISS.DAL.ReplyInfo dal=new HN863Soft.ISS.DAL.ReplyInfo();
		public ReplyInfo()
		{}
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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(HN863Soft.ISS.Model.ReplyInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ReplyInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string Idlist )
        //{
        //    return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Idlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.ReplyInfo GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public HN863Soft.ISS.Model.ReplyInfo GetModelByCache(int Id)
        //{
			
        //    string CacheKey = "ReplyInfoModel-" + Id;
        //    object objModel = HN863Soft.ISS.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = HN863Soft.ISS.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                HN863Soft.ISS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (HN863Soft.ISS.Model.ReplyInfo)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ReplyInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ReplyInfo> DataTableToList(DataTable dt)
		{
			List<HN863Soft.ISS.Model.ReplyInfo> modelList = new List<HN863Soft.ISS.Model.ReplyInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HN863Soft.ISS.Model.ReplyInfo model;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="sId">服务信息ID</param>
        /// <returns></returns>
        public DataSet GetListInfo(int sId)
        {
            return dal.GetALLListInfo(sId);
        }

        /// <summary>
        /// 获取普通用户评论信息列表
        /// </summary>
        /// <param name="sId">服务信息ID</param>
        /// <param name="sId">普通用户ID</param>
        /// <returns></returns>
        public DataSet GetListInfo(int sId,int userId)
        {
            return dal.GetALLListInfo(sId,userId);
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model">具体信息实体</param>
        /// <returns></returns>
        public int AddComment( Model.ReplyInfo  model)
        {
            return dal.AddComment(model);
        }

         /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateReplyInfo(HN863Soft.ISS.Model.ReplyInfo model)
        {
            return dal.UpdateReplyInfo(model);
        }

		#endregion  ExtensionMethod
	}
}

