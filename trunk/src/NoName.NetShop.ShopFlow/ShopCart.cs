using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public abstract class ShopCart : BaseCart
    {
        private List<OrderProduct> _orderProducts = new List<OrderProduct>();
        public string OrderId { get; set; }
        public string RecentSavedOrderId { get; set; }
        public ShopCart Container { get; set; }
        private string key;
        public NoName.NetShop.Member.Model.AddressModel Address { get; set; }

        private OrderType _opType;
        private decimal shipFee;
        public decimal DerateFee { get; set; }
        public int ShipMethodId { get; set; }
        public string ShipMethodName { get; set; }
        public int RegionId { get; set; }
        public int PayMethodId { get; set; }
        public string PayMethodName { get; set; }
        public string Invoice { get; set; }
        public string UserNotes { get; set; }

        public string ServerIp { get; set; }
        public string ClientIp { get; set; }
        public string UserId { get; set; }
        public abstract OrderProduct AddToCart(OrderType opType, int productId, int quantity, NameValueCollection paras);
        public abstract OrderProduct AddToCart(OrderType opType, int productId, int quantity, string[] paras);
        protected abstract HttpCookie BuildCartCookie();
        public abstract void RevertCartFromCookie();
        public abstract bool Exists();

        public void RemoveCartCookie()
        {
            HttpContext.Current.Response.Cookies.Remove(this.Key);
        }

        public void SaveCartToCookie()
        {
            HttpCookie cookie = BuildCartCookie();
            if (cookie != null)
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }


        /// <summary>
        /// 继续购物URL，添加为最近放入购物车的商品url
        /// </summary>
        public string ContinueShopUrl { get; set; }

        #region 成员变量


        public List<OrderProduct> OrderProducts
        {
            get
            {
                return _orderProducts;
            }
        }

        public OrderType OpType
        {
            get
            {
                return _opType;
            }
            set
            {
                _opType = value;
            }
        }
        #endregion

        #region 属性

        /// <summary>
        ///  商品总计金额
        /// </summary>
        public decimal ProductSum
        {
            get
            {
                return (from s in OrderProducts
                        select s.ProductSum).Sum();
            }
        }

        /// <summary>
        /// 订单中商品总重量
        /// </summary>
        public decimal TotalWeight
        {
            get
            {
                return (from s in OrderProducts select s.Weight).Sum();
            }
        }

        /// <summary>
        /// 总积分
        /// </summary>
        public int TotalScore
        {
            get
            {
                return (from s in OrderProducts select s.TotalScore).Sum();
            }
        }
        /// <summary>
        /// 购物车中订单商品种类的数量
        /// </summary>
        public int ProductNum
        {
            get
            {
                return OrderProducts.Count;
            }
        }

        /// <summary>
        /// 购物车中订单商品的数量
        /// </summary>
        public int ProductQuantity
        {
            get
            {
                return (from s in OrderProducts select s.Quantity).Sum();
            }
        }

        public decimal ShipFee
        {
            get { return shipFee; }
            set { shipFee = value; }
        }


        /// <summary>
        /// 订单合计金额：商品总额 + 配送费用 - 优惠费用
        /// </summary>
        public decimal TotalSum
        {
            get { return ProductSum + ShipFee - DerateFee; }
        }


        #endregion


        public void Save()
        {
            if (PreSaveValidate())
            {
                string orderId = SaveOrderInfo();
                foreach (OrderProduct op in this.OrderProducts)
                {
                    op.OrderId = orderId;
                    op.Save();
                }
                this.OrderId = orderId;
            }
        }

        public virtual bool PreSaveValidate()
        {
            if (this.OrderProducts.Count == 0) return false;
            if (this.Address == null) return false;
            if (this.ShipMethodId == 0) return false;
            return true;
        }

        internal abstract string SaveOrderInfo();

        internal OrderProduct GetOrderProduct(string key)
        {
            return _orderProducts.Find(c => c.Key == key);
        }


        #region 支付配送相关操作
        /// <summary>
        /// 选择配送区域
        /// </summary>
        /// <param name="addressId"></param>
        public void SetShipRegion(int addressId)
        {
            this.RegionId = addressId;
            this.ShipMethodId = 0;
        }

        /// <summary>
        /// 选择配送方式
        /// </summary>
        /// <param name="shipId"></param>
        public void SetShipMethod(int shipId)
        {
            this.ShipMethodId = shipId;
            //this.ShipMethodName = ShipPayHelper.GetShipMethod()[shipId];
        }

        /// <summary>
        /// 选择支付方式
        /// </summary>
        /// <param name="paymentId"></param>
        public void SetPayment(int paymentId)
        {
            this.PayMethodId = paymentId;
            //this.PayMethodName = ShipPayHelper.GetPayMethod()[paymentId];
        }
        #endregion

    }
}
