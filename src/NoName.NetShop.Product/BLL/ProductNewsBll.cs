using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
    public class ProductNewsBll
    {
        private ProductNewsDal dal = new ProductNewsDal();
        
        public void Add(ProductNewsModel model)
        {
            dal.Add(model);
        }

        public void Update(ProductNewsModel model)
        {
            dal.Update(model);
        }

        public void Delete(ProductNewsModel model)
        {
            dal.Delete(model);
        }

        public bool Exists(int ProductID)
        {
            return dal.Exists(ProductID);
        }

        public ProductNewsModel GetModel(int ProductID)
        {
            return dal.GetModel(ProductID);
        }


        public void Save(ProductNewsModel model)
        {
            if (!Exists(model.ProdutID))
            {
                Add(model);
            }
            else
            {
                Update(model);
            }
        }
    }
}
