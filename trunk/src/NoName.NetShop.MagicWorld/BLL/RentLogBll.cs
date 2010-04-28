using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.DAL;
using NoName.NetShop.MagicWorld.Model;
using System.Data;

namespace NoName.NetShop.MagicWorld.BLL
{
    public class RentLogBll
    {
        private RentLogDal dal = new RentLogDal();

        public void Add(RentLogModel model)
        {
            dal.Add(model);
        }

        public void Delete(int RentLogID)
        {
            dal.Delete(RentLogID);
        }

        public void Update(RentLogModel model)
        {
            dal.Update(model);
        }
        public void UpdateStatus(int RentLogID, int Status)
        {
            dal.UpdateStatus(RentLogID, Status);
        }

        public RentLogModel GetModel(int RentID, string UserID)
        {
            return dal.GetModel(RentID, UserID);
        }

        public RentLogModel GetModel(int RentLogID)
        {
            return dal.GetModel(RentLogID);
        }

        public int GetLogCount(int RentID)
        {
            return dal.GetLogCount(RentID);
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition, out RecordCount);
        }

        public DataTable GetListOfProduct(int PageIndex, int PageSize, int RentID, out int RecordCount)
        {
            return dal.GetListOfProduct(PageIndex, PageSize, RentID, out RecordCount);
        }

        public DataTable GetListOfUser(int PageIndex, int PageSize, string UserID, out int RecordCount)
        {
            return dal.GetListOfUser(PageIndex, PageSize, UserID, out RecordCount);
        }
    }
}
