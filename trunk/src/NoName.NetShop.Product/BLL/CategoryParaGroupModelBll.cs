using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;
using System.Data;

namespace NoName.NetShop.Product.BLL
{
    public class CategoryParaGroupModelBll
    {
        private CategoryParaGroupModelDal dal = new CategoryParaGroupModelDal();

        public void Add(CategoryParaGroupModel model)
        {
            dal.Add(model);
        }

        public void Delete(int GroupID)
        {
            dal.Delete(GroupID);
        }

        public void Update(CategoryParaGroupModel model)
        {
            dal.Update(model); 
        }

        public void SwichOrder(int GroupID, int SwitchGroupID)
        {
            dal.SwichOrder(GroupID, SwitchGroupID);
        }


        public CategoryParaGroupModel GetModel(int GroupID)
        {
            return dal.GetModel(GroupID);
        }

        public DataTable GetList(int CategoryID)
        {
            return dal.GetList(CategoryID);
        }

    }
}
