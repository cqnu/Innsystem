/**  版本信息模板在安装目录下，可自行修改。
* ReplyInfo.cs
*
* 功 能： N/A
* 类 名： ReplyInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/21 10:03:12   N/A    初版
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
using HN863Soft.ISS.DBUtility;//Please add references
namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:ReplyInfo
    /// </summary>
    public partial class ReplyInfo
    {
        public ReplyInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ReplyInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ReplyInfo");
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
        public int Add(HN863Soft.ISS.Model.ReplyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReplyInfo(");
            strSql.Append("SId,ResponderId,Content,IsVis,CommentId,Time)");
            strSql.Append(" values (");
            strSql.Append("@SId,@ResponderId,@Content,@IsVis,@CommentId,@Time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4),
					new SqlParameter("@ResponderId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@CommentId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime)};
            parameters[0].Value = model.SId;
            parameters[1].Value = model.ResponderId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.IsVis;
            parameters[4].Value = model.CommentId;
            parameters[5].Value = model.Time;

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
        public bool Update(HN863Soft.ISS.Model.ReplyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReplyInfo set ");
            strSql.Append("SId=@SId,");
            strSql.Append("ResponderId=@ResponderId,");
            strSql.Append("Content=@Content,");
            strSql.Append("IsVis=@IsVis,");
            strSql.Append("CommentId=@CommentId,");
            strSql.Append("Time=@Time");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4),
					new SqlParameter("@ResponderId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@CommentId", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.SId;
            parameters[1].Value = model.ResponderId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.IsVis;
            parameters[4].Value = model.CommentId;
            parameters[5].Value = model.Time;
            parameters[6].Value = model.Id;

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
            strSql.Append("delete from ReplyInfo ");
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
            strSql.Append("delete from ReplyInfo ");
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
        public HN863Soft.ISS.Model.ReplyInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,SId,ResponderId,Content,IsVis,CommentId,Time from ReplyInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.ReplyInfo model = new HN863Soft.ISS.Model.ReplyInfo();
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
        public HN863Soft.ISS.Model.ReplyInfo DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.ReplyInfo model = new HN863Soft.ISS.Model.ReplyInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["SId"] != null && row["SId"].ToString() != "")
                {
                    model.SId = int.Parse(row["SId"].ToString());
                }
                if (row["ResponderId"] != null && row["ResponderId"].ToString() != "")
                {
                    model.ResponderId = int.Parse(row["ResponderId"].ToString());
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["IsVis"] != null && row["IsVis"].ToString() != "")
                {
                    model.IsVis = int.Parse(row["IsVis"].ToString());
                }
                if (row["CommentId"] != null && row["CommentId"].ToString() != "")
                {
                    model.CommentId = int.Parse(row["CommentId"].ToString());
                }
                if (row["Time"] != null && row["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(row["Time"].ToString());
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
            strSql.Append("select Id,SId,ResponderId,Content,IsVis,CommentId,Time ");
            strSql.Append(" FROM ReplyInfo ");
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
            strSql.Append(" Id,SId,ResponderId,Content,IsVis,CommentId,Time ");
            strSql.Append(" FROM ReplyInfo ");
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
            strSql.Append("select count(1) FROM ReplyInfo ");
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
            strSql.Append(")AS Row, T.*  from ReplyInfo T ");
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
            parameters[0].Value = "ReplyInfo";
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
        /// 获得数据列表
        /// </summary>
        /// <param name="sId">服务信息Id</param>
        /// <returns></returns>
        public DataSet GetALLListInfo(int sId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("    select *,ROW_NUMBER() OVER (ORDER BY t.Time) AS Floor from ( select  rf.*,u.UserName Name ,r1.FL,r1.ResponderId PersonId  from ");
            strSql.Append("       (select r.*,u.UserName  from ReplyInfo r ");
            strSql.Append("    left join Users u on u.ID=r.ResponderId ) rf  ");
            strSql.Append(" left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ReplyInfo where SId=@SId )r1   ");
            strSql.Append(" on rf.CommentId=r1.Id ");
            strSql.Append(" left join Users u on u.ID=r1.ResponderId ) t  ");
            strSql.Append(" where SId=@SId ");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@SId",SqlDbType.Int,4)
            };
            parameter[0].Value = sId;
            return DbHelperSQL.Query(strSql.ToString(), parameter);
        }


        /// <summary>
        /// 获取普通用户评论信息
        /// </summary>
        /// <param name="sId">服务信息Id</param>
        /// <param name="userId">普通用户Id</param>
        /// <returns></returns>
        public DataSet GetALLListInfo(int sId,int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("    select *,ROW_NUMBER() OVER (ORDER BY t.Time) AS Floor from ( select  rf.*,u.UserName Name ,r1.FL,r1.ResponderId PersonId  from ");
            strSql.Append("       (select r.*,u.UserName  from ReplyInfo r ");
            strSql.Append("    left join Users u on u.ID=r.ResponderId ) rf  ");
            strSql.Append(" left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ReplyInfo where SId=@SId )r1   ");
            strSql.Append(" on rf.CommentId=r1.Id ");
            strSql.Append(" left join Users u on u.ID=r1.ResponderId ) t  ");
            strSql.Append(" where SId=@SId and (t.ResponderId=@UserId or t.PersonId=@UserId) ");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@SId",SqlDbType.Int,4),
                new SqlParameter("@UserId",SqlDbType.Int,4)
            };
            parameter[0].Value = sId;
            parameter[1].Value = userId;
            return DbHelperSQL.Query(strSql.ToString(), parameter);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddComment(HN863Soft.ISS.Model.ReplyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReplyInfo(");
            strSql.Append("SId,ResponderId,Content,IsVis,CommentId,Time)");
            strSql.Append(" values (");
            strSql.Append("@SId,@ResponderId,@Content,@IsVis,@CommentId,@Time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4),
					new SqlParameter("@ResponderId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CommentId", SqlDbType.Int,4),
                    new SqlParameter("@IsVis",SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime)};
            parameters[0].Value = model.SId;
            parameters[1].Value = model.ResponderId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CommentId;
            parameters[4].Value = model.IsVis;
            parameters[5].Value = model.Time;

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
        public bool UpdateReplyInfo(HN863Soft.ISS.Model.ReplyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReplyInfo set ");
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

        #endregion  ExtensionMethod
    }
}

