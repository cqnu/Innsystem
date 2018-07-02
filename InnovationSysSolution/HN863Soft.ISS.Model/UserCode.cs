using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.Model
{
    /// <summary>
    /// 用户随机码表
    /// </summary>
    [Serializable]
    public partial class UserCode
    {
        public UserCode() { }

        private int _id;
        private int _user_id;
        private string _user_name;
        private string _type;
        private string _str_code;
        private int _count = 0;
        private int _status = 0;
        private string _user_ip;
        private DateTime _eff_time;
        private DateTime _createTime = DateTime.Now;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 生成码类别 password取回密码,register邀请注册
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 生成的字符串
        /// </summary>
        public string StrCode
        {
            set { _str_code = value; }
            get { return _str_code; }
        }
        /// <summary>
        /// 使用次数
        /// </summary>
        public int Count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 状态0未使用1已使用
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP
        {
            set { _user_ip = value; }
            get { return _user_ip; }
        }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime EffTime
        {
            set { _eff_time = value; }
            get { return _eff_time; }
        }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createTime = value; }
            get { return _createTime; }
        }
    }
}
