﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Comment;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.Comment
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

        public DataTable GetList(string AppType, int TargetID)
        {
            return dal.GetList(AppType, TargetID);
        }

        public CommentModel GetModel(int CommentID)
        {
            return dal.GetModel(CommentID);
        }

        public DataTable GetList(int PageIndex,int PageSize,  string TableFields, string AppType, string JoinStr, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize,TableFields, AppType,JoinStr, out RecordCount);
        }
    }
}
