/**  版本信息模板在安装目录下，可自行修改。
* ServiceInfo.cs
*
* 功 能： N/A
* 类 名： ServiceInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/16 14:13:42   N/A    初版
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
    /// 数据访问类:ServiceInfo
    /// </summary>
    public partial class ServiceInfo
    {
        public ServiceInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "ServiceInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ServiceInfo");
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
        public int Add(HN863Soft.ISS.Model.ServiceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ServiceInfo(");
            strSql.Append("PublisherId,Title,Content,CreatTime,Visite,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@PublisherId,@Title,@Content,@CreatTime,@Visite,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreatTime", SqlDbType.Date,3),
					new SqlParameter("@Visite", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PublisherId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreatTime;
            parameters[4].Value = model.Visite;
            parameters[5].Value = model.Remarks;

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
        public bool Update(HN863Soft.ISS.Model.ServiceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServiceInfo set ");
            strSql.Append("PublisherId=@PublisherId,");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("CreatTime=@CreatTime,");
            strSql.Append("Visite=@Visite,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreatTime", SqlDbType.Date,3),
					new SqlParameter("@Visite", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.PublisherId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreatTime;
            parameters[4].Value = model.Visite;
            parameters[5].Value = model.Remarks;
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
            strSql.Append("delete from ServiceInfo ");
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
            strSql.Append("delete from ServiceInfo ");
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
        public HN863Soft.ISS.Model.ServiceInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,PublisherId,Title,Content,CreatTime,Visite,Remarks from ServiceInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.ServiceInfo model = new HN863Soft.ISS.Model.ServiceInfo();
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
        public HN863Soft.ISS.Model.ServiceInfo DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.ServiceInfo model = new HN863Soft.ISS.Model.ServiceInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["PublisherId"] != null && row["PublisherId"].ToString() != "")
                {
                    model.PublisherId = int.Parse(row["PublisherId"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["CreatTime"] != null && row["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(row["CreatTime"].ToString());
                }
                if (row["Visite"] != null && row["Visite"].ToString() != "")
                {
                    model.Visite = int.Parse(row["Visite"].ToString());
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
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
            strSql.Append("select Id,PublisherId,Title,Content,CreatTime,Visite,Remarks ");
            strSql.Append(" FROM ServiceInfo ");
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
            strSql.Append(" Id,PublisherId,Title,Content,CreatTime,Visite,Remarks ");
            strSql.Append(" FROM ServiceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select s.*,m.RealName,m.RoleType  from ServiceInfo s  ");
            strSql.Append(" left join Manager m on s.PublisherId=m.ID)  t ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ServiceInfo ");
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
            strSql.Append(")AS Row, T.*  from ServiceInfo T ");
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
            parameters[0].Value = "ServiceInfo";
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
        /// 条件更新一条数据
        /// </summary>
        public bool UpdateCondition(HN863Soft.ISS.Model.ServiceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServiceInfo set ");
            strSql.Append("PublisherId=isnull(@PublisherId,PublisherId),");
            strSql.Append("Title=isnull(@Title,Title),");
            strSql.Append("Content=isnull(@Content,Content),");
            strSql.Append("CreatTime=isnull(@CreatTime,CreatTime),");
            strSql.Append("Visite=isnull(@Visite,Visite),");
            strSql.Append("Remarks=isnull(@Remarks,Remarks)");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.Text),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@CreatTime", SqlDbType.Date,3),
					new SqlParameter("@Visite", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.PublisherId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.CreatTime;
            parameters[4].Value = model.Visite;
            parameters[5].Value = model.Remarks;
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
        /// 更新服务信息：是否隐藏
        /// </summary>
        /// <param name="model">服务信息</param>
        /// <returns></returns>
        public bool UpdateInfo(HN863Soft.ISS.Model.ServiceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ServiceInfo set ");
            strSql.Append("Visite=@Visite");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameter ={
                                          new SqlParameter("@Visite",SqlDbType.Int,4),
                                          new SqlParameter("@Id",SqlDbType.Int,4)
                                     };
            parameter[0].Value = model.Visite;
            parameter[1].Value = model.Id;
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

