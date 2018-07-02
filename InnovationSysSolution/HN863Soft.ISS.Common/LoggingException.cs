using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    [Serializable]
    public class LoggingException : ISSException
    {
        public static string CurrentFunction = "Function";
        public static string CurrentFilename = "Filename";
        public static string CurrentLineNumber = "Line Number";

        //定义够方法，调用Exception基类的构造方法
        public LoggingException() : base() { }
        public LoggingException(string message) : base(message) { }
        public LoggingException(string message, System.Exception inner) : base(message, inner) { }
        protected LoggingException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        //键值对的构造方法
        //把键值对存入Data,最终通过Enterprise library text foramtter存入数据库中
        public LoggingException(string message, Exception inner, IDictionary<string, string> props)
            : base(message, inner)
        {
            foreach (KeyValuePair<string, string> entry in props)
                if (!String.IsNullOrEmpty(entry.Key) && props[entry.Key] != null)
                    Data[entry.Key] = entry.Key;
        }

        //获得错误属性值
        public string GetErrorProperty(string key)
        {
            return (Data[key] == null) ? string.Empty : Data[key].ToString();
        }

        //添加错误属性值
        public void SetErrorProperty(string key, string value)
        {
            if (!String.IsNullOrEmpty(key) && value != null)
                Data[key] = value;
        }
    }
}
