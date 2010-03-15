using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;
using System.Data;

namespace NoName.NetShop.Product.BLL
{
    public class ProductSpecificationBll
    {
        private ProductSpecificationDal dal = new ProductSpecificationDal();



        
        public bool Exists(int SpecificationID)
        {
            return dal.Exists(SpecificationID);
        }


        public void Insert(ProductSpecificationModel Model)
        {
            dal.Insert(Model);
        }


        public void Update(ProductSpecificationModel Model)
        {
            dal.Update(Model);
        }



        public void Delete(int SpecificationID)
        {
            dal.Delete(SpecificationID);
        }


        public ProductSpecificationModel GetModel(int SpecificationID)
        {
            return dal.GetModel(SpecificationID);
        }


        public DataTable GetList(SpecificationType sType)
        {
            return dal.GetList(sType);
        }
    }
}
