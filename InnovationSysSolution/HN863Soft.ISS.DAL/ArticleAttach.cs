/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttach.cs
*
* 功 能： N/A
* 类 名： ArticleAttach
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
using HN863Soft.ISS.Common;
using System.Collections.Generic;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ArticleAttach
	/// </summary>
	public partial class ArticleAttach
	{
		public ArticleAttach(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ArticleAttach"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleAttach");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 检查用户是否下载过该附件
        /// </summary>
        public bool ExistsLog(int attachID, int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserAttachLog where AttachID=@AttachID and UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@AttachID", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = attachID;
            parameters[1].Value = userID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ArticleAttach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleAttach(");
			strSql.Append("ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@ArticleID,@FileName,@FilePath,@FileSize,@FileExt,@DownNum,@Point,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,255),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,255),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@FileExt", SqlDbType.NVarChar,20),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.FilePath;
			parameters[3].Value = model.FileSize;
			parameters[4].Value = model.FileExt;
			parameters[5].Value = model.DownNum;
			parameters[6].Value = model.Point;
			parameters[7].Value = model.CreateTime;

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
		public bool Update(HN863Soft.ISS.Model.ArticleAttach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleAttach set ");
			strSql.Append("ArticleID=@ArticleID,");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("FileSize=@FileSize,");
			strSql.Append("FileExt=@FileExt,");
			strSql.Append("DownNum=@DownNum,");
			strSql.Append("Point=@Point,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,255),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,255),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@FileExt", SqlDbType.NVarChar,20),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.FilePath;
			parameters[3].Value = model.FileSize;
			parameters[4].Value = model.FileExt;
			parameters[5].Value = model.DownNum;
			parameters[6].Value = model.Point;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from ArticleAttach ");
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
			strSql.Append("delete from ArticleAttach ");
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
        /// 查找不存在的文件并删除已删除的附件及数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.ArticleAttach> models, int articleID)
        {
            StringBuilder sb = new StringBuilder();
            if (models != null)
            {
                foreach (Model.ArticleAttach modelt in models)
                {
                    if (modelt.ID > 0)
                    {
                        sb.Append(modelt.ID + ",");
                    }
                }
            }
            string idList = Utils.DelLastChar(sb.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FilePath from ArticleAttach where ArticleID=" + articleID);
            if (!string.IsNullOrEmpty(idList))
            {
                strSql.Append(" and ID not in(" + idList + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from ArticleAttach where ID=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["FilePath"].ToString()); //删除文件
                }
            }
        }

        /// <summary>
        /// 删除附件文件
        /// </summary>
        public void DeleteFile(List<Model.ArticleAttach> models)
        {
            if (models != null)
            {
                foreach (var item in models)
                {
                    Utils.DeleteFile(item.FilePath);
                }
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HN863Soft.ISS.Model.ArticleAttach GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point,CreateTime from ArticleAttach ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ArticleAttach model=new HN863Soft.ISS.Model.ArticleAttach();
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
		public HN863Soft.ISS.Model.ArticleAttach DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleAttach model=new HN863Soft.ISS.Model.ArticleAttach();
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
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FilePath"]!=null)
				{
					model.FilePath=row["FilePath"].ToString();
				}
				if(row["FileSize"]!=null && row["FileSize"].ToString()!="")
				{
					model.FileSize=int.Parse(row["FileSize"].ToString());
				}
				if(row["FileExt"]!=null)
				{
					model.FileExt=row["FileExt"].ToString();
				}
				if(row["DownNum"]!=null && row["DownNum"].ToString()!="")
				{
					model.DownNum=int.Parse(row["DownNum"].ToString());
				}
				if(row["Point"]!=null && row["Point"].ToString()!="")
				{
					model.Point=int.Parse(row["Point"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleAttach set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point,CreateTime ");
			strSql.Append(" FROM ArticleAttach ");
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
			strSql.Append(" ID,ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point,CreateTime ");
			strSql.Append(" FROM ArticleAttach ");
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
        public List<Model.ArticleAttach> GetList(int articleID)
        {
            List<Model.ArticleAttach> modelList = new List<Model.ArticleAttach>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point,CreateTime FROM ArticleAttach ");
            strSql.Append(" where ArticleID=" + articleID);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ArticleAttach model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.ArticleAttach();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["ArticleID"] != null && dt.Rows[n]["ArticleID"].ToString() != "")
                    {
                        model.ArticleID = int.Parse(dt.Rows[n]["ArticleID"].ToString());
                    }
                    if (dt.Rows[n]["FileName"] != null && dt.Rows[n]["FileName"].ToString() != "")
                    {
                        model.FileName = dt.Rows[n]["FileName"].ToString();
                    }
                    if (dt.Rows[n]["FilePath"] != null && dt.Rows[n]["FilePath"].ToString() != "")
                    {
                        model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    }
                    if (dt.Rows[n]["FileExt"] != null && dt.Rows[n]["FileExt"].ToString() != "")
                    {
                        model.FileExt = dt.Rows[n]["FileExt"].ToString();
                    }
                    if (dt.Rows[n]["FileSize"] != null && dt.Rows[n]["FileSize"].ToString() != "")
                    {
                        model.FileSize = int.Parse(dt.Rows[n]["FileSize"].ToString());
                    }
                    if (dt.Rows[n]["DownNum"] != null && dt.Rows[n]["DownNum"].ToString() != "")
                    {
                        model.DownNum = int.Parse(dt.Rows[n]["DownNum"].ToString());
                    }
                    if (dt.Rows[n]["Point"] != null && dt.Rows[n]["Point"].ToString() != "")
                    {
                        model.Point = int.Parse(dt.Rows[n]["Point"].ToString());
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
			strSql.Append("select count(1) FROM ArticleAttach ");
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
        /// 获取总下载次数
        /// </summary>
        public int GetCountNum(int articleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(DownNum) from ArticleAttach where ArticleID=" + articleID);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// 获取单个附件下载次数
        /// </summary>
        public int GetDownNum(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 DownNum from ArticleAttach where ID=" + id);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
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
			strSql.Append(")AS Row, T.*  from ArticleAttach T ");
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
			parameters[0].Value = "ArticleAttach";
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

