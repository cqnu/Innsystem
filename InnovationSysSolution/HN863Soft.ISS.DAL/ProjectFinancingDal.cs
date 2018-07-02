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
    public class ProjectFinancingDal
    {

        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public DataSet GetProvince()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from Province ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="strProvinceID"></param>
        /// <returns></returns>
        public DataSet GetCity(string strProvinceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from City where ProvinceID = '" + strProvinceID + "'");
            ; return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="strProvinceID"></param>
        /// <returns></returns>
        public DataSet GetShi(string CityId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from City where CityId = '" + CityId + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取省
        /// </summary>
        /// <param name="strProvinceID"></param>
        /// <returns></returns>
        public DataSet GetS(string ProvinceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Province where ProvinceID = '" + ProvinceID + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取对应城市的省份
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns></returns>
        public string GetProvince(string cityId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ProvinceID from City where CityId= " + cityId);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            string strPId = "0";
            if (dt.Rows.Count > 0)
            {
                strPId = (dt.Rows[0]["ProvinceID"]).ToString();
            }
            return strPId;
        }

        /// <summary>
        /// 绑定模版
        /// </summary>
        /// <returns></returns>
        public DataSet GetTemplate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from MailTemplate where Title='众筹' ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int Add(HN863Soft.ISS.Model.ProjectFinancing model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProjectFinancing(");
            strSql.Append("UserId,Jurisdiction,Type,Cover,Title,KeyWord,Objective,Place,StartTime,EndTime,PromotionalVideo,Content,State,Datatime)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Jurisdiction,@Type,@Cover,@Title,@KeyWord,@Objective,@Place,@StartTime,@EndTime,@PromotionalVideo,@Content,@State,@Datatime)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Jurisdiction", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Objective", SqlDbType.NVarChar,500),
					new SqlParameter("@Place", SqlDbType.NVarChar,100),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PromotionalVideo", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
                      new SqlParameter("@Datatime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Jurisdiction;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Cover;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.KeyWord;
            parameters[6].Value = model.Objective;
            parameters[7].Value = model.Place;
            parameters[8].Value = model.StartTime;
            parameters[9].Value = model.EndTime;
            parameters[10].Value = model.PromotionalVideo;
            parameters[11].Value = model.Content;
            parameters[12].Value = model.State;
            parameters[13].Value = System.DateTime.Now;
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

        public bool UpdateState(ProjectFinancing model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProjectFinancing set ");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(ProjectFinancing model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProjectFinancing set ");
            strSql.Append("Jurisdiction=@Jurisdiction,");
            strSql.Append("Type=@Type,");
            strSql.Append("Cover=@Cover,");
            strSql.Append("Title=@Title,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("Objective=@Objective,");
            strSql.Append("Place=@Place,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("PromotionalVideo=@PromotionalVideo,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Jurisdiction", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Cover", SqlDbType.NVarChar,500),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Objective", SqlDbType.NVarChar,500),
					new SqlParameter("@Place", SqlDbType.NVarChar,100),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PromotionalVideo", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,200)
                                        };
            parameters[0].Value = model.Jurisdiction;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Cover;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.KeyWord;
            parameters[5].Value = model.Objective;
            parameters[6].Value = model.Place;
            parameters[7].Value = model.StartTime;
            parameters[8].Value = model.EndTime;
            parameters[9].Value = model.PromotionalVideo;
            parameters[10].Value = model.Content;
            parameters[11].Value = model.State;
            parameters[12].Value = model.ID;
            parameters[13].Value = model.Describe;
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



        public bool UpdateJurisdiction(string strTable, int id, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + strTable + " set ");
            strSql.Append(" Jurisdiction=@Jurisdiction ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Jurisdiction", SqlDbType.Int,4),
				
					new SqlParameter("@ID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = state;
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public ProjectFinancing GetModel(int ID)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select  * from ProjectFinancing ");
        //    strSql.Append(" where ID=@ID ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ID", SqlDbType.Int,4)			};
        //    parameters[0].Value = ID;

        //    ProjectFinancing model = new ProjectFinancing();
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public ProjectFinancing GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  a.*,m.UserName,m.RealName from ProjectFinancing a left join Manager m  on a.UserId=m.id ");
            strSql.Append(" where a.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            ProjectFinancing model = new ProjectFinancing();
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
        public ProjectFinancing DataRowToModel(DataRow row)
        {
            ProjectFinancing model = new ProjectFinancing();
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
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
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
                if (row["Objective"] != null)
                {
                    model.Objective = row["Objective"].ToString();
                }
                if (row["Place"] != null)
                {
                    model.Place = row["Place"].ToString();
                }
                if (row["StartTime"] != null && row["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(row["StartTime"].ToString());
                }
                if (row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["PromotionalVideo"] != null)
                {
                    model.PromotionalVideo = row["PromotionalVideo"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from ProjectFinancing a ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProjectFinancing ");
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
