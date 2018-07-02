/**  版本信息模板在安装目录下，可自行修改。
* SoftwareS.cs
*
* 功 能： N/A
* 类 名： SoftwareS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/9 17:47:41   N/A    初版
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
    /// 数据访问类:SoftwareS
    /// </summary>
    public partial class SoftwareS
    {
        public SoftwareS()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "SoftwareS");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SoftwareS");
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
        public int Add(HN863Soft.ISS.Model.SoftwareS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SoftwareS(");
            strSql.Append("SName,SIntroduction,TeamIntroduction,Example,Phone,Type,IsVis,CreateDate,LogImg,KeyWord,Introduce,CreatorId,Jurisdiction)");
            strSql.Append(" values (");
            strSql.Append("@SName,@SIntroduction,@TeamIntroduction,@Example,@Phone,@Type,@IsVis,@CreateDate,@LogImg,@KeyWord,@Introduce,@CreatorId,0)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.NVarChar,250),
					new SqlParameter("@SIntroduction", SqlDbType.Text),
					new SqlParameter("@TeamIntroduction", SqlDbType.Text),
					new SqlParameter("@Example", SqlDbType.Text),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.Date,3),
					new SqlParameter("@LogImg", SqlDbType.NVarChar,500),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Introduce", SqlDbType.NVarChar,100),
                    new SqlParameter("@CreatorId",SqlDbType.Int,4)};
            parameters[0].Value = model.SName;
            parameters[1].Value = model.SIntroduction;
            parameters[2].Value = model.TeamIntroduction;
            parameters[3].Value = model.Example;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.IsVis;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.LogImg;
            parameters[9].Value = model.KeyWord;
            parameters[10].Value = model.Introduce;
            parameters[11].Value = model.CreatorId;

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
        public bool Update(HN863Soft.ISS.Model.SoftwareS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SoftwareS set ");
            strSql.Append("SName=@SName,");
            strSql.Append("SIntroduction=@SIntroduction,");
            strSql.Append("TeamIntroduction=@TeamIntroduction,");
            strSql.Append("Example=@Example,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Type=@Type,");
            strSql.Append("LogImg=@LogImg,");
            strSql.Append("IsVis=@IsVis,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("Introduce=@Introduce,Describe='' ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.NVarChar,250),
					new SqlParameter("@SIntroduction", SqlDbType.Text),
					new SqlParameter("@TeamIntroduction", SqlDbType.Text),
					new SqlParameter("@Example", SqlDbType.Text),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@LogImg", SqlDbType.NVarChar,500),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Introduce", SqlDbType.NVarChar,100),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.SName;
            parameters[1].Value = model.SIntroduction;
            parameters[2].Value = model.TeamIntroduction;
            parameters[3].Value = model.Example;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.IsVis;
            parameters[7].Value = model.LogImg;
            parameters[8].Value = model.KeyWord;
            parameters[9].Value = model.Introduce;
            parameters[10].Value = model.Id;

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
            strSql.Append("delete from SoftwareS ");
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
            strSql.Append("delete from SoftwareS ");
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
        public HN863Soft.ISS.Model.SoftwareS GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,SName,SIntroduction,TeamIntroduction,Example,Phone,Type,IsVis,CreateDate,LogImg,KeyWord,Introduce,CreatorId from SoftwareS  ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.SoftwareS model = new HN863Soft.ISS.Model.SoftwareS();
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
        public HN863Soft.ISS.Model.SoftwareS DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.SoftwareS model = new HN863Soft.ISS.Model.SoftwareS();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["SName"] != null)
                {
                    model.SName = row["SName"].ToString();
                }
                if (row["SIntroduction"] != null)
                {
                    model.SIntroduction = row["SIntroduction"].ToString();
                }
                if (row["TeamIntroduction"] != null)
                {
                    model.TeamIntroduction = row["TeamIntroduction"].ToString();
                }
                if (row["Example"] != null)
                {
                    model.Example = row["Example"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["IsVis"] != null && row["IsVis"].ToString() != "")
                {
                    model.IsVis = int.Parse(row["IsVis"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["LogImg"] != null)
                {
                    model.LogImg = row["LogImg"].ToString();
                }
                if (row["KeyWord"] != null)
                {
                    model.KeyWord = row["KeyWord"].ToString();
                }
                if (row["Introduce"] != null)
                {
                    model.Introduce = row["Introduce"].ToString();
                }
                //,CreatorId
                if (row["CreatorId"] != null && row["CreatorId"].ToString() != "")
                {
                    model.CreatorId = int.Parse(row["CreatorId"].ToString());
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
            strSql.Append("select Id,SName,SIntroduction,TeamIntroduction,Example,Phone,Type,IsVis,CreateDate,LogImg,KeyWord,Introduce,CreatorId  ");
            strSql.Append(" FROM SoftwareS ");
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
            strSql.Append(" Id,SName,SIntroduction,TeamIntroduction,Example,Phone,Type,IsVis,CreateDate,LogImg,KeyWord,Introduce,CreatorId ");
            strSql.Append(" FROM SoftwareS ");
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
            strSql.Append("select count(1) FROM SoftwareS ");
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
            strSql.Append(")AS Row, T.*  from SoftwareS T ");
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
            parameters[0].Value = "SoftwareS";
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
        /// 更新一条数据:审核
        /// </summary>
        public bool UpdateIsVis(HN863Soft.ISS.Model.SoftwareS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SoftwareS set ");
            strSql.Append(" IsVis=@IsVis, ");
            strSql.Append(" Describe=@Describe ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.IsVis;
            parameters[1].Value = model.Id;
            parameters[2].Value = model.Describe;
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT Id,SName,SIntroduction,TeamIntroduction,Example,Phone,Type,IsVis,CreateDate,LogImg,KeyWord,Introduce,CreatorId,  ROW_NUMBER() OVER (order by Id desc) rowIndex,Jurisdiction,Describe");
            //strSql.Append(" FROM SoftwareS ");


            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowIndex, a.*,u.UserName from SoftwareS a ");
            strSql.Append(" left join Manager u  on a.CreatorId=u.id   ");
            //strSql.Append(" where 1=1   ");


            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), "a."+filedOrder));
        }

        #endregion  ExtensionMethod
    }
}

