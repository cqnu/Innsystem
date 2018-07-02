using HN863Soft.ISS.Common;
using HN863Soft.ISS.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.DAL
{
    public class PolicyDal
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ROW_NUMBER() OVER (ORDER BY a.CrawDate desc) AS rowid, a.* from CrawlerInfo a ");

            strSql.Append(" where 1=1   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            if (recordCount == 0)
            {
                recordCount = 1;
            }

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), " a.CrawDate desc"));
        }


        public DataTable GetInfo(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from  CrawlerInfo where id=   " + id);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
