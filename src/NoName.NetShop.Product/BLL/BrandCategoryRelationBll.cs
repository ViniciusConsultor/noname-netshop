using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.DAL;
using System.Data;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
    public class BrandCategoryRelationBll
    {
        private BrandCategoryRelationDal dal = new BrandCategoryRelationDal();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Add(BrandCategoryRelationModel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BrandID"></param>
        /// <param name="CategoryID"></param>
        public void Delete(int BrandID,int CategoryID)
        {
            dal.Delete(BrandID, CategoryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public DataTable GetCategoryBrandList(int CategoryID)
        {
            return dal.GetCategoryBrandList(CategoryID);
        }
    }
}
