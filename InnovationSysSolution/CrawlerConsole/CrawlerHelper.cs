using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerConsole
{
    public class CrawlerHelper
    {
        /// <summary>
        /// 采集日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 页面链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 页面正文
        /// </summary>
        public string Content { get; set; }

        public string Source { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Date, Url, Title,
                Content.Replace(" ", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(List<CrawlerHelper> listPage)
        {
            object obj = new object();
            try
            {
                List<String> SQLStringList = new List<string>();
                for (int i = 0; i < listPage.Count; i++)
                {
                    if (listPage[i] == null)
                        continue;
                    byte[] strInfo = Encoding.UTF8.GetBytes(listPage[i].Content);
                    string msg = Encoding.UTF8.GetString(strInfo, 0, strInfo.Length);

                    StringBuilder strSql = new StringBuilder();

                    strSql.Append("insert into CrawlerInfo(");
                    strSql.Append("Title,CrawContent,Url,CrawDate,Source,State)");
                    strSql.Append(" values (");
                    strSql.Append("@Title,@CrawContent,@Url,@CrawDate,@Source,@State)");

                    SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,255),
					new SqlParameter("@CrawContent", SqlDbType.NText),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@CrawDate", SqlDbType.DateTime),
                    new SqlParameter("@Source",SqlDbType.VarChar,255),
                    new SqlParameter("@State",SqlDbType.Int,4)
                                            };
                    parameters[0].Value = listPage[i].Title;
                    parameters[1].Value = listPage[i].Content;
                    parameters[2].Value = listPage[i].Url;
                    parameters[3].Value = listPage[i].Date;
                    parameters[4].Value = listPage[i].Source;
                    parameters[5].Value = 0;

                    DataTable dt = new DataTable();
                    dt = GetDataUrl(listPage[i].Url);

                    if (dt.Rows.Count == 0)
                    {
                        obj = DbHelper.ExecuteSql(strSql.ToString(), parameters);
                    }
                }
            }
            catch (Exception)
            {
                obj = null;
            }

            if (obj == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public DataTable GetData(int KeyType)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select * ");
                sb.Append(" from CrawlerKeys ");
                sb.Append(" where KeyType= @KeyType ");
                SqlParameter[] param ={
                                     new SqlParameter("@KeyType",SqlDbType.Int) };

                param[0].Value = KeyType;

                DataSet ds = DbHelper.Query(sb.ToString(), param);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public DataTable GetDataUrl(string url)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select * ");
                sb.Append(" from CrawlerInfo ");
                sb.Append(" where ");
                SqlParameter[] param ={
                                     new SqlParameter("@Url",SqlDbType.NVarChar,255) };
                if (url != null)
                {
                    sb.Append(" Url= @Url");
                    param[0].Value = url;
                }

                return DbHelper.Query(sb.ToString(), param).Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
