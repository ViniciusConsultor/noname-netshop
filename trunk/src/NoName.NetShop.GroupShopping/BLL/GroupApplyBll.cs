using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.GroupShopping.DAL;
using NoName.NetShop.GroupShopping.Model;
using System.Data;

namespace NoName.NetShop.GroupShopping.BLL
{
    public class GroupApplyBll
    {
        private GroupApplyDal dal = new GroupApplyDal();

        public bool Exists(int GroupApplyID)
        {
            return dal.Exists(GroupApplyID);
        }

        public void Add(GroupApplyModel model)
        {
            dal.Add(model);
        }

        public void Update(GroupApplyModel model)
        {
            dal.Update(model);
        }

        public void Delete(int GroupApplyID)
        {
            dal.Delete(GroupApplyID);
        }

        public GroupApplyModel GetModel(int GroupApplyID)
        {
            return dal.GetModel(GroupApplyID);
        }

        public DataTable GetList(int ProductID)
        {
            return dal.GetList(ProductID);
        }

        public List<GroupApplyModel> GetIList(int ProductID)
        {
            return GetIList(ProductID);
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition, out RecordCount);
        }


        public void UpdateStatus(int ApplyID, int Status) 
        {
            dal.UpdateStatus(ApplyID,Status);
        }


        public int GetApplyCount(int ProductID)
        {
            return dal.GetApplyCount(ProductID);
        }
    }
}
