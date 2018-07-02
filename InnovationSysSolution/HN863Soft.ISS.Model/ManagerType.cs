using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// 管理角色类型表
    /// </summary>
    [Serializable]
    public class ManagerType
    {
        public ManagerType() { }

        private int _id;
        private string _typeNname;
        private int _isSys = 0;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 角色类型名称
        /// </summary>
        public string TypeName
        {
            set { _typeNname = value; }
            get { return _typeNname; }
        }
        /// <summary>
        /// 是否系统默认0否1是
        /// </summary>
        public int IsSys
        {
            set { _isSys = value; }
            get { return _isSys; }
        }
    }
}
