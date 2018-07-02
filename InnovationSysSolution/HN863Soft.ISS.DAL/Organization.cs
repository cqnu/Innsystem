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
    /// 数据访问类:Organization
    /// </summary>
    public partial class Organization
    {
        public Organization() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Organization");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organization");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string orgName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Organization");
            strSql.Append(" where OrgName=@OrgName");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgName", SqlDbType.Int,4)
			};
            parameters[0].Value = orgName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Organization(");//Lng,Lat

            strSql.Append("UserID,OrgName,OrgLocation,OrgIntro,Proposer,ProposerMobile,ProposerCard,ProposerEmail,WeiXin,OrgType,Evidence,OrgExhibit,State,CreateTime,Remark,RegionId,Introduce,LogImg,Lng,Lat,VideoUrl,Weburl,IdCadrUrlZ,IdCadrUrlF )");
            strSql.Append(" values (");
            strSql.Append("@UserID,@OrgName,@OrgLocation,@OrgIntro,@Proposer,@ProposerMobile,@ProposerCard,@ProposerEmail,@WeiXin,@OrgType,@Evidence,@OrgExhibit,@State,@CreateTime,@Remark,@RegionId,@Introduce,@LogImg,@Lng,@Lat,@VideoUrl,@Weburl,@IdCadrUrlZ,@IdCadrUrlF )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@OrgName", SqlDbType.NVarChar,100),
					new SqlParameter("@OrgLocation", SqlDbType.NVarChar,200),
					new SqlParameter("@OrgIntro", SqlDbType.Text),
					new SqlParameter("@Proposer", SqlDbType.NVarChar,50),
					new SqlParameter("@ProposerMobile", SqlDbType.VarChar,30),
					new SqlParameter("@ProposerCard", SqlDbType.VarChar,30),
					new SqlParameter("@ProposerEmail", SqlDbType.VarChar,30),
					new SqlParameter("@WeiXin", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgType", SqlDbType.Int,4),
					new SqlParameter("@Evidence", SqlDbType.Text),
					new SqlParameter("@OrgExhibit", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@RegionId",SqlDbType.Int,4),
                    new SqlParameter("@Introduce",SqlDbType.NVarChar,100),
                    new SqlParameter("@LogImg",SqlDbType.NVarChar,500),
                    new SqlParameter("@Lng",SqlDbType.NVarChar,20),
                    new SqlParameter("@Lat",SqlDbType.NVarChar,20),
                    new SqlParameter("@VideoUrl",SqlDbType.NVarChar,200),
                    new SqlParameter("@Weburl",SqlDbType.NVarChar,500),
                    new SqlParameter("@IdCadrUrlZ",SqlDbType.NVarChar,500),
                    new SqlParameter("@IdCadrUrlF",SqlDbType.NVarChar,500)
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrgName;
            parameters[2].Value = model.OrgLocation;
            parameters[3].Value = model.OrgIntro;
            parameters[4].Value = model.Proposer;
            parameters[5].Value = model.ProposerMobile;
            parameters[6].Value = model.ProposerCard;
            parameters[7].Value = model.ProposerEmail;
            parameters[8].Value = model.WeiXin;
            parameters[9].Value = model.OrgType;
            parameters[10].Value = model.Evidence;
            parameters[11].Value = model.OrgExhibit;
            parameters[12].Value = 1;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.RegionId;
            parameters[16].Value = model.Introduce;
            parameters[17].Value = model.LogImg;
            parameters[18].Value = model.Lng;
            parameters[19].Value = model.Lat;
            parameters[20].Value = model.VideoUrl;
            parameters[21].Value = model.Weburl;
            parameters[22].Value = model.IdCadrUrlZ;
            parameters[23].Value = model.IdCadrUrlF;
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
        public bool Update(HN863Soft.ISS.Model.Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Organization set ");
            strSql.Append("OrgName=@OrgName,");
            strSql.Append("OrgLocation=@OrgLocation,");
            strSql.Append("OrgIntro=@OrgIntro,");
            strSql.Append("Proposer=@Proposer,");
            strSql.Append("ProposerMobile=@ProposerMobile,");
            strSql.Append("ProposerCard=@ProposerCard,");
            strSql.Append("ProposerEmail=@ProposerEmail,");
            strSql.Append("WeiXin=@WeiXin,");
            strSql.Append("OrgType=@OrgType,");
            strSql.Append("Evidence=@Evidence,");
            strSql.Append("OrgExhibit=@OrgExhibit,");
            strSql.Append("State=@State,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("RegionId=@RegionId,");
            strSql.Append("Introduce=@Introduce,");
            strSql.Append("LogImg=@LogImg,");
            strSql.Append(" Lng=@Lng, ");
            strSql.Append("Lat=@Lat,");
            strSql.Append("VideoUrl=@VideoUrl,");
            strSql.Append("Weburl=@Weburl, ");
            strSql.Append("IdCadrUrlZ=@IdCadrUrlZ, ");
            strSql.Append("IdCadrUrlF=@IdCadrUrlF ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrgName", SqlDbType.NVarChar,100),
					new SqlParameter("@OrgLocation", SqlDbType.NVarChar,200),
					new SqlParameter("@OrgIntro", SqlDbType.Text),
					new SqlParameter("@Proposer", SqlDbType.NVarChar,50),
					new SqlParameter("@ProposerMobile", SqlDbType.VarChar,30),
					new SqlParameter("@ProposerCard", SqlDbType.VarChar,30),
					new SqlParameter("@ProposerEmail", SqlDbType.VarChar,30),
					new SqlParameter("@WeiXin", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgType", SqlDbType.Int,4),
					new SqlParameter("@Evidence", SqlDbType.Text),
					new SqlParameter("@OrgExhibit", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@RegionId",SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Introduce",SqlDbType.NVarChar,100),
                    new SqlParameter("@LogImg",SqlDbType.NVarChar,500),
                    new SqlParameter("@Lng",SqlDbType.NVarChar,20),
                    new SqlParameter("@Lat",SqlDbType.NVarChar,20),
                    new SqlParameter("@VideoUrl",SqlDbType.NVarChar,200),
                    new SqlParameter("@Weburl",SqlDbType.NVarChar,500),
                    new SqlParameter("@IdCadrUrlZ",SqlDbType.NVarChar,500),
                    new SqlParameter("@IdCadrUrlF",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.OrgName;
            parameters[1].Value = model.OrgLocation;
            parameters[2].Value = model.OrgIntro;
            parameters[3].Value = model.Proposer;
            parameters[4].Value = model.ProposerMobile;
            parameters[5].Value = model.ProposerCard;
            parameters[6].Value = model.ProposerEmail;
            parameters[7].Value = model.WeiXin;
            parameters[8].Value = model.OrgType;
            parameters[9].Value = model.Evidence;
            parameters[10].Value = model.OrgExhibit;
            parameters[11].Value = model.State;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.RegionId;
            parameters[15].Value = model.ID;
            parameters[16].Value = model.Introduce;
            parameters[17].Value = model.LogImg;
            parameters[18].Value = model.Lng;
            parameters[19].Value = model.Lat;
            parameters[20].Value = model.VideoUrl;
            parameters[21].Value = model.Weburl;
            parameters[22].Value = model.IdCadrUrlZ;
            parameters[23].Value = model.IdCadrUrlF;
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
        /// 审核机构认证信息及管理账户认证状态
        /// </summary>
        /// <param name="id">机构信息ID</param>
        /// <param name="state">审核状态</param>
        /// <param name="reason">原因</param>
        /// <returns></returns>
        public bool UpdateState(int id, int userID, int state, int orgType)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
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

                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        //修改管理账户认证状态
                        new DAL.Manager().UpdateIsUseable(userID, state == 3 ? 1 : 0, orgType);

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Organization ");
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
            strSql.Append("delete from Organization ");
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
        public HN863Soft.ISS.Model.Organization GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,OrgName,OrgLocation,OrgIntro,Proposer,ProposerMobile,ProposerCard,ProposerEmail,WeiXin,OrgType,Evidence,OrgExhibit,State,CreateTime,Remark,RegionId,Introduce,LogImg,Lng,Lat,VideoUrl,Weburl,IdCadrUrlZ,IdCadrUrlF from Organization ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            HN863Soft.ISS.Model.Organization model = new HN863Soft.ISS.Model.Organization();
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
        public HN863Soft.ISS.Model.Organization GetModelByUserID(int userID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,OrgName,OrgLocation,OrgIntro,Proposer,ProposerMobile,ProposerCard,ProposerEmail,WeiXin,OrgType,Evidence,OrgExhibit,State,CreateTime,Remark,RegionId,Introduce,LogImg,Lng,Lat,VideoUrl,Weburl  from Organization ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userID;

            HN863Soft.ISS.Model.Organization model = new HN863Soft.ISS.Model.Organization();
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
        public HN863Soft.ISS.Model.Organization DataRowToModel(DataRow row)
        {
            HN863Soft.ISS.Model.Organization model = new HN863Soft.ISS.Model.Organization();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["OrgName"] != null)
                {
                    model.OrgName = row["OrgName"].ToString();
                }
                if (row["OrgLocation"] != null)
                {
                    model.OrgLocation = row["OrgLocation"].ToString();
                }
                if (row["OrgIntro"] != null)
                {
                    model.OrgIntro = row["OrgIntro"].ToString();
                }
                if (row["Proposer"] != null)
                {
                    model.Proposer = row["Proposer"].ToString();
                }
                if (row["ProposerMobile"] != null)
                {
                    model.ProposerMobile = row["ProposerMobile"].ToString();
                }
                if (row["ProposerCard"] != null)
                {
                    model.ProposerCard = row["ProposerCard"].ToString();
                }
                if (row["ProposerEmail"] != null)
                {
                    model.ProposerEmail = row["ProposerEmail"].ToString();
                }
                if (row["WeiXin"] != null)
                {
                    model.WeiXin = row["WeiXin"].ToString();
                }
                if (row["OrgType"] != null && row["OrgType"].ToString() != "")
                {
                    model.OrgType = int.Parse(row["OrgType"].ToString());
                }
                if (row["Evidence"] != null)
                {
                    model.Evidence = row["Evidence"].ToString();
                }
                if (row["OrgExhibit"] != null)
                {
                    model.OrgExhibit = row["OrgExhibit"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                //RegionId
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                //,Introduce,LogImg
                if (row["Introduce"] != null)
                {
                    model.Introduce = row["Introduce"].ToString();
                }
                if (row["LogImg"] != null)
                {
                    model.LogImg = row["LogImg"].ToString();
                }

                if (row.Table.Columns.Contains("IdCadrUrlZ"))
                {
                    //存在
                    if (row["IdCadrUrlZ"] != null)
                    {
                        model.IdCadrUrlZ = row["IdCadrUrlZ"].ToString();
                    }
                }

                if (row.Table.Columns.Contains("IdCadrUrlF"))
                {

                    if (row["IdCadrUrlF"] != null)
                    {
                        model.IdCadrUrlF = row["IdCadrUrlF"].ToString();
                    }
                }
                //,Lng,Lat 经度纬度
                if (row["Lng"] != null)
                {
                    model.Lng = row["Lng"].ToString();
                }
                if (row["Lat"] != null)
                {
                    model.Lat = row["Lat"].ToString();
                }
                //VideoUrl
                if (row["VideoUrl"] != null)
                {
                    model.VideoUrl = row["VideoUrl"].ToString();
                }
                if (row["Weburl"] != null)
                {
                    model.Weburl = row["Weburl"].ToString();
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
            strSql.Append("select ID,UserID,OrgName,OrgLocation,OrgIntro,Proposer,ProposerMobile,ProposerCard,ProposerEmail,WeiXin,OrgType,Evidence,OrgExhibit,State,CreateTime,Remark,RegionId,Introduce,LogImg,Lng,Lat,VideoUrl ");
            strSql.Append(" FROM Organization ");
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
            strSql.Append(" ID,UserID,OrgName,OrgLocation,OrgIntro,Proposer,ProposerMobile,ProposerCard,ProposerEmail,WeiXin,OrgType,Evidence,OrgExhibit,State,CreateTime,Remark,RegionId,Introduce,LogImg,Lng,Lat,VideoUrl ");
            strSql.Append(" FROM Organization ");
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
            strSql.Append("select a.*,ROW_NUMBER() over(order by a.Id desc) rowIndex,u.UserName  FROM Organization a");
            strSql.Append(" left join Manager u  on a.UserID=u.id   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
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
            strSql.Append("select count(1) FROM Organization ");
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
            strSql.Append(")AS Row, T.*  from Organization T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得已经入孵的省份
        /// </summary>
        public DataSet GetProvice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct(p.Name),p.ProvinceID");
            strSql.Append("   FROM Organization o left join City c on c.CityId=o.RegionId ");
            strSql.Append(" left join Province p on c.ProvinceID=p.ProvinceID ");
            strSql.Append(" where o.OrgType=12 and o.State=3 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得已经入孵的省份入驻地的城市
        /// </summary>
        public DataSet GetCity(string strPro)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct(c.CityId),c.Name");
            strSql.Append("   FROM Organization o left join City c on c.CityId=o.RegionId ");
            strSql.Append(" left join Province p on c.ProvinceID=p.ProvinceID ");
            if (!string.IsNullOrEmpty(strPro))
            {
                strSql.Append(" where p.ProvinceID= " + strPro);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetHList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select p.ProvinceID,c.Name,o.* ");
            strSql.Append(" FROM Organization o left join City c on c.CityId=o.RegionId ");
            strSql.Append(" left join Province p on c.ProvinceID=p.ProvinceID  ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        #endregion  ExtensionMethod
    }
}
