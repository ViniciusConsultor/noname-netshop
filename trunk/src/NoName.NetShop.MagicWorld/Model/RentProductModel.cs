using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class RentProductModel
    {
        private int _RentID;
        private string _RentName;
        private string _SmallImage;
        private string _MediumImage;
        private int _Stock;
        private string _Keywords;
        private int _CategoryID;
        private string _CategoryPath;
        private decimal _RentPrice;
        private int _MaxRentDays;
        private string _Brief;
        private int _Status;
        private DateTime _CreateTime;
        private DateTime _UpdateTime;

        public int RentID
        {
            get { return _RentID; }
            set { _RentID=value; }
        }
        public string RentName
        {
            get { return _RentName; }
            set { _RentName=value; }
        }
        public string SmallImage
        {
            get { return _SmallImage; }
            set { _SmallImage=value; }
        }
        public string MediumImage
        {
            get { return _MediumImage; }
            set { _MediumImage=value; }
        }
        public int Stock
        {
            get { return _Stock; }
            set { _Stock=value; }
        }
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords=value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID=value; }
        }
        public string CategoryPath
        {
            get { return _CategoryPath; }
            set { _CategoryPath=value; }
        }
        public decimal RentPrice
        {
            get { return _RentPrice; }
            set { _RentPrice=value; }
        }
        public int MaxRentDays
        {
            get { return _MaxRentDays; }
            set { _MaxRentDays=value; }
        }
        public string Brief
        {
            get { return _Brief; }
            set { _Brief=value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status=value; }
        }
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime=value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime=value; }
        }
    }
}
