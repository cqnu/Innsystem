//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class Logger
    {
        private static FileStream logfile;
        private static TextWriterTraceListener traceListener = null;
        private static int LogLevel = 0;
        private static string currentLogContent;
        public static List<string> lastLog = new List<string>();
        //private static bool needInit = true;
        private static string lastLogFileName = null;
        private static string originalLogFileName = null;

        public static void InitLogger(string logFileName)
        {
            try
            {
                originalLogFileName = logFileName;
                string logdir = ConfigurationManager.AppSettings["LogFolder"];
                if (string.IsNullOrEmpty(logdir) == true)
                    logdir = "logs";
                logdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LogFolder"]);
                LogLevel = int.Parse(ConfigurationManager.AppSettings["LogLevel"] == null ? "0" : ConfigurationManager.AppSettings["LogLevel"]);
                if (!System.IO.Directory.Exists(logdir))
                {
                    System.IO.Directory.CreateDirectory(logdir);
                }
                if (string.IsNullOrEmpty(logFileName) == true)
                    logFileName = "";
                else
                    logFileName += "_";
                string logPath = Path.Combine(logdir, "Log_" + logFileName + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                lock (lastLog)
                {
                    if (LogInited(logPath) == true)
                        return;
                }
                lastLogFileName = logPath;
                DisposeLogWriter();
                if (!File.Exists(logPath))
                    logfile = new FileStream(logPath, System.IO.FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                else
                    logfile = new FileStream(logPath, System.IO.FileMode.Append, FileAccess.Write, FileShare.Read);

                if (traceListener != null)
                {
                    if (Trace.Listeners.Contains(traceListener) == true)
                        Trace.Listeners.Remove(traceListener);
                    traceListener.Close();
                    traceListener.Dispose();
                }
                StreamWriter sw = new StreamWriter(logfile, Encoding.UTF8);
                traceListener = new TextWriterTraceListener(sw);
                Trace.Listeners.Add(traceListener);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void InitLogger()
        {
            InitLogger("");
        }

        public static void Write(string logcontent)
        {
            InitLogger(originalLogFileName);
            currentLogContent = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + logcontent;
            traceListener.WriteLine(currentLogContent);
            traceListener.Flush();

            lock (lastLog)
            {
                if (lastLog.Count > 50)
                {
                    List<string> tempList = new List<string>();
                    for (int i = 50; i <= 0; i--)
                        tempList.Add(lastLog[lastLog.Count - i]);
                    lastLog.Clear();
                    lastLog.AddRange(tempList);
                }
            }
        }

        public static void Write(Exception logException)
        {
            Write(GetExceptionMessage(logException.InnerException ?? logException));
        }

        public static void Write(LogLevel level, string message)
        {
            if (level.GetHashCode() >= LogLevel)
            {
                Write("[" + level.ToString() + "]" + message);
            }
        }

        public static void Write(LogLevel level, Exception logException)
        {
            if (level.GetHashCode() >= LogLevel)
            {
                Write("[" + level.ToString() + "]" + GetExceptionMessage(logException.InnerException ?? logException));
            }
        }
        public static void Write(LogType logType, LogLevel level, string message)
        {
            switch (logType)
            {
                case LogType.LogFile:
                    Write(level, message);
                    break;
                case LogType.LogDatabase:
                    break;
            }
        }

        public static void Write(LogType logType, LogLevel level, Exception logException)
        {
            switch (logType)
            {
                case LogType.LogFile:
                    Write(level, logException);
                    break;
                case LogType.LogDatabase:
                    HandleException(logException, null, "");
                    break;
            }
        }

        public static void DeInitLogger()
        {
            traceListener.Close();
        }

        public static string GetCurrentLogContent()
        {
            return currentLogContent;
        }

        public static string HandleException(Exception exception, Dictionary<string, object> parms, string message)
        {
            return HandleException(exception, parms, message, "JZPolicy");
        }

        public static string HandleException(Exception exception, Dictionary<string, object> parms, string message, string exceptionHandlPolicyName)
        {
            //穿件我们自己定义的异常类
            LoggingException tyException = new LoggingException(message + " ", exception);

            //建立一个StackFrame
            StackFrame frame = new StackFrame(1, true);

            //记录抛出异常的文件名，方法名和，行号
            tyException.SetErrorProperty(LoggingException.CurrentFilename, frame.GetFileName());
            tyException.SetErrorProperty(LoggingException.CurrentFunction, frame.GetMethod().Name);
            tyException.SetErrorProperty(LoggingException.CurrentLineNumber, frame.GetFileLineNumber().ToString());
            // parameters, if present
            if (parms != null)
            {
                foreach (KeyValuePair<string, object> parm in parms)
                {
                    if (parm.Value != null)
                    {
                        tyException.SetErrorProperty(parm.Key, parm.Value.ToString());
                    }
                }
            }

            //使用EntityPrise Library记录异常信息，JZPolicy配置在Web.Config文件中
            //ExceptionPolicy.HandleException(tyException, exceptionHandlPolicyName);

            //返回有好的错误信息到页面
            return tyException.Message;
        }

        private static void WriteLog(string message)
        {
            //Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry oEntity = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry.EventLog();
            //oEntity.mess
            //LogWriter my = new LogWriterFactory().Create();
            //my.Write(oEntity);
        }

        private static bool LogInited(string logFileName)
        {
            if (lastLogFileName == logFileName)
                return true;
            else
                return false;
        }

        private static void DisposeLogWriter()
        {
            if (logfile != null)
            {
                logfile.Close();
                logfile.Dispose();
            }
        }

        private static string GetBetweenString(string str, string beginTag, string endTag, int beginOffset)
        {
            int startIndex = str.IndexOf(beginTag);
            int endIndex = str.LastIndexOf(endTag);
            int length = endIndex - (startIndex);
            return length == -1 ? "" : str.Substring(startIndex + beginOffset, length - beginOffset);
        }

        private static string GetExceptionMessage(Exception ex)
        {
            return (string.Concat("Message:", ex.Message, "\r\n", "Source Trace:", ex.StackTrace));
        }
    }

    public enum LogLevel
    {
        DEBUG = 0,
        NORMAL = 1,
        WARNING = 2,
        ERROR = 3,
        CRITICAL = 4
    }

    public enum LogType
    {
        LogFile,
        LogDatabase
    }
}
