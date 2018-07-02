/**  版本信息模板在安装目录下，可自行修改。
* ManagerRole.cs
*
* 功 能： N/A
* 类 名： ManagerRole
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/14 11:31:00   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　   　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HN863Soft.ISS.DBUtility;
using System.Collections.Generic;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:ManagerRole
    /// </summary>
    public partial class ManagerRole
    {
        public ManagerRole() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "ManagerRole");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ManagerRole where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool GetTypeNmae(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ManagerType where TypeName=@TypeName");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = TypeName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 返回角色名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 RoleName from ManagerRole");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        public string GetT(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TypeName from ManagerType");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        public HN863Soft.ISS.Model.ManagerType GetManagerType(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ManagerType");
            strSql.Append(" where id=" + id);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToManagerTypeModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        public int GetType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 RoleType from ManagerRole order by id desc");

            int type = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
            return type;

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.ManagerRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ManagerRole(");
            strSql.Append("RoleName,RoleType,IsSys)");
            strSql.Append(" values (");
            strSql.Append("@RoleName,@RoleType,@IsSys)");
            strSql.Append("; set  @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleType", SqlDbType.TinyInt,1),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleType;
            parameters[2].Value = model.IsSys;
            parameters[3].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2;
            if (model.ManagerRoleValues != null)
            {
                foreach (Model.ManagerRoleValue item in model.ManagerRoleValues)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into ManagerRoleValue(");
                    strSql2.Append("RoleID,NavName,ActionType)");
                    strSql2.Append(" values (");
                    strSql2.Append("@RoleID,@NavName,@ActionType)");
                    SqlParameter[] parameters2 = {
						    new SqlParameter("@RoleID", SqlDbType.Int,4),
					        new SqlParameter("@NavName", SqlDbType.NVarChar,100),
					        new SqlParameter("@ActionType", SqlDbType.NVarChar,50)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = item.NavName;
                    parameters2[2].Value = item.ActionType;
                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[3].Value;
        }

        public bool AddTypeName(string typeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ManagerType(");
            strSql.Append(" TypeName,IsSys )");
            strSql.Append(" values (@TypeName,@IsSys )");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsSys", SqlDbType.Int,4)};
            parameters[0].Value = typeName;
            parameters[1].Value = 0;
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rowsAffected > 0)
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
        public bool Update(HN863Soft.ISS.Model.ManagerRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ManagerRole set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleType=@RoleType,");
            strSql.Append("IsSys=@IsSys");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleType", SqlDbType.TinyInt,1),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleType;
            parameters[2].Value = model.IsSys;
            parameters[3].Value = model.ID;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //先删除该角色所有权限
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from ManagerRoleValue where RoleID=@RoleID ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters2[0].Value = model.ID;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //添加权限
            if (model.ManagerRoleValues != null)
            {
                StringBuilder strSql3;
                foreach (Model.ManagerRoleValue item in model.ManagerRoleValues)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into ManagerRoleValue(RoleID,NavName,ActionType)");
                    strSql3.Append(" values (");
                    strSql3.Append("@RoleID,@NavName,@ActionType)");
                    SqlParameter[] parameters3 = {
						    new SqlParameter("@RoleID", SqlDbType.Int,4),
					        new SqlParameter("@NavName", SqlDbType.NVarChar,100),
					        new SqlParameter("@ActionType", SqlDbType.NVarChar,50)};
                    parameters3[0].Value = item.RoleID;
                    parameters3[1].Value = item.NavName;
                    parameters3[2].Value = item.ActionType;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool UpdateType(int id, string typeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ManagerType set ");
            strSql.Append(" TypeName=@TypeName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = typeName;
            parameters[1].Value = id;

            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rowsAffected > 0)
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
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除管理角色权限
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ManagerRoleValue ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //删除管理角色
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from ManagerRole ");
            strSql1.Append(" where ID=@ID");
            SqlParameter[] parameters1 = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters1[0].Value = ID;
            cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            int rows1 = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            int rows = DbHelperSQL.ExecuteSql(strSql1.ToString(), parameters1);
            if (rows > 0 && rows1 > 0)
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
            strSql.Append("delete from ManagerRole ");
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
        public HN863Soft.ISS.Model.ManagerRole GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RoleName,RoleType,IsSys from ManagerRole ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.ManagerRole model = new HN863Soft.ISS.Model.ManagerRole();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region 父表信息
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                if (ds.Tables[0].Rows[0]["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(ds.Tables[0].Rows[0]["RoleType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSys"].ToString() != "")
                {
                    model.IsSys = int.Parse(ds.Tables[0].Rows[0]["IsSys"].ToString());
                }
                #endregion

                #region 子表信息"@RoleID,@NavName,@ActionType
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select ID,RoleID,NavName,ActionType from ManagerRoleValue ");
                strSql2.Append(" where RoleID=@RoleID");
                SqlParameter[] parameters2 = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
                parameters2[0].Value = ID;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    List<Model.ManagerRoleValue> models = new List<Model.ManagerRoleValue>();
                    Model.ManagerRoleValue modelt;
                    foreach (DataRow dr in ds2.Tables[0].Rows)
                    {
                        modelt = new Model.ManagerRoleValue();
                        if (dr["ID"].ToString() != "")
                        {
                            modelt.ID = int.Parse(dr["ID"].ToString());
                        }
                        if (dr["RoleID"].ToString() != "")
                        {
                            modelt.RoleID = int.Parse(dr["RoleID"].ToString());
                        }
                        modelt.NavName = dr["NavName"].ToString();
                        modelt.ActionType = dr["ActionType"].ToString();
                        models.Add(modelt);
                    }
                    model.ManagerRoleValues = models;
                }
                #endregion

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.ManagerRole DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.ManagerRole model = new HN863Soft.ISS.Model.ManagerRole();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["RoleType"] != null && row["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(row["RoleType"].ToString());
                }
                if (row["IsSys"] != null && row["IsSys"].ToString() != "")
                {
                    model.IsSys = int.Parse(row["IsSys"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.ManagerType DataRowToManagerTypeModel(DataRow row)
        {
            HN863Soft.ISS.Model.ManagerType model = new HN863Soft.ISS.Model.ManagerType();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["IsSys"] != null && row["IsSys"].ToString() != "")
                {
                    model.IsSys = int.Parse(row["IsSys"].ToString());
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
            strSql.Append("select ID,RoleName,RoleType,IsSys ");
            strSql.Append(" FROM ManagerRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ManagerType ");
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
            strSql.Append(" ID,RoleName,RoleType,IsSys ");
            strSql.Append(" FROM ManagerRole ");
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
            strSql.Append("select count(1) FROM ManagerRole ");
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
            strSql.Append(")AS Row, T.*  from ManagerRole T ");
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
            parameters[0].Value = "ManagerRole";
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

