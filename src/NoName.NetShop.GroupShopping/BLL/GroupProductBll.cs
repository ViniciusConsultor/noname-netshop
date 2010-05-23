using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.GroupShopping.DAL;
using NoName.NetShop.GroupShopping.Model;
using System.Data;

namespace NoName.NetShop.GroupShopping.BLL
{
    public class GroupProductBll
    {
        private GroupProductDal dal = new GroupProductDal();

        public bool Exists(int ProductID)
        {
            return dal.Exists(ProductID);
        }

        public void Add(GroupProductModel model)
        {
            dal.Add(model);
        }

        public void Update(GroupProductModel model)
        {
            dal.Update(model);
        }

        public void Delete(int ProductID)
        {
            dal.Delete(ProductID);
        }

        public GroupProductModel GetModel(int ProductID)
        {
            return dal.GetModel(ProductID);
        }

        public DataTable GetList()
        {
            return dal.GetList();
        }

        public List<GroupProductModel> GetIList()
        {
            return dal.GetIList();
        }
    }
}
