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

        public bool HasChild(int CategoryID)
        {
            return dal.HasChild(CategoryID);
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

        public string GetNamePath(int CategoryID)
        {
            string CatePath = GetPath(CategoryID);

            if (CatePath.Contains("/"))
            {
                string NamePath = String.Empty;
                foreach (string ID in CatePath.Split('/'))
                {
                    NamePath += "/"+GetModel(Convert.ToInt32(ID)).CateName;
                }
                return NamePath.Substring(1);
            }
            else
            {
                return GetModel(CategoryID).CateName;
            }
        }

        public DataTable GetPathList(int CategoryID)
        {
            return dal.GetPathList(CategoryID);
        }


        public string GetPath(int CategoryID)
        {
            return dal.GetPath(CategoryID);
        }
    }
}

