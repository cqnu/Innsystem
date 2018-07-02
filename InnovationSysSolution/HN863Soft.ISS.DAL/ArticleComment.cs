/**  版本信息模板在安装目录下，可自行修改。
* ArticleComment.cs
*
* 功 能： N/A
* 类 名： ArticleComment
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
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ArticleComment
	/// </summary>
	public partial class ArticleComment
	{
		public ArticleComment(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ArticleComment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleComment");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回数据总数(AJAX分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from ArticleComment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ArticleComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleComment(");
			strSql.Append("ChannelID,ArticleID,ParentID,UserID,UserName,UserIP,Content,IsLock,CreateTime,IsReply,ReplyContent,ReplyTime)");
			strSql.Append(" values (");
			strSql.Append("@ChannelID,@ArticleID,@ParentID,@UserID,@UserName,@UserIP,@Content,@IsLock,@CreateTime,@IsReply,@ReplyContent,@ReplyTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsReply", SqlDbType.TinyInt,1),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ChannelID;
			parameters[1].Value = model.ArticleID;
			parameters[2].Value = model.ParentID;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserIP;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.IsLock;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.IsReply;
			parameters[10].Value = model.ReplyContent;
			parameters[11].Value = model.ReplyTime;

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
		public bool Update(HN863Soft.ISS.Model.ArticleComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleComment set ");
			strSql.Append("ChannelID=@ChannelID,");
			strSql.Append("ArticleID=@ArticleID,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserIP=@UserIP,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("IsReply=@IsReply,");
			strSql.Append("ReplyContent=@ReplyContent,");
			strSql.Append("ReplyTime=@ReplyTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsReply", SqlDbType.TinyInt,1),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ChannelID;
			parameters[1].Value = model.ArticleID;
			parameters[2].Value = model.ParentID;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserIP;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.IsLock;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.IsReply;
			parameters[10].Value = model.ReplyContent;
			parameters[11].Value = model.ReplyTime;
			parameters[12].Value = model.ID;

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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleComment set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleComment where ID=@ID");
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
			strSql.Append("delete from ArticleComment ");
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
		public HN863Soft.ISS.Model.ArticleComment GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ChannelID,ArticleID,ParentID,UserID,UserName,UserIP,Content,IsLock,CreateTime,IsReply,ReplyContent,ReplyTime from ArticleComment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ArticleComment model=new HN863Soft.ISS.Model.ArticleComment();
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
		public HN863Soft.ISS.Model.ArticleComment DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleComment model=new HN863Soft.ISS.Model.ArticleComment();
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
				if(row["ArticleID"]!=null && row["ArticleID"].ToString()!="")
				{
					model.ArticleID=int.Parse(row["ArticleID"].ToString());
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserIP"]!=null)
				{
					model.UserIP=row["UserIP"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["IsLock"]!=null && row["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(row["IsLock"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["IsReply"]!=null && row["IsReply"].ToString()!="")
				{
					model.IsReply=int.Parse(row["IsReply"].ToString());
				}
				if(row["ReplyContent"]!=null)
				{
					model.ReplyContent=row["ReplyContent"].ToString();
				}
				if(row["ReplyTime"]!=null && row["ReplyTime"].ToString()!="")
				{
					model.ReplyTime=DateTime.Parse(row["ReplyTime"].ToString());
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
			strSql.Append("select ID,ChannelID,ArticleID,ParentID,UserID,UserName,UserIP,Content,IsLock,CreateTime,IsReply,ReplyContent,ReplyTime ");
			strSql.Append(" FROM ArticleComment ");
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
			strSql.Append(" ID,ChannelID,ArticleID,ParentID,UserID,UserName,UserIP,Content,IsLock,CreateTime,IsReply,ReplyContent,ReplyTime ");
			strSql.Append(" FROM ArticleComment ");
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
            strSql.Append("select * FROM ArticleComment");
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
			strSql.Append("select count(1) FROM ArticleComment ");
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
			strSql.Append(")AS Row, T.*  from ArticleComment T ");
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
			parameters[0].Value = "ArticleComment";
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

