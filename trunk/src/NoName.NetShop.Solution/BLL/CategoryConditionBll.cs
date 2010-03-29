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


        public DataTable GetCategoryProductList(int ScenceID,int CategoryID,int FatherCategoryID,int BrandID,string ProductName)
        {


            //if (FatherCategoryID != 0) //点击了子分类的情况
            //{
            //    //此时用ScenceID和FatherCategoryID获取所有条件，循环拼接SQL
            //    //循环中判断，如果RuleName包含CateID时，排除该条件，添加CategoryID的条件
            //}
            //else //点击了父分类的情况
            //{
            //    //按照正常情况获取所有条件，拼接SQL 
            //}

            List<CategoryConditionModel> Conditions = dal.GetListArray(String.Format(" cateid={0} and senceid={1}", FatherCategoryID == 0 ? CategoryID : FatherCategoryID, ScenceID));

            bool IsHasProperity = false;
            string ConditionString = String.Empty;

            foreach (CategoryConditionModel m in Conditions) if (m.RuleName.Contains("paraid")) IsHasProperity = true;

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

            return String.IsNullOrEmpty(ConditionString)?new DataTable() : dal.GetCategoryProductList(IsHasProperity, ConditionString.Substring(0, ConditionString.LastIndexOf("and")));
        }

        public DataTable GetConditionSubCategory(int ScenceID, int CategoryID)
        {
            return dal.GetConditionSubCategory(ScenceID, CategoryID);
        }
		#endregion  成员方法
	}
}