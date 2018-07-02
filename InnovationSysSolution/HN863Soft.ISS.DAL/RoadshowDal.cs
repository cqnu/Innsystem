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
    public class RoadshowDal
    {
        /// <summary>
        /// 绑定模版
        /// </summary>
        /// <returns></returns>
        public DataSet GetTemplate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from MailTemplate where Title='路演' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from RoadShow a ");
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

        public int Add(HN863Soft.ISS.Model.Roadshow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoadShow(");
            strSql.Append("UserId,Jurisdiction,Cover,Title,KeyWord,OrganizationName,Speaker,StartTime,EndTime,Video,Content,State,Describe,Objective,Place,Datatime)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Jurisdiction,@Cover,@Title,@KeyWord,@OrganizationName,@Speaker,@StartTime,@EndTime,@Video,@Content,@State,@Describe,@Objective,@Place,@Datatime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Jurisdiction", SqlDbType.Int,4),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@OrganizationName", SqlDbType.NVarChar,50),
					new SqlParameter("@Speaker", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Video", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,200),
                    new SqlParameter("@Objective", SqlDbType.NVarChar,500),
                    new SqlParameter("@Place", SqlDbType.NVarChar,100),
                     new SqlParameter("@Datatime", SqlDbType.NVarChar,100)
                                        };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Jurisdiction;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.KeyWord;
            parameters[5].Value = model.OrganizationName;
            parameters[6].Value = model.Speaker;
            parameters[7].Value = model.StartTime;
            parameters[8].Value = model.EndTime;
            parameters[9].Value = model.Video;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Describe;
            parameters[13].Value = model.Objective;
            parameters[14].Value = model.Place;
            parameters[15].Value = System.DateTime.Now;
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

        public bool UpdateState(Roadshow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoadShow set ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoadShow ");
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
        /// 得到一个对象实体
        /// </summary>
        public Roadshow GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from RoadShow a left join Manager m  on a.UserId=m.id ");
            strSql.Append(" where a.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            Roadshow model = new Roadshow();
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
        public Roadshow DataRowToModel(DataRow row)
        {
            Roadshow model = new Roadshow();
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
                if (row["Jurisdiction"] != null && row["Jurisdiction"].ToString() != "")
                {
                    model.Jurisdiction = int.Parse(row["Jurisdiction"].ToString());
                }
                if (row["Cover"] != null)
                {
                    model.Cover = row["Cover"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["KeyWord"] != null)
                {
                    model.KeyWord = row["KeyWord"].ToString();
                }
                if (row["Place"] != null)
                {
                    model.Place = row["Place"].ToString();
                }
                if (row["OrganizationName"] != null)
                {
                    model.OrganizationName = row["OrganizationName"].ToString();
                }
                if (row["Speaker"] != null)
                {
                    model.Speaker = row["Speaker"].ToString();
                }
                if (row["StartTime"] != null && row["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(row["StartTime"].ToString());
                }
                if (row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["Video"] != null)
                {
                    model.Video = row["Video"].ToString();
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
                if (row["Objective"] != null)
                {
                    model.Objective = row["Objective"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Roadshow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoadShow set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Jurisdiction=@Jurisdiction,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Title=@Title,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("OrganizationName=@OrganizationName,");
            strSql.Append("Speaker=@Speaker,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Video=@Video,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Objective=@Objective,");
            strSql.Append("Place=@Place");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Jurisdiction", SqlDbType.Int,4),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@OrganizationName", SqlDbType.NVarChar,50),
					new SqlParameter("@Speaker", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Video", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Objective", SqlDbType.NVarChar,500),
                    new SqlParameter("@Place", SqlDbType.NVarChar,100)
                                        };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Jurisdiction;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.KeyWord;
            parameters[5].Value = model.OrganizationName;
            parameters[6].Value = model.Speaker;
            parameters[7].Value = model.StartTime;
            parameters[8].Value = model.EndTime;
            parameters[9].Value = model.Video;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Describe;
            parameters[13].Value = model.ID;
            parameters[14].Value = model.Objective;
            parameters[15].Value = model.Place;
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
