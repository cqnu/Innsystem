using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    public partial class UserCode
    {
        public UserCode() { }


        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserCode");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string type, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserCode");
            strSql.Append(" where Status=0 and datediff(d,EffTime,getdate())<=0 and Type=@Type and UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,20),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = type;
            parameters[1].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserCode(");
            strSql.Append("UserID,UserName,Type,StrCode,Count,Status,UserIP,EffTime,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@Type,@StrCode,@Count,@Status,@UserIP,@EffTime,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Type", SqlDbType.NVarChar,20),
					new SqlParameter("@str_code", SqlDbType.NVarChar,255),
                    new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar,20),
					new SqlParameter("@EffTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.StrCode;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.UserIP;
            parameters[7].Value = model.EffTime;
            parameters[8].Value = model.CreateTime;

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
        public bool Update(Model.UserCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserCode set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Type=@Type,");
            strSql.Append("StrCode=@StrCode,");
            strSql.Append("Count=@Count,");
            strSql.Append("Status=@Status,");
            strSql.Append("UserIP=@UserIP,");
            strSql.Append("EffTime=@EffTime,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Type", SqlDbType.NVarChar,20),
					new SqlParameter("@StrCode", SqlDbType.NVarChar,255),
                    new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar,20),
					new SqlParameter("@EffTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.StrCode;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.UserIP;
            parameters[7].Value = model.EffTime;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.ID;

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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserCode ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 根据条件批量删除
        /// </summary>
        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserCode ");
            strSql.Append(" where " + strWhere);
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
        public Model.UserCode GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,UserID,UserName,Type,StrCode,Count,Status,UserIP,EffTime,CreateTime from UserCode ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 根据生成码得到一个对象实体
        /// </summary>
        public Model.UserCode GetModel(string strCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,UserID,UserName,Type,StrCode,Count,Status,UserIP,EffTime,CreateTime from UserCode ");
            strSql.Append(" where Status=0 and datediff(d,EffTime,getdate())<=0 and StrCode=@StrCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StrCode", SqlDbType.NVarChar,255)};
            parameters[0].Value = strCode;

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
        /// 根据用户名得到一个对象实体
        /// </summary>
        public Model.UserCode GetModel(string userName, string codeType, string datepart)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,UserID,UserName,Type,StrCode,Count,Status,UserIP,EffTime,CreateTime from UserCode ");
            strSql.Append(" where Status=0 and datediff(" + datepart + ",EffTime,getdate())<=0 and UserName=@UserName and Type=@Type");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Type", SqlDbType.NVarChar,20)};
            parameters[0].Value = userName;
            parameters[1].Value = codeType;

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
            strSql.Append(" ID,UserID,UserName,Type,StrCode,Count,Status,UserIP,EffTime,CreateTime from UserCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("select * FROM UserCode");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        #region 扩展方法================================
        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from UserCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 将对象转换为实体
        /// </summary>
        public Model.UserCode DataRowToModel(DataRow row)
        {
            Model.UserCode model = new Model.UserCode();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["StrCode"] != null)
                {
                    model.StrCode = row["StrCode"].ToString();
                }
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = int.Parse(row["Count"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["UserIP"] != null)
                {
                    model.UserIP = row["UserIP"].ToString();
                }
                if (row["EffTime"] != null && row["EffTime"].ToString() != "")
                {
                    model.EffTime = DateTime.Parse(row["EffTime"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }
        #endregion
    }
}
