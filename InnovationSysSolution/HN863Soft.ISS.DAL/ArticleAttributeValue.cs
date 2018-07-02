/**  版本信息模板在安装目录下，可自行修改。
* ArticleAttributeValue.cs
*
* 功 能： N/A
* 类 名： ArticleAttributeValue
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:33:58   N/A    初版
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

namespace HN863Soft.ISS.DAL
{
	/// <summary>
	/// 数据访问类:ArticleAttributeValue
	/// </summary>
	public partial class ArticleAttributeValue
	{
		public ArticleAttributeValue(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ArticleId", "ArticleAttributeValue"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ArticleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArticleAttributeValue");
			strSql.Append(" where ArticleId=@ArticleId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4)			};
			parameters[0].Value = ArticleId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(HN863Soft.ISS.Model.ArticleAttributeValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleAttributeValue(");
			strSql.Append("ArticleId,SubTitle,Source,Author,GoodsNo,StockQuantity,MarketPrice,SellPrice,Point,VideoSrc)");
			strSql.Append(" values (");
			strSql.Append("@ArticleId,@SubTitle,@Source,@Author,@GoodsNo,@StockQuantity,@MarketPrice,@SellPrice,@Point,@VideoSrc)");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@Source", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsNo", SqlDbType.NVarChar,100),
					new SqlParameter("@StockQuantity", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,5),
					new SqlParameter("@SellPrice", SqlDbType.Decimal,5),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@VideoSrc", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ArticleId;
			parameters[1].Value = model.SubTitle;
			parameters[2].Value = model.Source;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.GoodsNo;
			parameters[5].Value = model.StockQuantity;
			parameters[6].Value = model.MarketPrice;
			parameters[7].Value = model.SellPrice;
			parameters[8].Value = model.Point;
			parameters[9].Value = model.VideoSrc;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.ArticleAttributeValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleAttributeValue set ");
			strSql.Append("SubTitle=@SubTitle,");
			strSql.Append("Source=@Source,");
			strSql.Append("Author=@Author,");
			strSql.Append("GoodsNo=@GoodsNo,");
			strSql.Append("StockQuantity=@StockQuantity,");
			strSql.Append("MarketPrice=@MarketPrice,");
			strSql.Append("SellPrice=@SellPrice,");
			strSql.Append("Point=@Point,");
			strSql.Append("VideoSrc=@VideoSrc");
			strSql.Append(" where ArticleId=@ArticleId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@Source", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsNo", SqlDbType.NVarChar,100),
					new SqlParameter("@StockQuantity", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,5),
					new SqlParameter("@SellPrice", SqlDbType.Decimal,5),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@VideoSrc", SqlDbType.NVarChar,255),
					new SqlParameter("@ArticleId", SqlDbType.Int,4)};
			parameters[0].Value = model.SubTitle;
			parameters[1].Value = model.Source;
			parameters[2].Value = model.Author;
			parameters[3].Value = model.GoodsNo;
			parameters[4].Value = model.StockQuantity;
			parameters[5].Value = model.MarketPrice;
			parameters[6].Value = model.SellPrice;
			parameters[7].Value = model.Point;
			parameters[8].Value = model.VideoSrc;
			parameters[9].Value = model.ArticleId;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ArticleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleAttributeValue ");
			strSql.Append(" where ArticleId=@ArticleId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4)			};
			parameters[0].Value = ArticleId;

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
		public bool DeleteList(string ArticleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleAttributeValue ");
			strSql.Append(" where ArticleId in ("+ArticleIdlist + ")  ");
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
		public HN863Soft.ISS.Model.ArticleAttributeValue GetModel(int ArticleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ArticleId,SubTitle,Source,Author,GoodsNo,StockQuantity,MarketPrice,SellPrice,Point,VideoSrc from ArticleAttributeValue ");
			strSql.Append(" where ArticleId=@ArticleId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleId", SqlDbType.Int,4)			};
			parameters[0].Value = ArticleId;

			HN863Soft.ISS.Model.ArticleAttributeValue model=new HN863Soft.ISS.Model.ArticleAttributeValue();
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
		public HN863Soft.ISS.Model.ArticleAttributeValue DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.ArticleAttributeValue model=new HN863Soft.ISS.Model.ArticleAttributeValue();
			if (row != null)
			{
				if(row["ArticleId"]!=null && row["ArticleId"].ToString()!="")
				{
					model.ArticleId=int.Parse(row["ArticleId"].ToString());
				}
				if(row["SubTitle"]!=null)
				{
					model.SubTitle=row["SubTitle"].ToString();
				}
				if(row["Source"]!=null)
				{
					model.Source=row["Source"].ToString();
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["GoodsNo"]!=null)
				{
					model.GoodsNo=row["GoodsNo"].ToString();
				}
				if(row["StockQuantity"]!=null && row["StockQuantity"].ToString()!="")
				{
					model.StockQuantity=int.Parse(row["StockQuantity"].ToString());
				}
				if(row["MarketPrice"]!=null && row["MarketPrice"].ToString()!="")
				{
					model.MarketPrice=decimal.Parse(row["MarketPrice"].ToString());
				}
				if(row["SellPrice"]!=null && row["SellPrice"].ToString()!="")
				{
					model.SellPrice=decimal.Parse(row["SellPrice"].ToString());
				}
				if(row["Point"]!=null && row["Point"].ToString()!="")
				{
					model.Point=int.Parse(row["Point"].ToString());
				}
				if(row["VideoSrc"]!=null)
				{
					model.VideoSrc=row["VideoSrc"].ToString();
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
			strSql.Append("select ArticleId,SubTitle,Source,Author,GoodsNo,StockQuantity,MarketPrice,SellPrice,Point,VideoSrc ");
			strSql.Append(" FROM ArticleAttributeValue ");
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
			strSql.Append(" ArticleId,SubTitle,Source,Author,GoodsNo,StockQuantity,MarketPrice,SellPrice,Point,VideoSrc ");
			strSql.Append(" FROM ArticleAttributeValue ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ArticleAttributeValue ");
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
				strSql.Append("order by T.ArticleId desc");
			}
			strSql.Append(")AS Row, T.*  from ArticleAttributeValue T ");
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
			parameters[0].Value = "ArticleAttributeValue";
			parameters[1].Value = "ArticleId";
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

