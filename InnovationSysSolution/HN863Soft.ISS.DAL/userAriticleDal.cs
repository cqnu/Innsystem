using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using HN863Soft.ISS.Common;
//*****************************
// 文件名（File Name）：Notice.cs
// 作者（Author）：邹峰
// 功能（Function）：发布、编辑、删除工业设计数据访问层
// 创建日期（Create Date）：2017/02/14
//*****************************
namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:userAriticle
    /// </summary>
    public partial class userAriticle
    {
        public userAriticle()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "userAriticle");
        }

        public DataSet GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from Manager ");
            strSql.Append(" where  ID =  " + id);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from userAriticle");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// 修改记录
        /// 修改人：雷登辉
        /// 修改项：添加Type字段
        public int Add(HN863Soft.ISS.Model.userAriticle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into userAriticle(");
            strSql.Append("UserId,Title,Content,datatime,hits,state,Type,LogImg,KeyWord,Introduce,Jurisdiction)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Title,@Content,@datatime,@hits,@state,@Type,@LogImg,@KeyWord,@Introduce,0)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@datatime", SqlDbType.DateTime),
					new SqlParameter("@hits", SqlDbType.BigInt,8),
                    new SqlParameter("@state", SqlDbType.Int),
                    new SqlParameter("@Type",SqlDbType.Int,4),
                    new SqlParameter("@LogImg", SqlDbType.NVarChar,500),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Introduce", SqlDbType.NVarChar,100)};

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.datatime;
            parameters[4].Value = model.hits;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Logimg;
            parameters[8].Value = model.Keyword;
            parameters[9].Value = model.Introduce;

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

        public int AddHits(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update userAriticle set hits=hits+1 ");
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

        public int AddAriticleClass(HN863Soft.ISS.Model.userAriticle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AriticleClass(");
            strSql.Append("Ariticleid,UserId,BeReplyId,title,content,datatime,DeletedState,LId)");
            strSql.Append(" values (");
            strSql.Append("@Ariticleid,@UserId,@BeReplyId,@title,@content,@datatime,0,@LId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Ariticleid", SqlDbType.Int,4),
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
            strSql.Append("update AriticleClass set ");
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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// 修改记录①
        /// 修改人：雷登辉
        /// 添加更新字段Type
        public bool Update(HN863Soft.ISS.Model.userAriticle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update userAriticle set ");
            //strSql.Append("UserId=@UserId,");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Type=@Type,");
            strSql.Append("LogImg=@LogImg,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("Introduce=@Introduce");
            //strSql.Append("state=@state,");
            //strSql.Append("Describe=@Describe");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
				
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,100),
                    new SqlParameter("@Type",SqlDbType.Int,4),
                    new SqlParameter("@LogImg", SqlDbType.NVarChar,500),
					new SqlParameter("@KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@Introduce", SqlDbType.NVarChar,100)
                    //new SqlParameter("@state", SqlDbType.Int),
                    //new SqlParameter("@Describe", SqlDbType.NVarChar,100)
                                        
                                        };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.State;
            parameters[4].Value = model.Describe;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Logimg;
            parameters[7].Value = model.Keyword;
            parameters[8].Value = model.Introduce;
          

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
            strSql.Append("delete from userAriticle ");
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
            strSql.Append("delete from userAriticle ");
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
        public HN863Soft.ISS.Model.userAriticle GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserId,state,Title,Content,datatime,hits,Describe,Type,LogImg,KeyWord,Introduce from userAriticle ");
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
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.userAriticle DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.userAriticle model = new HN863Soft.ISS.Model.userAriticle();
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
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.State = int.Parse(row["state"].ToString());
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
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["LogImg"] != null)
                {
                    model.Logimg = row["LogImg"].ToString();
                }
                if (row["KeyWord"] != null)
                {
                    model.Keyword = row["KeyWord"].ToString();
                }
                if (row["Introduce"] != null)
                {
                    model.Introduce = row["Introduce"].ToString();
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
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.id desc) AS rowid, a.*,u.UserName from userAriticle a ");
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

        public DataSet ShowToptie(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.*,u.UserName from userAriticle  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where  a.id =  " + id);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet ShowAriticleClass(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ROW_NUMBER() OVER (ORDER BY a.id  ) AS rowid, a.*,u.UserName from AriticleClass  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            //strSql.Append(" where 1=1  ");

            //strSql.Append(" select *,ROW_NUMBER() OVER (ORDER BY a.datatime) AS Floor   ");
            //strSql.Append("  from ( select  rf.*,u.UserName Name ,r1.FL,r1.ResponderId PersonId  from  ");
            //strSql.Append("  (select r.*,u.UserName  from AriticleClass r     left join Users u on u.ID=r.UserId ) rf    ");
            //strSql.Append("    left join  (select *,ROW_NUMBER() OVER (ORDER BY Time) AS FL from ReplyInfo where SId=5 )r1    ");
            //strSql.Append("   on rf.Ariticleid=r1.Id  left join Users u on u.ID=r1.ResponderId ) a   ");
            strSql.Append(" where 1=1  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " a.id  "));
        }

        public DataSet ShowAriticleClassInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  ROW_NUMBER() OVER (ORDER BY a.id  ) AS rowid, a.*,u.UserName from AriticleClass  a ");
            strSql.Append(" left join Manager u  on a.UserId=u.id   ");
            strSql.Append(" where 1=1  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append("ORDER BY a.id  ");
            return DbHelperSQL.Query(strSql.ToString());

        }

        public int SelAriticleClassCid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from AriticleClass ");

            strSql.Append(" where  Ariticleid =  " + id);
            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query(strSql.ToString());

            int num = ds.Tables[0].Rows.Count;

            return num;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// 修改记录①
        /// 修改人：雷登辉
        /// 添加字段Type
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UserId,state,Title,Content,datatime,hits,Describe,Type,LogImg,KeyWord,Introduce ");
            strSql.Append(" FROM userAriticle ");
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
            strSql.Append("select count(1) FROM userAriticle ");
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
            strSql.Append(")AS Row, T.*  from userAriticle T ");
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
            parameters[0].Value = "userAriticle";
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

