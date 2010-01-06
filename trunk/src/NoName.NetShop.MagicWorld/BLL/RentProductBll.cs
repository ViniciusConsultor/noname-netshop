using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.DAL;
using NoName.NetShop.MagicWorld.Model;
using System.Data;

namespace NoName.NetShop.MagicWorld.BLL
{
    public class RentProductBll
    {
        private RentProductDal dal = new RentProductDal();
        
        public void Add(RentProductModel model)
        {
            dal.Add(model);
        }

        public void Delete(int RentID)
        {
            dal.Delete(RentID);
        }

        public void Update(RentProductModel model)
        {
            dal.Update(model);
        }

        public RentProductModel GetModel(int RentID)
        {
            return dal.GetModel(RentID);
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition,string Order, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition,Order, out RecordCount);
        }
    }
}
