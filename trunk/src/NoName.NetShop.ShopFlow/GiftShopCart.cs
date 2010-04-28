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

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class GiftShopCart : ShopCart
    {
        public GiftShopCart(string key)
        {
            this.SetSteps(key);
            //RevertCartFromCookie();
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
            int typecode;
            if (!int.TryParse(paras["typecode"],out typecode))
            {
                typecode =0;
            }

            ShopIdentity user = HttpContext.Current.User.Identity as ShopIdentity;
            MemberInfo member = MemberInfo.GetBaseInfo(user.UserId);

            OrderProduct op = OrderProducts.Find(c => c.ProductID == productId && c.TypeCode == typecode);
            if (op == null)
            {
                op = OrderProductFactory.Instance().CreateOrderProduct(productId, quantity, opType, paras);
                op.Key = this.Key + "_op" + this.GetSerial();
                op.Container = this;
                this.ContinueShopUrl = op.ProductUrl;


                if (op != null)
                {
                    if (this.TotalScore + op.TotalScore <= member.CurScore)
                        OrderProducts.Add(op);
                    else
                        op = null;
                }
            }
            else
            {
                int oldQuantity = op.Quantity;
                op.SetQuantiy(op.Quantity + quantity);
                if (this.TotalScore > member.CurScore)
                {
                    op.SetQuantiy(oldQuantity);
                }
            }
            return op;
        }


        internal override string SaveOrderInfo()
        {
            string sql = "orders_Save_gift";
            DbCommand comm = CommDataAccess.DbWriter.GetStoredProcCommand(sql);

            if (!String.IsNullOrEmpty(this.OrderId) && this.Exists())
            {
                throw new NoName.NetShop.Common.ShopException("订单已经被存储过了");
            }
            else
            {
                this.OrderId = CommDataHelper.GetNewSerialStr(AppType.Order);

                CommDataAccess.DbWriter.AddInParameter(comm, "userId", DbType.String, Address.UserId);
                CommDataAccess.DbWriter.AddInParameter(comm, "OrderID", DbType.String, this.OrderId);

                CommDataAccess.DbWriter.AddInParameter(comm, "ShipMethod", DbType.Int32,ShipMethodId );
                CommDataAccess.DbWriter.AddInParameter(comm, "TotalScore", DbType.Int32, TotalScore);

                CommDataAccess.DbWriter.AddInParameter(comm, "UserNotes", DbType.String, UserNotes);
                CommDataAccess.DbWriter.AddInParameter(comm, "serverip", DbType.String, ServerIp);
                CommDataAccess.DbWriter.AddInParameter(comm, "ClientIp", DbType.String, ClientIp);

                CommDataAccess.DbWriter.AddInParameter(comm, "OrderType", DbType.Int32, (int)OpType);

                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverName", DbType.String, Address.RecieverName);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverEmail", DbType.String, Address.Email);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCountry", DbType.String, Address.Country);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverProvince", DbType.String, Address.Province);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCity", DbType.String, Address.City);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverCounty", DbType.String, Address.County);
                CommDataAccess.DbWriter.AddInParameter(comm, "RecieverPhone", DbType.String, (Address.Telephone + " " + Address.Mobile).Trim());
                CommDataAccess.DbWriter.AddInParameter(comm, "AddressDetial", DbType.String, Address.AddressDetail);
                CommDataAccess.DbWriter.AddInParameter(comm, "PostalCode", DbType.String, Address.Postalcode);
                CommDataAccess.DbWriter.ExecuteNonQuery(comm);

                MemberInfo.LogScore(Address.UserId, NoName.NetShop.Common.ScoreType.Gift, -this.TotalScore,this.OrderId, "积分礼品兑换订单生成");
                return this.OrderId;
            }

        }


        public override bool Exists()
        {
            bool result = false;
            if (!String.IsNullOrEmpty(this.OrderId))
            {
                string sql = "select count(*) from spGiftOrder where orderid=" + this.OrderId;
                DbCommand comm = CommDataAccess.DbReader.GetSqlStringCommand(sql);
                CommDataAccess.DbReader.AddInParameter(comm, "orderId", DbType.String, this.OrderId);
                int retval = Convert.ToInt32(CommDataAccess.DbReader.ExecuteScalar(comm));
                result = retval > 0;
            }
            return result;
        }

        public override decimal CaculateShipFee(int shipId, int regionId)
        {
            return 0m;
        }

    }
}
