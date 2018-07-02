using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
//*****************************
// 文件名（File Name）：Notice.cs
// 作者（Author）：邹峰
// 功能（Function）：发布、编辑、删除通知公告数据访问层
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:Notice
	/// </summary>
	public partial class Notice
	{
		public Notice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Notice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Notice");
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
		public int Add(HN863Soft.ISS.Model.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Notice(");
            strSql.Append("ReleaseTime,PublishContent,Remarks,PublisherID)");
			strSql.Append(" values (");
            strSql.Append("@ReleaseTime,@PublishContent,@Remarks,@PublisherID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,500),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
                    new SqlParameter("@PublisherID", SqlDbType.NVarChar,200)}
                    ;
			parameters[0].Value = model.ReleaseTime;
			parameters[1].Value = model.PublishContent;
			parameters[2].Value = model.Remarks;
            parameters[3].Value = model.Publisherid;
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
		public bool Update(HN863Soft.ISS.Model.Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Notice set ");
            //strSql.Append("ReleaseTime=@ReleaseTime,");
			strSql.Append("PublishContent=@PublishContent, ");
            strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
                    //new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
					new SqlParameter("@PublishContent", SqlDbType.NVarChar,500),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            //parameters[0].Value = model.ReleaseTime;
			parameters[0].Value = model.PublishContent;
            parameters[1].Value = model.Remarks;
			parameters[2].Value = model.ID;

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

            StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Notice ");
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
			strSql.Append("delete from Notice ");
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
		public HN863Soft.ISS.Model.Notice GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            //strSql.Append("select  top 1 ID,ReleaseTime,PublishContent,Remarks from Notice ");

            strSql.Append("select  top 1 n.ID, n.ReleaseTime,n.PublishContent,n.Remarks,m.UserName ");
            strSql.Append(" FROM Notice n left join Manager m on n.PublisherID=m.ID ");


			strSql.Append(" where n.ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.Notice model=new HN863Soft.ISS.Model.Notice();
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
		public HN863Soft.ISS.Model.Notice DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.Notice model=new HN863Soft.ISS.Model.Notice();
			if (row != null)
			{
                if (row["Username"] != null && row["Username"].ToString() != "")
				{
                    model.Username = row["Username"].ToString();
				}
				if(row["ReleaseTime"]!=null && row["ReleaseTime"].ToString()!="")
				{
					model.ReleaseTime=DateTime.Parse(row["ReleaseTime"].ToString());
				}
				if(row["PublishContent"]!=null)
				{
					model.PublishContent=row["PublishContent"].ToString();
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere,  out int recordCount)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ROW_NUMBER() OVER (ORDER BY n.id desc) AS rowid,n.ID,n.ReleaseTime,n.PublishContent,n.Remarks,m.UserName ");
            strSql.Append(" FROM Notice n left join Manager m on n.PublisherID=m.ID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " n.id desc"));
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
			strSql.Append(" ID,ReleaseTime,PublishContent,Remarks ");
			strSql.Append(" FROM Notice ");
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
			strSql.Append("select count(1) FROM Notice ");
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
			strSql.Append(")AS Row, T.*  from Notice T ");
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
			parameters[0].Value = "Notice";
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

