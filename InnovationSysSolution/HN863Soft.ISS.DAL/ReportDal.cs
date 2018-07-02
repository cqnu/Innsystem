using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.DAL
{
    public class ReportDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Report(");
            strSql.Append("Url,Title,uId,Time,State,Reason)");
            strSql.Append(" values (");
            strSql.Append("@Url,@Title,@uId,@Time,@State,@Reason)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@Title", SqlDbType.NVarChar,500),
					new SqlParameter("@uId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Reason", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.Url;
            parameters[1].Value = model.Titile;
            parameters[2].Value = model.uId;
            parameters[3].Value = model.Time;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Reason;

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

        public int AddExtension(string Title, string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PushMessage(");
            strSql.Append("Url,Title)");
            strSql.Append(" values (");
            strSql.Append("@Url,@Title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@Title", SqlDbType.NVarChar,500)
	                                                                  };
            parameters[0].Value = url;
            parameters[1].Value = Title;

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

        public bool DelExtension(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PushMessage ");
            strSql.Append(" where Url=@Url");
            SqlParameter[] parameters = {
					new SqlParameter("@Url", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = url;

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


        public int UpdateState(Report model, string table, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Report set ");
            strSql.Append(" State=@State ");
            strSql.Append(" where Url=@Url  ");

            if (model.State == 1)
            {
                string state = "State";

                if (table == "SoftwareS" || table == "SoftConsultingS" || table == "HSEConsulting")
                {
                    state = "IsVis";
                }

                strSql.Append(";declare @identety int ");
                strSql.Append(" set @identety=(select @@IDENTITY)");

                strSql.Append(" update " + table + " set ");
                strSql.Append(state + " =0 ");
                strSql.Append(" where id=@id");
            }

            SqlParameter[] parameters = {
					new SqlParameter("@State", SqlDbType.Int),
					new SqlParameter("@Url", SqlDbType.NVarChar,500),
                    new SqlParameter("@id", SqlDbType.Int)
		};
            parameters[0].Value = model.State;
            parameters[1].Value = model.Url;
            parameters[2].Value = id;


            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool Hide(int Id, string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  Report ");
            strSql.Append(" where uId=@ID   and Url=@Url and State=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Url", SqlDbType.NVarChar,200)
			};
            parameters[0].Value = Id;
            parameters[1].Value = url;
            DataSet dt = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (dt.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetExtension(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  PushMessage ");
            strSql.Append(" where  Url=@Url  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Url", SqlDbType.NVarChar,200)
			};
            parameters[0].Value = url;
            DataSet dt = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (dt.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from Report a ");
            strSql.Append(" left join Users u  on a.uId=u.id   ");
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

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), order));
        }


        public DataSet GetMessageInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from  PushMessage  ");
            return DbHelperSQL.Query(strSql.ToString());

        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Report ");
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

    }
}
