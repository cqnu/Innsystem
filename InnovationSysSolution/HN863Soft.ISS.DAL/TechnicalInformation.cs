using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Common;
//*****************************
// 文件名（File Name）：Notice.cs
// 作者（Author）：邹峰
// 功能（Function）：发布、编辑、删除技术信息资源数据访问层
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:TechnicalInformation
    /// </summary>
    public partial class TechnicalInformation
    {
        public TechnicalInformation()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "TechnicalInformation");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TechnicalInformation");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 添加点击量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddHits(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update TechnicalInformation set hits=hits+1 ");
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


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.TechnicalInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TechnicalInformation(");
            strSql.Append("EntryName,DetailedContent,UserId,Time,Keyword,InstitutionalDisplay,hits,State)");
            strSql.Append(" values (");
            strSql.Append("@EntryName,@DetailedContent,@UserId,@Time,@Keyword,@InstitutionalDisplay,@hits,@State)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@EntryName", SqlDbType.NVarChar,200),
					new SqlParameter("@DetailedContent", SqlDbType.Text),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
                    new SqlParameter("@Keyword", SqlDbType.NVarChar,200),
                    new SqlParameter("@InstitutionalDisplay", SqlDbType.Text),
                    new SqlParameter("@hits", SqlDbType.BigInt),
                     new SqlParameter("@State", SqlDbType.Int)
                                        };
            parameters[0].Value = model.EntryName;
            parameters[1].Value = model.DetailedContent;
            parameters[2].Value = model.UserId;
            parameters[3].Value = System.DateTime.Now;
            parameters[4].Value = model.Keyword;
            parameters[5].Value = model.Institutionaldisplay;
            parameters[6].Value = model.Hits;
            parameters[7].Value = model.State;
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
        public bool Update(HN863Soft.ISS.Model.TechnicalInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TechnicalInformation set ");
            strSql.Append("EntryName=@EntryName,");
            strSql.Append("DetailedContent=@DetailedContent,");
            strSql.Append("Time=@Time,");
            strSql.Append("Keyword=@Keyword,");
            strSql.Append("InstitutionalDisplay=@InstitutionalDisplay,");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@EntryName", SqlDbType.NVarChar,200),
					new SqlParameter("@DetailedContent", SqlDbType.Text),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Keyword", SqlDbType.NVarChar,200),
                    new SqlParameter("@InstitutionalDisplay", SqlDbType.Text),
                    new SqlParameter("@State", SqlDbType.Int,4),
                       new SqlParameter("@Describe", SqlDbType.NVarChar,200)
                                        };
            parameters[0].Value = model.EntryName;
            parameters[1].Value = model.DetailedContent;
            parameters[2].Value = System.DateTime.Now;
            parameters[3].Value = model.ID;
            parameters[4].Value = model.Keyword;
            parameters[5].Value = model.Institutionaldisplay;
            parameters[6].Value = model.State;
            parameters[7].Value = model.Describe;
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
        public bool UpdateState(int id, int istate, string str, string strTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update   " + strTable);
            strSql.Append("   set   State=@State,");
            strSql.Append("Describe=@Describe");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@State", SqlDbType.Int),
					new SqlParameter("@Describe", SqlDbType.NVarChar,200),

					new SqlParameter("@ID", SqlDbType.Int),
             
                                        };
            parameters[0].Value = istate;
            parameters[1].Value = str;
            parameters[2].Value = id;
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
            strSql.Append("delete from TechnicalInformation ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TechnicalInformation ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public HN863Soft.ISS.Model.TechnicalInformation GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,EntryName,DetailedContent,UserId,Time,InstitutionalDisplay,Keyword from TechnicalInformation ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.TechnicalInformation model = new HN863Soft.ISS.Model.TechnicalInformation();
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
        public HN863Soft.ISS.Model.TechnicalInformation DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.TechnicalInformation model = new HN863Soft.ISS.Model.TechnicalInformation();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["EntryName"] != null)
                {
                    model.EntryName = row["EntryName"].ToString();
                }
                if (row["DetailedContent"] != null)
                {
                    model.DetailedContent = row["DetailedContent"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(row["Time"].ToString());
                }
                if (row["InstitutionalDisplay"] != null)
                {
                    model.Institutionaldisplay = row["InstitutionalDisplay"].ToString();
                }
                if (row["Keyword"] != null)
                {
                    model.Keyword = row["Keyword"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() OVER (ORDER BY t.hits desc) AS rowid, t.*,u.UserName ");
            strSql.Append(" FROM TechnicalInformation t left join Manager u on t.UserId=u.id ");
            strSql.Append("  where 1 = 1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            if (recordCount == 0)
            {
                recordCount = 1;
            }

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " t.hits desc"));
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
            strSql.Append(" ID,EntryName,DetailedContent,UserId,Time ");
            strSql.Append(" FROM TechnicalInformation ");
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
            strSql.Append("select count(1) FROM TechnicalInformation ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from TechnicalInformation T ");
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
            parameters[0].Value = "TechnicalInformation";
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

