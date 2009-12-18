using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class GiftOrderItemModel
    {
        public GiftOrderItemModel()
        { }
        #region Model
        private string _orderid;
        private int _productid;
        private int _quantity;
        private int _score;
        private int _totalscore;
        public string ProductName { get; set; }
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
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
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
        public int TotalScore
        {
            set { _totalscore = value; }
            get { return _totalscore; }
        }
        #endregion Model

    }
}
