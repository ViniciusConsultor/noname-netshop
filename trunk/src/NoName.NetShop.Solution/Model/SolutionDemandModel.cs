using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Solution.Model
{
    public class SolutionDemandModel
    {
        private int _DemandID;
        private string _DemandDetail;
        private string _FieldPhotoes;
        private string _FieldSituation;
        private string _EffectSituation;
        private decimal _Budget;
        private string _Contactor;
        private string _ContactPhone;
        private string _Postcode;
        private string _Region;
        private string _Address;
        private string _UserID;
        private DateTime _CreateTime;
        private DateTime _UpdateTime;
        private int _Status;


        public int DemandID
        {
            get { return _DemandID; }
            set { _DemandID = value; }
        }
        public string DemandDetail
        {
            get { return _DemandDetail; }
            set { _DemandDetail = value; }
        }
        public string FieldPhotoes
        {
            get { return _FieldPhotoes; }
            set { _FieldPhotoes = value; }
        }
        public string FieldSituation
        {
            get { return _FieldSituation; }
            set { _FieldSituation = value; }
        }
        public string EffectSituation
        {
            get { return _EffectSituation; }
            set { _EffectSituation = value; }
        }
        public decimal Budget
        {
            get { return _Budget; }
            set { _Budget = value; }
        }
        public string Contactor
        {
            get { return _Contactor; }
            set { _Contactor = value; }
        }
        public string ContactPhone
        {
            get { return _ContactPhone; }
            set { _ContactPhone = value; }
        }
        public string Postcode
        {
            get { return _Postcode; }
            set { _Postcode = value; }
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
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }

    public enum SolutionDemandStatus
    {
        尚未处理=1,
        已处理=2,
    }
}
