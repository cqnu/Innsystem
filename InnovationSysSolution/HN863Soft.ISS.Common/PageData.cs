using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class PageData<T> where T : class
    {
        public List<T> DataList { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
