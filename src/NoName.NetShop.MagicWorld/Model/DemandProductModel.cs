using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class DemandProductModel
    {
        private int _DemandID;
        private string _DemandName;
        private string _SmallImage;
        private string _MediumImage;
        private int _CategoryID;
        private string _CategoryPath;
        private decimal _Price;
        private int _Count;
        private int _UsageCondition;
        private DateTime _ExpirationTime;
        private string _Brief;
        private string _UserID;
        private string _TrueName;
        private string _Phone;
        private string _CellPhone;
        private string _PostCode;
        private string _Region;
        private string _Address;
        private bool _Status;
        private DateTime _InsertTime;
        private DateTime _UpdateTime;


        public int DemandID
        {
            get { return _DemandID; }
            set { _DemandID=value; }
        }
        public string DemandName
        {
            get { return _DemandName; }
            set { _DemandName=value; }
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
        public decimal Price
        {
            get { return _Price; }
            set { _Price=value; }
        }
        public int Count
        {
            get { return _Count; }
            set { _Count=value; }
        }
        public int UsageCondition
        {
            get { return _UsageCondition; }
            set { _UsageCondition=value; }
        }
        public DateTime ExpirationTime
        {
            get { return _ExpirationTime; }
            set { _ExpirationTime=value; }
        }
        public string Brief
        {
            get { return _Brief; }
            set { _Brief=value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID=value; }
        }
        public string TrueName
        {
            get { return _TrueName; }
            set { _TrueName=value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone=value; }
        }
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone=value; }
        }
        public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode=value; }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region=value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address=value; }
        }
        public bool Status
        {
            get { return _Status; }
            set { _Status=value; }
        }
        public DateTime InsertTime
        {
            get { return _InsertTime; }
            set { _InsertTime=value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime=value; }
        }
    }
    public enum DemandProductStatus
    {
        尚未审核 = 1,
        审核通过 = 2,
        审核未通过 = 3,
    }
}
