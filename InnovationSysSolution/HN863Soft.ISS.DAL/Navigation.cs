/**  版本信息模板在安装目录下，可自行修改。
* Navigation.cs
*
* 功 能： N/A
* 类 名： Navigation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/14 11:31:01   N/A    初版
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

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:Navigation
	/// </summary>
	public partial class Navigation
	{
		public Navigation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Navigation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Navigation");
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
            strSql.Append("select count(1) from Navigation");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.Navigation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Navigation(");
			strSql.Append("ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys)");
			strSql.Append(" values (");
			strSql.Append("@ParentID,@ChannelID,@NavType,@Name,@Title,@SubTitle,@IconUrl,@LinkUrl,@SortID,@IsLock,@Remark,@ActionType,@IsSys)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@NavType", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@IconUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ActionType", SqlDbType.NVarChar,500),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ChannelID;
			parameters[2].Value = model.NavType;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Title;
			parameters[5].Value = model.SubTitle;
			parameters[6].Value = model.IconUrl;
			parameters[7].Value = model.LinkUrl;
			parameters[8].Value = model.SortID;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.ActionType;
			parameters[12].Value = model.IsSys;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.Navigation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Navigation set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("ChannelID=@ChannelID,");
			strSql.Append("NavType=@NavType,");
			strSql.Append("Name=@Name,");
			strSql.Append("Title=@Title,");
			strSql.Append("SubTitle=@SubTitle,");
			strSql.Append("IconUrl=@IconUrl,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("SortID=@SortID,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("ActionType=@ActionType,");
			strSql.Append("IsSys=@IsSys");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@NavType", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@IconUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ActionType", SqlDbType.NVarChar,500),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ChannelID;
			parameters[2].Value = model.NavType;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Title;
			parameters[5].Value = model.SubTitle;
			parameters[6].Value = model.IconUrl;
			parameters[7].Value = model.LinkUrl;
			parameters[8].Value = model.SortID;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.ActionType;
			parameters[12].Value = model.IsSys;
			parameters[13].Value = model.ID;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Navigation ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
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
			strSql.Append("delete from Navigation ");
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
		public HN863Soft.ISS.Model.Navigation GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys from Navigation ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.Navigation model=new HN863Soft.ISS.Model.Navigation();
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
        public HN863Soft.ISS.Model.Navigation GetModel(string navName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys from Navigation ");
            strSql.Append(" from Navigation  where Name=@NavName");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.NVarChar,50)};
            parameters[0].Value = navName;

            HN863Soft.ISS.Model.Navigation model = new HN863Soft.ISS.Model.Navigation();
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
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.Navigation DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.Navigation model=new HN863Soft.ISS.Model.Navigation();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["ChannelID"]!=null && row["ChannelID"].ToString()!="")
				{
					model.ChannelID=int.Parse(row["ChannelID"].ToString());
				}
				if(row["NavType"]!=null)
				{
					model.NavType=row["NavType"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["SubTitle"]!=null)
				{
					model.SubTitle=row["SubTitle"].ToString();
				}
				if(row["IconUrl"]!=null)
				{
					model.IconUrl=row["IconUrl"].ToString();
				}
				if(row["LinkUrl"]!=null)
				{
					model.LinkUrl=row["LinkUrl"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["IsLock"]!=null && row["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(row["IsLock"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["ActionType"]!=null)
				{
					model.ActionType=row["ActionType"].ToString();
				}
				if(row["IsSys"]!=null && row["IsSys"].ToString()!="")
				{
					model.IsSys=int.Parse(row["IsSys"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys ");
			strSql.Append(" FROM Navigation ");
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
			strSql.Append(" ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys ");
			strSql.Append(" FROM Navigation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parentID, string navTtype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys ");
            strSql.Append(" FROM Navigation");
            strSql.Append(" where NavType='" + navTtype + "'");
            strSql.Append(" order by SortID asc,ID desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //重组列表
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("ID", typeof(int));
            newData.Columns.Add("ParentID", typeof(int));
            newData.Columns.Add("ChannelID", typeof(int));
            newData.Columns.Add("ClassLayer", typeof(int));
            newData.Columns.Add("NavType", typeof(string));
            newData.Columns.Add("Name", typeof(string));
            newData.Columns.Add("Title", typeof(string));
            newData.Columns.Add("SubTitle", typeof(string));
            newData.Columns.Add("IconUrl", typeof(string));
            newData.Columns.Add("LinkUrl", typeof(string));
            newData.Columns.Add("SortID", typeof(int));
            newData.Columns.Add("IsLock", typeof(int));
            newData.Columns.Add("Remark", typeof(string));
            newData.Columns.Add("ActionType", typeof(string));
            newData.Columns.Add("IsSys", typeof(int));
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parentID, 0);
            return newData;
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Navigation ");
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
			strSql.Append(")AS Row, T.*  from Navigation T ");
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
			parameters[0].Value = "Navigation";
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
        /// 根据导航的名称查询其ID
        /// </summary>
        public int GetNavID(string navName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from Navigation");
            strSql.Append(" where Name=@NavName");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.NVarChar,50)};
            parameters[0].Value = navName;
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            return Utils.StrToInt(str, 0);
        }

        /// <summary>
        /// 获取父类下的所有子类ID(含自己本身)
        /// </summary>
        public string GetIDs(int parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ParentID");
            strSql.Append(" FROM Navigation");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            string ids = parentID.ToString() + ",";
            GetChildIDs(ds.Tables[0], parentID, ref ids);
            return ids.TrimEnd(',');
        }

        /// <summary>
        /// 获取父类下的所有子类ID(含自己本身)
        /// </summary>
        public string GetIDs(string navName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from Navigation");
            strSql.Append(" where Name=@NavName");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.NVarChar,50)};
            parameters[0].Value = navName;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetIDs(Convert.ToInt32(obj));
            }
            return string.Empty;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set " + strValue);
            strSql.Append(" where ID=" + id);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string name, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set " + strValue);
            strSql.Append(" where Name='" + name + "'");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 修改一条记录，带事务
        /// </summary>
        public bool Update(SqlConnection conn, SqlTransaction trans, string oldName, string newName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set Name=@NewName");
            strSql.Append(" where name=@OldName");
            SqlParameter[] parameters = {
					            new SqlParameter("@NewName", SqlDbType.NVarChar,50),
					            new SqlParameter("@OldName", SqlDbType.NVarChar,50)};
            parameters[0].Value = newName;
            parameters[1].Value = oldName;
            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
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
        /// 修改一条记录，带事务
        /// </summary>
        public bool Update(SqlConnection conn, SqlTransaction trans, string oldName, string newName, string title, int sortID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set");
            strSql.Append(" Name=@NewName,");
            strSql.Append(" Title=@Title,");
            strSql.Append(" SortID=@SortID");
            strSql.Append(" where Name=@OldName");
            SqlParameter[] parameters = {
					new SqlParameter("@NewName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Title", SqlDbType.NVarChar,100),
                    new SqlParameter("@SortID", SqlDbType.Int,4),
                    new SqlParameter("@OldName", SqlDbType.NVarChar,50)};
            parameters[0].Value = newName;
            parameters[1].Value = title;
            parameters[2].Value = sortID;
            parameters[3].Value = oldName;
            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
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
        /// 修改一条记录，带事务
        /// </summary>
        public bool Update(SqlConnection conn, SqlTransaction trans, string oldName, int parentID, string navName, string title, int sortID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Navigation set");
            strSql.Append(" ParentID=@ParentID,");
            strSql.Append(" Name=@NewName,");
            strSql.Append(" Title=@Title,");
            strSql.Append(" SortID=@SortID");
            strSql.Append(" where Name=@OldName");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@NewName", SqlDbType.NVarChar,50),
                    new SqlParameter("@title", SqlDbType.NVarChar,100),
                    new SqlParameter("@SortID", SqlDbType.Int,4),
                    new SqlParameter("@OldName", SqlDbType.NVarChar,50)};
            parameters[0].Value = parentID;
            parameters[1].Value = navName;
            parameters[2].Value = title;
            parameters[3].Value = sortID;
            parameters[4].Value = oldName;
            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
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
        /// 快捷添加系统默认导航
        /// </summary>
        public int Add(string parentName, string navName, string title, string linkUrl, int sortID, int channelID, string actionType)
        {
            //先根据名称查询该父ID
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select top 1 ID from Navigation");
            strSql1.Append(" where Name=@ParentName");
            SqlParameter[] parameters1 = {
					new SqlParameter("@ParentName", SqlDbType.NVarChar,50)};
            parameters1[0].Value = parentName;
            object obj1 = DbHelperSQL.GetSingle(strSql1.ToString(), parameters1);
            if (obj1 == null)
            {
                return 0;
            }
            int parentID = Convert.ToInt32(obj1);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Navigation(");
            strSql.Append("ParentID,ChannelID,NavType,Name,Title,LinkUrl,SortID,ActionType,IsSys)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@ChannelID,@NavType,@Name,@Title,@LinkUrl,@SortID,@ActionType,@IsSys)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@NavType", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ActionType", SqlDbType.NVarChar,500),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1)};
            parameters[0].Value = parentID;
            parameters[1].Value = channelID;
            parameters[2].Value = EnumsHelper.NavigationEnum.System.ToString();
            parameters[3].Value = navName;
            parameters[4].Value = title;
            parameters[5].Value = linkUrl;
            parameters[6].Value = sortID;
            parameters[7].Value = actionType;
            parameters[8].Value = 1;
            object obj2 = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj2);
        }

        /// <summary>
        /// 快捷添加系统默认导航，带事务
        /// </summary>
        public int Add(SqlConnection conn, SqlTransaction trans, string parentName, string navName, string title, string linkUrl, int sortID, int channelID, string actionType)
        {
            //先根据名称查询该父ID
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from Navigation");
            strSql.Append(" where Name=@ParentName");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentName", SqlDbType.NVarChar,50)};
            parameters[0].Value = parentName;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            int parentID = Convert.ToInt32(obj);

            return Add(conn, trans, parentID, navName, title, linkUrl, sortID, channelID, actionType);
        }


        /// <summary>
        /// 快捷添加系统默认导航，带事务
        /// </summary>
        public int Add(SqlConnection conn, SqlTransaction trans, int parentID, string navName, string title, string linkUrl, int sortID, int channelID, string actionType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Navigation(");
            strSql.Append("ParentID,ChannelID,NavType,Name,Title,LinkUrl,SortID,ActionType,IsSys)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@ChannelID,@NavType,@Name,@Title,@LinkUrl,@SortID,@ActionType,@IsSys)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@NavType", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ActionType", SqlDbType.NVarChar,500),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1)};
            parameters[0].Value = parentID;
            parameters[1].Value = channelID;
            parameters[2].Value = EnumsHelper.NavigationEnum.System.ToString();
            parameters[3].Value = navName;
            parameters[4].Value = title;
            parameters[5].Value = linkUrl;
            parameters[6].Value = sortID;
            parameters[7].Value = actionType;
            parameters[8].Value = 1;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 得到一个对象实体，带事务
        /// </summary>
        public Model.Navigation GetModel(SqlConnection conn, SqlTransaction trans, string navName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1                           ID,ParentID,ChannelID,NavType,Name,Title,SubTitle,IconUrl,LinkUrl,SortID,IsLock,Remark,ActionType,IsSys");
            strSql.Append(" from Navigation ");
            strSql.Append(" where Name=@NavName");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.NVarChar,50)};
            parameters[0].Value = navName;

            Model.Navigation model = new Model.Navigation();
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
        /// 删除一条数据，带事务
        /// </summary>
        public bool Delete(SqlConnection conn, SqlTransaction trans, string navName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Navigation where Name=@NavName");
            SqlParameter[] parameters = {
					new SqlParameter("@NavName", SqlDbType.NVarChar,50)};
            parameters[0].Value = navName;

            int rows = DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
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
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parentID, int classLayer)
        {
            classLayer++;
            DataRow[] dr = oldData.Select("ParentID=" + parentID);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["ID"] = int.Parse(dr[i]["ID"].ToString());
                row["ParentID"] = int.Parse(dr[i]["ParentID"].ToString());
                row["ChannelID"] = int.Parse(dr[i]["ChannelID"].ToString());
                row["ClassLayer"] = classLayer;
                row["NavType"] = dr[i]["NavType"].ToString();
                row["Name"] = dr[i]["Name"].ToString();
                row["Title"] = dr[i]["Title"].ToString();
                row["SubTitle"] = dr[i]["SubTitle"].ToString();
                row["IconUrl"] = dr[i]["IconUrl"].ToString();
                row["LinkUrl"] = dr[i]["LinkUrl"].ToString();
                row["SortID"] = int.Parse(dr[i]["SortID"].ToString());
                row["IsLock"] = int.Parse(dr[i]["IsLock"].ToString());
                row["Remark"] = dr[i]["Remark"].ToString();
                row["ActionType"] = dr[i]["ActionType"].ToString();
                row["IsSys"] = int.Parse(dr[i]["IsSys"].ToString());
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()), classLayer);
            }
        }

        /// <summary>
        /// 获取父类下的所有子类ID
        /// </summary>
        private void GetChildIDs(DataTable dt, int parentID, ref string IDs)
        {
            DataRow[] dr = dt.Select("ParentID=" + parentID);
            for (int i = 0; i < dr.Length; i++)
            {
                IDs += dr[i]["ID"].ToString() + ",";
                //调用自身迭代
                this.GetChildIDs(dt, int.Parse(dr[i]["ID"].ToString()), ref IDs);
            }
        }

		#endregion  ExtensionMethod
	}
}

