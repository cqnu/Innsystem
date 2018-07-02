/**  版本信息模板在安装目录下，可自行修改。
* MeetingActivity.cs
*
* 功 能： N/A
* 类 名： MeetingActivity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 9:32:11   N/A    初版
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
    /// 数据访问类:MeetingActivity
    /// </summary>
    public partial class MeetingActivity
    {
        public MeetingActivity()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "MeetingActivity");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MeetingActivity");
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
        public int Add(HN863Soft.ISS.Model.MeetingActivity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MeetingActivity(");
            strSql.Append("Title,Content,CreateTime,CreatorId,IsVis,Type,Reward,KeyWord)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Content,@CreateTime,@CreatorId,@IsVis,@Type,@Reward,@KeyWord)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreatorId", SqlDbType.Int,4),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
                    new SqlParameter("@Type",SqlDbType.Int,4),
                    new SqlParameter("@Reward",SqlDbType.Int,4),
                    new SqlParameter("@KeyWord",SqlDbType.NVarChar,100),
                                        };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.CreatorId;
            parameters[4].Value = model.IsVis;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Reward;
            parameters[7].Value = model.KeyWord;

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
        public bool Update(HN863Soft.ISS.Model.MeetingActivity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MeetingActivity set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("IsVis=@IsVis,");
            strSql.Append("Type=@Type,");
            strSql.Append("Reward=@Reward, Describe=@Describe ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreatorId", SqlDbType.Int,4),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
                    new SqlParameter("Type",SqlDbType.Int ,4),
                    new SqlParameter("Reward",SqlDbType.Int ,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.CreatorId;
            parameters[4].Value = model.IsVis;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Reward;
            parameters[7].Value = model.Id;
            parameters[8].Value = model.Describe;
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
            strSql.Append("delete from MeetingActivity ");
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
            strSql.Append("delete from MeetingActivity ");
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
        public HN863Soft.ISS.Model.MeetingActivity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Title,Content,CreateTime,CreatorId,IsVis,Type,Reward,KeyWord  from MeetingActivity ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.MeetingActivity model = new HN863Soft.ISS.Model.MeetingActivity();
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
        public HN863Soft.ISS.Model.MeetingActivity DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.MeetingActivity model = new HN863Soft.ISS.Model.MeetingActivity();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreatorId"] != null && row["CreatorId"].ToString() != "")
                {
                    model.CreatorId = int.Parse(row["CreatorId"].ToString());
                }
                if (row["IsVis"] != null && row["IsVis"].ToString() != "")
                {
                    model.IsVis = int.Parse(row["IsVis"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Reward"] != null && row["Reward"].ToString() != "")
                {
                    model.Reward = int.Parse(row["Reward"].ToString());
                }
                if (row["KeyWord"] != null && row["KeyWord"].ToString() != "")
                {
                    model.KeyWord = row["KeyWord"].ToString();
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
            strSql.Append("select Id,Title,Content,CreateTime,CreatorId,IsVis,Type,Reward,KeyWord ");
            strSql.Append(" FROM MeetingActivity ");
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
            strSql.Append(" Id,Title,Content,CreateTime,CreatorId,IsVis,Type,Reward,KeyWord ");
            strSql.Append(" FROM MeetingActivity ");
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
            strSql.Append("select count(1) FROM MeetingActivity ");
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
            strSql.Append(")AS Row, T.*  from MeetingActivity T ");
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
            parameters[0].Value = "MeetingActivity";
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT *,ROW_NUMBER() over(order by Id desc) rowIndex FROM ( SELECT a.*,M.NickName ");
            strSql.Append("     FROM MeetingActivity A left join Users M ON A.CreatorId=M.ID ) t  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateActiveInfo(HN863Soft.ISS.Model.MeetingActivity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MeetingActivity set ");
            strSql.Append("IsVis =@IsVis");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.IsVis;
            parameters[1].Value = model.Id;

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
        /// 更新信息
        /// </summary>
        /// <param name="model">服务信息</param>
        /// <returns></returns>
        public bool UpdateInfo(HN863Soft.ISS.Model.MeetingActivity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MeetingActivity set ");
            strSql.Append(" Title=@Title,");
            strSql.Append(" Content=@Content, ");//LogImg,KeyWord,Introduce
            strSql.Append(" Type=@Type,");
            strSql.Append(" KeyWord=@KeyWord,Describe='' ");
            //strSql.Append(" Reward=@Reward ");//悬赏积分
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameter ={
                                          new SqlParameter("@Title",SqlDbType.Text),
                                          new SqlParameter("@Content",SqlDbType.Text),
                                          new SqlParameter("@Id",SqlDbType.Int,4),
                                          new SqlParameter("@Type",SqlDbType.Int,4),
                                          new SqlParameter("@Reward",SqlDbType.Int,4),
                                          new SqlParameter("@KeyWord",SqlDbType.NVarChar,100),
                                     };
            parameter[0].Value = model.Title;
            parameter[1].Value = model.Content;
            parameter[2].Value = model.Id;
            parameter[3].Value = model.Type;
            parameter[4].Value = model.Reward;
            parameter[5].Value = model.KeyWord;
            int row = DbHelperSQL.ExecuteSql(strSql.ToString(), parameter);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion  ExtensionMethod
    }
}

