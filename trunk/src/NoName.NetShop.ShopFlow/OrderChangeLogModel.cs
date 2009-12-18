using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class OrderChangeLogModel
    {
        public OrderChangeLogModel()
        { }
        #region Model
        private string _orderid;
        private DateTime? _changetime;
        private string _remark;
        private string _operator;
        public string ActInfo{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        #endregion Model

    }
}
