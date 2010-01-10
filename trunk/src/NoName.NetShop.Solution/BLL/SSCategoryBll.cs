using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Category 的摘要说明。
	/// </summary>
	public class CategoryBll
	{
		private readonly NoName.NetShop.Solution.SSCategoryDal dal=new NoName.NetShop.Solution.SSCategoryDal();
		public CategoryBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryModel model)
		{
			dal.Save(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SenceId,int CateId)
		{
			
			dal.Delete(SenceId,CateId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSCategoryModel GetModel(int SenceId,int CateId)
		{
			
			return dal.GetModel(SenceId,CateId);
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  成员方法
	}
}

