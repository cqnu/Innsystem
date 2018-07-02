/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttributeField.cs
*
* 功 能： N/A
* 类 名： ArticleAttributeField
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

namespace HN863Soft.ISS.BLL
{
	/// <summary>
	/// 扩展属性表
	/// </summary>
	public partial class ArticleAttributeField
	{
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
		private readonly HN863Soft.ISS.DAL.ArticleAttributeField dal=new HN863Soft.ISS.DAL.ArticleAttributeField();
		public ArticleAttributeField(){}
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
        /// 查询是否存在列
        /// </summary>
        public bool Exists(string columnName)
        {
            return dal.Exists(columnName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(HN863Soft.ISS.Model.ArticleAttributeField model)
		{
            switch (model.ControlType)
            {
                case "single-text": //单行文本
                    if (model.DataLength > 0 && model.DataLength <= 4000)
                    {
                        model.DataType = "nvarchar(" + model.DataLength + ")";
                    }
                    else if (model.DataLength > 4000)
                    {
                        model.DataType = "ntext";
                    }
                    else
                    {
                        model.DataLength = 50;
                        model.DataType = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    model.DataType = "ntext";
                    break;
                case "images": //图片
                    model.DataType = "nvarchar(255)";
                    break;
                case "video": //视频
                    model.DataType = "nvarchar(255)";
                    break;
                case "number": //数字
                    if (model.DataPlace > 0)
                    {
                        model.DataType = "decimal(9," + model.DataPlace + ")";
                    }
                    else
                    {
                        model.DataType = "int";
                    }
                    break;
                case "checkbox": //复选框
                    model.DataType = "tinyint";
                    break;
                case "multi-radio": //多项单选
                    if (model.DataType == "int")
                    {
                        model.DataLength = 4;
                        model.DataType = "int";
                    }
                    else
                    {
                        if (model.DataLength > 0 && model.DataLength <= 4000)
                        {
                            model.DataType = "nvarchar(" + model.DataLength + ")";
                        }
                        else if (model.DataLength > 4000)
                        {
                            model.DataType = "ntext";
                        }
                        else
                        {
                            model.DataLength = 50;
                            model.DataType = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //多项多选
                    goto case "single-text";
            }
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ArticleAttributeField model)
		{
            switch (model.ControlType)
            {
                case "single-text": //单行文本
                    if (model.DataLength > 0 && model.DataLength <= 4000)
                    {
                        model.DataType = "nvarchar(" + model.DataLength + ")";
                    }
                    else if (model.DataLength > 4000)
                    {
                        model.DataType = "ntext";
                    }
                    else
                    {
                        model.DataLength = 50;
                        model.DataType = "nvarchar(50)";
                    }
                    break;
                case "multi-text": //多行文本
                    goto case "single-text";
                case "editor": //编辑器
                    model.DataType = "ntext";
                    break;
                case "images": //图片
                    model.DataType = "nvarchar(255)";
                    break;
                case "video": //视频
                    model.DataType = "nvarchar(255)";
                    break;
                case "number": //数字
                    if (model.DataPlace > 0)
                    {
                        model.DataType = "decimal(9," + model.DataPlace + ")";
                    }
                    else
                    {
                        model.DataType = "int";
                    }
                    break;
                case "checkbox": //复选框
                    model.DataType = "tinyint";
                    break;
                case "multi-radio": //多项单选
                    if (model.DataType == "int")
                    {
                        model.DataLength = 4;
                        model.DataType = "int";
                    }
                    else
                    {
                        if (model.DataLength > 0 && model.DataLength <= 4000)
                        {
                            model.DataType = "nvarchar(" + model.DataLength + ")";
                        }
                        else if (model.DataLength > 4000)
                        {
                            model.DataType = "ntext";
                        }
                        else
                        {
                            model.DataLength = 50;
                            model.DataType = "nvarchar(50)";
                        }
                    }

                    break;
                case "multi-checkbox": //多项多选
                    goto case "single-text";
            }
			return dal.Update(model);
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
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
		public HN863Soft.ISS.Model.ArticleAttributeField GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ArticleAttributeField> GetModelList(int channelID, string strWhere)
        {
            DataSet ds = dal.GetList(channelID, strWhere);
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
        /// 获得频道对应的数据
        /// </summary>
        public DataSet GetList(int channelID, string strWhere)
        {
            return dal.GetList(channelID, strWhere);
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
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ArticleAttributeField> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HN863Soft.ISS.Model.ArticleAttributeField> DataTableToList(DataTable dt)
		{
			List<HN863Soft.ISS.Model.ArticleAttributeField> modelList = new List<HN863Soft.ISS.Model.ArticleAttributeField>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HN863Soft.ISS.Model.ArticleAttributeField model;
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

