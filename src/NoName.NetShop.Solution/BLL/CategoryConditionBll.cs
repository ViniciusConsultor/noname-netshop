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
        { 

        }
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


        public DataTable GetCategoryProductList(int ScenceID,int CategoryID,int FatherCategoryID,int BrandID,string ProductName,int OrderType,out bool HasSubCategory)
        {
            List<CategoryConditionModel> Conditions = dal.GetListArray(String.Format(" cateid={0} and senceid={1}", FatherCategoryID , ScenceID));

            bool IsHasProperity = false; HasSubCategory = false;
            string ConditionString = String.Empty;

            foreach (CategoryConditionModel m in Conditions)
            {
                if (m.RuleName.Contains("paraid")) IsHasProperity = true;
                if (m.RuleName.Contains("cateid")) HasSubCategory = true;
            }

            if (IsHasProperity)
            {
                ConditionString += " pdproduct.catepath like (select catepath+'%' from pdcategory where cateid=" + FatherCategoryID + ") and ";
                foreach (CategoryConditionModel m in Conditions)
                {
                    if (m.RuleName.Contains("paraid")) ConditionString += m.GetFilterExpress("pdProductPara");
                    else if (m.RuleName.Contains("cateid")) ConditionString += CategoryID == 0 ? m.GetFilterExpress("pdproduct") : " pdproduct.cateid = " + CategoryID;
                    else ConditionString += m.GetFilterExpress("pdproduct");

                    ConditionString += " and ";
                }
                if (BrandID != 0) ConditionString += " pdproduct.brandid = " + BrandID + " and ";
                if (!String.IsNullOrEmpty(ProductName)) ConditionString += " pdproduct.productname like '%" + ProductName + "%' and ";
            }
            else
            {
                ConditionString += " catepath like (select catepath+'%' from pdcategory where cateid=" + FatherCategoryID + ") and ";
                foreach (CategoryConditionModel m in Conditions)
                {
                    if (m.RuleName.Contains("cateid")) ConditionString += CategoryID == 0 ? m.GetFilterExpress("") : " cateid = " + CategoryID;
                    else  ConditionString += m.GetFilterExpress("");
                    ConditionString += " and ";
                }
                if (BrandID != 0) ConditionString += " brandid = " + BrandID + " and ";
                if (!String.IsNullOrEmpty(ProductName)) ConditionString += " productname like '%" + ProductName + "%' and ";
            }

            return String.IsNullOrEmpty(ConditionString) ? new DataTable() : dal.GetCategoryProductList(IsHasProperity, ConditionString.Substring(0, ConditionString.LastIndexOf("and")), OrderType);
        }

        public DataTable GetConditionSubCategory(int ScenceID, int CategoryID)
        {
            return dal.GetConditionSubCategory(ScenceID, CategoryID);
        }

        public DataTable GetConditionBrandList(int ScenceID, int CategoryID)
        {
            return dal.GetConditionBrandList(ScenceID, CategoryID);
        }
		#endregion  成员方法
	}
}