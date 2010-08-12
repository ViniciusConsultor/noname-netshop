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

        public void SetRecommend(int ProductID, bool IsRecommend)
        {
            dal.SetRecommend(ProductID,IsRecommend);
        }

        public void Freeze(int ProductID, int Status)
        {
            dal.Freeze(ProductID, Status);
        }

        public GroupProductModel GetModel(int ProductID)
        {
            return dal.GetModel(ProductID);
        }

        public DataTable GetList()
        {
            return dal.GetList();
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition, out RecordCount);
        }

        public List<GroupProductModel> GetIList()
        {
            return dal.GetIList();
        }

        public DataTable GetTopList(string Condition, string OrderType, int TopCount)
        {
            return dal.GetTopList(Condition, OrderType, TopCount);
        }

        public DataTable GetUserGroupList(int PageIndex, int PageSize, string UserID, out int RecordCount)
        {
            return dal.GetUserGroupList(PageIndex, PageSize, UserID, out RecordCount);
        }

    }
}
