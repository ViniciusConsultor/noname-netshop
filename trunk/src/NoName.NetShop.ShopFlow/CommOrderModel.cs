using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public class CommOrderModel
    {
        #region Model
        private string _userid;
        private string _orderid;
        private OrderStatus _orderstatus;
        private PayMethType _paymethod;
        private ShipMethodType _shipmethod;
        private PayStatus _paystatus;
        private decimal _paysum;
        private decimal _shipfee;
        private decimal _productfee;
        private decimal _deratefee;
        private string _recievername;
        private string _recieveremail;
        private string _recieverphone;
        private string _postalcode;
        private string _recievercity;
        private string _recieverprovince;
        private string _addressdetial;
        private DateTime _changetime;
        private DateTime? _paytime;
        private DateTime _createtime;
        private OrderType _ordertype;
        private string _serverip;
        private string _clientip;
        private string _invoicetitle;
        private bool _isneedinvoice;
        private string _usernotes;
        private string _recievercountry;
        private string _recievercounty;
        private string _payorderId;
        private bool _isTotalFeeAdjust;

        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
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
        public OrderStatus OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PayMethType PayMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ShipMethodType ShipMethod
        {
            set { _shipmethod = value; }
            get { return _shipmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PayStatus PayStatus
        {
            set { _paystatus = value; }
            get { return _paystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Paysum
        {
            set { _paysum = value; }
            get { return _paysum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ShipFee
        {
            set { _shipfee = value; }
            get { return _shipfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ProductFee
        {
            set { _productfee = value; }
            get { return _productfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DerateFee
        {
            set { _deratefee = value; }
            get { return _deratefee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverName
        {
            set { _recievername = value; }
            get { return _recievername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverEmail
        {
            set { _recieveremail = value; }
            get { return _recieveremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverPhone
        {
            set { _recieverphone = value; }
            get { return _recieverphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Postalcode
        {
            set { _postalcode = value; }
            get { return _postalcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverCity
        {
            set { _recievercity = value; }
            get { return _recievercity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverProvince
        {
            set { _recieverprovince = value; }
            get { return _recieverprovince; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddressDetial
        {
            set { _addressdetial = value; }
            get { return _addressdetial; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public OrderType OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServerIp
        {
            set { _serverip = value; }
            get { return _serverip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClientIp
        {
            set { _clientip = value; }
            get { return _clientip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceTitle
        {
            set { _invoicetitle = value; }
            get { return _invoicetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNeedInvoice
        {
            set { _isneedinvoice = value; }
            get { return _isneedinvoice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserNotes
        {
            set { _usernotes = value; }
            get { return _usernotes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverCountry
        {
            set { _recievercountry = value; }
            get { return _recievercountry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecieverCounty
        {
            set { _recievercounty = value; }
            get { return _recievercounty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayorderId
        {
            set { _payorderId = value; }
            get { return _payorderId; }
        }        /// <summary>
        /// 
        /// </summary>
        public bool IsTotalFeeAdjust
        {
            set { _isTotalFeeAdjust = value; }
            get { return _isTotalFeeAdjust; }
        }
        
        #endregion Model

    }
}
