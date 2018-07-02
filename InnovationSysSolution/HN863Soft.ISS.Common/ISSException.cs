using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Common
{
    public class ISSException:Exception
    {
        public ISSException(): base(){ }

        public ISSException(string message) : base(message) { }

        public ISSException(string message, System.Exception inner) : base(message, inner) { }

        public ISSException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
