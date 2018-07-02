/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:01   N/A    初版
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
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
    /// 数据访问类:Users
    /// </summary>
    public partial class Users
    {
        public Users() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Users");
        }

        public DataSet RowTypeId(string rowType)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select * from ManagerType where TypeName= '" + rowType+"'");
           
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet RowId(int rowType)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select * from ManagerRole where RoleType= " + rowType + "");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <returns></returns>
        public bool ValidationInformation(string userName, string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserName=@UserName and Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = userName;
            parameters[1].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ValidationMail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where  Email=@Email ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Email", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查同一IP注册间隔(小时)内是否存在
        /// </summary>
        public bool Exists(string regIP, int regCtrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where RegIP=@RegIP and DATEDIFF(hh,TegTime,getdate())<@RegCtrl ");
            SqlParameter[] parameters = {
					new SqlParameter("@RegIP", SqlDbType.NVarChar,30),
                    new SqlParameter("@RegCtrl", SqlDbType.Int,4)};
            parameters[0].Value = regIP;
            parameters[1].Value = regCtrl;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查Email是否存在
        /// </summary>
        public bool ExistsEmail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,100)};
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查手机号码是否存在
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where Mobile=@Mobile ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20)};
            parameters[0].Value = mobile;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string userName)
        {
            //尝试用户名取得Salt
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Salt from Users");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            //尝试用手机号取得Salt
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select top 1 Salt from Users");
            strSql1.Append(" where Mobile=@Mobile");
            SqlParameter[] parameters1 = {
                    new SqlParameter("@Mobile", SqlDbType.NVarChar,20)};
            parameters1[0].Value = userName;
            salt = Convert.ToString(DbHelperSQL.GetSingle(strSql1.ToString(), parameters1));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            //尝试用邮箱取得Salt
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select top 1 Salt from Users");
            strSql2.Append(" where Email=@Email");
            SqlParameter[] parameters2 = {
                    new SqlParameter("@Email", SqlDbType.NVarChar,50)};
            parameters2[0].Value = userName;
            salt = Convert.ToString(DbHelperSQL.GetSingle(strSql2.ToString(), parameters2));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            return string.Empty;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId)");
            strSql.Append(" values (");
            strSql.Append("@GroupID,@UserName,@Salt,@Password,@Mobile,@Email,@Avatar,@NickName,@Sex,@Birthday,@Telphone,@Area,@Address,@QQ,@Msn,@Amount,@Point,@Exp,@Status,@RegTime,@RegIP,@MId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Salt", SqlDbType.NVarChar,20),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@NickName", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.NVarChar,20),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,255),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Msn", SqlDbType.NVarChar,100),
					new SqlParameter("@Amount", SqlDbType.Decimal,5),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@Exp", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIP", SqlDbType.NVarChar,20),
                    new SqlParameter("@MId", SqlDbType.Int,4)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Salt;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Avatar;
            parameters[7].Value = model.NickName;
            parameters[8].Value = model.Sex;
            parameters[9].Value = model.Birthday;
            parameters[10].Value = model.Telphone;
            parameters[11].Value = model.Area;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.QQ;
            parameters[14].Value = model.Msn;
            parameters[15].Value = model.Amount;
            parameters[16].Value = model.Point;
            parameters[17].Value = model.Exp;
            parameters[18].Value = model.Status;
            parameters[19].Value = model.RegTime;
            parameters[20].Value = model.RegIP;
            parameters[21].Value = model.MId;

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
        public bool Update(HN863Soft.ISS.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("GroupID=@GroupID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Salt=@Salt,");
            strSql.Append("Password=@Password,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Email=@Email,");
            strSql.Append("Avatar=@Avatar,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Telphone=@Telphone,");
            strSql.Append("Area=@Area,");
            strSql.Append("Address=@Address,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Msn=@Msn,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("Point=@Point,");
            strSql.Append("Exp=@Exp,");
            strSql.Append("Status=@Status,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("RegIP=@RegIP");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Salt", SqlDbType.NVarChar,20),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@NickName", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.NVarChar,20),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,255),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Msn", SqlDbType.NVarChar,100),
					new SqlParameter("@Amount", SqlDbType.Decimal,5),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@Exp", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIP", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Salt;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Avatar;
            parameters[7].Value = model.NickName;
            parameters[8].Value = model.Sex;
            parameters[9].Value = model.Birthday;
            parameters[10].Value = model.Telphone;
            parameters[11].Value = model.Area;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.QQ;
            parameters[14].Value = model.Msn;
            parameters[15].Value = model.Amount;
            parameters[16].Value = model.Point;
            parameters[17].Value = model.Exp;
            parameters[18].Value = model.Status;
            parameters[19].Value = model.RegTime;
            parameters[20].Value = model.RegIP;
            parameters[21].Value = model.ID;

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
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set " + strValue);
            strSql.Append(" where ID=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //获取用户旧数据
            Model.Users model = GetModel(id);
            if (model == null)
            {
                return false;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除积分记录
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from UserPointLog ");
            strSql1.Append(" where UserID=@ID");
            SqlParameter[] parameters1 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除金额记录
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from UserAmountLog ");
            strSql2.Append(" where UserID=@ID");
            SqlParameter[] parameters2 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //删除附件购买记录
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from UserAttachLog");
            strSql3.Append(" where UserID=@id");
            SqlParameter[] parameters3 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters3[0].Value = id;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //删除短消息
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from UserMessage ");
            strSql4.Append(" where PostUserName=@PostUserName or AcceptUserName=@AcceptUserName");
            SqlParameter[] parameters4 = {
					new SqlParameter("@PostUserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@AcceptUserName", SqlDbType.NVarChar,100)};
            parameters4[0].Value = model.UserName;
            parameters4[1].Value = model.UserName;
            cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);

            //删除申请码
            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from UserCode ");
            strSql5.Append(" where UserID=@ID");
            SqlParameter[] parameters5 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters5[0].Value = id;
            cmd = new CommandInfo(strSql5.ToString(), parameters5);
            sqllist.Add(cmd);

            //删除登录日志
            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("delete from UserLoginLog ");
            strSql6.Append(" where UserID=@ID");
            SqlParameter[] parameters6 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters6[0].Value = id;
            cmd = new CommandInfo(strSql6.ToString(), parameters6);
            sqllist.Add(cmd);

            //删除OAuth授权用户信息
            StringBuilder strSql8 = new StringBuilder();
            strSql8.Append("delete from UserOauth ");
            strSql8.Append(" where UserID=@ID");
            SqlParameter[] parameters8 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters8[0].Value = id;
            cmd = new CommandInfo(strSql8.ToString(), parameters8);
            sqllist.Add(cmd);

            //删除用户充值表
            StringBuilder strSql9 = new StringBuilder();
            strSql9.Append("delete from UserRecharge ");
            strSql9.Append(" where UserID=@ID");
            SqlParameter[] parameters9 = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters9[0].Value = id;
            cmd = new CommandInfo(strSql9.ToString(), parameters9);
            sqllist.Add(cmd);

            //删除用户主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
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
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Users ");
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
        public HN863Soft.ISS.Model.Users GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId from Users ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.Users model = new HN863Soft.ISS.Model.Users();
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
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.Users GetModel(string userName, string password, bool isEncrypt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId from Users ");

            strSql.Append(" where (UserName=@UserName");
            //if (emailLogin == 1)
            //{
            //    strSql.Append(" or Email=@UserName");
            //}
            //if (mobileLogin == 1)
            //{
            //    strSql.Append(" or Mobile=@UserName");
            //}
            strSql.Append(") and Password=@Password and status=1");

            SqlParameter[] parameters = {
					    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                        new SqlParameter("@Password", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;
            parameters[1].Value = password;

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
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.Users GetModel(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId from Users ");
            strSql.Append(" where UserName=@UserName and status<3");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = userName;

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
        public HN863Soft.ISS.Model.Users DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.Users model = new HN863Soft.ISS.Model.Users();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(row["GroupID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Salt"] != null)
                {
                    model.Salt = row["Salt"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Avatar"] != null)
                {
                    model.Avatar = row["Avatar"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Telphone"] != null)
                {
                    model.Telphone = row["Telphone"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Msn"] != null)
                {
                    model.Msn = row["Msn"].ToString();
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["Point"] != null && row["Point"].ToString() != "")
                {
                    model.Point = int.Parse(row["Point"].ToString());
                }
                if (row["Exp"] != null && row["Exp"].ToString() != "")
                {
                    model.Exp = int.Parse(row["Exp"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["RegIP"] != null)
                {
                    model.RegIP = row["RegIP"].ToString();
                }
                if (row["MId"] != null)
                {
                    model.MId = int.Parse(row["MId"].ToString());
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
            strSql.Append("select ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

                strSql.Append(" and Status=1 ");
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
            strSql.Append(" ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId ");
            strSql.Append(" FROM Users ");
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
            strSql.Append("select * FROM Users");
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
            strSql.Append("select count(1) FROM Users ");
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
            strSql.Append(")AS Row, T.*  from Users T ");
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
            parameters[0].Value = "Users";
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

        /// <summary>
        /// 添加组织账户
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public int Update(string name, string type)
        {
            StringBuilder strSql = new StringBuilder();

            if (type == "1")
            {

                strSql.Append(" update Manager set ");
                strSql.Append(" Status =1 where UserName= '" + name + "'");
            }

            strSql.Append(" update Users set ");
            strSql.Append("Status = 1 where UserName= '" + name + "'");





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


        public int UpdatePwd(string name, string pwd, string salt)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select * from Manager where UserName= '" + name + "'");

            bool flg = DbHelperSQL.Exists(strSql.ToString());

            strSql = new StringBuilder();
            if (flg)
            {
                strSql.Append(" update Manager set ");
                strSql.Append(" Password = @Password,  Salt=@Salt ");
                strSql.Append(" where UserName=@UserName ");
            }
            strSql.Append(" update Users set ");
            strSql.Append(" Password = @Password,  Salt=@Salt ");
            strSql.Append(" where UserName=@UserName");


            SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar),
                    new SqlParameter("@Salt", SqlDbType.NVarChar),
                    new SqlParameter("@UserName", SqlDbType.NVarChar)
			};

            parameters[0].Value = pwd;
            parameters[1].Value = salt;
            parameters[2].Value = name;
            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 添加组织账户
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public int Add(HN863Soft.ISS.Model.Users uModel, HN863Soft.ISS.Model.Manager mModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Manager(");
            strSql.Append("RoleID,RoleType,UserName,Password,Salt,RealName,Telephone,Email,IsLock,IsUseable,CreateTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@mRoleID,@mRoleType,@mUserName,@mPassword,@mSalt,@mRealName,@mTelephone,@mEmail,@mIsLock,@mIsUseable,@mCreateTime,0)");
            strSql.Append(";declare @identety int ");
            strSql.Append(" set @identety=(select @@IDENTITY)");

            strSql.Append("insert into Users(");
            strSql.Append("GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId)");
            strSql.Append(" values (");
            strSql.Append("@uGroupID,@uUserName,@uSalt,@uPassword,@uMobile,@uEmail,@uAvatar,@uNickName,@uSex,@uBirthday,@uTelphone,@uArea,@uAddress,@uQQ,@uMsn,@uAmount,@uPoint,@uExp,@uStatus,@uRegTime,@uRegIP,@identety)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@mRoleID", SqlDbType.Int,4),
					new SqlParameter("@mRoleType", SqlDbType.Int,4),
					new SqlParameter("@mUserName", SqlDbType.NVarChar,100),
					new SqlParameter("@mPassword", SqlDbType.NVarChar,100),
					new SqlParameter("@mSalt", SqlDbType.NVarChar,20),
					new SqlParameter("@mRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@mTelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@mEmail", SqlDbType.NVarChar,30),
					new SqlParameter("@mIsLock", SqlDbType.Int,4),
                    new SqlParameter("@mIsUseable", SqlDbType.Int,4),
					new SqlParameter("@mCreateTime", SqlDbType.DateTime),
                                        
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
                    };
            parameters[0].Value = mModel.RoleID;
            parameters[1].Value = mModel.RoleType;
            parameters[2].Value = mModel.UserName;
            parameters[3].Value = mModel.Password;
            parameters[4].Value = mModel.Salt;
            parameters[5].Value = mModel.RealName;
            parameters[6].Value = mModel.Telephone;
            parameters[7].Value = mModel.Email;
            parameters[8].Value = mModel.IsLock;
            parameters[9].Value = 0;
            parameters[10].Value = mModel.CreateTime;

            parameters[11].Value = uModel.GroupID;
            parameters[12].Value = uModel.UserName;
            parameters[13].Value = uModel.Salt;
            parameters[14].Value = uModel.Password;
            parameters[15].Value = uModel.Mobile;
            parameters[16].Value = uModel.Email;
            parameters[17].Value = uModel.Avatar;
            parameters[18].Value = uModel.NickName;
            parameters[19].Value = uModel.Sex;
            parameters[20].Value = uModel.Birthday;
            parameters[21].Value = uModel.Telphone;
            parameters[22].Value = uModel.Area;
            parameters[23].Value = uModel.Address;
            parameters[24].Value = uModel.QQ;
            parameters[25].Value = uModel.Msn;
            parameters[26].Value = uModel.Amount;
            parameters[27].Value = uModel.Point;
            parameters[28].Value = uModel.Exp;
            parameters[29].Value = uModel.Status;
            parameters[30].Value = uModel.RegTime;
            parameters[31].Value = uModel.RegIP;


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
        /// 根据管理员Id获取前台用户信息
        /// </summary>
        /// <param name="ID">管理员Id</param>
        /// <returns></returns>
        public HN863Soft.ISS.Model.Users GetUserModel(int mId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GroupID,UserName,Salt,Password,Mobile,Email,Avatar,NickName,Sex,Birthday,Telphone,Area,Address,QQ,Msn,Amount,Point,Exp,Status,RegTime,RegIP,MId from Users ");
            strSql.Append(" where MId=@MId");
            SqlParameter[] parameters = {
					new SqlParameter("@MId", SqlDbType.Int,4)
			};
            parameters[0].Value = mId;

            HN863Soft.ISS.Model.Users model = new HN863Soft.ISS.Model.Users();
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

        #endregion  ExtensionMethod
    }
}

