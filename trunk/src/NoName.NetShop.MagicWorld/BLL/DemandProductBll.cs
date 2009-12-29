using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.DAL;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.MagicWorld.BLL
{
    public class DemandProductBll
    {
        private DemandProductDal dal = new DemandProductDal();

        
        public void Add(DemandProductModel model)
        {
            dal.Add(model);
        }

        
        public void Update(DemandProductModel model)
        {
            dal.Update(model);
        }

        public void Delete(int DemandID)
        {
            dal.Delete(DemandID);
        }

        public DemandProductModel GetModel(int DemandID)
        {
            return dal.GetModel(DemandID);
        }
    }
}
