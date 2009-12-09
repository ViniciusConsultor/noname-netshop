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
        private int _CateID;
        private string _CatePath;
        private string _UserName;

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
        public int CateID
        {
            get { return _CateID; }
            set { _CateID = value; }
        }
        public string CatePath
        {
            get { return _CatePath; }
            set { _CatePath = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
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
