using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.PawnShop.DAL;
using NoName.NetShop.PawnShop.Model;

namespace NoName.NetShop.PawnShop.BLL
{
    public class PawnProductModelBll
    {
        private PawnProductModelDal dal = new PawnProductModelDal();

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
            info.TableName = "pwpawnproduct";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }
    }
}