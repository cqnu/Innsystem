using HN863Soft.ISS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HN863Soft.ISS.BLL
{
    public class ReportBll
    {

        private readonly HN863Soft.ISS.DAL.ReportDal dal = new HN863Soft.ISS.DAL.ReportDal();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Report model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 加入推广
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public int AddExtension(string Title, string url)
        {
            return dal.AddExtension(Title, url);
        }

        /// <summary>
        /// 取消推广
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool DelExtension(string url)
        {
            return dal.DelExtension( url);
        }

        /// <summary>
        /// 判断添加推广按钮或取消推广按钮显示隐藏
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool GetExtension(string url)
        {
            return dal.GetExtension(url);
        }



        public int UpdateState(Report model, string table,int id)
        {
            return dal.UpdateState(model, table, id);
        }


        /// <summary>
        /// 举报按钮是否可用
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool Hide(int Id, string url)
        {
            return dal.Hide(Id,url);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string order, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, order, out recordCount);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
          
        }


        public DataSet GetMessageInfo()
        {
            return dal.GetMessageInfo();
        }

    }
}
