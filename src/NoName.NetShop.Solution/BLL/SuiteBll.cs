using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// 业务逻辑类Suite 的摘要说明。
	/// </summary>
	public class SuiteBll
	{
		private readonly SuiteDal dal=new SuiteDal();
		public SuiteBll()
		{}
		#region  成员方法

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SuiteId)
		{
			return dal.Exists(SuiteId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(SuiteModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId)
		{
			
			dal.Delete(SuiteId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SuiteModel GetModel(int SuiteId)
		{
			
			return dal.GetModel(SuiteId);
		}


        public DataTable GetList(int PageIndex, int PageSize, string Condition, string Order, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition, Order, out RecordCount);
        }

		#endregion  成员方法
	}
}

