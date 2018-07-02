/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttributeField.cs
*
* 功 能： N/A
* 类 名： ArticleAttributeField
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:57   N/A    初版
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
	/// 数据访问类:ArticleAttributeField
	/// </summary>
	public partial class ArticleAttributeField
	{
		public ArticleAttributeField(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "ArticleAttributeField"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleAttributeField");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询是否存在列
        /// </summary>
        public bool Exists(string columnName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ArticleAttributeField where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100)};
            parameters[0].Value = columnName;

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select count(0) from syscolumns where ID=object_id('Article') and Name=@Name ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100)};
            parameters2[0].Value = columnName;

            if (DbHelperSQL.Exists(strSql.ToString(), parameters) || DbHelperSQL.Exists(strSql2.ToString(), parameters2))
            {
                return true;
            }
            return false;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.ArticleAttributeField model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleAttributeField(");
			strSql.Append("Name,Title,ControlType,DataType,DataLength,DataPlace,ItemOption,DefaultValue,IsRequired,IsPassword,IsHtml,EditorType,ValidTipMsg,ValidErrorMsg,ValidPattern,SortID,IsSys)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Title,@ControlType,@DataType,@DataLength,@DataPlace,@ItemOption,@DefaultValue,@IsRequired,@IsPassword,@IsHtml,@EditorType,@ValidTipMsg,@ValidErrorMsg,@ValidPattern,@SortID,@IsSys)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ControlType", SqlDbType.NVarChar,50),
					new SqlParameter("@DataType", SqlDbType.NVarChar,50),
					new SqlParameter("@DataLength", SqlDbType.Int,4),
					new SqlParameter("@DataPlace", SqlDbType.TinyInt,1),
					new SqlParameter("@ItemOption", SqlDbType.NText),
					new SqlParameter("@DefaultValue", SqlDbType.NText),
					new SqlParameter("@IsRequired", SqlDbType.TinyInt,1),
					new SqlParameter("@IsPassword", SqlDbType.TinyInt,1),
					new SqlParameter("@IsHtml", SqlDbType.TinyInt,1),
					new SqlParameter("@EditorType", SqlDbType.TinyInt,1),
					new SqlParameter("@ValidTipMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@ValidErrorMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@ValidPattern", SqlDbType.NVarChar,500),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.ControlType;
			parameters[3].Value = model.DataType;
			parameters[4].Value = model.DataLength;
			parameters[5].Value = model.DataPlace;
			parameters[6].Value = model.ItemOption;
			parameters[7].Value = model.DefaultValue;
			parameters[8].Value = model.IsRequired;
			parameters[9].Value = model.IsPassword;
			parameters[10].Value = model.IsHtml;
			parameters[11].Value = model.EditorType;
			parameters[12].Value = model.ValidTipMsg;
			parameters[13].Value = model.ValidErrorMsg;
			parameters[14].Value = model.ValidPattern;
			parameters[15].Value = model.SortID;
			parameters[16].Value = model.IsSys;
            parameters[17].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //增加扩展字段表中一列
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("alter table ArticleAttributeValue add " + model.Name + " " + model.DataType);
            SqlParameter[] parameters2 = { };
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[17].Value;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ArticleAttributeField model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update ArticleAttributeField set ");
                        strSql.Append("Name=@Name,");
                        strSql.Append("Title=@Title,");
                        strSql.Append("ControlType=@ControlType,");
                        strSql.Append("DataType=@DataType,");
                        strSql.Append("DataLength=@DataLength,");
                        strSql.Append("DataPlace=@DataPlace,");
                        strSql.Append("ItemOption=@ItemOption,");
                        strSql.Append("DefaultValue=@DefaultValue,");
                        strSql.Append("IsRequired=@IsRequired,");
                        strSql.Append("IsPassword=@IsPassword,");
                        strSql.Append("IsHtml=@IsHtml,");
                        strSql.Append("EditorType=@EditorType,");
                        strSql.Append("ValidTipMsg=@ValidTipMsg,");
                        strSql.Append("ValidErrorMsg=@ValidErrorMsg,");
                        strSql.Append("ValidPattern=@ValidPattern,");
                        strSql.Append("SortID=@SortID,");
                        strSql.Append("IsSys=@IsSys");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@ControlType", SqlDbType.NVarChar,50),
					new SqlParameter("@DataType", SqlDbType.NVarChar,50),
					new SqlParameter("@DataLength", SqlDbType.Int,4),
					new SqlParameter("@DataPlace", SqlDbType.TinyInt,1),
					new SqlParameter("@ItemOption", SqlDbType.NText),
					new SqlParameter("@DefaultValue", SqlDbType.NText),
					new SqlParameter("@IsRequired", SqlDbType.TinyInt,1),
					new SqlParameter("@IsPassword", SqlDbType.TinyInt,1),
					new SqlParameter("@IsHtml", SqlDbType.TinyInt,1),
					new SqlParameter("@EditorType", SqlDbType.TinyInt,1),
					new SqlParameter("@ValidTipMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@ValidErrorMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@ValidPattern", SqlDbType.NVarChar,500),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsSys", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.Name;
                        parameters[1].Value = model.Title;
                        parameters[2].Value = model.ControlType;
                        parameters[3].Value = model.DataType;
                        parameters[4].Value = model.DataLength;
                        parameters[5].Value = model.DataPlace;
                        parameters[6].Value = model.ItemOption;
                        parameters[7].Value = model.DefaultValue;
                        parameters[8].Value = model.IsRequired;
                        parameters[9].Value = model.IsPassword;
                        parameters[10].Value = model.IsHtml;
                        parameters[11].Value = model.EditorType;
                        parameters[12].Value = model.ValidTipMsg;
                        parameters[13].Value = model.ValidErrorMsg;
                        parameters[14].Value = model.ValidPattern;
                        parameters[15].Value = model.SortID;
                        parameters[16].Value = model.IsSys;
                        parameters[17].Value = model.ID;

                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                        //修改扩展字段表中一列
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("alter table ArticleAttributeValue alter column " + model.Name + " " + model.DataType);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
                        //没有错误确认事务
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleAttributeField set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			 //取得Model信息
            Model.ArticleAttributeField model = GetModel(id);
            //开始删除
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //查找关联的频道ID，得到后以备使用
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("select ChannelID,FieldID from ChannelField where FieldID=@FieldID");
                        SqlParameter[] parameters1 = {
					            new SqlParameter("@FieldID", SqlDbType.Int,4)};
                        parameters1[0].Value = id;
                        DataTable dt = DbHelperSQL.Query(conn, trans, strSql1.ToString(), parameters1).Tables[0];

                        //删除频道关联的字段表
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from ChannelField where FieldID=@FieldID");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@FieldID", SqlDbType.Int,4)};
                        parameters2[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //重建对应频道的视图
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Model.Channel modelt = new DAL.Channel().GetModel(conn, trans, int.Parse(dr["ChannelID"].ToString()));
                                if (modelt != null)
                                {
                                    new DAL.Channel().DeleteAndRebuildChannelViews(conn, trans, modelt, modelt.Name);
                                }
                            }
                        }

                        //删除主表
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from ArticleAttributeField where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
                        parameters[0].Value = id;

                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                         //删除扩展字段表中一列
                        DbHelperSQL.ExecuteSql(conn, trans, "alter table ArticleAttributeValue drop column " + model.Name);

                        //没有错误确认事务
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleAttributeField ");
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
		public HN863Soft.ISS.Model.ArticleAttributeField GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Title,ControlType,DataType,DataLength,DataPlace,ItemOption,DefaultValue,IsRequired,IsPassword,IsHtml,EditorType,ValidTipMsg,ValidErrorMsg,ValidPattern,SortID,IsSys from ArticleAttributeField ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.ArticleAttributeField model=new HN863Soft.ISS.Model.ArticleAttributeField();
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
		public HN863Soft.ISS.Model.ArticleAttributeField DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleAttributeField model=new HN863Soft.ISS.Model.ArticleAttributeField();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["ControlType"]!=null)
				{
					model.ControlType=row["ControlType"].ToString();
				}
				if(row["DataType"]!=null)
				{
					model.DataType=row["DataType"].ToString();
				}
				if(row["DataLength"]!=null && row["DataLength"].ToString()!="")
				{
					model.DataLength=int.Parse(row["DataLength"].ToString());
				}
				if(row["DataPlace"]!=null && row["DataPlace"].ToString()!="")
				{
					model.DataPlace=int.Parse(row["DataPlace"].ToString());
				}
				if(row["ItemOption"]!=null)
				{
					model.ItemOption=row["ItemOption"].ToString();
				}
				if(row["DefaultValue"]!=null)
				{
					model.DefaultValue=row["DefaultValue"].ToString();
				}
				if(row["IsRequired"]!=null && row["IsRequired"].ToString()!="")
				{
					model.IsRequired=int.Parse(row["IsRequired"].ToString());
				}
				if(row["IsPassword"]!=null && row["IsPassword"].ToString()!="")
				{
					model.IsPassword=int.Parse(row["IsPassword"].ToString());
				}
				if(row["IsHtml"]!=null && row["IsHtml"].ToString()!="")
				{
					model.IsHtml=int.Parse(row["IsHtml"].ToString());
				}
				if(row["EditorType"]!=null && row["EditorType"].ToString()!="")
				{
					model.EditorType=int.Parse(row["EditorType"].ToString());
				}
				if(row["ValidTipMsg"]!=null)
				{
					model.ValidTipMsg=row["ValidTipMsg"].ToString();
				}
				if(row["ValidErrorMsg"]!=null)
				{
					model.ValidErrorMsg=row["ValidErrorMsg"].ToString();
				}
				if(row["ValidPattern"]!=null)
				{
					model.ValidPattern=row["ValidPattern"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["IsSys"]!=null && row["IsSys"].ToString()!="")
				{
					model.IsSys=int.Parse(row["IsSys"].ToString());
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
			strSql.Append("select ID,Name,Title,ControlType,DataType,DataLength,DataPlace,ItemOption,DefaultValue,IsRequired,IsPassword,IsHtml,EditorType,ValidTipMsg,ValidErrorMsg,ValidPattern,SortID,IsSys ");
			strSql.Append(" FROM ArticleAttributeField ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得频道对应的数据
        /// </summary>
        public DataSet GetList(int channelID, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ArticleAttributeField.* FROM ArticleAttributeField INNER JOIN ChannelField ON ArticleAttributeField.ID = ChannelField.FieldID");
            strSql.Append(" where ChannelID=" + channelID);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by SortID asc,ArticleAttributeField.ID desc");
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
			strSql.Append(" ID,Name,Title,ControlType,DataType,DataLength,DataPlace,ItemOption,DefaultValue,IsRequired,IsPassword,IsHtml,EditorType,ValidTipMsg,ValidErrorMsg,ValidPattern,SortID,IsSys ");
			strSql.Append(" FROM ArticleAttributeField ");
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
            strSql.Append("select * FROM ArticleAttributeField");
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
			strSql.Append("select count(1) FROM ArticleAttributeField ");
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
			strSql.Append(")AS Row, T.*  from ArticleAttributeField T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取扩展字段对称值
        /// </summary>
        public Dictionary<string, string> GetFields(int channelID, int articleID, string strWhere)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataTable dt = GetList(channelID, strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(dr["Name"].ToString() + ",");
                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 " + Utils.DelLastComma(sb.ToString()) + " from ArticleAttributeValue ");
                strSql.Append(" where ArticleID=@ArticleID ");
                SqlParameter[] parameters = {
					    new SqlParameter("@ArticleID", SqlDbType.Int,4)};
                parameters[0].Value = articleID;

                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (ds.Tables[0].Rows[0][dr["Name"].ToString()] != null)
                        {
                            dic.Add(dr["Name"].ToString(), ds.Tables[0].Rows[0][dr["Name"].ToString()].ToString());
                        }
                        else
                        {
                            dic.Add(dr["Name"].ToString(), "");
                        }
                    }
                }
            }
            return dic;
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
			parameters[0].Value = "ArticleAttributeField";
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

