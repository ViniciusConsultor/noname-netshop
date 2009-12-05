using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class PawnProductModel
    {
        private int _PawnProductID;
        private string _PawnProductName;
        private int _UserID;
        private decimal _PawnPrice;
        private decimal _SellingPrice;
        private int _CateID;
        private string _CatePath;
        private int _Stock;
        private string _SmallImage;
        private string _MediumImage;
        private string _LargeImage;
        private string _Keywords;
        private string _Brief;
        private DateTime _InsertTime;
        private DateTime _ChangeTime;
        private int _Status;
        private int _SortValue;


        public int PawnProductID
        {
            get { return _PawnProductID; }
            set { _PawnProductID = value; }
        }
        public string PawnProductName
        {
            get { return _PawnProductName; }
            set { _PawnProductName = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public decimal PawnPrice
        {
            get { return _PawnPrice; }
            set { _PawnPrice = value; }
        }
        public decimal SellingPrice
        {
            get { return _SellingPrice; }
            set { _SellingPrice = value; }
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
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
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
        public string LargeImage
        {
            get { return _LargeImage; }
            set { _LargeImage = value; }
        }
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }
        public string Brief
        {
            get { return _Brief; }
            set { _Brief = value; }
        }
        public DateTime InsertTime
        {
            get { return _InsertTime; }
            set { _InsertTime = value; }
        }
        public DateTime ChangeTime
        {
            get { return _ChangeTime; }
            set { _ChangeTime = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public int SortValue
        {
            get { return _SortValue; }
            set { _SortValue = value; }
        }
    }
    public enum PawnProductStatus
    {
        尚未收当 = 1,
        已收当 = 2,
        冻结 = 3,
    }
}
