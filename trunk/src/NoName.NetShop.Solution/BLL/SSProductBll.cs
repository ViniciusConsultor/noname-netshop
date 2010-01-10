using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Product 的摘要说明。
	/// </summary>
	public class SSProductBll
	{
		private readonly NoName.NetShop.Solution.SSProductDal dal=new NoName.NetShop.Solution.SSProductDal();
		public SSProductBll()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSProductModel model)
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
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSProductModel GetModel(int SuiteId,int ProductId)
		{
			
			return dal.GetModel(SuiteId,ProductId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSProductModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}
		#endregion  成员方法
	}
}

