/**  版本信息模板在安装目录下，可自行修改。
* ConductInfo.cs
*
* 功 能： N/A
* 类 名： ConductInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/27 11:43:35   N/A    初版
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
	/// 数据访问类:ConductInfo
	/// </summary>
	public partial class ConductInfo
	{
		public ConductInfo()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ConductInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ConductInfo");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.ConductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ConductInfo(");
            strSql.Append("MId,Title,IsVis,Creator,Hot,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@MId,@Title,@IsVis,@Creator,@Hot,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Creator", SqlDbType.Int,4),
					new SqlParameter("@Hot", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.IsVis;
            parameters[3].Value = model.Creator;
            parameters[4].Value = model.Hot;
            parameters[5].Value = model.CreateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(HN863Soft.ISS.Model.ConductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ConductInfo set ");
            strSql.Append("MId=@MId,");
            strSql.Append("Title=@Title,");
            strSql.Append("IsVis=@IsVis,");
            strSql.Append("Creator=@Creator,");
            strSql.Append("Hot=@Hot,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@MId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Creator", SqlDbType.Int,4),
					new SqlParameter("@Hot", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.MId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.IsVis;
            parameters[3].Value = model.Creator;
            parameters[4].Value = model.Hot;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.Id;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ConductInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ConductInfo ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.ConductInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,MId,Title,IsVis,Creator,Hot,CreateTime from ConductInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.ConductInfo model = new HN863Soft.ISS.Model.ConductInfo();
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
        public HN863Soft.ISS.Model.ConductInfo DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.ConductInfo model = new HN863Soft.ISS.Model.ConductInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["MId"] != null && row["MId"].ToString() != "")
                {
                    model.MId = int.Parse(row["MId"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["IsVis"] != null && row["IsVis"].ToString() != "")
                {
                    model.IsVis = int.Parse(row["IsVis"].ToString());
                }
                if (row["Creator"] != null && row["Creator"].ToString() != "")
                {
                    model.Creator = int.Parse(row["Creator"].ToString());
                }
                if (row["Hot"] != null && row["Hot"].ToString() != "")
                {
                    model.Hot = int.Parse(row["Hot"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,MId,Title,IsVis,Creator,Hot,CreateTime ");
            strSql.Append(" FROM ConductInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,MId,Title,IsVis,Creator,Hot,CreateTime ");
            strSql.Append(" FROM ConductInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ConductInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from ConductInfo T ");
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
            parameters[0].Value = "ConductInfo";
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select t.* ,u.NickName from (select c.*,m.RealName,m.RoleType FROM ConductInfo c left join Manager m on c.MId=m.Id) t  left join Users u on t.Creator =u.ID) Info");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDIY(HN863Soft.ISS.Model.ConductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ConductInfo set ");
            //strSql.Append("Title=@Title,");
            strSql.Append("IsVis=@IsVis,");
            //strSql.Append("Creator=@Creator,");
            //strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" Hot=@Hot ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    //new SqlParameter("@Title", SqlDbType.Text),
                    new SqlParameter("@IsVis", SqlDbType.Int,4),
                    new SqlParameter("@Hot",SqlDbType.Int,4),
                    //new SqlParameter("@Creator", SqlDbType.Int,4),
                    //new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.IsVis;
            parameters[1].Value = model.Hot;
            //parameters[3].Value = model.Creator;
            //parameters[4].Value = model.CreateTime;
            parameters[2].Value = model.Id;

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

        /// <summary>
        /// 更新服务信息：是否隐藏
        /// </summary>
        /// <param name="model">服务信息</param>
        /// <returns></returns>
        public bool UpdateInfo(HN863Soft.ISS.Model.ConductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ConductInfo set ");
            strSql.Append("IsVis=@IsVis");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameter ={
                                          new SqlParameter("@IsVis",SqlDbType.Int,4),
                                          new SqlParameter("@Id",SqlDbType.Int,4)
                                     };
            parameter[0].Value = model.IsVis;
            parameter[1].Value = model.Id;
            int row = DbHelperSQL.ExecuteSql(strSql.ToString(), parameter);
            if (row > 0)
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

