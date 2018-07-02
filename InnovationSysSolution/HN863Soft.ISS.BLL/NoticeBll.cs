﻿/**  版本信息模板在安装目录下，可自行修改。
* Notice.cs
*
* 功 能： N/A
* 类 名： Notice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/14 11:35:15   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　   　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using HN863Soft.ISS.Model;
namespace HN863Soft.ISS.BLL
{
	/// <summary>
	/// Notice
	/// </summary>
	public partial class NoticeBll
	{
        private readonly HN863Soft.ISS.DAL.Notice dal=new HN863Soft.ISS.DAL.Notice();
		public NoticeBll()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(HN863Soft.ISS.Model.Notice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.Notice model)
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
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.Notice GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

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
		public List<HN863Soft.ISS.Model.Notice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.Notice> DataTableToList(DataTable dt)
		{
			List<HN863Soft.ISS.Model.Notice> modelList = new List<HN863Soft.ISS.Model.Notice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HN863Soft.ISS.Model.Notice model;
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

		#endregion  ExtensionMethod
	}
}

