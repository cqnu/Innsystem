﻿/**  版本信息模板在安装目录下，可自行修改。
* Hatchery.cs
*
* 功 能： N/A
* 类 名： Hatchery
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/2 10:36:23   N/A    初版
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
    /// Hatchery
    /// </summary>
    public partial class Hatchery
    {
        private readonly HN863Soft.ISS.DAL.Hatchery dal = new HN863Soft.ISS.DAL.Hatchery();
        public Hatchery()
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
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Hatchery model)
        {
            return dal.Add(model);
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
        //public bool DeleteList(string Idlist)
        //{
        //    return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Idlist, 0));
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.Hatchery GetModel(int Id)
        {

            return dal.GetModel(Id);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.Hatchery> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.Hatchery> DataTableToList(DataTable dt)
        {
            List<HN863Soft.ISS.Model.Hatchery> modelList = new List<HN863Soft.ISS.Model.Hatchery>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HN863Soft.ISS.Model.Hatchery model;
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


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 更新一条数据:是否审核：0未审核；1正常。
        /// </summary>
        public bool UpdateInfo(HN863Soft.ISS.Model.Hatchery model)
        {
            return dal.UpdateInfo(model);
        }

        #endregion  ExtensionMethod
    }
}

