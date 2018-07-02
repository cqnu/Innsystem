/**  版本信息模板在安装目录下，可自行修改。
* ChannelSite.cs
*
* 功 能： N/A
* 类 名： ChannelSite
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:59   N/A    初版
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
using System.IO;

namespace HN863Soft.ISS.BLL
{
	/// <summary>
	/// 频道分类
	/// </summary>
	public partial class ChannelSite
	{
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
		private readonly HN863Soft.ISS.DAL.ChannelSite dal=new HN863Soft.ISS.DAL.ChannelSite();
		public ChannelSite(){}
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
        /// 查询生成目录名是否存在
        /// </summary>
        public bool Exists(string buildPath)
        {
            //与站点目录下的一级文件夹是否重名
            if (DirPathExists(siteConfig.webpath, buildPath))
            {
                return true;
            }
            //与站点aspx目录下的一级文件夹是否重名
            if (DirPathExists(siteConfig.webpath + "/" + KeysHelper.DIRECTORY_REWRITE_ASPX + "/", buildPath))
            {
                return true;
            }
            //与频道名称是否重名
            if (new DAL.Channel().Exists(buildPath))
            {
                return true;
            }
            //与其它站点目录是否重名
            if (dal.Exists(buildPath))
            {
                return true;
            }
            return false;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(HN863Soft.ISS.Model.ChannelSite model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ChannelSite model)
		{
            string oldBuildPath = dal.GetBuildPath(model.ID);
            if (string.IsNullOrEmpty(oldBuildPath))
            {
                return false;
            }
            if (dal.Update(model, oldBuildPath))
            {
                if (oldBuildPath.ToLower() != model.BuildPath.ToLower())
                {
                    //更改频道分类对应的目录名称
                    Utils.MoveDirectory(siteConfig.webpath + KeysHelper.DIRECTORY_REWRITE_ASPX + "/" + oldBuildPath,
                        siteConfig.webpath + KeysHelper.DIRECTORY_REWRITE_ASPX + "/" + model.BuildPath);
                    Utils.MoveDirectory(siteConfig.webpath + KeysHelper.DIRECTORY_REWRITE_HTML + "/" + oldBuildPath,
                        siteConfig.webpath + KeysHelper.DIRECTORY_REWRITE_HTML + "/" + model.BuildPath);
                }
                return true;
            }
            return false;
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
		public HN863Soft.ISS.Model.ChannelSite GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ChannelSite GetModel(string buildPath)
        {
            return dal.GetModel(buildPath);
        }

        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetTitle(string buildPath)
        {
            return dal.GetTitle(buildPath);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string buildPath, string strValue)
        {
            return dal.UpdateField(buildPath, strValue);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        public bool UpdateSort(int id, int sortID)
        {
            //取得站点的目录名
            string build_path = dal.GetBuildPath(id);
            if (build_path == string.Empty)
            {
                return false;
            }
            new BLL.Navigation().UpdateField("channel_" + build_path, "SortID=" + sortID);
            dal.UpdateField(id, "SortID=" + sortID);
            return true;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ChannelSite> GetModelList()
        {
            DataSet ds = dal.GetList(0, string.Empty, "SortID asc,ID desc");
            return DataTableToList(ds.Tables[0]);
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 检查生成目录名与指定路径下的一级目录是否同名
        /// </summary>
        /// <param name="dirPath">指定的路径</param>
        /// <param name="buildPath">生成目录名</param>
        /// <returns>bool</returns>
        private bool DirPathExists(string dirPath, string buildPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(dirPath));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (buildPath.ToLower() == dir.Name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ChannelSite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ChannelSite> DataTableToList(DataTable dt)
		{
			List<HN863Soft.ISS.Model.ChannelSite> modelList = new List<HN863Soft.ISS.Model.ChannelSite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HN863Soft.ISS.Model.ChannelSite model;
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

