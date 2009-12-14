using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.DAL;
using NoName.NetShop.MagicWorld.Model;
using System.Data;

namespace NoName.NetShop.MagicWorld.BLL
{
    public class MagicCategoryBll
    {
        private MagicCategoryDal dal = new MagicCategoryDal();

        public void Add(MagicCategoryModel model)
        {
            dal.Add(model);
        }

        public void Update(MagicCategoryModel model)
        {
            dal.Update(model);
        }

        public void Delete(int CategoryID)
        {
            dal.Delete(CategoryID);
        }
        
        public void SwitchOrder(int OriginCateID, int SwitchCateID)
        {
            dal.SwitchOrder(OriginCateID, SwitchCateID);
        }

        public DataTable GetList(int ParentID)
        {
            return dal.GetList(ParentID);
        }

        public MagicCategoryModel GetModel(int CategoryID)
        {
            return dal.GetModel(CategoryID);
        }
    }
}
