using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Suite 的摘要说明。
	/// </summary>
	public class SuiteBll
	{
		private readonly NoName.NetShop.Solution.SuiteDal dal=new NoName.NetShop.Solution.SuiteDal();
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
		public void Save(NoName.NetShop.Solution.SuiteModel model)
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
		public NoName.NetShop.Solution.SuiteModel GetModel(int SuiteId)
		{
			
			return dal.GetModel(SuiteId);
		}

		#endregion  成员方法
	}
}

