using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    public class ManagementDal
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from Management a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where 1=1   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            if (recordCount == 0)
            {
                recordCount = 1;
            }

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " a.id desc"));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Management ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        /// 增加一条数据
        /// </summary>
        public int Add(Management model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Management(");
            strSql.Append("UserId,Title,Content,Remarks,Time)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@Content,@Remarks,@Time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@Time", SqlDbType.DateTime)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Remarks;
            parameters[4].Value = model.Time;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Management GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Management ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            Management model = new Management();
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
        public Management DataRowToModel(DataRow row)
        {
            Management model = new Management();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(row["Time"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Management model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Management set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.Remarks;
            parameters[3].Value = model.ID;
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

    }
}
