using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace NoName.NetShop.ShopFlow
{
    public abstract class OrderProduct
    {
        #region ˽�г�Ա
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
        protected int _score; // ����
        protected int _quantity;
        protected OrderType _producttype;  // ��ӦorderType

        public ShopCart Container { get; set; }

        /// <summary>
        /// ��Ʒ���֣�������Ʒ��
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        /// <summary>
        /// ��Ʒ�ܻ���
        /// </summary>
        public int TotalScore
        {
            get { return _score * _quantity; }
        }

        /// <summary>
        /// ������Ʒ��ֵ
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// ��ƷID
        /// </summary>
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }

        /// <summary>
        /// ��Ʒ��url��ַ����Ϊ���޸ģ���Ϊ�����㶨����Ʒ����Ҫ
        /// </summary>
        public string ProductUrl
        {
            set { _producturl = value; }
            get { return _producturl; }
        }
        /// <summary>
        /// ��Ʒ��ͼƬ��ַ����Ϊ���޸ģ���Ϊ�����㶨����Ʒ����Ҫ
        /// </summary>
        public string ProductImg
        {
            set { _productimg = value; }
            get { return _productimg; }
        }

        /// <summary>
        /// ��Ʒ�ķ���·��
        /// </summary>
        public string CatePath
        {
            get { return _catepath; }
            set { _catepath = value; }
        }

        /// <summary>
        /// �г���
        /// </summary>
        public decimal TradePrice
        {
            get { return _tradePrice; }
            set { _tradePrice = value; }
        }

        /// <summary>
        /// �̻��ۣ���Ϊ���޸ģ���Ϊ�����㶨����Ʒ����ʹ��
        /// </summary>
        public decimal MerchantPrice
        {
            set { _merchantPrice = value; }
            get { return _merchantPrice; }
        }

        /// <summary>
        /// ֱ���۸�
        /// </summary>
        public decimal ReducePrice
        {
            set { _reducePrice = value; }
            get { return _reducePrice; }
        }

        /// <summary>
        /// ��Ʒʵ�ʵ���
        /// </summary>
        public decimal FactPrice
        {
            get { return _merchantPrice - _reducePrice; }
        }

        /// <summary>
        /// ��ƷĿǰ�Ŀ��
        /// </summary>
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        /// <summary>
        /// ��ǰ���ﳵ����Ʒ������
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
        }


        /// <summary>
        /// ��Ʒ���ͣ��������й�
        /// </summary>
        public OrderType ProductType
        {
            get { return _producttype; }
            set { _producttype = value; }
        }

        /// <summary>
        /// ��Ʒ��һЩ����ѡ����Ϣ������ߴ硢��ɫ��
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
        /// ��Ʒ�ܼ�
        /// </summary>
        public decimal ProductSum
        {
            get { return FactPrice * _quantity; }
        }

        /// <summary>
        /// ��Ʒ�г���
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
        #endregion ����

        /// <summary>
        /// ���ⲿ����Ĳ��������충����Ʒ
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="productId"></param>
        /// <param name="opType"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public abstract OrderProduct CreateOrderProduct(int productId,int quantity, OrderType opType, NameValueCollection paras);
        /// <summary>
        /// ��������Ʒ��Ϣ�洢��cookie��
        /// </summary>
        /// <returns></returns>
        public abstract string BuildCookieValue();

        /// <summary>
        /// ��Cookie�е���Ʒ�����ַ���ת��ΪNameValueCollection
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public abstract NameValueCollection GetParasFromCookieValue(string[] paras);

        internal abstract void Save();
    }
}
