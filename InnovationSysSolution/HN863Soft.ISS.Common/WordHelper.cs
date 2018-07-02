using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace HN863Soft.ISS.Common
{
    public class WordHelper
    {
        /// <summary>
        /// 调用模板生成word
        /// </summary>
        /// <param name="templateFile">模板文件</param>
        /// <param name="fileName">生成的具有模板样式的新文件</param>
        /// <param name="obj">书签值替换对象，书签名字和属性名字一致则替换</param>
        /// <param name="dt">表格，有值则可以在word对应位置插入表格行列顺序按照dt结构生成，不包含表头</param>
        public static void ExportWord(string templateFilePath, string savefilePath, object obj, DataTable dt, int rowIndex, int tableIndex)
        {
            //生成word程序对象
            Word.Application app = new Word.Application();
            try
            {
                //模板文件拷贝到新文件
                File.Copy(templateFilePath, savefilePath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Word.Document doc = new Word.Document();
            object Obj_FileName = savefilePath;
            object Visible = false;
            object ReadOnly = false;
            object missing = System.Reflection.Missing.Value;
            object IsSave = true;

            try
            {
                //打开文件
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref Visible,
                    ref missing, ref missing, ref missing,
                    ref missing);
                doc.Activate();

                if (obj != null)
                {
                    var bookMarks = doc.Bookmarks;
                    foreach (Word.Bookmark book in bookMarks)
                    {
                        object WordMarkName = book.Name;//word模板中的书签名称
                        object what = Word.WdGoToItem.wdGoToBookmark;
                        doc.ActiveWindow.Selection.GoTo(ref what, ref missing, ref missing, ref WordMarkName);//光标转到书签的位置
                        doc.ActiveWindow.Selection.TypeText(GetObjPropertyValue(obj, book.Name));//插入的内容，插入位置是word模板中书签定位的位置
                        doc.ActiveWindow.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//设置当前定位书签位置插入内容的格式
                    }
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    GenerateTable(dt, ref doc, rowIndex, tableIndex);
                }

                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref missing, ref missing, ref missing);
                throw ex;
            }
        }

        /// <summary>
        /// 生成表格
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="expPairColumn"></param>
        /// <param name="wDoc">word文档</param>
        /// <returns></returns>
        private static void GenerateTable(DataTable dt, ref Word.Document wDoc, int rowIndex, int tableIndex)
        {
            try
            {
                Word.Table tb = wDoc.Tables[tableIndex];

                Word.Row tableDr = tb.Rows[rowIndex];
                for (int j = dt.Rows.Count - 1; j >= 0; j--)
                {
                    DataRow dr = dt.Rows[j];
                    tableDr = tb.Rows.Add(tableDr);
                    tableDr.Cells[1].Range.Text = (j + 1).ToString();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(dr[i].ToString()) == false)
                        {
                            tableDr.Cells[i + 1].Range.Text = dr[i].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetObjPropertyValue(object obj, string propertyName)
        {
            string propertyValue = string.Empty;
            if (obj != null)
            {
                PropertyInfo property = obj.GetType().GetProperty(propertyName);
                if (property != null && property.GetValue(obj) != null)
                {
                    propertyValue = property.GetValue(obj).ToString();
                }
            }

            return propertyValue;
        }
    }
}
