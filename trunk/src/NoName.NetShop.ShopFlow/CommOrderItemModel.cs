using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class CommOrderItemModel
    {
        #region Model
        private string _orderid;
        private int _productid;
        private int _typecode;
        private int _quantity;
        private decimal _productsum;
        private string _typeinfo;
        private int _score;
        private decimal _factprice;
        private decimal _merchantprice;
        private decimal _tradeprice;
        private decimal _reduceprice;
        public string ProductName{get;set;}

        /// <summary>
        /// 
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeCode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ProductSum
        {
            set { _productsum = value; }
            get { return _productsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeInfo
        {
            set { _typeinfo = value; }
            get { return _typeinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FactPrice
        {
            set { _factprice = value; }
            get { return _factprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MerchantPrice
        {
            set { _merchantprice = value; }
            get { return _merchantprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TradePrice
        {
            set { _tradeprice = value; }
            get { return _tradeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ReducePrice
        {
            set { _reduceprice = value; }
            get { return _reduceprice; }
        }
        #endregion Model


    }
}
