using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    /// <summary>
    /// 实体类AuctionLogModel 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class AuctionLogModel
    {
        public AuctionLogModel()
        { }

        private int _LogID;
        private int _AuctionID;
        private string _UserName;
        private DateTime _AuctionTime;
        private decimal _AutionPrice;



        public int LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuctionID
        {
            set { _AuctionID = value; }
            get { return _AuctionID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuctionTime
        {
            set { _AuctionTime = value; }
            get { return _AuctionTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AutionPrice
        {
            set { _AutionPrice = value; }
            get { return _AutionPrice; }
        }
    }
}
