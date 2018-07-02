/**  版本信息模板在安装目录下，可自行修改。
* Channel.cs
*
* 功 能： N/A
* 类 名： Channel
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
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Common;
using System.Collections.Generic;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:Channel
	/// </summary>
	public partial class Channel
	{
		public Channel(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Channel"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Channel");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Channel");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.Channel model)
		{
            //取得站点对应的导航ID
            int parent_id = new DAL.ChannelSite().GetSiteNavID(model.SiteID);
            if (parent_id == 0)
            {
                return 0;
            }
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into Channel(");
                        strSql.Append("SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID)");
                        strSql.Append(" values (");
                        strSql.Append("@SiteID,@Name,@Title,@IsAlbums,@IsAttach,@IsSpec,@SortID)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@SiteID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@IsAlbums", SqlDbType.TinyInt,1),
					new SqlParameter("@IsAttach", SqlDbType.TinyInt,1),
					new SqlParameter("@IsSpec", SqlDbType.TinyInt,1),
					new SqlParameter("@SortID", SqlDbType.Int,4)};
                        parameters[0].Value = model.SiteID;
                        parameters[1].Value = model.Name;
                        parameters[2].Value = model.Title;
                        parameters[3].Value = model.IsAlbums;
                        parameters[4].Value = model.IsAttach;
                        parameters[5].Value = model.IsSpec;
                        parameters[6].Value = model.SortID;
                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.ID = Convert.ToInt32(obj);

                        //扩展字段
                        if (model.ChannelFields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.ChannelField modelt in model.ChannelFields)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into ChannelField(");
                                strSql2.Append("ChannelID,FieldID)");
                                strSql2.Append(" values (");
                                strSql2.Append("@ChannelID,@FieldID)");
                                SqlParameter[] parameters2 = {
					                    new SqlParameter("@ChannelID", SqlDbType.Int,4),
					                    new SqlParameter("@FieldID", SqlDbType.Int,4)};
                                parameters2[0].Value = model.ID;
                                parameters2[1].Value = modelt.FieldID;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }

                        //添加视图
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("CREATE VIEW ViewChannel" + model.Name + " as");
                        strSql3.Append(" SELECT Article.*");
                        if (model.ChannelFields != null)
                        {
                            foreach (Model.ChannelField item in model.ChannelFields)
                            {
                                Model.ArticleAttributeField fieldModel = new DAL.ArticleAttributeField().GetModel(item.FieldID);
                                if (fieldModel != null)
                                {
                                    strSql3.Append(",ArticleAttributeValue." + fieldModel.Name);
                                }
                            }
                        }
                        strSql3.Append(" FROM ArticleAttributeValue INNER JOIN");
                        strSql3.Append(" Article ON ArticleAttributeValue.ArticleID = Article.ID");
                        strSql3.Append(" WHERE Article.ChannelID=" + model.ID);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString());

                        //添加导航菜单
                        int newNavId = new DAL.Navigation().Add(conn, trans, parent_id, "channel_" + model.Name, model.Title, "", model.SortID, model.ID, "Show");
                        new DAL.Navigation().Add(conn, trans, newNavId, "channel_" + model.Name + "_list", "内容管理", "article/ArticleList.aspx", 99, model.ID, "Show,View,Add,Edit,Delete,Audit");
                        //new DAL.Navigation().Add(conn, trans, newNavId, "channel_" + model.Name + "_category", "栏目类别", "article/CategoryList.aspx", 100, model.ID, "Show,View,Add,Edit,Delete");
                        new DAL.Navigation().Add(conn, trans, newNavId, "channel_" + model.Name + "_comment", "评论管理", "article/CommentList.aspx", 101, model.ID, "Show,View,Delete,Reply");

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
        public bool Update(HN863Soft.ISS.Model.Channel model)
        {
            Model.Channel oldModel = GetModel(model.ID); //旧的数据
            //取得站点对应的导航ID
            int parent_id = new DAL.ChannelSite().GetSiteNavID(model.SiteID);
            if (parent_id == 0)
            {
                return false;
            }
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update Channel set ");
                        strSql.Append("SiteID=@SiteID,");
                        strSql.Append("Name=@Name,");
                        strSql.Append("Title=@Title,");
                        strSql.Append("IsAlbums=@IsAlbums,");
                        strSql.Append("IsAttach=@IsAttach,");
                        strSql.Append("IsSpec=@IsSpec,");
                        strSql.Append("SortID=@SortID");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@SiteID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@IsAlbums", SqlDbType.TinyInt,1),
					new SqlParameter("@IsAttach", SqlDbType.TinyInt,1),
					new SqlParameter("@IsSpec", SqlDbType.TinyInt,1),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.SiteID;
                        parameters[1].Value = model.Name;
                        parameters[2].Value = model.Title;
                        parameters[3].Value = model.IsAlbums;
                        parameters[4].Value = model.IsAttach;
                        parameters[5].Value = model.IsSpec;
                        parameters[6].Value = model.SortID;
                        parameters[7].Value = model.ID;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已移除的扩展字段
                        FieldDelete(conn, trans, model.ChannelFields, model.ID);
                        //添加扩展字段
                        if (model.ChannelFields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.ChannelField modelt in model.ChannelFields)
                            {
                                strSql2 = new StringBuilder();
                                Model.ChannelField fieldModel = null;
                                if (oldModel.ChannelFields != null)
                                {
                                    fieldModel = oldModel.ChannelFields.Find(p => p.FieldID == modelt.FieldID); //查找是否已经存在
                                }
                                if (fieldModel == null) //如果不存在则添加
                                {
                                    strSql2.Append("insert into ChannelField(");
                                    strSql2.Append("ChannelID,FieldID)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@ChannelID,@FieldID)");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@ChannelID", SqlDbType.Int,4),
					                        new SqlParameter("@FieldID", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.ChannelID;
                                    parameters2[1].Value = modelt.FieldID;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }
                        //删除旧视图重建新视图
                        DeleteAndRebuildChannelViews(conn, trans, model, oldModel.Name);

                        //修改对应的导航
                        new DAL.Navigation().Update(conn, trans, "channel_" + oldModel.Name, parent_id, "channel_" + model.Name, model.Title, model.SortID);
                        new DAL.Navigation().Update(conn, trans, "channel_" + oldModel.Name + "_list", "channel_" + model.Name + "_list"); //内容管理
                        //new DAL.Navigation().Update(conn, trans, "channel_" + oldModel.Name + "_category", "channel_" + model.Name + "_category"); //栏目类别
                        new DAL.Navigation().Update(conn, trans, "channel_" + oldModel.Name + "_comment", "channel_" + model.Name + "_comment"); //评论管理

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int id)
        {
            //取得频道的名称
            string channelName = GetChannelName(id);
            if (string.IsNullOrEmpty(channelName))
            {
                return false;
            }
            //取得要删除的所有导航ID
            string navIDs = new Navigation().GetIDs("channel_" + channelName);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //删除导航主表
                        if (!string.IsNullOrEmpty(navIDs))
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from Navigation where id in(" + navIDs + ")");
                        }

                        //删除视图
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("if exists (select 1 from sysobjects where id = object_id('ViewChannel" + channelName + "') and type = 'V')");
                        strSql1.Append("drop View ViewChannel" + channelName);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());

                        //删除频道扩展字段表
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from ChannelField where ChannelID=@ChannelID ");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@ChannelID", SqlDbType.Int,4)};
                        parameters2[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //删除频道表
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("delete from Channel where ID=@ID ");
                        SqlParameter[] parameters3 = {
					            new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters3[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Channel ");
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
		public HN863Soft.ISS.Model.Channel GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID from Channel ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.Channel model=new HN863Soft.ISS.Model.Channel();
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
        /// 得到一个对象实体
        /// </summary>
        public Model.Channel GetModel(string channelName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID from Channel ");
            strSql.Append(" where Name=@ChannelName ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelName", SqlDbType.VarChar,50)};
            parameters[0].Value = channelName;

            Model.Channel model = new Model.Channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        /// 得到一个对象实体，带事务
        /// </summary>
        public Model.Channel GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID from Channel ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.Channel model = new Model.Channel();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(conn, trans, ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.Channel DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.Channel model=new HN863Soft.ISS.Model.Channel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["SiteID"]!=null && row["SiteID"].ToString()!="")
				{
					model.SiteID=int.Parse(row["SiteID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["IsAlbums"]!=null && row["IsAlbums"].ToString()!="")
				{
					model.IsAlbums=int.Parse(row["IsAlbums"].ToString());
				}
				if(row["IsAttach"]!=null && row["IsAttach"].ToString()!="")
				{
					model.IsAttach=int.Parse(row["IsAttach"].ToString());
				}
				if(row["IsSpec"]!=null && row["IsSpec"].ToString()!="")
				{
					model.IsSpec=int.Parse(row["IsSpec"].ToString());
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 将对象转换实体
        /// </summary>
        public Model.Channel DataRowToModel(SqlConnection conn, SqlTransaction trans, DataRow row)
        {
            Model.Channel model = new Model.Channel();
            if (row != null)
            {
                #region 主表信息======================
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["SiteID"] != null && row["SiteID"].ToString() != "")
                {
                    model.SiteID = int.Parse(row["SiteID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["IsAlbums"] != null && row["IsAlbums"].ToString() != "")
                {
                    model.IsAlbums = int.Parse(row["IsAlbums"].ToString());
                }
                if (row["IsAttach"] != null && row["IsAttach"].ToString() != "")
                {
                    model.IsAttach = int.Parse(row["IsAttach"].ToString());
                }
                if (row["IsSpec"] != null && row["IsSpec"].ToString() != "")
                {
                    model.IsSpec = int.Parse(row["IsSpec"].ToString());
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                #endregion

                #region 子表信息======================
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 ID,ChannelID,FieldID from ChannelField ");
                strSql.Append(" where ChannelID=@ChannelID ");
                SqlParameter[] parameters = {
					    new SqlParameter("@ChannelID", SqlDbType.Int,4)};
                parameters[0].Value = model.ID;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int i = ds.Tables[0].Rows.Count;
                    List<Model.ChannelField> models = new List<Model.ChannelField>();
                    Model.ChannelField modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.ChannelField();
                        if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                        {
                            modelt.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                        }
                        if (ds.Tables[0].Rows[n]["ChannelID"].ToString() != "")
                        {
                            modelt.ChannelID = int.Parse(ds.Tables[0].Rows[n]["ChannelID"].ToString());
                        }
                        if (ds.Tables[0].Rows[n]["FieldID"].ToString() != "")
                        {
                            modelt.FieldID = int.Parse(ds.Tables[0].Rows[n]["FieldID"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.ChannelFields = models;
                }
                #endregion
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID ");
			strSql.Append(" FROM Channel ");
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
			strSql.Append(" ID,SiteID,Name,Title,IsAlbums,IsAttach,IsSpec,SortID FROM Channel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Channel");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Channel ");
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
			strSql.Append(")AS Row, T.*  from Channel T ");
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
			parameters[0].Value = "Channel";
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
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Channel set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 返回频道名称
        /// </summary>
        public string GetChannelName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Name from Channel");
            strSql.Append(" where ID=" + id);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToString(obj);
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回频道ID
        /// </summary>
        public int GetChannelID(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from Channel");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        /// <summary>
        /// 删除及重建该频道视图
        /// </summary>
        public void DeleteAndRebuildChannelViews(SqlConnection conn, SqlTransaction trans, Model.Channel model, string oldName)
        {
            //删除旧的视图
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("if exists (select 1 from sysobjects where id = object_id('ViewChannel" + oldName + "') and type = 'V')");
            strSql1.Append("drop view ViewChannel" + oldName);
            DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());
            //添加视图
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("CREATE VIEW ViewChannel" + model.Name + " as");
            strSql2.Append(" SELECT Article.*");
            if (model.ChannelFields != null)
            {
                foreach (Model.ChannelField modelt in model.ChannelFields)
                {
                    Model.ArticleAttributeField fieldModel = new DAL.ArticleAttributeField().GetModel(modelt.FieldID);
                    if (fieldModel != null)
                    {
                        strSql2.Append(",ArticleAttributeValue." + fieldModel.Name);
                    }
                }
            }
            strSql2.Append(" FROM ArticleAttributeValue INNER JOIN");
            strSql2.Append(" Article ON ArticleAttributeValue.ArticleID = Article.ID");
            strSql2.Append(" WHERE Article.ChannelID=" + model.ID);
            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
        }

        /// <summary>
        /// 删除已移除的频道扩展字段
        /// </summary>
        private void FieldDelete(SqlConnection conn, SqlTransaction trans, List<Model.ChannelField> models, int channelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FieldID from ChannelField where ChannelID=" + channelID);
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.ChannelField model = models.Find(p => p.FieldID == int.Parse(dr["FieldID"].ToString())); //查找对应的字段ID
                if (model == null)
                {
                    DbHelperSQL.ExecuteSql(conn, trans, "delete from ChannelField where ChannelID=" + channelID + " and FieldID=" + dr["FieldID"].ToString()); //删除该字段
                }
            }
        }
		#endregion  ExtensionMethod
	}
}

