using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.DAL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.Common;
using System.Data;

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

        public void UpdateStatus(int DemandID, int Status)
        {
            dal.UpdateStatus(DemandID, Status); 
        }

        public DemandProductModel GetModel(int DemandID)
        {
            return dal.GetModel(DemandID);
        }


        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = " demandid desc";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "demandid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 " + Condition;
            info.TableName = "mwDemand";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }
    }
}
