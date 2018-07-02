using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN863Soft.ISS.BLL
{
    // <summary>
	/// Orgnization
	/// </summary>
	public partial class  Organization
    {
        private readonly HN863Soft.ISS.DAL.Organization dal=new HN863Soft.ISS.DAL.Organization();
        public Organization(){}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string orgName)
        {
            return dal.Exists(orgName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(HN863Soft.ISS.Model.Organization model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(HN863Soft.ISS.Model.Organization model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 审核机构认证信息及管理账户认证状态
        /// </summary>
        /// <param name="id">机构信息ID</param>
        /// <param name="state">审核状态</param>
        /// <param name="reason">原因</param>
        /// <returns></returns>
        public bool UpdateState(int id, int userID, int state, int orgType)
        {
            return dal.UpdateState(id, userID, state, orgType);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			return dal.Delete(ID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public HN863Soft.ISS.Model.Organization GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HN863Soft.ISS.Model.Organization GetModelByUserID(int userID)
        {
            return dal.GetModelByUserID(userID);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
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
        public List<HN863Soft.ISS.Model.Organization> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<HN863Soft.ISS.Model.Organization> DataTableToList(DataTable dt)
		{
            List<HN863Soft.ISS.Model.Organization> modelList = new List<HN863Soft.ISS.Model.Organization>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                HN863Soft.ISS.Model.Organization model;
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

          /// <summary>
        /// 获得已经入孵的省份
        /// </summary>
        public DataSet GetProvice()
        {
            return dal.GetProvice();
        }

           /// <summary>
        /// 获得已经入孵的省份入驻地的城市
        /// </summary>
        public DataSet GetCity(string strPro)
        {
            return dal.GetCity(strPro);
        }

             /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetHList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetHList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  ExtensionMethod
    }
}
