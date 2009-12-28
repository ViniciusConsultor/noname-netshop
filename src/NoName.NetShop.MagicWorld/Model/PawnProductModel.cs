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
        private string _UserID;
        private decimal _PawnPrice;
        private decimal _SellingPrice;
        private int _CateID;
        private string _CatePath;
        private int _Stock;
        private string _SmallImage;
        private string _MediumImage;
        private string _Brief;
        private DateTime _InsertTime;
        private DateTime _ChangeTime;
        private int _Status;
        private int _SortValue;
        private DateTime _DeadTime;
        private string _TrueName;
        private string _Phone;
        private string _CellPhone;
        private string _PostCode;
        private string _Region;
        private string _Address;


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
        public string UserID
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
        public DateTime DeadTime
        {
            get { return _DeadTime; }
            set { _DeadTime = value; }
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
    }
    public enum PawnProductStatus
    {
        尚未收当 = 1,
        已收当 = 2,
        冻结 = 3,
    }
}
