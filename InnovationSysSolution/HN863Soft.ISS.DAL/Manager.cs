/**  版本信息模板在安装目录下，可自行修改。
* Manager.cs
*
* 功 能： N/A
* 类 名： Manager
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
using HN863Soft.ISS.Common;
using System.Collections.Generic;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:Manager
    /// </summary>
    public partial class Manager
    {
        public Manager() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Manager");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Manager where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool UpdateManagerType(int id, int type, int roId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Manager set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("RoleType=@RoleType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@RoleType", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = roId;
            parameters[1].Value = type;
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

        public bool UpdateOrganizationType(int userId, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Organization set ");
            strSql.Append("OrgType=@OrgType ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrgType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = type;
            parameters[1].Value = userId;

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
        /// 查询后台用户名是否存在
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from manager where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询前台用户名是否存在
        /// </summary>
        public bool ExistsReception(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询角色是否存在
        /// </summary>
        public bool ExistRole(int roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from manager where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.NVarChar,100)};
            parameters[0].Value = roleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from manager where UserName=@UserName");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }


        public string GetIntegral(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Point from Users where MId=@MId");
            SqlParameter[] parameters = {
                    new SqlParameter("@MId", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Manager(");
            strSql.Append("RoleID,RoleType,UserName,Password,Salt,RealName,Telephone,Email,IsLock,IsUseable,CreateTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@RoleType,@UserName,@Password,@Salt,@RealName,@Telephone,@Email,@IsLock,@IsUseable,@CreateTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleType", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Salt", SqlDbType.NVarChar,20),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
                    new SqlParameter("@IsUseable", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int,4)
        };
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleType;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Salt;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.Telephone;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.IsLock;
            parameters[9].Value = 0;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.Status;
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
        /// 增加一条数据
        /// </summary>
        public int AddUser(HN863Soft.ISS.Model.Users uModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId)");
            strSql.Append(" values (");
            strSql.Append("@uGroupID,@uUserName,@uSalt,@uPassword,@uMobile,@uEmail,@uAvatar,@uNickName,@uSex,@uBirthday,@uTelphone,@uArea,@uAddress,@uQQ,@uMsn,@uAmount,@uPoint,@uExp,@uStatus,@uRegTime,@uRegIP,@MId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					  new SqlParameter("@uGroupID", SqlDbType.Int,4),
					new SqlParameter("@uUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@uSalt", SqlDbType.NVarChar,20),
					new SqlParameter("@uPassword", SqlDbType.NVarChar,100),
					new SqlParameter("@uMobile", SqlDbType.NVarChar,20),
					new SqlParameter("@uEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@uAvatar", SqlDbType.NVarChar,255),
					new SqlParameter("@uNickName", SqlDbType.NVarChar,100),
					new SqlParameter("@uSex", SqlDbType.NVarChar,20),
					new SqlParameter("@uBirthday", SqlDbType.DateTime),
					new SqlParameter("@uTelphone", SqlDbType.NVarChar,50),
					new SqlParameter("@uArea", SqlDbType.NVarChar,255),
					new SqlParameter("@uAddress", SqlDbType.NVarChar,255),
					new SqlParameter("@uQQ", SqlDbType.NVarChar,20),
					new SqlParameter("@uMsn", SqlDbType.NVarChar,100),
					new SqlParameter("@uAmount", SqlDbType.Decimal,5),
					new SqlParameter("@uPoint", SqlDbType.Int,4),
					new SqlParameter("@uExp", SqlDbType.Int,4),
					new SqlParameter("@uStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@uRegTime", SqlDbType.DateTime),
					new SqlParameter("@uRegIP", SqlDbType.NVarChar,20),
                    new SqlParameter("@MId", SqlDbType.Int,4)};
            parameters[0].Value = uModel.GroupID;
            parameters[1].Value = uModel.UserName;
            parameters[2].Value = uModel.Salt;
            parameters[3].Value = uModel.Password;
            parameters[4].Value = uModel.Mobile;
            parameters[5].Value = uModel.Email;
            parameters[6].Value = uModel.Avatar;
            parameters[7].Value = uModel.NickName;
            parameters[8].Value = uModel.Sex;
            parameters[9].Value = uModel.Birthday;
            parameters[10].Value = uModel.Telphone;
            parameters[11].Value = uModel.Area;
            parameters[12].Value = uModel.Address;
            parameters[13].Value = uModel.QQ;
            parameters[14].Value = uModel.Msn;
            parameters[15].Value = uModel.Amount;
            parameters[16].Value = uModel.Point;
            parameters[17].Value = uModel.Exp;
            parameters[18].Value = uModel.Status;
            parameters[19].Value = uModel.RegTime;
            parameters[20].Value = uModel.RegIP;
            parameters[21].Value = uModel.MId;
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
        public bool Update(HN863Soft.ISS.Model.Manager model, HN863Soft.ISS.Model.Users umodel)
        {

            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Manager set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("RoleType=@RoleType,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Salt=@Salt,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Email=@Email,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleType", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Salt", SqlDbType.NVarChar,20),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleType;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Salt;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.Telephone;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.IsLock;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.ID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (umodel != null)
            {

                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update Users set ");
                strSql2.Append("UserName=@UserName,");
                strSql2.Append("Password=@Password,");
                strSql2.Append("Salt=@Salt,");
                strSql2.Append("NickName=@NickName,");
                strSql2.Append("Email=@Email,");
                strSql2.Append("Telphone=@Telphone,");
                strSql2.Append("Point=@Point");
                strSql2.Append(" where MId=@MId");
                SqlParameter[] parameters2 = {
					new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),                     
                    new SqlParameter("@Password", SqlDbType.NVarChar,100),   
                    new SqlParameter("@Salt", SqlDbType.NVarChar,20),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@Telphone", SqlDbType.NVarChar,50),
                    new SqlParameter("@Point", SqlDbType.Int,4)
                                         };
                parameters2[0].Value = umodel.MId;
                parameters2[1].Value = umodel.UserName;
                parameters2[2].Value = umodel.Password;
                parameters2[3].Value = umodel.Salt;
                parameters2[4].Value = umodel.NickName;
                parameters2[5].Value = umodel.Email;
                parameters2[6].Value = umodel.Telphone;
                parameters2[7].Value = umodel.Point;
                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);
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

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 更新机构认证信息
        /// </summary>
        public bool UpdateIsUseable(int id, int isUseable, int orgType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Manager set ");
            strSql.Append("IsUseable=@IsUseable,");
            strSql.Append("OrgType=@OrgType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@IsUseable", SqlDbType.Int,4),
                    new SqlParameter("@OrgType", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = isUseable;
            parameters[1].Value = orgType;
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

        public bool UpdateIntegral(HN863Soft.ISS.Model.Users model, HN863Soft.ISS.Model.Integral imodel)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("Point=Point+ @Point");

            strSql.Append(" where MId=@MId");
            SqlParameter[] parameters = {
					new SqlParameter("@Point", SqlDbType.Int,4),
                    new SqlParameter("@MId", SqlDbType.Int,4)
					};
            parameters[0].Value = model.Point;
            parameters[1].Value = model.ID;

            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);


            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into Integral ( ");
            strSql2.Append(" userID,projectID,projectName) ");
            strSql2.Append(" values (");
            strSql2.Append(" @userID,@projectID,@projectName)");

            SqlParameter[] parameters2 = {
					new SqlParameter("@userID", SqlDbType.Int,4),
                    new SqlParameter("@projectID", SqlDbType.Int,4),                     
                    new SqlParameter("@projectName", SqlDbType.NVarChar,200)
                 
                                         };
            parameters2[0].Value = imodel.Userid;
            parameters2[1].Value = imodel.Projectid;
            parameters2[2].Value = imodel.Projectname;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


            //parameters[2].Value = id;

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Manager ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from Users ");
            strSql2.Append(" where MId=@ID");
            SqlParameter[] parameters2 = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters2[0].Value = ID;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);
            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Manager ");
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
        public HN863Soft.ISS.Model.Manager GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RoleID,RoleType,UserName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime from Manager ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.Manager model = new HN863Soft.ISS.Model.Manager();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(ds.Tables[0].Rows[0]["RoleType"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Salt = ds.Tables[0].Rows[0]["Salt"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.Manager GetModel(string userName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from manager where UserName=@UserName and password=@password and IsLock=0 and Status=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.Manager DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.Manager model = new HN863Soft.ISS.Model.Manager();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["RoleType"] != null && row["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(row["RoleType"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Salt"] != null)
                {
                    model.Salt = row["Salt"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Telephone"] != null)
                {
                    model.Telephone = row["Telephone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["IsLock"] != null && row["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(row["IsLock"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select ID,RoleID,RoleType,UserName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime FROM Manager ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public bool GetIntegralList(HN863Soft.ISS.Model.Integral model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Integral ");
            strSql.Append(" where userID=@userID and projectID=@projectID and projectName=@projectName ");
            SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4),
                    new SqlParameter("@projectID", SqlDbType.Int,4),
                    new SqlParameter("@projectName", SqlDbType.NVarChar,200)
			};

            parameters[0].Value = model.Userid;
            parameters[1].Value = model.Projectid;
            parameters[2].Value = model.Projectname;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            strSql.Append(" ID,RoleID,RoleType,UserName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime ");
            strSql.Append(" FROM Manager ");
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
            strSql.Append(" select m.*,u.Point FROM Manager m left join Users u on m.ID=u.MId ");
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
            strSql.Append("select count(1) FROM Manager ");
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
            strSql.Append(")AS Row, T.*  from Manager T ");
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
            parameters[0].Value = "Manager";
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

