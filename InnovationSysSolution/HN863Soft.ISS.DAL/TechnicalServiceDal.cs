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
  public  class TechnicalServiceDal
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.hits desc) AS rowid, a.*,u.UserName from Technology a ");
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
        public HN863Soft.ISS.Model.TechnicalService GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserId,Title,Content,datatime,hits,ActiveState from Technology ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.userAriticle model = new HN863Soft.ISS.Model.userAriticle();
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
        public bool Update(HN863Soft.ISS.Model.TechnicalService model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Technology set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("state=@state,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("ActiveState=@ActiveState");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
				
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int),
			        new SqlParameter("@state", SqlDbType.Int),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,200),
                    new SqlParameter("@ActiveState", SqlDbType.Int)
					};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.State;
            parameters[4].Value = model.Describe;
            parameters[5].Value = model.ActiveState;
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
        public int Add(HN863Soft.ISS.Model.TechnicalService model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Technology(");
            strSql.Append("UserId,Title,Content,datatime,hits,state,ActiveState)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@Content,@datatime,@hits,@state,@ActiveState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@datatime", SqlDbType.DateTime),
					new SqlParameter("@hits", SqlDbType.BigInt,8),
                    new SqlParameter("@state", SqlDbType.Int,4),
                     new SqlParameter("@ActiveState", SqlDbType.Int)
                                        }
                    ;
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.datatime;
            parameters[4].Value = model.hits;
            parameters[5].Value = model.State;
            parameters[6].Value = model.ActiveState;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Technology ");
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
        public HN863Soft.ISS.Model.TechnicalService DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.TechnicalService model = new HN863Soft.ISS.Model.TechnicalService();
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
                if (row["datatime"] != null && row["datatime"].ToString() != "")
                {
                    model.datatime = DateTime.Parse(row["datatime"].ToString());
                }
                if (row["hits"] != null && row["hits"].ToString() != "")
                {
                    model.hits = long.Parse(row["hits"].ToString());
                }
                if (row["ActiveState"] != null && row["ActiveState"].ToString() != "")
                {
                    model.ActiveState = int.Parse(row["ActiveState"].ToString());
                }

            }
            return model;
        }

        public int AddHits(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update Technology set hits=hits+1 ");
            strSql.Append("where id =" + id);
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

        public DataSet ShowToptie(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,u.UserName from Technology  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where  a.id =  " + id);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet ShowFinancingClass(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ROW_NUMBER() OVER (ORDER BY a.id  ) AS rowid, a.*,u.UserName from TechnologyClass  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where 1=1  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            if (recordCount == 0)
            {
                recordCount = 1;
            }

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " a.id  "));
        }

        public DataSet ShowFinancingClassInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ROW_NUMBER() OVER (ORDER BY a.id  ) AS rowid, a.*,u.UserName from TechnologyClass  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where 1=1  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append("ORDER BY a.id  ");
            return DbHelperSQL.Query(strSql.ToString());

        }

        public int AddFinancingClass(HN863Soft.ISS.Model.TechnicalService model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TechnologyClass(");
            strSql.Append("Technologyid,UserId,BeReplyId,title,content,datatime,DeletedState,LId)");
            strSql.Append(" values (");
            strSql.Append("@Talentid,@UserId,@BeReplyId,@title,@content,@datatime,0,@LId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Talentid", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int),
					new SqlParameter("@BeReplyId", SqlDbType.Int),
					new SqlParameter("@title", SqlDbType.Char,100),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@datatime", SqlDbType.DateTime),
                    new SqlParameter("@LId", SqlDbType.Int)
                                        };
            parameters[0].Value = model.Ariticleid;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.BeReplyId;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.datatime;
            parameters[6].Value = model.Lid;
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

        public bool UpdateComment(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TechnologyClass set ");
            strSql.Append("Content=@Content,");
            strSql.Append("DeletedState=1 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
		
				new SqlParameter("@Content", SqlDbType.Text),
				new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = "<p><strong><span style='font-family: 隶书, SimLi;'>该评论已被管理员或者发布人删除</span></strong></p>";
            parameters[1].Value = id;
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

        public DataSet GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from Manager ");
            strSql.Append(" where  ID =  " + id);

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
