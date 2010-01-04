using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class SecondhandProductModel
    {
        public SecondhandProductModel()
        { }
        

        private int _seproductid;
        private string _seproductname;
        private decimal _price;
        private int _cateid;
        private string _catepath;
        private int _stock;
        private string _smallimage;
        private string _mediumimage;
        private string _brief;
        private DateTime _inserttime;
        private DateTime _updatetime;
        private int _status;
        private int _sortvalue;
        private string _userid;
        private int _usagecondition;
        private string _truename;
        private string _phone;
        private string _cellphone;
        private string _postcode;
        private string _region;
        private string _address;
        /// <summary>
        /// 
        /// </summary>
        public int SecondhandProductID
        {
            set { _seproductid = value; }
            get { return _seproductid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondhandProductName
        {
            set { _seproductname = value; }
            get { return _seproductname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CateID
        {
            set { _cateid = value; }
            get { return _cateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CatePath
        {
            set { _catepath = value; }
            get { return _catepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Stock
        {
            set { _stock = value; }
            get { return _stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallImage
        {
            set { _smallimage = value; }
            get { return _smallimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MediumImage
        {
            set { _mediumimage = value; }
            get { return _mediumimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brief
        {
            set { _brief = value; }
            get { return _brief; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortValue
        {
            set { _sortvalue = value; }
            get { return _sortvalue; }
        }

        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public int UsageCondition
        {
            set { _usagecondition = value; }
            get { return _usagecondition; }
        }
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        public string CellPhone
        {
            set { _cellphone = value; }
            get { return _cellphone; }
        }
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        public string Region
        {
            set { _region = value; }
            get { return _region; }
        }
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
    }

    public enum SecondhandProductStatus
    {
        尚未审核 = 1,
        审核通过 = 2,
        审核未通过 = 3,
        冻结 = 4,
    }

    public enum SecondhandProductUsageCondition
    {
        全新 = 1,
        半年以内 = 2,
        使用一年 = 3,
        使用两年 = 4,
        两年以上 = 5,
    }
}
