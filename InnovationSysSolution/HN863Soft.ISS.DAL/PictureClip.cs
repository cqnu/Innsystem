/**  版本信息模板在安装目录下，可自行修改。
* PictureClip.cs
*
* 功 能： N/A
* 类 名： PictureClip
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/3 14:54:04   N/A    初版
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
using System.Collections;
using System.Collections.Generic;//Please add references
namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:PictureClip
    /// </summary>
    public partial class PictureClip
    {
        public PictureClip()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "PictureClip");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PictureClip");
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
        public int Add(HN863Soft.ISS.Model.PictureClip model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PictureClip(");
            strSql.Append("ParentId,ImgUrl)");
            strSql.Append(" values (");
            strSql.Append("@ParentId,@ImgUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.ParentId;
            parameters[1].Value = model.ImgUrl;

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
        public bool Update(HN863Soft.ISS.Model.PictureClip model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PictureClip set ");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ImgUrl=@ImgUrl");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ParentId;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.Id;

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
            strSql.Append("delete from PictureClip ");
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
            strSql.Append("delete from PictureClip ");
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
        public HN863Soft.ISS.Model.PictureClip GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ParentId,ImgUrl from PictureClip ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            HN863Soft.ISS.Model.PictureClip model = new HN863Soft.ISS.Model.PictureClip();
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
        public HN863Soft.ISS.Model.PictureClip DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.PictureClip model = new HN863Soft.ISS.Model.PictureClip();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
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
            strSql.Append("select Id,ParentId,ImgUrl,ROW_NUMBER() over(order by Id) num ");
            strSql.Append(" FROM PictureClip ");
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
            strSql.Append(" Id,ParentId,ImgUrl ");
            strSql.Append(" FROM PictureClip ");
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
            strSql.Append("select count(1) FROM PictureClip ");
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
            strSql.Append(")AS Row, T.*  from PictureClip T ");
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
            parameters[0].Value = "PictureClip";
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

        //ExecuteSqlTranWithIndentity


        /// <summary>
        /// 批量增加一条数据
        /// </summary>
        public void Add(List<HN863Soft.ISS.Model.PictureClip> lstModel, int parentId)
        {
            List<CommandInfo> SQLStringList = new List<CommandInfo>();
            int i = 0;
            CommandInfo delInfo = new CommandInfo();
            StringBuilder strDelSql = new StringBuilder();
            strDelSql.Append("delete from PictureClip ");
            strDelSql.Append(" where ParentId=@ParentId");
            SqlParameter[] paramet = {
					new SqlParameter("@ParentId", SqlDbType.Int,4)
			};
            paramet[0].Value = parentId;
            delInfo.CommandText = strDelSql.ToString();
            delInfo.Parameters = paramet;
            SQLStringList.Add(delInfo);

            foreach (Model.PictureClip model in lstModel)
            {
                CommandInfo info = new CommandInfo();
                
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into PictureClip(");
                strSql.Append("ParentId,ImgUrl)");
                strSql.Append(" values (");
                strSql.Append("@ParentId,@ImgUrl" + i + ")");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl"+i, SqlDbType.NVarChar,250)};
                parameters[0].Value = model.ParentId;
                parameters[1].Value = model.ImgUrl;
                info.CommandText = strSql.ToString();
                info.Parameters = parameters;
                SQLStringList.Add(info);
                i++;
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(SQLStringList);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PictureClip set ");
            strSql.Append("ParentId=@ParentId");
            strSql.Append(" where ParentId=0");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4)};
            parameters[0].Value = parentId;

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListImg(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ImgUrl");
            strSql.Append(" FROM PictureClip ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteClass(int parentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PictureClip ");
            strSql.Append(" where ParentId=@ParentId");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentId", SqlDbType.Int,4)
			};
            parameters[0].Value = parentId;

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

