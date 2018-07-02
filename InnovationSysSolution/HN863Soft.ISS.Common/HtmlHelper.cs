using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace HN863Soft.ISS.Common
{
    public class HtmlHelper
    {
        public static HtmlLink GetHtmlStyleLink(string href)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("href", href);
            return link;
        }
        public static string GetFileSize(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                return "";
            }
            System.IO.FileInfo fi = new System.IO.FileInfo(file);

            return (fi.Length / 1000).ToString("###,###");
        } /// <summary>
        /// 产生随机字符串
        /// </summary>
        /// <returns>字符串位数</returns> 
        public static string GetRandomString(int length = 5)
        {
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < length + 1; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += code.ToString();
            }
            return checkCode;
        }

        public static HtmlLink GetHtmlICOLink(string rel, string href)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("rel", rel);
            link.Attributes.Add("type", "image/x-icon");
            link.Attributes.Add("href", href);
            return link;
        }
    }
}
