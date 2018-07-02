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
    public class FiscalDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Fiscal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Fiscal(");
            strSql.Append("UserId,Title,KeyWord,Cover,Content,State,Describe,Introduce,Datatime,Jurisdiction )");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@KeyWord,@Cover,@Content,@State,@Describe,@Introduce,@Datatime,0 )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,200),
                     new SqlParameter("@Introduce", SqlDbType.NVarChar,100),
                      new SqlParameter("@Datatime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.KeyWord;
            parameters[3].Value = model.Cover;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Describe;
            parameters[7].Value = model.Introduce;
            parameters[8].Value = System.DateTime.Now;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Fiscal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Fiscal set ");
            strSql.Append("Title=@Title,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Introduce=@Introduce");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4),
                     new SqlParameter("@Introduce", SqlDbType.NVarChar,100)
                                        };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.KeyWord;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Describe;
            parameters[6].Value = model.ID;
            parameters[7].Value = model.Introduce;
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
            strSql.Append("delete from Fiscal ");
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


        public bool UpdateState(Fiscal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Fiscal set ");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {

					
					new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,200),

					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.State;
            parameters[1].Value = model.Describe;
            parameters[2].Value = model.ID;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from Fiscal a ");
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

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), order));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Fiscal GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Fiscal ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            Fiscal model = new Fiscal();
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
        public Fiscal DataRowToModel(DataRow row)
        {
            Fiscal model = new Fiscal();
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
                if (row["KeyWord"] != null)
                {
                    model.KeyWord = row["KeyWord"].ToString();
                }
                if (row["Introduce"] != null)
                {
                    model.Introduce = row["Introduce"].ToString();
                }
                if (row["Cover"] != null)
                {
                    model.Cover = row["Cover"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
            }
            return model;
        }
    }
}
