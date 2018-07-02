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
    public class LinkPatentDal
    {



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.hits desc) AS rowid, a.*,u.UserName from LinkPatent a ");
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

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " a.hits desc"));
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.LinkPatent GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,* from LinkPatent ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.LinkPatent model = new HN863Soft.ISS.Model.LinkPatent();
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
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.LinkPatent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LinkPatent set ");
            strSql.Append("SiteName=@SiteName,");
            strSql.Append("SiteUrl=@SiteUrl,");
            strSql.Append("LogUrl=@LogUrl,");
            strSql.Append("SiteDescription=@SiteDescription");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
				
					new SqlParameter("@SiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@SiteUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@LogUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@SiteDescription", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int)
					};
            parameters[0].Value = model.SiteName;
            parameters[1].Value = model.SiteUrl;
            parameters[2].Value = model.LogUrl;
            parameters[3].Value = model.SiteDescription;
            parameters[4].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LinkPatent ");
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
        public int Add(HN863Soft.ISS.Model.LinkPatent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LinkPatent(");
            strSql.Append("UserId,SiteName,SiteUrl,SiteDescription,hits,LogUrl)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@SiteName,@SiteUrl,@SiteDescription,@hits,@LogUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@SiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@SiteUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@SiteDescription", SqlDbType.NVarChar,200),
					new SqlParameter("@hits", SqlDbType.BigInt,8),
                    new SqlParameter("@LogUrl", SqlDbType.NVarChar,200)
                                        }
                    ;
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.SiteName;
            parameters[2].Value = model.SiteUrl;
            parameters[3].Value = model.SiteDescription;
            parameters[4].Value = model.hits;
            parameters[5].Value = model.LogUrl;
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
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.LinkPatent DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.LinkPatent model = new HN863Soft.ISS.Model.LinkPatent();
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
                if (row["SiteName"] != null)
                {
                    model.SiteName = row["SiteName"].ToString();
                }
                if (row["SiteUrl"] != null)
                {
                    model.SiteUrl = row["SiteUrl"].ToString();
                }
                if (row["SiteDescription"] != null && row["SiteDescription"].ToString() != "")
                {
                    model.SiteDescription =row["SiteDescription"].ToString();
                }
                if (row["hits"] != null && row["hits"].ToString() != "")
                {
                    model.hits = long.Parse(row["hits"].ToString());
                }
                if (row["LogUrl"] != null && row["LogUrl"].ToString() != "")
                {
                    model.LogUrl = row["LogUrl"].ToString();
                }

            }
            return model;
        }
    }
}
