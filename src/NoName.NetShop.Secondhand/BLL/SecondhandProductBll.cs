using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Secondhand.DAL;
using NoName.NetShop.Secondhand.Model;
using System.Data;

namespace NoName.NetShop.Secondhand.BLL
{
    public class SecondhandProductBll
    {
        private SecondhandProductDal dal = new SecondhandProductDal();



        public void Add(SecondhandProductModel model)
        {
            dal.Add(model);
        }

        public void Delete(int SecondhandProductID)
        {
            dal.Delete(SecondhandProductID);
        }

        public void Update(SecondhandProductModel model)
        {
            dal.Update(model);
        }

        public SecondhandProductModel GetModel(int SecondhandProductID)
        {
            return dal.GetModel(SecondhandProductID);
        }

        public DataTable GetList()
        {
            return dal.GetList();
        }

        public bool Exists(int SecondhandProductID)
        {
            return dal.Exists(SecondhandProductID);
        }
    }
}
