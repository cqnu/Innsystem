/**  版本信息模板在安装目录下，可自行修改。
* ConductReply.cs
*
* 功 能： N/A
* 类 名： ConductReply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/27 16:30:41   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Common;//Please add references
namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ConductReply
	/// </summary>
	public partial class ConductReply
	{
		public ConductReply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "ConductReply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ConductReply");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ConductReply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ConductReply(");
			strSql.Append("CId,UId,Content,IsVis,RId,Time)");
			strSql.Append(" values (");
			strSql.Append("@CId,@UId,@Content,@IsVis,@RId,@Time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@RId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime)};
			parameters[0].Value = model.CId;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.IsVis;
			parameters[4].Value = model.RId;
			parameters[5].Value = model.Time;

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
		public bool Update(HN863Soft.ISS.Model.ConductReply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ConductReply set ");
			strSql.Append("CId=@CId,");
			strSql.Append("UId=@UId,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsVis=@IsVis,");
			strSql.Append("RId=@RId,");
			strSql.Append("Time=@Time");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@RId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.CId;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.IsVis;
			parameters[4].Value = model.RId;
			parameters[5].Value = model.Time;
			parameters[6].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConductReply ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConductReply ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public HN863Soft.ISS.Model.ConductReply GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,CId,UId,Content,IsVis,RId,Time from ConductReply ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			HN863Soft.ISS.Model.ConductReply model=new HN863Soft.ISS.Model.ConductReply();
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
		public HN863Soft.ISS.Model.ConductReply DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ConductReply model=new HN863Soft.ISS.Model.ConductReply();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["CId"]!=null && row["CId"].ToString()!="")
				{
					model.CId=int.Parse(row["CId"].ToString());
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=int.Parse(row["UId"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["IsVis"]!=null && row["IsVis"].ToString()!="")
				{
					model.IsVis=int.Parse(row["IsVis"].ToString());
				}
				if(row["RId"]!=null && row["RId"].ToString()!="")
				{
					model.RId=int.Parse(row["RId"].ToString());
				}
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=DateTime.Parse(row["Time"].ToString());
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
			strSql.Append("select Id,CId,UId,Content,IsVis,RId,Time ");
			strSql.Append(" FROM ConductReply ");
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
			strSql.Append(" Id,CId,UId,Content,IsVis,RId,Time ");
			strSql.Append(" FROM ConductReply ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ConductReply ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from ConductReply T ");
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
			parameters[0].Value = "ConductReply";
			parameters[1].Value = "Id";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, int cId, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" 	select *,ROW_NUMBER() OVER (ORDER BY t.Time) AS Floor from ( select  rf.*,u.UserName Name ,r1.FL,r1.UId PersonId  from ");
            strSql.Append("    (select r.*,u.UserName  from ConductReply r ");
            strSql.Append("   left join Users u on u.ID=r.UId ) rf  ");
            strSql.Append("   left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ConductReply where CId=@CId )r1   ");
            strSql.Append("   on rf.RId=r1.Id ");
            strSql.Append("    left join Users u on u.ID=r1.UId ) t  ");
            strSql.Append("   where CId=@CId");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@CId",SqlDbType.Int,4)
            };
            parameter[0].Value = cId;
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString()),parameter));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder), parameter);
        }

        /// <summary>
        /// 获取制定问题的所有回复
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList(int cId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" 	select *,ROW_NUMBER() OVER (ORDER BY t.Time) AS Floor from ( select  rf.*,u.UserName Name ,r1.FL,r1.UId PersonId  from ");
            strSql.Append("    (select r.*,u.UserName  from ConductReply r ");
            strSql.Append("   left join Users u on u.ID=r.UId ) rf  ");
            strSql.Append("   left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ConductReply where CId=@CId )r1   ");
            strSql.Append("   on rf.RId=r1.Id ");
            strSql.Append("    left join Users u on u.ID=r1.UId ) t  ");
            strSql.Append("   where CId=@CId");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@CId",SqlDbType.Int,4)
            };
            parameter[0].Value = cId;
            return DbHelperSQL.Query(strSql.ToString(), parameter);

        }

        /// <summary>
        /// 获取普通用户评论信息列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetCommonList(int cId, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" 	select *,ROW_NUMBER() OVER (ORDER BY t.Time) AS Floor from ( select  rf.*,u.UserName Name ,r1.FL,r1.UId PersonId  from ");
            strSql.Append("    (select r.*,u.UserName  from ConductReply r ");
            strSql.Append("   left join Users u on u.ID=r.UId ) rf  ");
            strSql.Append("   left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ConductReply where CId=@CId )r1   ");
            strSql.Append("   on rf.RId=r1.Id ");
            strSql.Append("    left join Users u on u.ID=r1.UId ) t  ");
            strSql.Append(" where CId=@CId and (t.UId=@UserId or t.PersonId=@UserId) ");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@CId",SqlDbType.Int,4),
                new SqlParameter("@UserId",SqlDbType.Int,4)
            };
            parameter[0].Value = cId;
            parameter[1].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameter);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateReplyInfo(HN863Soft.ISS.Model.ConductReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ConductReply set ");
            strSql.Append("IsVis =@IsVis");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.IsVis;
            parameters[1].Value = model.Id;

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

