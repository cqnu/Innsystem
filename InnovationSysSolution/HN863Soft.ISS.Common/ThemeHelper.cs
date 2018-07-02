using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class ThemeHelper
    {
        public static string GetCssStyle(string selectedCssFileName, string defaultCssFileName, string cssRoot, string cssFileName = "site.css")
        {
            selectedCssFileName = selectedCssFileName.Replace("/", "").Replace(@"\", "");

            string selectedCss = Path.Combine(cssRoot, selectedCssFileName + @"\" + cssFileName);
            if (File.Exists(selectedCss) == true)
                return selectedCssFileName;

            selectedCss = Path.Combine(cssFileName, defaultCssFileName + @"\" + cssFileName);
            if (File.Exists(selectedCss) == true)
                return selectedCss;

            string[] cssArray = Directory.GetDirectories(cssRoot);
            if (cssArray.Length == 0)
                return null;
            else
            {
                string firstCss = Path.GetDirectoryName(cssArray[0]);
                selectedCss = Path.Combine(cssRoot, firstCss + @"\" + cssFileName);
                if (File.Exists(selectedCss) == true)
                    return firstCss;
                else
                    return null;
            }
        }
    }
}
