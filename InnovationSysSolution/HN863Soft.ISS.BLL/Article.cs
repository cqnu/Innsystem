/**  版本信息模板在安装目录下，可自行修改。
* Article.cs
*
* 功 能： N/A
* 类 名： Article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:57   N/A    初版
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
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.BLL
{
	/// <summary>
	/// Article
	/// </summary>
	public partial class Article
	{
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
		private readonly HN863Soft.ISS.DAL.Article dal=new HN863Soft.ISS.DAL.Article();
		public Article(){}
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string callIndex)
        {
            return dal.Exists(callIndex);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(HN863Soft.ISS.Model.Article model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.Article model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
            string content = dal.GetContent(ID); //获取信息内容
            bool result = dal.Delete(ID);
            if (result && !string.IsNullOrEmpty(content))
            {
                Utils.DeleteContentPic(content, siteConfig.webpath + siteConfig.filepath); //删除内容图片
            }
            return result;
		}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string IDlist )
        //{
        //    //return dal.DeleteList(SafeLongFilter(IDlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.Article GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Article GetModel(string callIndex)
        {
            return dal.GetModel(callIndex);
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int channelID, int categoryID, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channelID, categoryID, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.Article> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.Article> DataTableToList(DataTable dt)
		{
			List<HN863Soft.ISS.Model.Article> modelList = new List<HN863Soft.ISS.Model.Article>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HN863Soft.ISS.Model.Article model;
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
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title)
        {
            return dal.ExistsTitle(title);
        }
        /// <summary>
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title, int categoryID)
        {
            return dal.ExistsTitle(title, categoryID);
        }

        /// <summary>
        /// 返回信息标题
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 获取阅读次数
        /// </summary>
        public int GetClick(int id)
        {
            return dal.GetClick(id);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
       
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
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

        #region 前台模板调用方法========================
        /// <summary>
        /// 根据视图显示前几条数据
        /// </summary>
        public DataSet GetList(string channelName, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channelName, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据视图显示前几条数据
        /// </summary>
        public DataSet GetList(string channelName, int categoryID, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channelName, categoryID, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据视图获得查询分页数据
        /// </summary>
        public DataSet GetList(string channelName, int categoryID, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channelName, categoryID, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 根据视图获取总记录数
        /// </summary>
        public int GetCount(string channelName, int categoryID, string strWhere)
        {
            return dal.GetCount(channelName, categoryID, strWhere);
        }

        /// <summary>
        /// 获得关健字查询分页数据(搜索用到)
        /// </summary>
        public DataSet GetSearch(string channelName, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetSearch(channelName, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion
	}
}

