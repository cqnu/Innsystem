using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace HN863Soft.ISS.Common
{
    public class CommonHelper
    {
        public static string GetGuid
        {
            get
            {
                return Guid.NewGuid().ToString().ToLower();
            }
        }

        public static int GetInt(object obj)
        {
            int result;
            if (obj != null)
            {
                int i;
                int.TryParse(obj.ToString(), out i);
                result = i;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static float GetFloat(object obj)
        {
            float i;
            float.TryParse(obj.ToString(), out i);
            return i;
        }

        public static int GetInt(object obj, int exceptionvalue)
        {
            int result;
            if (obj == null)
            {
                result = exceptionvalue;
            }
            else
            {
                if (string.IsNullOrEmpty(obj.ToString()))
                {
                    result = exceptionvalue;
                }
                else
                {
                    int i = exceptionvalue;
                    try
                    {
                        i = Convert.ToInt32(obj);
                    }
                    catch
                    {
                        i = exceptionvalue;
                    }
                    result = i;
                }
            }
            return result;
        }

        public static byte Getbyte(object obj)
        {
            byte result;
            if (obj.ToString() != "")
            {
                result = byte.Parse(obj.ToString());
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static long GetLong(object obj)
        {
            long result;
            if (obj.ToString() != "")
            {
                result = long.Parse(obj.ToString());
            }
            else
            {
                result = 0L;
            }
            return result;
        }

        public static long GetLong(object obj, long exceptionvalue)
        {
            long result;
            if (obj == null)
            {
                result = exceptionvalue;
            }
            else
            {
                if (string.IsNullOrEmpty(obj.ToString()))
                {
                    result = exceptionvalue;
                }
                else
                {
                    long i = exceptionvalue;
                    try
                    {
                        i = Convert.ToInt64(obj);
                    }
                    catch
                    {
                        i = exceptionvalue;
                    }
                    result = i;
                }
            }
            return result;
        }

        public static decimal GetDecimal(object obj)
        {
            decimal result;
            if (obj.ToString() != "")
            {
                result = decimal.Parse(obj.ToString());
            }
            else
            {
                result = 0m;
            }
            return result;
        }

        public static DateTime GetDateTime(object obj)
        {
            DateTime result;
            if (obj.ToString() != "")
            {
                result = DateTime.Parse(obj.ToString());
            }
            else
            {
                result = DateTime.Now;
            }
            return result;
        }

        public static string GetFormatDateTime(object obj, string Format)
        {
            string result;
            if (obj.ToString() != "")
            {
                result = DateTime.Parse(obj.ToString()).ToString(Format);
            }
            else
            {
                result = "";
            }
            return result;
        }

        public static bool GetBool(object obj)
        {
            bool result;
            if (obj != null)
            {
                bool flag;
                bool.TryParse(obj.ToString(), out flag);
                result = flag;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static byte[] GetByte(object obj)
        {
            byte[] result;
            if (obj.ToString() != "")
            {
                result = (byte[])obj;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static string GetString(object obj)
        {
            string result;
            if (obj != null && obj != DBNull.Value)
            {
                result = obj.ToString();
            }
            else
            {
                result = "";
            }
            return result;
        }

        public static bool IsDateTime(string strValue)
        {
            bool result;
            if (strValue == null || strValue == "")
            {
                result = false;
            }
            else
            {
                string regexDate = "[1-2]{1}[0-9]{3}((-|[.]){1}(([0]?[1-9]{1})|(1[0-2]{1}))((-|[.]){1}((([0]?[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1})))( (([0-1]{1}[0-9]{1})|2[0-3]{1}):([0-5]{1}[0-9]{1}):([0-5]{1}[0-9]{1})(\\.[0-9]{3})?)?)?)?$";
                if (Regex.IsMatch(strValue, regexDate))
                {
                    int _IndexY;
                    int _IndexM;
                    int _IndexD;
                    if (-1 != (_IndexY = strValue.IndexOf("-")))
                    {
                        _IndexM = strValue.IndexOf("-", _IndexY + 1);
                        _IndexD = strValue.IndexOf(":");
                    }
                    else
                    {
                        _IndexY = strValue.IndexOf(".");
                        _IndexM = strValue.IndexOf(".", _IndexY + 1);
                        _IndexD = strValue.IndexOf(":");
                    }
                    if (-1 == _IndexM)
                    {
                        result = true;
                        return result;
                    }
                    if (-1 == _IndexD)
                    {
                        _IndexD = strValue.Length + 3;
                    }
                    int iYear = Convert.ToInt32(strValue.Substring(0, _IndexY));
                    int iMonth = Convert.ToInt32(strValue.Substring(_IndexY + 1, _IndexM - _IndexY - 1));
                    int iDate = Convert.ToInt32(strValue.Substring(_IndexM + 1, _IndexD - _IndexM - 4));
                    if ((iMonth < 8 && 1 == iMonth % 2) || (iMonth > 8 && 0 == iMonth % 2))
                    {
                        if (iDate < 32)
                        {
                            result = true;
                            return result;
                        }
                    }
                    else
                    {
                        if (iMonth != 2)
                        {
                            if (iDate < 31)
                            {
                                result = true;
                                return result;
                            }
                        }
                        else
                        {
                            if (iYear % 400 == 0 || (iYear % 4 == 0 && 0 < iYear % 100))
                            {
                                if (iDate < 30)
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else
                            {
                                if (iDate < 29)
                                {
                                    result = true;
                                    return result;
                                }
                            }
                        }
                    }
                }
                result = false;
            }
            return result;
        }

        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;
        }

        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            string[] result;
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    result = new string[]
					{
						strContent
					};
                }
                else
                {
                    result = Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
                }
            }
            else
            {
                result = new string[0];
            }
            return result;
        }

        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = CommonHelper.SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                {
                    result[i] = splited[i];
                }
                else
                {
                    result[i] = string.Empty;
                }
            }
            return result;
        }

        public static string WebPathTran(string path)
        {
            string result;
            try
            {
                result = HttpContext.Current.Server.MapPath(path);
            }
            catch
            {
                result = path;
            }
            return result;
        }
        public static void CopyObjectValue<T>(T sourceObject, T desObject) where T : class
        {
            if (sourceObject == null && desObject == null) return;
            PropertyInfo[] propertyArray = sourceObject.GetType().GetProperties();
            foreach (var property in propertyArray)
            {
                try
                {
                    property.SetValue(desObject, property.GetValue(sourceObject), null);
                }
                catch { }
            }
        }

        public static void CopyObjectValueWithNoNull<T>(T sourceObject, T desObject) where T : class
        {
            if (sourceObject == null && desObject == null) return;
            PropertyInfo[] propertyArray = sourceObject.GetType().GetProperties();
            foreach (var property in propertyArray)
            {
                try
                {
                    if (property.GetValue(sourceObject) != null)
                    {
                        property.SetValue(desObject, property.GetValue(sourceObject), null);
                    }
                }
                catch { }
            }
        }

        public static void CopyObjectValue<T>(T sourceObject, T desObject, IList<string> fields, bool withField) where T : class
        {
            if (sourceObject == null && desObject == null) return;
            if (fields == null || fields.Count == 0)
                CopyObjectValue<T>(sourceObject, desObject);
            else
            {
                PropertyInfo[] propertyArray = sourceObject.GetType().GetProperties();
                foreach (var property in propertyArray)
                {
                    try
                    {
                        if (withField == true)
                        {
                            if (fields.Contains(property.Name) == true)
                                property.SetValue(desObject, property.GetValue(sourceObject), null);
                        }
                        else
                        {
                            if (fields.Contains(property.Name) == false)
                                property.SetValue(desObject, property.GetValue(sourceObject), null);
                        }
                    }
                    catch { }

                }
            }
        }

        public static void CopyObjectValue<T>(List<T> sourceObject, List<T> desObject) where T : class
        {
            if (sourceObject == null && desObject == null) return;

            PropertyInfo[] propertyArray = typeof(T).GetProperties();
            try
            {
                foreach (T item in sourceObject)
                {
                    T oBject = System.Activator.CreateInstance<T>();
                    foreach (var property in propertyArray)
                    {
                        try
                        {
                            property.SetValue(oBject, property.GetValue(item), null);
                        }
                        catch { }
                    }
                    desObject.Add(oBject);
                }

            }
            catch { }

        }

        public static T CreateObject<T>(T sourceObject) where T : class
        {
            if (sourceObject == null) return null;
            T desObject = System.Activator.CreateInstance<T>();
            CopyObjectValue(sourceObject, desObject);
            return desObject;
        }

        public static List<T> CreateObject<T>(List<T> sourceObject) where T : class
        {
            List<T> desObject = new List<T>();
            CopyObjectValue<T>(sourceObject, desObject);
            return desObject;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {

            DataTable dt = new DataTable();
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                //throw new Exception("需转换的集合为空");
                return dt;
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
    }
}
