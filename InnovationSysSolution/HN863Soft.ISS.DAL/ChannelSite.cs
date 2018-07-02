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
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ChannelSite
	/// </summary>
	public partial class ChannelSite
	{
		public ChannelSite(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ChannelSite"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ChannelSite");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询生成目录名是否存在
        /// </summary>
        public bool Exists(string buildPath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ChannelSite");
            strSql.Append(" where BuildPath=@BuildPath ");
            SqlParameter[] parameters = {
					new SqlParameter("@BuildPath", SqlDbType.NVarChar,100)};
            parameters[0].Value = buildPath;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(HN863Soft.ISS.Model.ChannelSite model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into ChannelSite(");
                        strSql.Append("Title,BuildPath,TempletPath,Domain,Name,Logo,Company,Address,Tel,Fax,Email,Crod,Copyright,SEOTitle,SEOKeyword,SEODescription,IsDefault,SortID)");
                        strSql.Append(" values (");
                        strSql.Append("@Title,@BuildPath,@TempletPath,@Domain,@Name,@Logo,@Company,@Address,@Tel,@Fax,@Email,@Crod,@Copyright,@SEOTitle,@SEOKeyword,@SEODescription,@IsDefault,@SortID)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@BuildPath", SqlDbType.NVarChar,100),
					new SqlParameter("@TempletPath", SqlDbType.NVarChar,100),
					new SqlParameter("@Domain", SqlDbType.NVarChar,255),
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@Logo", SqlDbType.NVarChar,255),
					new SqlParameter("@Company", SqlDbType.NVarChar,255),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@Fax", SqlDbType.NVarChar,30),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Crod", SqlDbType.NVarChar,100),
					new SqlParameter("@Copyright", SqlDbType.Text),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeyword", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,500),
					new SqlParameter("@IsDefault", SqlDbType.TinyInt,1),
					new SqlParameter("@SortID", SqlDbType.Int,4)};
                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.BuildPath;
                        parameters[2].Value = model.TempletPath;
                        parameters[3].Value = model.Domain;
                        parameters[4].Value = model.Name;
                        parameters[5].Value = model.Logo;
                        parameters[6].Value = model.Company;
                        parameters[7].Value = model.Address;
                        parameters[8].Value = model.Tel;
                        parameters[9].Value = model.Fax;
                        parameters[10].Value = model.Email;
                        parameters[11].Value = model.Crod;
                        parameters[12].Value = model.Copyright;
                        parameters[13].Value = model.SEOTitle;
                        parameters[14].Value = model.SEOKeyword;
                        parameters[15].Value = model.SEODescription;
                        parameters[16].Value = model.IsDefault;
                        parameters[17].Value = model.SortID;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.ID = Convert.ToInt32(obj);

                        //添加导航菜单
                        new DAL.Navigation().Add(conn, trans, "sys_contents", "channel_" + model.BuildPath, model.Title, "", model.SortID, 0, "Show");
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
        public bool Update(HN863Soft.ISS.Model.ChannelSite model, string oldBuildPath)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update ChannelSite set ");
                        strSql.Append("Title=@Title,");
                        strSql.Append("BuildPath=@BuildPath,");
                        strSql.Append("TempletPath=@TempletPath,");
                        strSql.Append("Domain=@Domain,");
                        strSql.Append("Name=@Name,");
                        strSql.Append("Logo=@Logo,");
                        strSql.Append("Company=@Company,");
                        strSql.Append("Address=@Address,");
                        strSql.Append("Tel=@Tel,");
                        strSql.Append("Fax=@Fax,");
                        strSql.Append("Email=@Email,");
                        strSql.Append("Crod=@Crod,");
                        strSql.Append("Copyright=@Copyright,");
                        strSql.Append("SEOTitle=@SEOTitle,");
                        strSql.Append("SEOKeyword=@SEOKeyword,");
                        strSql.Append("SEODescription=@SEODescription,");
                        strSql.Append("IsDefault=@IsDefault,");
                        strSql.Append("SortID=@SortID");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@BuildPath", SqlDbType.NVarChar,100),
					new SqlParameter("@TempletPath", SqlDbType.NVarChar,100),
					new SqlParameter("@Domain", SqlDbType.NVarChar,255),
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@Logo", SqlDbType.NVarChar,255),
					new SqlParameter("@Company", SqlDbType.NVarChar,255),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@Fax", SqlDbType.NVarChar,30),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Crod", SqlDbType.NVarChar,100),
					new SqlParameter("@Copyright", SqlDbType.Text),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeyword", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,500),
					new SqlParameter("@IsDefault", SqlDbType.TinyInt,1),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.BuildPath;
                        parameters[2].Value = model.TempletPath;
                        parameters[3].Value = model.Domain;
                        parameters[4].Value = model.Name;
                        parameters[5].Value = model.Logo;
                        parameters[6].Value = model.Company;
                        parameters[7].Value = model.Address;
                        parameters[8].Value = model.Tel;
                        parameters[9].Value = model.Fax;
                        parameters[10].Value = model.Email;
                        parameters[11].Value = model.Crod;
                        parameters[12].Value = model.Copyright;
                        parameters[13].Value = model.SEOTitle;
                        parameters[14].Value = model.SEOKeyword;
                        parameters[15].Value = model.SEODescription;
                        parameters[16].Value = model.IsDefault;
                        parameters[17].Value = model.SortID;
                        parameters[18].Value = model.ID;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //检查旧导航是否存在
                        if (new DAL.Navigation().GetModel(conn, trans, "channel_" + oldBuildPath) != null)
                        {
                            //修改导航菜单
                            new DAL.Navigation().Update(conn, trans, "channel_" + oldBuildPath, "channel_" + model.BuildPath, model.Title, model.SortID);
                        }
                        else //需要添加新导航菜单
                        {
                            new DAL.Navigation().Add(conn, trans, "sys_contents", "channel_" + model.BuildPath, model.Title, "", model.SortID, 0, "Show");
                        }

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
        public bool Delete(int ID)
        {
            string buildPath = GetBuildPath(ID);
            if (string.IsNullOrEmpty(buildPath))
            {
                return false;
            }
            //取得要删除的所有导航ID
            string navIDs = new Navigation().GetIDs("channel_" + buildPath);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //删除导航
                        if (!string.IsNullOrEmpty(navIDs))
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from Navigation where id in(" + navIDs + ")");
                        }
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from ChannelSite ");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
                        parameters[0].Value = ID;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

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
			strSql.Append("delete from ChannelSite ");
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
		public HN863Soft.ISS.Model.ChannelSite GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Title,BuildPath,TempletPath,Domain,Name,Logo,Company,Address,Tel,Fax,Email,Crod,Copyright,SEOTitle,SEOKeyword,SEODescription,IsDefault,SortID from ChannelSite ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ChannelSite model=new HN863Soft.ISS.Model.ChannelSite();
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
        public Model.ChannelSite GetModel(string buildPath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,Title,BuildPath,TempletPath,Domain,Name,Logo,Company,Address,Tel,Fax,Email,Crod,Copyright,SEOTitle,SEOKeyword,SEODescription,IsDefault,SortID from ChannelSite ");
            strSql.Append(" where BuildPath=@BuildPath");
            SqlParameter[] parameters = {
					new SqlParameter("@BuildPath", SqlDbType.NVarChar,50)};
            parameters[0].Value = buildPath;

            Model.ChannelSite model = new Model.ChannelSite();
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
		public HN863Soft.ISS.Model.ChannelSite DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ChannelSite model=new HN863Soft.ISS.Model.ChannelSite();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["BuildPath"]!=null)
				{
					model.BuildPath=row["BuildPath"].ToString();
				}
				if(row["TempletPath"]!=null)
				{
					model.TempletPath=row["TempletPath"].ToString();
				}
				if(row["Domain"]!=null)
				{
					model.Domain=row["Domain"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Logo"]!=null)
				{
					model.Logo=row["Logo"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Crod"]!=null)
				{
					model.Crod=row["Crod"].ToString();
				}
				if(row["Copyright"]!=null)
				{
					model.Copyright=row["Copyright"].ToString();
				}
				if(row["SEOTitle"]!=null)
				{
					model.SEOTitle=row["SEOTitle"].ToString();
				}
				if(row["SEOKeyword"]!=null)
				{
					model.SEOKeyword=row["SEOKeyword"].ToString();
				}
				if(row["SEODescription"]!=null)
				{
					model.SEODescription=row["SEODescription"].ToString();
				}
				if(row["IsDefault"]!=null && row["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(row["IsDefault"].ToString());
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
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
			strSql.Append("select ID,Title,BuildPath,TempletPath,Domain,Name,Logo,Company,Address,Tel,Fax,Email,Crod,Copyright,SEOTitle,SEOKeyword,SEODescription,IsDefault,SortID ");
			strSql.Append(" FROM ChannelSite ");
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
			strSql.Append(" ID,Title,BuildPath,TempletPath,Domain,Name,Logo,Company,Address,Tel,Fax,Email,Crod,Copyright,SEOTitle,SEOKeyword,SEODescription,IsDefault,SortID ");
			strSql.Append(" FROM ChannelSite ");
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
            strSql.Append("select * FROM ChannelSite");
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
			strSql.Append("select count(1) FROM ChannelSite ");
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
			strSql.Append(")AS Row, T.*  from ChannelSite T ");
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
			parameters[0].Value = "ChannelSite";
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
        /// 返回站点名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from ChannelSite");
            strSql.Append(" where ID=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetTitle(string buildPath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from ChannelSite");
            strSql.Append(" where BuildPath=@BuildPath");
            SqlParameter[] parameters = {
                    new SqlParameter("@BuildPath", SqlDbType.NVarChar,100)};
            parameters[0].Value = buildPath;
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 返回站点的生成目录名
        /// </summary>
        public string GetBuildPath(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BuildPath from ChannelSite");
            strSql.Append(" where ID=" + id);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToString(obj);
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回站点对应的导航ID
        /// </summary>
        public int GetSiteNavID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select N.id from Navigation as N,ChannelSite as S");
            strSql.Append(" where 'channel_'+S.BuildPath=N.name and S.ID=" + id);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ChannelSite set " + strValue);
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
        public bool UpdateField(string buildPath, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ChannelSite set " + strValue);
            strSql.Append(" where BuildPath=@BuildPath");
            SqlParameter[] parameters = {
                    new SqlParameter("@BuildPath", SqlDbType.NVarChar,100)};
            parameters[0].Value = buildPath;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion  ExtensionMethod
	}
}

