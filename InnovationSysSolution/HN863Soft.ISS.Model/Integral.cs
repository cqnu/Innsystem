using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.Model
{
    public class Integral
    {
        private int _id;
        private int _userid;
        private int _projectid;
        private string _projectname;

        /// <summary>
        /// 服务名称
        /// </summary>
        public string Projectname
        {
            get { return _projectname; }
            set { _projectname = value; }
        }

        /// <summary>
        /// 服务项目Id
        /// </summary>
        public int Projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        /// <summary>
        /// 用户id
        /// </summary>
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
