/**  版本信息模板在安装目录下，可自行修改。
* ArticleCategory.cs
*
* 功 能： N/A
* 类 名： ArticleCategory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:58   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　   　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ArticleCategory
	/// </summary>
	public partial class ArticleCategory
	{
		public ArticleCategory(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ArticleCategory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleCategory");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from ArticleCategory");
            strSql.Append(" where ID=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ArticleCategory model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into ArticleCategory(");
                        strSql.Append("ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription)");
                        strSql.Append(" values (");
                        strSql.Append("@ChannelID,@Title,@CallIndex,@ParentID,@ClassList,@ClassLayer,@SortID,@LinkUrl,@ImgUrl,@Content,@SEOTitle,@SEOKeywords,@SEODescription)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,255)};
                        parameters[0].Value = model.ChannelID;
                        parameters[1].Value = model.Title;
                        parameters[2].Value = model.CallIndex;
                        parameters[3].Value = model.ParentID;
                        parameters[4].Value = model.ClassList;
                        parameters[5].Value = model.ClassLayer;
                        parameters[6].Value = model.SortID;
                        parameters[7].Value = model.LinkUrl;
                        parameters[8].Value = model.ImgUrl;
                        parameters[9].Value = model.Content;
                        parameters[10].Value = model.SEOTitle;
                        parameters[11].Value = model.SEOKeywords;
                        parameters[12].Value = model.SEODescription;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.ID = Convert.ToInt32(obj);

                        if (model.ParentID > 0)
                        {
                            Model.ArticleCategory model2 = GetModel(conn, trans, model.ParentID); //带事务
                            model.ClassList = model2.ClassList + model.ID + ",";
                            model.ClassLayer = model2.ClassLayer + 1;
                        }
                        else
                        {
                            model.ClassList = "," + model.ID + ",";
                            model.ClassLayer = 1;
                        }
                        //修改节点列表和深度
                        DbHelperSQL.ExecuteSql(conn, trans, "update ArticleCategory set ClassList='" + model.ClassList + "', ClassLayer=" + model.ClassLayer + " where ID=" + model.ID); //带事务
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.ID;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ArticleCategory model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                         //先判断选中的父节点是否被包含
                        if (IsContainNode(model.ID, model.ParentID))
                        {
                            //查找旧数据
                            Model.ArticleCategory oldModel = GetModel(model.ID);
                            //查找旧父节点数据
                            string classList = "," + model.ParentID + ",";
                            int classLayer = 1;
                            if (oldModel.ParentID > 0)
                            {
                                Model.ArticleCategory oldParentModel = GetModel(conn, trans, oldModel.ParentID); //带事务
                                classList = oldParentModel.ClassList + model.ParentID + ",";
                                classLayer = oldParentModel.ClassLayer + 1;
                            }
                            //先提升选中的父节点
                            DbHelperSQL.ExecuteSql(conn, trans, "update ArticleCategory set ParentID=" + oldModel.ParentID + ",ClassList='" + classList + "', ClassLayer=" + classLayer + " where ID=" + model.ParentID); //带事务
                            UpdateChilds(conn, trans, model.ParentID); //带事务
                        }
                        //更新子节点
                        if (model.ParentID > 0)
                        {
                            Model.ArticleCategory model2 = GetModel(conn, trans, model.ParentID); //带事务
                            model.ClassList = model2.ClassList + model.ID + ",";
                            model.ClassLayer = model2.ClassLayer + 1;
                        }
                        else
                        {
                            model.ClassList = "," + model.ID + ",";
                            model.ClassLayer = 1;
                        }

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update ArticleCategory set ");
                        strSql.Append("ChannelID=@ChannelID,");
                        strSql.Append("Title=@Title,");
                        strSql.Append("CallIndex=@CallIndex,");
                        strSql.Append("ParentID=@ParentID,");
                        strSql.Append("ClassList=@ClassList,");
                        strSql.Append("ClassLayer=@ClassLayer,");
                        strSql.Append("SortID=@SortID,");
                        strSql.Append("LinkUrl=@LinkUrl,");
                        strSql.Append("ImgUrl=@ImgUrl,");
                        strSql.Append("Content=@Content,");
                        strSql.Append("SEOTitle=@SEOTitle,");
                        strSql.Append("SEOKeywords=@SEOKeywords,");
                        strSql.Append("SEODescription=@SEODescription");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,255),
					new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.ChannelID;
                        parameters[1].Value = model.Title;
                        parameters[2].Value = model.CallIndex;
                        parameters[3].Value = model.ParentID;
                        parameters[4].Value = model.ClassList;
                        parameters[5].Value = model.ClassLayer;
                        parameters[6].Value = model.SortID;
                        parameters[7].Value = model.LinkUrl;
                        parameters[8].Value = model.ImgUrl;
                        parameters[9].Value = model.Content;
                        parameters[10].Value = model.SEOTitle;
                        parameters[11].Value = model.SEOKeywords;
                        parameters[12].Value = model.SEODescription;
                        parameters[13].Value = model.ID;

                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        //更新子节点
                        UpdateChilds(conn, trans, model.ID);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleCategory set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleCategory where ClassList like '%," + ID + ",%' ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassList", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleCategory ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.ArticleCategory GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription from ArticleCategory ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ArticleCategory model=new HN863Soft.ISS.Model.ArticleCategory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        public Model.ArticleCategory GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription from ArticleCategory ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.ArticleCategory model = new Model.ArticleCategory();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.ArticleCategory DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleCategory model=new HN863Soft.ISS.Model.ArticleCategory();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ChannelID"]!=null && row["ChannelID"].ToString()!="")
				{
					model.ChannelID=int.Parse(row["ChannelID"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["CallIndex"]!=null)
				{
					model.CallIndex=row["CallIndex"].ToString();
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["ClassList"]!=null)
				{
					model.ClassList=row["ClassList"].ToString();
				}
				if(row["ClassLayer"]!=null && row["ClassLayer"].ToString()!="")
				{
					model.ClassLayer=int.Parse(row["ClassLayer"].ToString());
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["LinkUrl"]!=null)
				{
					model.LinkUrl=row["LinkUrl"].ToString();
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["SEOTitle"]!=null)
				{
					model.SEOTitle=row["SEOTitle"].ToString();
				}
				if(row["SEOKeywords"]!=null)
				{
					model.SEOKeywords=row["SEOKeywords"].ToString();
				}
				if(row["SEODescription"]!=null)
				{
					model.SEODescription=row["SEODescription"].ToString();
				}
			}
			return model;
		}

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parentID, int channelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription from ArticleCategory ");
            strSql.Append(" where ChannelID=" + channelID + " and ParentID=" + parentID + " order by SortID asc,ID desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription FROM ArticleCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription FROM ArticleCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parentID, int channelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ChannelID,Title,CallIndex,ParentID,ClassList,ClassLayer,SortID,LinkUrl,ImgUrl,Content,SEOTitle,SEOKeywords,SEODescription from ArticleCategory ");
            strSql.Append(" where ChannelID=" + channelID + " order by SortID asc,ID desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parentID, channelID);
            return newData;
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parentID, int channelID)
        {
            DataRow[] dr = oldData.Select("ParentID=" + parentID);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["ID"] = int.Parse(dr[i]["ID"].ToString());
                row["ChannelID"] = int.Parse(dr[i]["ChannelID"].ToString());
                row["Title"] = dr[i]["Title"].ToString();
                row["CallIndex"] = dr[i]["CallIndex"].ToString();
                row["ParentID"] = int.Parse(dr[i]["ParentID"].ToString());
                row["ClassList"] = dr[i]["ClassList"].ToString();
                row["ClassLayer"] = int.Parse(dr[i]["ClassLayer"].ToString());
                row["SortID"] = int.Parse(dr[i]["SortID"].ToString());
                row["LinkUrl"] = dr[i]["LinkUrl"].ToString();
                row["ImgUrl"] = dr[i]["ImgUrl"].ToString();
                row["Content"] = dr[i]["Content"].ToString();
                row["SEOTitle"] = dr[i]["SEOTitle"].ToString();
                row["SEOKeywords"] = dr[i]["SEOKeywords"].ToString();
                row["SEODescription"] = dr[i]["SEODescription"].ToString();
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["ID"].ToString()), channelID);
            }
        }


        public int GetParentID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ParentID from ArticleCategory where ID=" + id);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id"></param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parentID)
        {
            //查找父节点信息
            Model.ArticleCategory model = GetModel(conn, trans, parentID);
            if (model != null)
            {
                //查找子节点
                string strSql = "select ID from ArticleCategory where ParentID=" + parentID;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["ID"].ToString());
                    string classList = model.ClassList + id + ",";
                    int classLayer = model.ClassLayer + 1;
                    DbHelperSQL.ExecuteSql(conn, trans, "update ArticleCategory set ClassList='" + classList + "', ClassLayer=" + classLayer + " where ID=" + id); //带事务

                    //调用自身迭代
                    this.UpdateChilds(conn, trans, id); //带事务
                }
            }
        }

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        /// <param name="id">待查询的节点</param>
        /// <param name="parent_id">父节点</param>
        /// <returns></returns>
        private bool IsContainNode(int id, int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ArticleCategory where ClassList like '%," + id + ",%' and ID=" + parentID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ArticleCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ArticleCategory T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ArticleCategory";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

