using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class ActionMessage:MessageInfo 
    {
        public dynamic ReturnObject { get; set; }

        public ActionState Signal { get; set; }
    }
}
