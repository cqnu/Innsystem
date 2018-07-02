using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public static class ExpandClass
    {
        /// <summary>
        /// 将当前字符串转换为int类型，出错时返回零
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            int result = 0;
            if (int.TryParse(str, out result) == false)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// 将当前字符串转换为int类型，出错时返回null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToIntNull(this string str)
        {
            int? result = null;
            int t = 0;
            if (int.TryParse(str, out t) == false)
            {
                result = null;
            }
            else
            {
                result = t;
            }

            return result;
        }

        /// <summary>
        /// 将当前字符串转换为decimal类型，出错时返回零
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str)
        {
            decimal result = 0;
            if (decimal.TryParse(str, out result) == false)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// 将当前字符串转换为DateTime类型，出错时返回时间最小值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string str)
        {
            DateTime? result = null;
            DateTime t = DateTime.MinValue;
            if (DateTime.TryParse(str, out t))
            {
                result = t;
            }

            return result;
        }

        #region get enum entity value
        /// <summary>
        /// get enum value
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static int GetValue(this Enum enumType)
        {
            int fieldValue = 0;

            FieldInfo[] fieldInfos = enumType.GetType().GetFields();
            foreach (FieldInfo field in fieldInfos)
            {
                if (field.Name == enumType.ToString())
                {
                    try
                    {
                        fieldValue = (int)field.GetValue(field);
                    }
                    catch
                    {
                    }
                    break;
                }
            }

            return fieldValue;
        }

        #endregion
    }
}
