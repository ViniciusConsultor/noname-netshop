using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class GiftOrderModel
    {
        #region Model
        private string _userid;
        private string _orderid;
        private OrderStatus _orderstatus;
        private ShipMethodType _shipmethod;
        private string _recievername;
        private string _recieveremail;
        private string _recieverphone;
        private string _postalcode;
        private string _recievercountry;
        private string _recievercity;
        private string _recieverprovince;
        private string _recievercounty;
        private string _addressdetial;
        private DateTime _changetime;
        private DateTime _createtime;
        private OrderType _ordertype;
        private string _serverip;
        private string _clientip;
        private string _usernotes;
        private int _totalscore;
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
        /// 0:生成 1：备货 2：发货 9：作废
        /// </summary>
        public OrderStatus OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
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
        public string RecieverCountry
        {
            set { _recievercountry = value; }
            get { return _recievercountry; }
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
        public string RecieverCounty
        {
            set { _recievercounty = value; }
            get { return _recievercounty; }
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
        public string UserNotes
        {
            set { _usernotes = value; }
            get { return _usernotes; }
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
