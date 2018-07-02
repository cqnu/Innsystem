/**  版本信息模板在安装目录下，可自行修改。
* ArticleAlbum.cs
*
* 功 能： N/A
* 类 名： ArticleAlbum
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
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using System.Collections.Generic;
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ArticleAlbum
	/// </summary>
	public partial class ArticleAlbum
	{
		public ArticleAlbum(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ArticleAlbum"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleAlbum");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ArticleAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleAlbum(");
			strSql.Append("ArticleID,ThumbPath,OriginalPath,Remark,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@ArticleID,@ThumbPath,@OriginalPath,@Remark,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ThumbPath", SqlDbType.NVarChar,255),
					new SqlParameter("@OriginalPath", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.ThumbPath;
			parameters[2].Value = model.OriginalPath;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.CreateTime;

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
		public bool Update(HN863Soft.ISS.Model.ArticleAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleAlbum set ");
			strSql.Append("ArticleID=@ArticleID,");
			strSql.Append("ThumbPath=@ThumbPath,");
			strSql.Append("OriginalPath=@OriginalPath,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ThumbPath", SqlDbType.NVarChar,255),
					new SqlParameter("@OriginalPath", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.ThumbPath;
			parameters[2].Value = model.OriginalPath;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from ArticleAlbum ");
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
			strSql.Append("delete from ArticleAlbum ");
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
        /// 查找不存在的图片并删除已删除的图片及数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.ArticleAlbum> models, int articleID)
        {
            StringBuilder sb = new StringBuilder();
            if (models != null)
            {
                foreach (Model.ArticleAlbum item in models)
                {
                    if (item.ID > 0)
                    {
                        sb.Append(item.ID + ",");
                    }
                }
            }
            string idList = Utils.DelLastChar(sb.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ThumbPath,OriginalPath from ArticleAlbum where ArticleID=" + articleID);
            if (!string.IsNullOrEmpty(idList))
            {
                strSql.Append(" and ID not in(" + idList + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from ArticleAlbum where ID=" + dr["ID"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["ThumbPath"].ToString()); //删除缩略图
                    Utils.DeleteFile(dr["OriginalPath"].ToString()); //删除原图
                }
            }
        }

        /// <summary>
        /// 删除相册图片
        /// </summary>
        public void DeleteFile(List<Model.ArticleAlbum> models)
        {
            if (models != null)
            {
                foreach (Model.ArticleAlbum item in models)
                {
                    Utils.DeleteFile(item.ThumbPath);
                    Utils.DeleteFile(item.OriginalPath);
                }
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.ArticleAlbum GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ArticleID,ThumbPath,OriginalPath,Remark,CreateTime from ArticleAlbum ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ArticleAlbum model=new HN863Soft.ISS.Model.ArticleAlbum();
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
		public HN863Soft.ISS.Model.ArticleAlbum DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleAlbum model=new HN863Soft.ISS.Model.ArticleAlbum();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ArticleID"]!=null && row["ArticleID"].ToString()!="")
				{
					model.ArticleID=int.Parse(row["ArticleID"].ToString());
				}
				if(row["ThumbPath"]!=null)
				{
					model.ThumbPath=row["ThumbPath"].ToString();
				}
				if(row["OriginalPath"]!=null)
				{
					model.OriginalPath=row["OriginalPath"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select ID,ArticleID,ThumbPath,OriginalPath,Remark,CreateTime ");
			strSql.Append(" FROM ArticleAlbum ");
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
			strSql.Append(" ID,ArticleID,ThumbPath,OriginalPath,Remark,CreateTime ");
			strSql.Append(" FROM ArticleAlbum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ArticleAlbum> GetList(int articleID)
        {
            List<Model.ArticleAlbum> modelList = new List<Model.ArticleAlbum>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ArticleID,ThumbPath,OriginalPath,Remark,CreateTime FROM ArticleAlbum ");
            strSql.Append(" where ArticleID=" + articleID);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ArticleAlbum model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.ArticleAlbum();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["ArticleID"] != null && dt.Rows[n]["ArticleID"].ToString() != "")
                    {
                        model.ArticleID = int.Parse(dt.Rows[n]["ArticleID"].ToString());
                    }
                    if (dt.Rows[n]["ThumbPath"] != null && dt.Rows[n]["ThumbPath"].ToString() != "")
                    {
                        model.ThumbPath = dt.Rows[n]["ThumbPath"].ToString();
                    }
                    if (dt.Rows[n]["OriginalPath"] != null && dt.Rows[n]["OriginalPath"].ToString() != "")
                    {
                        model.OriginalPath = dt.Rows[n]["OriginalPath"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[0]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[0]["CreateTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ArticleAlbum ");
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
			strSql.Append(")AS Row, T.*  from ArticleAlbum T ");
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
			parameters[0].Value = "ArticleAlbum";
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

