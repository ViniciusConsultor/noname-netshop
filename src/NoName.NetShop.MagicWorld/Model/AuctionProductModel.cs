using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class AuctionProductModel
    {
        private int _AuctionID;
        private string _ProductName;
        private string _SmallImage;
        private string _MediumImage;
        private string _OutLinkUrl;
        private decimal _StartPrice;
        private string _AddPrices;
        private decimal _CurPrice;
        private string _Brief;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private int _Status;
        private int _CategoryID;
        private string _CategoryPath;
        private string _UserID;
        private string _TrueName;
        private string _Phone;
        private string _CellPhone;
        private string _PostCode;
        private string _Region;
        private string _Address;
        private DateTime _InsertTime;
        private DateTime _UpdateTime;

        public int AuctionID
        {
            get { return _AuctionID; }
            set { _AuctionID = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string SmallImage
        {
            get { return _SmallImage; }
            set { _SmallImage = value; }
        }
        public string MediumImage
        {
            get { return _MediumImage; }
            set { _MediumImage = value; }
        }
        public string OutLinkUrl
        {
            get { return _OutLinkUrl; }
            set { _OutLinkUrl = value; }
        }
        public decimal StartPrice
        {
            get { return _StartPrice; }
            set { _StartPrice = value; }
        }
        public string AddPrices
        {
            get { return _AddPrices; }
            set { _AddPrices = value; }
        }
        public decimal CurPrice
        {
            get { return _CurPrice; }
            set { _CurPrice = value; }
        }
        public string Brief
        {
            get { return _Brief; }
            set { _Brief = value; }
        }
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string CategoryPath
        {
            get { return _CategoryPath; }
            set { _CategoryPath = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string TrueName
        {
            get { return _TrueName; }
            set { _TrueName = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode = value; }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public DateTime InsertTime
        {
            get { return _InsertTime; }
            set { _InsertTime = value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }
    }
    public enum AuctionProductStatus
    {
        尚未审核 = 1,
        审核通过 = 2,
        审核未通过 = 3,
        冻结 = 4,
    }
}
