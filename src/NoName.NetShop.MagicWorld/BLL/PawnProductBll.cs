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
    public class PawnProductBll
    {
        private PawnProductDal dal = new PawnProductDal();

        public void Add(PawnProductModel model)
        {
            dal.Add(model);
        }

        public void Delete(int PawnProductID)
        {
            dal.Delete(PawnProductID);
        }

        public void Update(PawnProductModel model)
        {
            dal.Update(model);
        }

        public void ChangeStatus(int PawnProductID, int Status)
        {
            dal.ChangeStatus(PawnProductID, Status);
        }

        public PawnProductModel GetModel(int PawnProductID)
        {
            return dal.GetModel(PawnProductID);
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = "";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "pawnproductid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 " + Condition;
            info.TableName = "mwpawnproduct";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }

        public DataTable GetNewestList(int TopCount, PawnProductStatus Status)
        {
            return dal.GetNewestList(TopCount,Status);
        }
    }
}
