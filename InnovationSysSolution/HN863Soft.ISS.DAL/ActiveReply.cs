/**  版本信息模板在安装目录下，可自行修改。
* ActiveReply.cs
*
* 功 能： N/A
* 类 名： ActiveReply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 9:32:08   N/A    初版
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
    /// 数据访问类:ActiveReply
    /// </summary>
    public partial class ActiveReply
    {
        public ActiveReply()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ActiveReply");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ActiveReply");
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
        public int Add(HN863Soft.ISS.Model.ActiveReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ActiveReply(");
            strSql.Append("MeetingId,UId,ParentId,Content,CreateTime,IsVis,Score)");
            strSql.Append(" values (");
            strSql.Append("@MeetingId,@UId,@ParentId,@Content,@CreateTime,@IsVis,@Score)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MeetingId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
                    new SqlParameter("@Score",SqlDbType.Int,4)};
            parameters[0].Value = model.MeetingId;
            parameters[1].Value = model.UId;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.IsVis;
            parameters[6].Value = model.Score;

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
        public bool Update(HN863Soft.ISS.Model.ActiveReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ActiveReply set ");
            strSql.Append("MeetingId=@MeetingId,");
            strSql.Append("UId=@UId,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("Content=@Content,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("IsVis=@IsVis");
            strSql.Append("Score=@Score,");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@MeetingId", SqlDbType.Int,4),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsVis", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Score",SqlDbType.Int,4)};
            parameters[0].Value = model.MeetingId;
            parameters[1].Value = model.UId;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.IsVis;
            parameters[6].Value = model.Id;
            parameters[7].Value = model.Score;

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
            strSql.Append("delete from ActiveReply ");
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
            strSql.Append("delete from ActiveReply ");
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
        public HN863Soft.ISS.Model.ActiveReply GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,MeetingId,UId,ParentId,Content,CreateTime,IsVis,Score from ActiveReply ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.ActiveReply model = new HN863Soft.ISS.Model.ActiveReply();
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
        public HN863Soft.ISS.Model.ActiveReply DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.ActiveReply model = new HN863Soft.ISS.Model.ActiveReply();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["MeetingId"] != null && row["MeetingId"].ToString() != "")
                {
                    model.MeetingId = int.Parse(row["MeetingId"].ToString());
                }
                if (row["UId"] != null && row["UId"].ToString() != "")
                {
                    model.UId = int.Parse(row["UId"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["IsVis"] != null && row["IsVis"].ToString() != "")
                {
                    model.IsVis = int.Parse(row["IsVis"].ToString());
                }
                if (row["Score"] != null && row["Score"].ToString() != "")
                {
                    model.Score = int.Parse(row["Score"].ToString());
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
            strSql.Append("select Id,MeetingId,UId,ParentId,Content,CreateTime,IsVis,Score ");
            strSql.Append(" FROM ActiveReply ");
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
            strSql.Append(" Id,MeetingId,UId,ParentId,Content,CreateTime,IsVis,Score ");
            strSql.Append(" FROM ActiveReply ");
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
            strSql.Append("select count(1) FROM ActiveReply ");
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
            strSql.Append(")AS Row, T.*  from ActiveReply T ");
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
            parameters[0].Value = "ActiveReply";
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
        public DataSet GetList(int pageSize, int pageIndex, int parentId, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *,ROW_NUMBER() OVER (ORDER BY t.CreateTime) AS Floor from ( select  rf.*,u.NickName Name ,r1.FL,r1.UId PersonId  from ");
            strSql.Append("   (select r.*,u.NickName, u.Avatar,u.GroupID from ActiveReply r  left join Users u on u.ID=r.UId ) rf   ");
            strSql.Append(" left join  (select *,ROW_NUMBER() OVER (ORDER BY CreateTime) AS FL from ActiveReply where MeetingId=@MeetingId )r1 ");
            strSql.Append(" on rf.ParentId=r1.Id  ");
            strSql.Append("  left join Users u on u.ID=r1.UId ) t   ");
            strSql.Append(" where MeetingId=@MeetingId  ");
            SqlParameter[] parameter = 
            {
                new SqlParameter("@MeetingId",SqlDbType.Int,4)
            };
            parameter[0].Value = parentId;
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString()), parameter));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder), parameter);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateIsVis(HN863Soft.ISS.Model.ActiveReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ActiveReply set ");
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
        /// 更新吐槽得分
        /// </summary>
        public bool UpdateScore(HN863Soft.ISS.Model.ActiveReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ActiveReply set ");
            strSql.Append("Score =@Score");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Score;
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
        /// 获得已分配的积分总值
        /// </summary>
        public int GetSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(Score)  from ActiveReply ");
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


        #endregion  ExtensionMethod
    }
}

