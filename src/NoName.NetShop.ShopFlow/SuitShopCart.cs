using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Data.Common;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Member;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;

namespace NoName.NetShop.ShopFlow
{
    public class SuitShopCart:ShopCart
    {
        private int _score;
        public int SuitId { get; set; }

        public SuitShopCart(string key)
        {
            this.SetSteps(key);
            RevertCartFromCookie();
        }

        /// <summary>
        /// 把购物车数据转为HttpCookie，用于在客户端持久存储购物车数据
        /// cartkey=pid-ot-qua@p1-p2-p3;pid-ot-qua@p1-p2-p3
        /// 参数p1…pn，中不能包括的字符有：:-;@#
        /// </summary>
        /// <returns></returns>
        protected override HttpCookie BuildCartCookie()
        {
            return null;
        }


        /// <summary>
        /// 从cookie中恢复购物车
        /// cartkey=pid-ot-qua@p1-p2-p3;pid-ot-qua@p1-p2-p3
        /// </summary>
        public override void RevertCartFromCookie()
        {
        }

        public override OrderProduct AddToCart(OrderType opType, int productId, int quantity, string[] paras)
        {
            NameValueCollection nv = OrderProductFactory.Instance().GetParasFromCookieValue(opType, paras);
            return this.AddToCart(opType,productId, quantity,  nv);
        }

        public override OrderProduct AddToCart(OrderType opType, int productId, int quantity, NameValueCollection paras)
        {
            SuitId = productId;
            int typecode;
            if (int.TryParse(paras["typecode"],out typecode))
            {
                typecode =0;
            }

            NoName.NetShop.Solution.BLL.SuiteBll sbll = new SuiteBll();
            SolutionProductBll spbll = new SolutionProductBll();

            SuiteModel smodel = sbll.GetModel(SuitId);

            List<SolutionProductModel> list = spbll.GetModelList(SuitId);

            this.OrderProducts.Clear();
            foreach (SolutionProductModel model in list)
            {
                OrderProduct op = OrderProductFactory.Instance().CreateOrderProduct(model.ProductId, model.Quantity, opType, paras);
                op.Key = this.Key + "_op" + this.GetSerial();
                op.Container = this;
                if (op != null)
                {
                    OrderProducts.Add(op);
                }
            }
            this.DerateFee = this.ProductSum - smodel.Price;
            _score = smodel.Score;

            return null;
       }

        public new int TotalScore
        {
            get { return _score; }
        }



        internal override string SaveOrderInfo()
        {
            string sql = "orders_Save_Suit";
            DbCommand comm = CommDataAccess.DbWriter.GetStoredProcCommand(sql);

            if (!String.IsNullOrEmpty(this.OrderId) && this.Exists())
            {
                throw new NoName.NetShop.Common.ShopException("订单已经被存储过了");
            }
            else
            {
                this.OrderId = CommDataHelper.GetNewSerialStr(AppType.Order);

                CommDataAccess.DbWriter.AddInParameter(comm, "OrderID", DbType.String, this.OrderId);
                CommDataAccess.DbWriter.AddInParameter(comm, "PayMethod", DbType.Int32, PayMethodId);
                CommDataAccess.DbWriter.AddInParameter(comm, "ShipMethod", DbType.Int32,ShipMethodId );
                CommDataAccess.DbWriter.AddInParameter(comm, "PaySum", DbType.Decimal, TotalSum);
                CommDataAccess.DbWriter.AddInParameter(comm, "ShipFee", DbType.Decimal, this.ShipFee);
                CommDataAccess.DbWriter.AddInParameter(comm, "ProductFee", DbType.Decimal, ProductSum);
                CommDataAccess.DbWriter.AddInParameter(comm, "DerateFee", DbType.Decimal, this.DerateFee);

                CommDataAccess.DbWriter.AddInParameter(comm, "isNeedInvoice", DbType.Boolean, !String.IsNullOrEmpty(Invoice));
                CommDataAccess.DbWriter.AddInParameter(comm, "InvoiceTitle", DbType.String, Invoice);
                CommDataAccess.DbWriter.AddInParameter(comm, "UserNotes", DbType.String, UserNotes);
                CommDataAccess.DbWriter.AddInParameter(comm, "serverip", DbType.String, ServerIp);
                CommDataAccess.DbWriter.AddInParameter(comm, "ClientIp", DbType.String, ClientIp);

                CommDataAccess.DbWriter.AddInParameter(comm, "OrderType", DbType.Int32, (int)OpType);

                CommDataAccess.DbWriter.AddInParameter(comm, "userId", DbType.String, Address.UserId);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverName", DbType.String, Address.RecieverName);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverEmail", DbType.String, Address.Email);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCountry", DbType.String, Address.Country);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverProvince", DbType.String, Address.Province);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCity", DbType.String, Address.City);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCounty", DbType.String, Address.County);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverPhone", DbType.String, (Address.Telephone + " " + Address.Mobile).Trim());

                CommDataAccess.DbWriter.AddInParameter(comm, "AddressDetial", DbType.String, Address.AddressDetail);
                CommDataAccess.DbWriter.AddInParameter(comm, "PostalCode", DbType.String, Address.Postalcode);
                CommDataAccess.DbWriter.AddInParameter(comm, "SuitId", DbType.Int32, this.SuitId);
                CommDataAccess.DbWriter.ExecuteNonQuery(comm);
                return this.OrderId;
            }

        }


        public override bool Exists()
        {
            bool result = false;
            if (!String.IsNullOrEmpty(this.OrderId))
            {
                string sql = "select count(*) from spOrder where orderid=@orderId";
                DbCommand comm = CommDataAccess.DbReader.GetSqlStringCommand(sql);
                CommDataAccess.DbReader.AddInParameter(comm, "orderId", DbType.String, this.OrderId);
                int retval = Convert.ToInt32(CommDataAccess.DbReader.ExecuteScalar(comm));
                result = retval > 0;
            }
            return result;
        }

        private decimal GetExpressShipFee()
        {
            return GetExpressShipFee(this.Address.UserId, this.Address.RegionId, this.ProductSum);
        }

        private decimal GetExpressShipFee(string userId,int regionId,decimal productFee)
        {
            string sql = "UP_unExpressInfo_GetShipFee";

            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(sql);
            CommDataAccess.DbReader.AddInParameter(comm, "userId", DbType.String, userId);
            CommDataAccess.DbReader.AddInParameter(comm, "RegionId", DbType.Int32, regionId);
            CommDataAccess.DbReader.AddInParameter(comm, "productfee", DbType.Decimal, productFee);
            CommDataAccess.DbReader.AddOutParameter(comm, "ShipFee", DbType.Decimal, 8);

            CommDataAccess.DbReader.ExecuteNonQuery(comm);
            object result = CommDataAccess.DbReader.GetParameterValue(comm, "ShipFee");
            return Convert.ToDecimal(result);
        }

        public decimal CaculateShipFee(int shipId,int regionId)
        {
            decimal result = 0m;
            switch (shipId)
            {
                case 1: // 自提
                    result = 0m;
                    break;
                case 2: // EMS
                    result = 22 + (TotalWeight<= 500? 0: (Math.Ceiling(TotalWeight / 500) - 1) * 20);
                    break;
                case 3: // 中铁快运
                    result = 40 + (TotalWeight <= 6000 ? 0 : (Math.Ceiling(TotalWeight / 1000) - 6) * 2.8m);
                    break;
                case 4: // 快递
                    result = GetExpressShipFee(this.UserId,regionId,ProductSum);
                    if (result == -1)
                        goto case 2;
                    break;
            }
            return result;
        }

    }
}
