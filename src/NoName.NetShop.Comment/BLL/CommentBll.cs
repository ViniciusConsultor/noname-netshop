using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Comment.DAL;
using NoName.NetShop.Comment.Model;
using System.Data;

namespace NoName.NetShop.Comment.BLL
{
    public class CommentBll
    {
        private CommentDal dal = new CommentDal();

        public void Add(CommentModel model)
        {
            dal.Add(model);
        }

        public void Delete(int CommentID)
        {
            dal.Delete(CommentID);
        }

        public void Update(CommentModel model)
        {
            dal.Update(model);
        }

        public DataTable GetList(int AppType, int TargetID)
        {
            return dal.GetList(AppType, TargetID);
        }

        public CommentModel GetModel(int CommentID)
        {
            return dal.GetModel(CommentID);
        }
    }
}
