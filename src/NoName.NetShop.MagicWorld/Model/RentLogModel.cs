using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class RentLogModel
    {        
        private int _RentLogID;
        private int _RentID;
        private string _UserID;
        private decimal _PaySum;
        private string _ApplyInfo;
        private int _RentMonths;
        private DateTime _ApplyTime;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private int _Status;
        private string _truename;
        private string _phone;
        private string _cellphone;
        private string _postcode;
        private string _region;
        private string _address;


        public int RentLogID
        {
            get { return _RentLogID; }
            set { _RentLogID = value; }
        }
        public int RentID
        {
            get { return _RentID; }
            set { _RentID=value;}
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID=value;}
        }
        public decimal PaySum
        {
            get { return _PaySum; }
            set { _PaySum=value;}
        }
        public string ApplyInfo
        {
            get { return _ApplyInfo; }
            set { _ApplyInfo=value;}
        }
        public int RentMonths
        {
            get { return _RentMonths; }
            set { _RentMonths = value; }
        }
        public DateTime ApplyTime
        {
            get { return _ApplyTime; }
            set { _ApplyTime=value;}
        }
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime=value;}
        }
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime=value;}
        }
        public int Status
        {
            get { return _Status; }
            set { _Status=value;}
        }
        public string Truename
        {
            get { return _truename; }
            set { _truename = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }

    public enum RentLogStatus
    {
        等待确认 = 1,
        已确认 = 2,        
    }
}

