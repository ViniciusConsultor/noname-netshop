﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Data.Common;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class CommShopCart : ShopCart
    {
        public CommShopCart(string key)
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
            StringBuilder sb = new StringBuilder(100);
            foreach (OrderProduct op in this.OrderProducts)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.AppendFormat(op.BuildCookieValue());
            }
            HttpCookie cookie = new HttpCookie(this.Key);
            cookie.Value = sb.ToString();
            cookie.HttpOnly = false;
            cookie.Expires = DateTime.Now.AddHours(2);
            return cookie;
        }


        /// <summary>
        /// 从cookie中恢复购物车
        /// cartkey=pid-ot-qua@p1-p2-p3;pid-ot-qua@p1-p2-p3
        /// </summary>
        public override void RevertCartFromCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[this.Key];
            if (cookie != null && !String.IsNullOrEmpty(cookie.Value))
            {
                string cartinfo = cookie.Value;
                string[] ops = cartinfo.Split(';');
                for (int i = 0; i < ops.Length; i++)
                {
                    string[] opinfo = ops[i].Split('@');
                    if (!String.IsNullOrEmpty(opinfo[0]))
                    {
                        string[] pq = opinfo[0].Split('-');

                        int productId = int.Parse(pq[0]);
                        OrderType optype = (OrderType)(int.Parse(pq[1]));
                        int quantity = int.Parse(pq[2]);

                        string[] para = null;

                        if (opinfo.Length == 2)
                        {
                            para = opinfo[1].Split('-');
                        }
                        else
                        {
                            para = new string[0];
                        }
                        this.AddToCart(optype, productId, quantity, para);
                    }
                }
            }
        }

        public override OrderProduct AddToCart(OrderType opType, int productId, int quantity, string[] paras)
        {
            NameValueCollection nv = OrderProductFactory.Instance().GetParasFromCookieValue(opType, paras);
            return this.AddToCart(opType,productId, quantity,  nv);
        }

        public override OrderProduct AddToCart(OrderType opType, int productId, int quantity, NameValueCollection paras)
        {
            int typecode;
            if (int.TryParse(paras["typecode"],out typecode))
            {
                typecode =0;
            }

            OrderProduct op = OrderProducts.Find(c => c.ProductID == productId && c.TypeCode == typecode);
            if (op == null)
            {
                op = OrderProductFactory.Instance().CreateOrderProduct(productId, quantity, opType, paras);
                op.Key = this.Key + "_op" + this.GetSerial();
                op.Container = this;
                this.ContinueShopUrl = op.ProductUrl;

                if (op != null)
                {
                    OrderProducts.Add(op);
                }
            }
            else
            {
                op.SetQuantiy(op.Quantity + quantity);
            }
            return op;
        }


        internal override string SaveOrderInfo()
        {
            string sql = "orders_Save_Comm";
            DbCommand comm = DBFacroty.DbWriter.GetStoredProcCommand(sql);

            if (!String.IsNullOrEmpty(this.OrderId) && this.Exists())
            {
                throw new NoName.NetShop.Common.ShopException("订单已经被存储过了");
            }
            else
            {
                this.OrderId = CommDataHelper.GetNewSerialStr(AppType.Order);

                DBFacroty.DbWriter.AddInParameter(comm, "OrderID", DbType.String, this.OrderId);
                DBFacroty.DbWriter.AddInParameter(comm, "PayMethod", DbType.Int32, PayMethodId);
                DBFacroty.DbWriter.AddInParameter(comm, "ShipMethod", DbType.Int32,ShipMethodId );
                DBFacroty.DbWriter.AddInParameter(comm, "PaySum", DbType.Decimal, TotalSum);
                DBFacroty.DbWriter.AddInParameter(comm, "ShipFee", DbType.Decimal, this.ShipFee);
                DBFacroty.DbWriter.AddInParameter(comm, "ProductFee", DbType.Decimal, ProductSum);
                DBFacroty.DbWriter.AddInParameter(comm, "DerateFee", DbType.Decimal, this.DerateFee);

                DBFacroty.DbWriter.AddInParameter(comm, "isNeedInvoice", DbType.Boolean, !String.IsNullOrEmpty(Invoice));
                DBFacroty.DbWriter.AddInParameter(comm, "InvoiceTitle", DbType.String, Invoice);
                DBFacroty.DbWriter.AddInParameter(comm, "UserNotes", DbType.String, UserNotes);
                DBFacroty.DbWriter.AddInParameter(comm, "serverip", DbType.String, ServerIp);
                DBFacroty.DbWriter.AddInParameter(comm, "ClientIp", DbType.String, ClientIp);

                DBFacroty.DbWriter.AddInParameter(comm, "OrderType", DbType.Int32, (int)OpType);

                DBFacroty.DbWriter.AddInParameter(comm, "userId", DbType.String, Address.UserId);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverName", DbType.String, Address.RecieverName);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverEmail", DbType.String, Address.Email);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverCountry", DbType.String, Address.Country);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverProvince", DbType.String, Address.Province);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverCity", DbType.String, Address.City);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverCounty", DbType.String, Address.County);
                DBFacroty.DbWriter.AddInParameter(comm, "RecieverPhone", DbType.String, (Address.Telephone + " " + Address.Mobile).Trim());

                DBFacroty.DbWriter.AddInParameter(comm, "AddressDetial", DbType.String, Address.AddressDetail);
                DBFacroty.DbWriter.AddInParameter(comm, "PostalCode", DbType.String, Address.Postalcode);
                DBFacroty.DbWriter.ExecuteNonQuery(comm);
                return this.OrderId;
            }

        }


        public override bool Exists()
        {
            bool result = false;
            if (!String.IsNullOrEmpty(this.OrderId))
            {
                string sql = "select count(*) from spOrder where orderid=@orderId";
                DbCommand comm = DBFacroty.DbReader.GetSqlStringCommand(sql);
                DBFacroty.DbReader.AddInParameter(comm, "orderId", DbType.String, this.OrderId);
                int retval = Convert.ToInt32(DBFacroty.DbReader.ExecuteScalar(comm));
                result = retval > 0;
            }
            return result;
        }


    }
}
