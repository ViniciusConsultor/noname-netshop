using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类CategoryCondition 的摘要说明。
	/// </summary>
	public class SSCategoryConditionBll
	{
		private readonly NoName.NetShop.Solution.CategoryCondition dal=new NoName.NetShop.Solution.CategoryCondition();
		public SSCategoryConditionBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryConditionModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}
		#endregion  成员方法
	}
}

