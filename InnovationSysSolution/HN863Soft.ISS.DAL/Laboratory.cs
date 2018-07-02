using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    /// <summary>
	/// 数据访问类:Laboratory
	/// </summary>
	public partial class Laboratory
	{
		public Laboratory(){}

		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Laboratory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Laboratory");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.Laboratory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Laboratory(");
			strSql.Append("UserID,LabName,LabLocation,LabIntro,Owner,ChargingStandard,LinkMan,Phone,Email,WeiXin,Evidence,LabExhibit,LabType,State,CreateTime,Remark)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@LabName,@LabLocation,@LabIntro,@Owner,@ChargingStandard,@LinkMan,@Phone,@Email,@WeiXin,@Evidence,@LabExhibit,@LabType,@State,@CreateTime,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.NVarChar,100),
					new SqlParameter("@LabLocation", SqlDbType.NVarChar,200),
					new SqlParameter("@LabIntro", SqlDbType.Text),
					new SqlParameter("@Owner", SqlDbType.NVarChar,200),
					new SqlParameter("@ChargingStandard", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@WeiXin", SqlDbType.VarChar,50),
					new SqlParameter("@Evidence", SqlDbType.Text),
					new SqlParameter("@LabExhibit", SqlDbType.Text),
					new SqlParameter("@LabType", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.LabName;
			parameters[2].Value = model.LabLocation;
			parameters[3].Value = model.LabIntro;
			parameters[4].Value = model.Owner;
			parameters[5].Value = model.ChargingStandard;
			parameters[6].Value = model.LinkMan;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.WeiXin;
			parameters[10].Value = model.Evidence;
			parameters[11].Value = model.LabExhibit;
			parameters[12].Value = model.LabType;
			parameters[13].Value = model.State;
			parameters[14].Value = model.CreateTime;
			parameters[15].Value = model.Remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(HN863Soft.ISS.Model.Laboratory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Laboratory set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("LabName=@LabName,");
			strSql.Append("LabLocation=@LabLocation,");
			strSql.Append("LabIntro=@LabIntro,");
			strSql.Append("Owner=@Owner,");
			strSql.Append("ChargingStandard=@ChargingStandard,");
			strSql.Append("LinkMan=@LinkMan,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("WeiXin=@WeiXin,");
			strSql.Append("Evidence=@Evidence,");
			strSql.Append("LabExhibit=@LabExhibit,");
			strSql.Append("LabType=@LabType,");
			strSql.Append("State=@State,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.NVarChar,100),
					new SqlParameter("@LabLocation", SqlDbType.NVarChar,200),
					new SqlParameter("@LabIntro", SqlDbType.Text),
					new SqlParameter("@Owner", SqlDbType.NVarChar,200),
					new SqlParameter("@ChargingStandard", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@WeiXin", SqlDbType.VarChar,50),
					new SqlParameter("@Evidence", SqlDbType.Text),
					new SqlParameter("@LabExhibit", SqlDbType.Text),
					new SqlParameter("@LabType", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.LabName;
			parameters[2].Value = model.LabLocation;
			parameters[3].Value = model.LabIntro;
			parameters[4].Value = model.Owner;
			parameters[5].Value = model.ChargingStandard;
			parameters[6].Value = model.LinkMan;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.WeiXin;
			parameters[10].Value = model.Evidence;
			parameters[11].Value = model.LabExhibit;
			parameters[12].Value = model.LabType;
			parameters[13].Value = model.State;
			parameters[14].Value = model.CreateTime;
			parameters[15].Value = model.Remark;
			parameters[16].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 审核重点实验室信息
        /// </summary>
        /// <param name="id">机构信息ID</param>
        /// <param name="state">审核状态</param>
        /// <returns></returns>
        public bool UpdateState(int id, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Organization set ");
            strSql.Append("State=@State, ");
            strSql.Append(" Remark=@Remark ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@Remark",SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = state;
            parameters[1].Value = "";
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Laboratory ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Laboratory ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public HN863Soft.ISS.Model.Laboratory GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,LabName,LabLocation,LabIntro,Owner,ChargingStandard,LinkMan,Phone,Email,WeiXin,Evidence,LabExhibit,LabType,State,CreateTime,Remark from Laboratory ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.Laboratory model=new HN863Soft.ISS.Model.Laboratory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public HN863Soft.ISS.Model.Laboratory DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.Laboratory model=new HN863Soft.ISS.Model.Laboratory();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["LabName"]!=null)
				{
					model.LabName=row["LabName"].ToString();
				}
				if(row["LabLocation"]!=null)
				{
					model.LabLocation=row["LabLocation"].ToString();
				}
				if(row["LabIntro"]!=null)
				{
					model.LabIntro=row["LabIntro"].ToString();
				}
				if(row["Owner"]!=null)
				{
					model.Owner=row["Owner"].ToString();
				}
				if(row["ChargingStandard"]!=null)
				{
					model.ChargingStandard=row["ChargingStandard"].ToString();
				}
				if(row["LinkMan"]!=null)
				{
					model.LinkMan=row["LinkMan"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["WeiXin"]!=null)
				{
					model.WeiXin=row["WeiXin"].ToString();
				}
				if(row["Evidence"]!=null)
				{
					model.Evidence=row["Evidence"].ToString();
				}
				if(row["LabExhibit"]!=null)
				{
					model.LabExhibit=row["LabExhibit"].ToString();
				}
				if(row["LabType"]!=null && row["LabType"].ToString()!="")
				{
					model.LabType=int.Parse(row["LabType"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,LabName,LabLocation,LabIntro,Owner,ChargingStandard,LinkMan,Phone,Email,WeiXin,Evidence,LabExhibit,LabType,State,CreateTime,Remark ");
			strSql.Append(" FROM Laboratory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,UserID,LabName,LabLocation,LabIntro,Owner,ChargingStandard,LinkMan,Phone,Email,WeiXin,Evidence,LabExhibit,LabType,State,CreateTime,Remark ");
			strSql.Append(" FROM Laboratory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("select * FROM Laboratory");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Laboratory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Laboratory T ");
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
			parameters[0].Value = "Laboratory";
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
