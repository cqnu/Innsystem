/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 13:34:01   N/A    初版
*
* Copyright (c) 2017 河南863软件孵化器有限公司. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：河南863软件孵化器有限公司　　　　　　　　　　　　   　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using HN863Soft.ISS.Model;
using HN863Soft.ISS.Common;

namespace HN863Soft.ISS.BLL
{
    /// <summary>
    /// 会员主表
    /// </summary>
    public partial class Users
    {
        private readonly Model.SiteConfig siteConfig = new BLL.SiteConfig().loadConfig(); //获得站点配置信息
        private readonly HN863Soft.ISS.DAL.Users dal = new HN863Soft.ISS.DAL.Users();
        public Users() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        public int Update(string name, string type)
        {
            return dal.Update(name,type);
        }
        public int UpdatePwd(string name, string pwd, string salt)
        {
            return dal.UpdatePwd(name, pwd,salt);
        }


        public bool ValidationInformation(string userName, string email)
        {
            return dal.ValidationInformation(userName, email);
        }

        public bool ValidationMail(string email)
        {
            return dal.ValidationMail(email);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        /// <summary>
        /// 检查同一IP注册间隔(小时)内是否存在
        /// </summary>
        public bool Exists(string regIP, int regCtrl)
        {
            return dal.Exists(regIP, regCtrl);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HN863Soft.ISS.Model.Users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HN863Soft.ISS.Model.Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        /// <param name="userName">用户名(明文)</param>
        /// <param name="password">密码</param>
        /// <param name="emailLogin">是否允许邮箱做为登录</param>
        /// <param name="mobileLogin">是否允许手机做为登录</param>
        /// <param name="isEncrypt">是否需要加密密码</param>
        /// <returns></returns>
        public Model.Users GetModel(string userName, string password,  bool isEncrypt)
        {
            //检查一下是否需要加密
            if (isEncrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(userName);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                password = EncryptionHelper.Encrypt(password, salt);
            }
            return dal.GetModel(userName, password, isEncrypt);
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.Users GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.Users GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet RowId(int rowType)
        {
            return dal.RowId(rowType);
        }

        public DataSet RowTypeId(string rowType)
        {
            return dal.RowTypeId(rowType);
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HN863Soft.ISS.Model.Users> DataTableToList(DataTable dt)
        {
            List<HN863Soft.ISS.Model.Users> modelList = new List<HN863Soft.ISS.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HN863Soft.ISS.Model.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 检查Email是否存在
        /// </summary>
        public bool ExistsEmail(string email)
        {
            return dal.ExistsEmail(email);
        }

        /// <summary>
        /// 检查手机号码是否存在
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            return dal.ExistsMobile(mobile);
        }

        /// <summary>
        /// 返回一个随机用户名
        /// </summary>
        public string GetRandomName(int length)
        {
            string temp = Utils.Number(length, true);
            if (Exists(temp))
            {
                return GetRandomName(length);
            }
            return temp;
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string userName)
        {
            return dal.GetSalt(userName);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 添加组织账户
        /// </summary>
        /// <param name="uModel"></param>
        /// <param name="mModel"></param>
        /// <returns></returns>
        public int Add(HN863Soft.ISS.Model.Users uModel, HN863Soft.ISS.Model.Manager mModel)
        {
            return dal.Add(uModel, mModel);
        }

        /// <summary>
        /// 根据管理员id获取前台的用户信息
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public Model.Users GetUserModel(int mId)
        {
            return dal.GetUserModel(mId);
        }

        /// <summary>
        /// 等级提升
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="value">任务类型</param>
        /// <returns></returns>
        public bool UpLevel(int id, EnumsHelper.UserUpLevel value)
        {
            try
            {
                Model.Users user = GetModel(id);//获取用户信息
                user.Exp = user.Exp + value.GetValue();//获取当前任务经验
                //等级提升并更新用户信息
                foreach (EnumsHelper.ForumLevel item in Enum.GetValues(typeof(EnumsHelper.ForumLevel)))
                {
                    if (item.GetValue() == user.GroupID)
                    {
                        int exp = int.Parse(EnumsHelper.FetchDescription(item));
                        if (user.GroupID == 12 && user.Exp >= exp)
                        {
                            user.Exp = exp;
                            //经验值为满更新
                            if (dal.UpdateField(user.ID, "Exp=" + user.Exp) != 1)
                            {
                                return false;
                            }
                        }
                        else if (user.Exp > exp)
                        {
                            user.GroupID += 1;
                            user.Exp -= exp;
                            //等级提升更新
                            if (dal.UpdateField(user.ID, "Exp=" + user.Exp + ",GroupID=" + user.GroupID) != 1)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            //经验值更新
                            if (dal.UpdateField(user.ID, "Exp=" + user.Exp) != 1)
                            {
                                return false;
                            }
                        }
                        break;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新积分信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="value">积分操作类型</param>
        /// <param name="pointVal">操作积分值</param>
        /// <returns></returns>
        public bool UpPoint(int id, EnumsHelper.ActionEnum value, int pointVal)
        {
            Model.Users user = GetModel(id);
            if (user == null)
            {
                return false;
            }
            if (value.ToString() == "Add")
            {
                if (dal.UpdateField(user.ID, "Point=" + (user.Point + pointVal)) != 1)
                {
                    return false;
                }
            }
            else if (value.ToString() == "Reduce")
            {
                if (dal.UpdateField(user.ID, "Point=" + (user.Point - pointVal)) != 1)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion  ExtensionMethod
    }
}

