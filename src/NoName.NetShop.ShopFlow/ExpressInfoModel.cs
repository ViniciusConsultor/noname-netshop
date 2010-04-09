using System;
namespace NoName.NetShop.ShopFlow
{
    /// <summary>
    /// 实体类unExpressInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ExpressInfoModel
    {
        public ExpressInfoModel()
        { }
        #region Model
        private int _shipregion;
        private int _usertype;
        private int _userlevel;
        private decimal? _markmoney;
        private decimal? _lshipfee;
        private decimal? _gshipfee;
        private int _ruleid;
        /// <summary>
        /// 
        /// </summary>
        public int ShipRegion
        {
            set { _shipregion = value; }
            get { return _shipregion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserLevel
        {
            set { _userlevel = value; }
            get { return _userlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MarkMoney
        {
            set { _markmoney = value; }
            get { return _markmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LShipFee
        {
            set { _lshipfee = value; }
            get { return _lshipfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GShipFee
        {
            set { _gshipfee = value; }
            get { return _gshipfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RuleId
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }
        #endregion Model

    }
}

