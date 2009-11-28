using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace NoName.NetShop.ShopFlow
{
    public abstract class OrderProduct
    {
        #region 私有成员
        private string key;
        public string OrderId { get; set; }
        protected int _productid;
        protected int _typeCode { get; set; }
        protected string _typeInfo { get; set; }

        protected string _productname;
        protected string _producturl;
        protected string _productimg;
        protected string _catepath;

        protected decimal _tradePrice = 0.00M;
        protected decimal _merchantPrice = 0.00M;
        protected decimal _reducePrice = 0.00m;

        protected int _stock = 0;
        protected int _score; // 积分
        protected int _quantity;
        protected OrderType _producttype;  // 对应orderType

        public ShopCart Container { get; set; }

        /// <summary>
        /// 商品积分（单件商品）
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        /// <summary>
        /// 商品总积分
        /// </summary>
        public int TotalScore
        {
            get { return _score * _quantity; }
        }

        /// <summary>
        /// 订单商品键值
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }

        /// <summary>
        /// 商品的url地址，置为可修改，是为了满足定制商品的需要
        /// </summary>
        public string ProductUrl
        {
            set { _producturl = value; }
            get { return _producturl; }
        }
        /// <summary>
        /// 商品的图片地址，置为可修改，是为了满足定制商品的需要
        /// </summary>
        public string ProductImg
        {
            set { _productimg = value; }
            get { return _productimg; }
        }

        /// <summary>
        /// 商品的分类路径
        /// </summary>
        public string CatePath
        {
            get { return _catepath; }
            set { _catepath = value; }
        }

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal TradePrice
        {
            get { return _tradePrice; }
            set { _tradePrice = value; }
        }

        /// <summary>
        /// 商户价，置为可修改，是为了满足定制商品调价使用
        /// </summary>
        public decimal MerchantPrice
        {
            set { _merchantPrice = value; }
            get { return _merchantPrice; }
        }

        /// <summary>
        /// 直降价格
        /// </summary>
        public decimal ReducePrice
        {
            set { _reducePrice = value; }
            get { return _reducePrice; }
        }

        /// <summary>
        /// 商品实际单件
        /// </summary>
        public decimal FactPrice
        {
            get { return _merchantPrice - _reducePrice; }
        }

        /// <summary>
        /// 商品目前的库存
        /// </summary>
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        /// <summary>
        /// 当前购物车此商品的数量
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
        }


        /// <summary>
        /// 商品类型，跟订单有关
        /// </summary>
        public OrderType ProductType
        {
            get { return _producttype; }
            set { _producttype = value; }
        }

        /// <summary>
        /// 商品的一些附属选择信息，比如尺寸、颜色等
        /// </summary>
        public string TypeInfo
        {
            set { _typeInfo = value; }
            get { return _typeInfo; }
        }

        public int TypeCode
        {
            get { return _typeCode; }
            set { _typeCode = value; }
        }

        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal ProductSum
        {
            get { return FactPrice * _quantity; }
        }

        /// <summary>
        /// 商品市场价
        /// </summary>
        public decimal TradeSum
        {
            get { return _tradePrice * _quantity; }
        }


        public void SetQuantiy(int quantity)
        {
            if (quantity <= 0)
            {
                Container.OrderProducts.Remove(this);
            }
            else
            {
                _quantity = _stock > quantity ? quantity : _stock;
            }
        }
        #endregion 属性

        /// <summary>
        /// 从外部传入的参数来构造订单商品
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="productId"></param>
        /// <param name="opType"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public abstract OrderProduct CreateOrderProduct(int productId,int quantity, OrderType opType, NameValueCollection paras);
        /// <summary>
        /// 将订单商品信息存储如cookie中
        /// </summary>
        /// <returns></returns>
        public abstract string BuildCookieValue();

        /// <summary>
        /// 把Cookie中的商品参数字符串转换为NameValueCollection
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public abstract NameValueCollection GetParasFromCookieValue(string[] paras);

        internal abstract void Save();
    }
}
