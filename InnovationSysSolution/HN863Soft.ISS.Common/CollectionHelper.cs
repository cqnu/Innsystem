using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using org.in2bits.MyXls;

namespace HN863Soft.ISS.Common
{
    public class CollectionHelper
    {
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
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

        /// <summary>
        /// 获取保存在服务器上的文件名称(如：file20150101080107.txt)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileName(string fileName)
        {
            string strResult = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                string strFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                string strHouZhui = strFileName.Substring(strFileName.LastIndexOf("."));
                string strName = strFileName.Substring(0, strFileName.LastIndexOf(".")) + DateTime.Now.ToString("yyyyMMddhhmmss");
                strResult = strName + strHouZhui;
            }
            return strResult;
        }

        /// <summary>
        /// 导出多个sheet的Excel。
        /// </summary>
        public static string ExportExcelForPercent(string sheetName, string xlsname, string strxlsFolder, List<DataTable> dataTableList)
        {
            if (dataTableList == null || dataTableList.Count == 0) { return ""; }

            try
            {
                XlsDocument xls = new XlsDocument();
                //StringBuilder GYSFiles = new StringBuilder();
                int n = 0;
                foreach (DataTable table in dataTableList)
                {
                    if (table == null || table.Rows.Count == 0)
                    {
                        n++;
                        continue;
                    }
                    Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName.Split(',')[n]);

                    //填充表头  
                    foreach (DataColumn col in table.Columns)
                    {
                        sheet.Cells.Add(1, col.Ordinal + 1, col.ColumnName);
                    }

                    //填充内容  
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            if (table.Rows[i][j] != null)
                            {
                                sheet.Cells.Add(i + 2, j + 1, table.Rows[i][j].ToString());
                            }
                        }
                        //if (n == 1)
                        //{
                        //    GYSFiles.Append(table.Rows[i]["FilePath"].ToString() + ",");
                        //}
                    }
                    n++;
                }

                //保存
                string strBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = GetFileName(xlsname);
                string saveFilePath = strBaseDirectory + strxlsFolder;
                if (File.Exists(saveFilePath))
                {
                    File.Delete(saveFilePath);
                }
                if (Directory.Exists(Path.GetDirectoryName(saveFilePath)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
                }
                xls.FileName = filePath;
                xls.Save(saveFilePath);
                xls = null;

                ////供应商上传文件
                //if (GYSFiles.Length > 0)
                //{
                //    GYSFiles.Append(",").Replace(",,", "");
                //    GYSFilesCopy(strBaseDirectory, GYSFiles.ToString());
                //}

                return saveFilePath + filePath;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog(string.Format("导出Excel文件报错，详细：{0}\n\n", ex));
            }

            return "";
        }

        /// <summary>
        /// 把上传的文件copy到压缩目录.
        /// </summary>
        /// <param name="strBaseDirectory"></param>
        /// <param name="files"></param>
        public static void FilesCopy(string strBaseDirectory, string files, string strxlsFolder)
        {
            try
            {
                if (files.Length > 0)
                {
                    string[] FileArr = files.Split(',');
                    foreach (string item in FileArr)
                    {
                        string Newfile = FileHelper.GetFileName(item);
                        string strPath = strBaseDirectory + strxlsFolder + Newfile;
                        FileHelper.Copy(strBaseDirectory + item, strPath);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog(string.Format("copy文件报错，详细：{0}\n\n", ex));
            }
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="strDirectory">压缩目录全路径</param>
        /// <param name="zipfile">压缩文件全路径</param>
        /// <returns></returns>
        public static string FilesZip(string strDirectory, string zipFile)
        {
            try
            {
                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.
                string[] filenames = Directory.GetFiles(strDirectory);
                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFile)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression		
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        // Setup the entry data as required.					
                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.
                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog(string.Format("压缩文件报错，详细：{0}\n\n", ex));
            }

            return zipFile;
        }

        /// <summary>
        /// 根据压缩文件解压文件(解压在当前目录)。
        /// </summary>
        /// <param name="zipFile"></param>
        /// <returns></returns>
        public static int UnFileZip(string zipFile)
        {
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = zipFile.Replace(".zip", "") + "\\"; //Path.GetDirectoryName(theEntry.Name); //
                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            FileHelper.CreateDirectory(directoryName);
                        }
                        if (fileName != String.Empty)
                        {
                            string createFilePath = directoryName + theEntry.Name;
                            using (FileStream streamWriter = File.Create(createFilePath))
                            {
                                int size = 4096;
                                byte[] data = new byte[4096];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog(string.Format("压缩文件报错，详细：{0}\n\n", ex));
                return 0;
            }

            return 1;
        }
    }
}
