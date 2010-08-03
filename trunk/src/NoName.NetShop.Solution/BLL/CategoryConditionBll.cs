using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;
using System.Text.RegularExpressions;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���CategoryCondition ��ժҪ˵����
	/// </summary>
	public class CategoryConditionBll
	{
        private readonly CategoryConditionDal dal = new CategoryConditionDal();
        public CategoryConditionBll()
        { 

        }
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(CategoryConditionModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ��������б�
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
                string ParaCondition = String.Empty, ParaValueCondition = String.Empty;
                string ParaRegular = @"paraid=(?<paraid>\d+) and", ParaValueRegular = @"in\((?<paravalue>'.+')\)";
                foreach (CategoryConditionModel m in Conditions)
                {
                    if (m.IsParameter)
                    {
                        Match pm = Regex.Match(m.RuleName, ParaRegular);
                        Match vm = Regex.Match(m.RuleValue, ParaValueRegular);

                        if (pm.Success && vm.Success)
                        {
                            ParaCondition += pm.Groups["paraid"] + ",";
                            ParaValueCondition += vm.Groups["paravalue"] + ",";
                        }
                    }
                }

                ConditionString += " pdproduct.catepath like (select catepath+'%' from pdcategory where cateid=" + FatherCategoryID + ") and ";
                foreach (CategoryConditionModel m in Conditions)
                {
                    if (m.RuleName.Contains("paraid")) ConditionString += "";//m.GetFilterExpress("pdProductPara");
                    else if (m.RuleName.Contains("cateid")) ConditionString += CategoryID == 0 ? m.GetFilterExpress("pdproduct") + " and " : " pdproduct.cateid = " + CategoryID + " and ";
                    else ConditionString += m.GetFilterExpress("pdproduct") + " and ";
                }

                ConditionString += String.Format("pdProductPara.paraid in ({0}) and pdProductPara.paravalue in ({1}) and ", ParaCondition.Substring(0, ParaCondition.Length - 1), ParaValueCondition.Substring(0, ParaValueCondition.Length - 1));

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
		#endregion  ��Ա����
	}
}