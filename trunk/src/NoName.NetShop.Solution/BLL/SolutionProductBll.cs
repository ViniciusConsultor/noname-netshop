using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// 业务逻辑类Product 的摘要说明。
	/// </summary>
	public class SolutionProductBll
	{
        private readonly SolutionProductDal dal = new SolutionProductDal();
		public SolutionProductBll()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Save(SolutionProductModel model)
		{
			dal.Save(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId,int ProductId)
		{
			
			dal.Delete(SuiteId,ProductId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<SolutionProductModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SolutionProductModel> GetModelList(int suiteId)
        {
            return dal.GetListArray("suiteId=" + suiteId);
        }

        public DataTable GetList(int SuiteID)
        {
            return dal.GetList(SuiteID);
        }
		#endregion  成员方法
	}
}

