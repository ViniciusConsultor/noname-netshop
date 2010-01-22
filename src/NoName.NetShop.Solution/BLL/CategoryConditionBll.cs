using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// 业务逻辑类CategoryCondition 的摘要说明。
	/// </summary>
	public class CategoryConditionBll
	{
        private readonly CategoryConditionDal dal = new CategoryConditionDal();
        public CategoryConditionBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(CategoryConditionModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CategoryConditionModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        public List<CategoryConditionModel> GetModelList(int scenceId, int cateId)
        {
            return dal.GetListArray("SenceId=" + scenceId + " and cateId=" + cateId);
        }


        public DataTable GetCategoryProductList(int CurrentCategoryID, int ScenceID,int BrandID,string ProductName)
        {
            List<CategoryConditionModel> Conditions = dal.GetListArray(String.Format(" cateid={0} and senceid={1}", CurrentCategoryID, ScenceID));

            bool IsHasProperity = false;
            string ConditionString = String.Empty;

            foreach (CategoryConditionModel m in Conditions) if (m.RuleName.Contains("paraid")) IsHasProperity = true;
            if (IsHasProperity)
            {
                foreach (CategoryConditionModel m in Conditions)
                {
                    if (m.RuleName.Contains("paraid")) ConditionString += m.GetFilterExpress("pdProductPara");
                    else ConditionString += m.GetFilterExpress("pdproduct");

                    ConditionString += " and ";
                }
                if (BrandID != 0) ConditionString += " pdproduct.brandid = " + BrandID + " and ";
                if (!String.IsNullOrEmpty(ProductName)) ConditionString += " and pdproduct.productname like '%" + ProductName + "%' and ";
            }
            else
            {
                foreach (CategoryConditionModel m in Conditions)
                {
                    ConditionString += m.GetFilterExpress("");
                    ConditionString += " and ";
                }
                if (BrandID != 0) ConditionString += " brandid = " + BrandID + " and ";
                if (!String.IsNullOrEmpty(ProductName)) ConditionString += " and productname like '%" + ProductName + "%' and ";
            }

            return String.IsNullOrEmpty(ConditionString)?new DataTable() : dal.GetCategoryProductList(IsHasProperity, ConditionString.Substring(0, ConditionString.LastIndexOf("and")));
        }
		#endregion  成员方法
	}
}

