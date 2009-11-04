using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.News.DAL;
using NoName.NetShop.News.Model;
using System.Data;

namespace NoName.NetShop.News.BLL
{
    public class NewsCategoryModelBll
    {
        private NewsCategoryModelDal dal = new NewsCategoryModelDal();

        public void Add(NewsCategoryModel Model)
        {
            dal.Add(Model);
        }

        public void Delete(int CategoryID)
        {
            dal.Delete(CategoryID);
        }

        public void Update(NewsCategoryModel Model)
        {
            dal.Update(Model);
        }

        public bool Exists(int CategoryID)
        {
            return dal.Exists(CategoryID);
        }

        public DataTable GetList(int ParentID)
        {
            return dal.GetList(ParentID);
        }

        public NewsCategoryModel GetModel(int CateID)
        {
            return dal.GetModel(CateID);
        }
    }
}
