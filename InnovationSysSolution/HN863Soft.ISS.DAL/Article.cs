/**  版本信息模板在安装目录下，可自行修改。
* Article.cs
*
* 功 能： N/A
* 类 名： Article
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
	/// 数据访问类:Article
	/// </summary>
	public partial class Article
	{
		public Article(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Article");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string callIndex)
        {
            if (string.IsNullOrEmpty(callIndex))
            {
                return false;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Article");
            strSql.Append(" where CallIndex=@CallIndex ");
            SqlParameter[] parameters = {
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50)};
            parameters[0].Value = callIndex;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Article");
            strSql.Append(" where Title=@Title ");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,200)};
            parameters[0].Value = title;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title, int categoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Article");
            strSql.Append(" where Title=@Title and CategoryID=@CategoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,200),
                    new SqlParameter("@CategoryID", SqlDbType.Int,4)  }
                                        ;
            parameters[0].Value = title;
            parameters[1].Value = categoryID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回信息标题
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from Article");
            strSql.Append(" where ID=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }
            return title;
        }

        /// <summary>
        /// 返回信息内容
        /// </summary>
        public string GetContent(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ArticleContent from Article");
            strSql.Append(" where ID=" + id);
            string content = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(content))
            {
                return "";
            }
            return content;
        }

        /// <summary>
        /// 获取阅读次数
        /// </summary>
        public int GetClick(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClickNum from Article");
            strSql.Append(" where ID=" + id);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Article set " + strValue);
            strSql.Append(" where ID=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HN863Soft.ISS.Model.Article model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 添加主表数据
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into Article(");
                        strSql.Append("ChannelID,CategoryID,CallIndex,Title,LinkURL,ImgURL,SEOTitle,SEOKeywords,SEODescription,Tags,Digest,ArticleContent,SortID,ClickNum,Status,FlagComment,FlagTop,FlagRecommend,FlagHot,FlagSlide,FlagAdmin,UserName,CreateTime,UpdateTime)");
                        strSql.Append(" values (");
                        strSql.Append("@ChannelID,@CategoryID,@CallIndex,@Title,@LinkURL,@ImgURL,@SEOTitle,@SEOKeywords,@SEODescription,@Tags,@Digest,@ArticleContent,@SortID,@ClickNum,@Status,@FlagComment,@FlagTop,@FlagRecommend,@FlagHot,@FlagSlide,@FlagAdmin,@UserName,@CreateTime,@UpdateTime)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,255),
					new SqlParameter("@ImgURL", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,255),
					new SqlParameter("@Tags", SqlDbType.NVarChar,500),
					new SqlParameter("@Digest", SqlDbType.NVarChar,255),
					new SqlParameter("@ArticleContent", SqlDbType.NText),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagComment", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagTop", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagRecommend", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagHot", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagSlide", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagAdmin", SqlDbType.TinyInt,1),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
                        parameters[0].Value = model.ChannelID;
                        parameters[1].Value = model.CategoryID;
                        parameters[2].Value = model.CallIndex;
                        parameters[3].Value = model.Title;
                        parameters[4].Value = model.LinkURL;
                        parameters[5].Value = model.ImgURL;
                        parameters[6].Value = model.SEOTitle;
                        parameters[7].Value = model.SEOKeywords;
                        parameters[8].Value = model.SEODescription;
                        parameters[9].Value = model.Tags;
                        parameters[10].Value = model.Digest;
                        parameters[11].Value = model.ArticleContent;
                        parameters[12].Value = model.SortID;
                        parameters[13].Value = model.ClickNum;
                        parameters[14].Value = model.Status;
                        parameters[15].Value = model.FlagComment;
                        parameters[16].Value = model.FlagTop;
                        parameters[17].Value = model.FlagRecommend;
                        parameters[18].Value = model.FlagHot;
                        parameters[19].Value = model.FlagSlide;
                        parameters[20].Value = model.FlagAdmin;
                        parameters[21].Value = model.UserName;
                        parameters[22].Value = model.CreateTime;
                        parameters[23].Value = model.UpdateTime;

                        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                        if (obj == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
                        #endregion

                        #region 添加扩展字段
                        StringBuilder strSql2 = new StringBuilder();
                        StringBuilder strFieldName = new StringBuilder(); //字段列表
                        StringBuilder strFieldVar = new StringBuilder(); //字段声明
                        SqlParameter[] parameters2 = new SqlParameter[model.Fields.Count + 1];
                        int i = 1;
                        strFieldName.Append("ArticleID");
                        strFieldVar.Append("@ArticleID");
                        parameters2[0] = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
                        parameters2[0].Value = model.ID;
                        foreach (KeyValuePair<string, string> kvp in model.Fields)
                        {
                            strFieldName.Append("," + kvp.Key);
                            strFieldVar.Append(",@" + kvp.Key);
                            if (kvp.Value.Length <= 4000)
                            {
                                parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NVarChar, kvp.Value.Length);
                            }
                            else
                            {
                                parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NText);
                            }

                            parameters2[i].Value = kvp.Value;
                            i++;
                        }
                        strSql2.Append("insert into ArticleAttributeValue(");
                        strSql2.Append(strFieldName.ToString() + ")");
                        strSql2.Append(" values (");
                        strSql2.Append(strFieldVar.ToString() + ")");
                        DbHelperSQL.GetSingle(conn, trans, strSql2.ToString(), parameters2); //带事务
                        #endregion

                        #region 添加图片相册====================
                        if (model.Albums != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.ArticleAlbum modelt in model.Albums)
                            {
                                strSql3 = new StringBuilder();
                                strSql3.Append("insert into ArticleAlbum(");
                                strSql3.Append("ArticleID,ThumbPath,OriginalPath,Remark)");
                                strSql3.Append(" values (");
                                strSql3.Append("@ArticleID,@ThumbPath,@OriginalPath,@Remark)");
                                SqlParameter[] parameters3 = {
					                new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                new SqlParameter("@ThumbPath", SqlDbType.NVarChar,255),
					                new SqlParameter("@OriginalPath", SqlDbType.NVarChar,255),
					                new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
                                parameters3[0].Value = model.ID;
                                parameters3[1].Value = modelt.ThumbPath;
                                parameters3[2].Value = modelt.OriginalPath;
                                parameters3[3].Value = modelt.Remark;
                                DbHelperSQL.GetSingle(conn, trans, strSql3.ToString(), parameters3); //带事务
                            }
                        }
                        #endregion

                        #region 添加内容附件====================
                        if (model.Attach != null)
                        {
                            StringBuilder strSql4;
                            foreach (Model.ArticleAttach modelt in model.Attach)
                            {
                                strSql4 = new StringBuilder();
                                strSql4.Append("insert into ArticleAttach(");
                                strSql4.Append("ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point)");
                                strSql4.Append(" values (");
                                strSql4.Append("@ArticleID,@FileName,@FilePath,@FileSize,@FileExt,@DownNum,@Point)");
                                SqlParameter[] parameters4 = {
					                    new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                    new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					                    new SqlParameter("@FilePath", SqlDbType.NVarChar,255),
					                    new SqlParameter("@FileSize", SqlDbType.Int,4),
					                    new SqlParameter("@FileExt", SqlDbType.NVarChar,20),
					                    new SqlParameter("@DownNum", SqlDbType.Int,4),
					                    new SqlParameter("@Point", SqlDbType.Int,4)};
                                parameters4[0].Value = model.ID;
                                parameters4[1].Value = modelt.FileName;
                                parameters4[2].Value = modelt.FilePath;
                                parameters4[3].Value = modelt.FileSize;
                                parameters4[4].Value = modelt.FileExt;
                                parameters4[5].Value = modelt.DownNum;
                                parameters4[6].Value = modelt.Point;
                                DbHelperSQL.GetSingle(conn, trans, strSql4.ToString(), parameters4); //带事务
                            }
                        }
                        #endregion

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }

        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HN863Soft.ISS.Model.Article model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 修改主表数据

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update Article set ");
                        strSql.Append("ChannelID=@ChannelID,");
                        strSql.Append("CategoryID=@CategoryID,");
                        strSql.Append("CallIndex=@CallIndex,");
                        strSql.Append("Title=@Title,");
                        strSql.Append("LinkURL=@LinkURL,");
                        strSql.Append("ImgURL=@ImgURL,");
                        strSql.Append("SEOTitle=@SEOTitle,");
                        strSql.Append("SEOKeywords=@SEOKeywords,");
                        strSql.Append("SEODescription=@SEODescription,");
                        strSql.Append("Tags=@Tags,");
                        strSql.Append("Digest=@Digest,");
                        strSql.Append("ArticleContent=@ArticleContent,");
                        strSql.Append("SortID=@SortID,");
                        strSql.Append("ClickNum=@ClickNum,");
                        strSql.Append("Status=@Status,");
                        strSql.Append("FlagComment=@FlagComment,");
                        strSql.Append("FlagTop=@FlagTop,");
                        strSql.Append("FlagRecommend=@FlagRecommend,");
                        strSql.Append("FlagHot=@FlagHot,");
                        strSql.Append("FlagSlide=@FlagSlide,");
                        strSql.Append("FlagAdmin=@FlagAdmin,");
                        strSql.Append("UserName=@UserName,");
                        strSql.Append("CreateTime=@CreateTime,");
                        strSql.Append("UpdateTime=@UpdateTime");
                        strSql.Append(" where ID=@ID");
                        SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,255),
					new SqlParameter("@ImgURL", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@SEOKeywords", SqlDbType.NVarChar,255),
					new SqlParameter("@SEODescription", SqlDbType.NVarChar,255),
					new SqlParameter("@Tags", SqlDbType.NVarChar,500),
					new SqlParameter("@Digest", SqlDbType.NVarChar,255),
					new SqlParameter("@ArticleContent", SqlDbType.NText),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagComment", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagTop", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagRecommend", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagHot", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagSlide", SqlDbType.TinyInt,1),
					new SqlParameter("@FlagAdmin", SqlDbType.TinyInt,1),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
                        parameters[0].Value = model.ChannelID;
                        parameters[1].Value = model.CategoryID;
                        parameters[2].Value = model.CallIndex;
                        parameters[3].Value = model.Title;
                        parameters[4].Value = model.LinkURL;
                        parameters[5].Value = model.ImgURL;
                        parameters[6].Value = model.SEOTitle;
                        parameters[7].Value = model.SEOKeywords;
                        parameters[8].Value = model.SEODescription;
                        parameters[9].Value = model.Tags;
                        parameters[10].Value = model.Digest;
                        parameters[11].Value = model.ArticleContent;
                        parameters[12].Value = model.SortID;
                        parameters[13].Value = model.ClickNum;
                        parameters[14].Value = model.Status;
                        parameters[15].Value = model.FlagComment;
                        parameters[16].Value = model.FlagTop;
                        parameters[17].Value = model.FlagRecommend;
                        parameters[18].Value = model.FlagHot;
                        parameters[19].Value = model.FlagSlide;
                        parameters[20].Value = model.FlagAdmin;
                        parameters[21].Value = model.UserName;
                        parameters[22].Value = model.CreateTime;
                        parameters[23].Value = model.UpdateTime;
                        parameters[24].Value = model.ID;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        #endregion

                        #region 修改扩展字段
                         
                        if (model.Fields.Count > 0)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            StringBuilder strFieldName = new StringBuilder(); //字段列表
                            SqlParameter[] parameters2 = new SqlParameter[model.Fields.Count + 1];
                            int i = 0;
                            foreach (KeyValuePair<string, string> kvp in model.Fields)
                            {
                                strFieldName.Append(kvp.Key + "=@" + kvp.Key + ",");
                                if (kvp.Value.Length <= 4000)
                                {
                                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NVarChar, kvp.Value.Length);
                                }
                                else
                                {
                                    parameters2[i] = new SqlParameter("@" + kvp.Key, SqlDbType.NText);
                                }
                                parameters2[i].Value = kvp.Value;
                                i++;
                            }
                            strSql2.Append("update ArticleAttributeValue set ");
                            strSql2.Append(Utils.DelLastComma(strFieldName.ToString()));
                            strSql2.Append(" where ArticleID=@ArticleID");
                            parameters2[i] = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
                            parameters2[i].Value = model.ID;
                            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                        }
                        #endregion

                        #region 修改图片相册
                        //删除已删除的图片
                        new ArticleAlbum().DeleteList(conn, trans, model.Albums, model.ID);
                        //添加/修改相册
                        if (model.Albums != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.ArticleAlbum modelt in model.Albums)
                            {
                                strSql3 = new StringBuilder();
                                if (modelt.ID > 0)
                                {
                                    strSql3.Append("update ArticleAlbum set ");
                                    strSql3.Append("ArticleID=@ArticleID,");
                                    strSql3.Append("ThumbPath=@ThumbPath,");
                                    strSql3.Append("OriginalPath=@OriginalPath,");
                                    strSql3.Append("Remark=@Remark");
                                    strSql3.Append(" where ID=@ID");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                        new SqlParameter("@ThumbPath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@OriginalPath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                                            new SqlParameter("@ID", SqlDbType.Int,4)};
                                    parameters3[0].Value = modelt.ArticleID;
                                    parameters3[1].Value = modelt.ThumbPath;
                                    parameters3[2].Value = modelt.OriginalPath;
                                    parameters3[3].Value = modelt.Remark;
                                    parameters3[4].Value = modelt.ID;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                                else
                                {
                                    strSql3.Append("insert into ArticleAlbum(");
                                    strSql3.Append("ArticleID,ThumbPath,OriginalPath,Remark)");
                                    strSql3.Append(" values (");
                                    strSql3.Append("@ArticleID,@ThumbPath,@OriginalPath,@Remark)");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                        new SqlParameter("@ThumbPath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@OriginalPath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
                                    parameters3[0].Value = modelt.ArticleID;
                                    parameters3[1].Value = modelt.ThumbPath;
                                    parameters3[2].Value = modelt.OriginalPath;
                                    parameters3[3].Value = modelt.Remark;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                            }
                        }
                        #endregion

                        #region 修改内容附件
                        //删除已删除的附件
                        new ArticleAttach().DeleteList(conn, trans, model.Attach, model.ID);
                        // 添加/修改附件
                        if (model.Attach != null)
                        {
                            StringBuilder strSql4;
                            foreach (Model.ArticleAttach modelt in model.Attach)
                            {
                                strSql4 = new StringBuilder();
                                if (modelt.ID > 0)
                                {
                                    strSql4.Append("update ArticleAttach set ");
                                    strSql4.Append("ArticleID=@ArticleID,");
                                    strSql4.Append("FileName=@FileName,");
                                    strSql4.Append("FilePath=@FilePath,");
                                    strSql4.Append("FileSize=@FileSize,");
                                    strSql4.Append("FileExt=@FileExt,");
                                    strSql4.Append("Point=@Point");
                                    strSql4.Append(" where ID=@ID");
                                    SqlParameter[] parameters4 = {
					                        new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                        new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@FilePath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@FileSize", SqlDbType.Int,4),
					                        new SqlParameter("@FileExt", SqlDbType.NVarChar,20),
					                        new SqlParameter("@Point", SqlDbType.Int,4),
					                        new SqlParameter("@ID", SqlDbType.Int,4)};
                                    parameters4[0].Value = modelt.ArticleID;
                                    parameters4[1].Value = modelt.FileName;
                                    parameters4[2].Value = modelt.FilePath;
                                    parameters4[3].Value = modelt.FileSize;
                                    parameters4[4].Value = modelt.FileExt;
                                    parameters4[5].Value = modelt.Point;
                                    parameters4[6].Value = modelt.ID;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql4.ToString(), parameters4);
                                }
                                else
                                {
                                    strSql4.Append("insert into ArticleAttach(");
                                    strSql4.Append("ArticleID,FileName,FilePath,FileSize,FileExt,DownNum,Point)");
                                    strSql4.Append(" values (");
                                    strSql4.Append("@ArticleID,@FileName,@FilePath,@FileSize,@FileExt,@DownNum,@Point)");
                                    SqlParameter[] parameters4 = {
					                        new SqlParameter("@ArticleID", SqlDbType.Int,4),
					                        new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@FilePath", SqlDbType.NVarChar,255),
					                        new SqlParameter("@FileSize", SqlDbType.Int,4),
					                        new SqlParameter("@FileExt", SqlDbType.NVarChar,20),
					                        new SqlParameter("@DownNum", SqlDbType.Int,4),
					                        new SqlParameter("@Point", SqlDbType.Int,4)};
                                    parameters4[0].Value = modelt.ArticleID;
                                    parameters4[1].Value = modelt.FileName;
                                    parameters4[2].Value = modelt.FilePath;
                                    parameters4[3].Value = modelt.FileSize;
                                    parameters4[4].Value = modelt.FileExt;
                                    parameters4[5].Value = modelt.DownNum;
                                    parameters4[6].Value = modelt.Point;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql4.ToString(), parameters4);
                                }
                            }
                        }
                        #endregion

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
            //取得相册MODEL
            List<Model.ArticleAlbum> albumsList = new DAL.ArticleAlbum().GetList(id);
            //取得附件MODEL
            List<Model.ArticleAttach> attachList = new DAL.ArticleAttach().GetList(id);

            //删除扩展字段表
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from ArticleAttributeValue ");
            strSql1.Append(" where ArticleID=@ArticleID ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除图片相册
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from ArticleBlbum ");
            strSql2.Append(" where ArticleID=@ArticleID ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //删除附件
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from ArticleAttach ");
            strSql3.Append(" where ArticleID=@ArticleID ");
            SqlParameter[] parameters3 = {
                    new SqlParameter("@ArticleID", SqlDbType.Int,4)};
            parameters3[0].Value = id;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //删除评论
            StringBuilder strSql8 = new StringBuilder();
            strSql8.Append("delete from ArticleComment ");
            strSql8.Append(" where ArticleID=@ArticleID ");
            SqlParameter[] parameters8 = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4)};
            parameters8[0].Value = id;
            cmd = new CommandInfo(strSql8.ToString(), parameters8);
            sqllist.Add(cmd);

            //删除主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Article ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                new DAL.ArticleAlbum().DeleteFile(albumsList); //删除图片
                new DAL.ArticleAttach().DeleteFile(attachList); //删除附件
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
			strSql.Append("delete from Article ");
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
		public HN863Soft.ISS.Model.Article GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ChannelID,CategoryID,CallIndex,Title,LinkURL,ImgURL,SEOTitle,SEOKeywords,SEODescription,Tags,Digest,ArticleContent,SortID,ClickNum,Status,FlagComment,FlagTop,FlagRecommend,FlagHot,FlagSlide,FlagAdmin,UserName,CreateTime,UpdateTime from Article ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			HN863Soft.ISS.Model.Article model=new HN863Soft.ISS.Model.Article();
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
        public Model.Article GetModel(string callIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from Article");
            strSql.Append(" where CallIndex=@CallIndex");
            SqlParameter[] parameters = {
					new SqlParameter("@CallIndex", SqlDbType.NVarChar,50)};
            parameters[0].Value = callIndex;

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
		public HN863Soft.ISS.Model.Article DataRowToModel(DataRow row)
		{
			HN863Soft.ISS.Model.Article model=new HN863Soft.ISS.Model.Article();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ChannelID"]!=null && row["ChannelID"].ToString()!="")
				{
					model.ChannelID=int.Parse(row["ChannelID"].ToString());
				}
				if(row["CategoryID"]!=null && row["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(row["CategoryID"].ToString());
				}
				if(row["CallIndex"]!=null)
				{
					model.CallIndex=row["CallIndex"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["LinkURL"]!=null)
				{
					model.LinkURL=row["LinkURL"].ToString();
				}
				if(row["ImgURL"]!=null)
				{
					model.ImgURL=row["ImgURL"].ToString();
				}
				if(row["SEOTitle"]!=null)
				{
					model.SEOTitle=row["SEOTitle"].ToString();
				}
				if(row["SEOKeywords"]!=null)
				{
					model.SEOKeywords=row["SEOKeywords"].ToString();
				}
				if(row["SEODescription"]!=null)
				{
					model.SEODescription=row["SEODescription"].ToString();
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
				}
				if(row["Digest"]!=null)
				{
					model.Digest=row["Digest"].ToString();
				}
				if(row["ArticleContent"]!=null)
				{
					model.ArticleContent=row["ArticleContent"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["ClickNum"]!=null && row["ClickNum"].ToString()!="")
				{
					model.ClickNum=int.Parse(row["ClickNum"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["FlagComment"]!=null && row["FlagComment"].ToString()!="")
				{
					model.FlagComment=int.Parse(row["FlagComment"].ToString());
				}
				if(row["FlagTop"]!=null && row["FlagTop"].ToString()!="")
				{
					model.FlagTop=int.Parse(row["FlagTop"].ToString());
				}
				if(row["FlagRecommend"]!=null && row["FlagRecommend"].ToString()!="")
				{
					model.FlagRecommend=int.Parse(row["FlagRecommend"].ToString());
				}
				if(row["FlagHot"]!=null && row["FlagHot"].ToString()!="")
				{
					model.FlagHot=int.Parse(row["FlagHot"].ToString());
				}
				if(row["FlagSlide"]!=null && row["FlagSlide"].ToString()!="")
				{
					model.FlagSlide=int.Parse(row["FlagSlide"].ToString());
				}
				if(row["FlagAdmin"]!=null && row["FlagAdmin"].ToString()!="")
				{
					model.FlagAdmin=int.Parse(row["FlagAdmin"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}

                //扩展字段信息
                model.Fields = new ArticleAttributeField().GetFields(model.ChannelID, model.ID, string.Empty);
                //相册信息
                model.Albums = new ArticleAlbum().GetList(model.ID);
                //附件信息
                model.Attach = new ArticleAttach().GetList(model.ID);
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ChannelID,CategoryID,CallIndex,Title,LinkURL,ImgURL,SEOTitle,SEOKeywords,SEODescription,Tags,Digest,ArticleContent,SortID,ClickNum,Status,FlagComment,FlagTop,FlagRecommend,FlagHot,FlagSlide,FlagAdmin,UserName,CreateTime,UpdateTime ");
			strSql.Append(" FROM Article ");
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
			strSql.Append(" ID,ChannelID,CategoryID,CallIndex,Title,LinkURL,ImgURL,SEOTitle,SEOKeywords,SEODescription,Tags,Digest,ArticleContent,SortID,ClickNum,Status,FlagComment,FlagTop,FlagRecommend,FlagHot,FlagSlide,FlagAdmin,UserName,CreateTime,UpdateTime ");
			strSql.Append(" FROM Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据视图显示前几条数据
        /// </summary>
        public DataSet GetList(string channelName, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * FROM ViewChannel" + channelName);
            strSql.Append(" where datediff(d,CreateTime,getdate())>=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int channelID, int categoryID, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Article");
            if (channelID > 0)
            {
                strSql.Append(" where ChannelID=" + channelID);
            }
            if (categoryID > 0)
            {
                if (channelID > 0)
                {
                    strSql.Append(" and CategoryID in(select ID from ArticleCategory where ClassList like '%," + categoryID + ",%')");
                }
                else
                {
                    strSql.Append(" where CategoryID in(select ID from ArticleCategory where ClassList like '%," + categoryID + ",%')");
                }
            }
            if (strWhere.Trim() != "")
            {
                if (channelID > 0 || categoryID > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 根据视图显示前几条数据
        /// </summary>
        public DataSet GetList(string channelName, int categoryID, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * FROM ViewChannel" + channelName);
            strSql.Append(" where datediff(d,CreateTime,getdate())>=0");
            if (categoryID > 0)
            {
                strSql.Append(" and CategoryID in(select ID from ArticleCategory where ClassList like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据视图获得查询分页数据
        /// </summary>
        public DataSet GetList(string channelName, int categoryID, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM ViewChannel" + channelName);
            strSql.Append(" where datediff(d,CreateTime,getdate())>=0");
            if (categoryID > 0)
            {
                strSql.Append(" and CategoryID in(select ID from ArticleCategory where ClassList like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得关健字查询分页数据(搜索用到)
        /// </summary>
        public DataSet GetSearch(string channelName, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ChannelID,CallIndex,Title,CreateTime,ImgUrl from Article");
            strSql.Append(" where ID>0");
            if (!string.IsNullOrEmpty(channelName))
            {
                strSql.Append(" and ChannelID=(select ID from Channel where [Name]='" + channelName + "')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from Article");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 根据视图获取总记录数
        /// </summary>
        public int GetCount(string channelName, int categoryID, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" count(1) FROM ViewChannel" + channelName);
            strSql.Append(" where datediff(d,CreateTime,getdate())>=0");
            if (categoryID > 0)
            {
                strSql.Append(" and CategoryID in(select ID from ArticleCategory where ClassList like '%," + categoryID + ",%')");
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Article ");
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
			strSql.Append(")AS Row, T.*  from Article T ");
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
			parameters[0].Value = "Article";
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

