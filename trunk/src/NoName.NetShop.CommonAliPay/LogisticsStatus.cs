using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// 支付宝物流状态
    /// </summary>
    class LogisticsStatus
    {
        private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static LogisticsStatus()
        {
            dict.Add(INITIAL_STATUS.Key, INITIAL_STATUS);
            dict.Add(WAIT_LOGISTICS_FETCH_GOODS.Key, WAIT_LOGISTICS_FETCH_GOODS);
            dict.Add(WAIT_LOGISTICS_SEND_GOODS.Key, WAIT_LOGISTICS_SEND_GOODS);
            dict.Add(LOGISTICS_SENDING.Key, LOGISTICS_SENDING);
            dict.Add(WAIT_RECEIVER_CONFIRM_GOODS.Key, WAIT_RECEIVER_CONFIRM_GOODS);
            dict.Add(GOODS_RECEIVED.Key, GOODS_RECEIVED);
            dict.Add(LOGISTICS_FAILURE.Key, LOGISTICS_FAILURE);
        }
        /// <summary>
        /// 初始状态
        /// </summary>
        public readonly static FlagInfo INITIAL_STATUS = new FlagInfo { Key = "INITIAL_STATUS", Name = "初始状态", Description = String.Empty };
        /// <summary>
        /// 等待物流取货
        /// </summary>
        public readonly static FlagInfo WAIT_LOGISTICS_FETCH_GOODS = new FlagInfo { Key = "WAIT_LOGISTICS_FETCH_GOODS", Name = "等待物流取货", Description = String.Empty };
        /// <summary>
        /// 等待物流发货
        /// </summary>
        public readonly static FlagInfo WAIT_LOGISTICS_SEND_GOODS = new FlagInfo { Key = "WAIT_LOGISTICS_SEND_GOODS", Name = "等待物流发货", Description = String.Empty };
        /// <summary>
        /// 物流发货中
        /// </summary>
        public readonly static FlagInfo LOGISTICS_SENDING = new FlagInfo { Key = "LOGISTICS_SENDING", Name = "物流发货中", Description = String.Empty };
        /// <summary>
        /// 等待收货人确讣收货
        /// </summary>
        public readonly static FlagInfo WAIT_RECEIVER_CONFIRM_GOODS = new FlagInfo { Key = "WAIT_RECEIVER_CONFIRM_GOODS", Name = "等待收货人确讣收货", Description = String.Empty };
        /// <summary>
        /// 货物收到了
        /// </summary>
        public readonly static FlagInfo GOODS_RECEIVED = new FlagInfo { Key = "GOODS_RECEIVED", Name = "货物收到了", Description = String.Empty };
        /// <summary>
        /// 物流失败
        /// </summary>
        public readonly static FlagInfo LOGISTICS_FAILURE = new FlagInfo { Key = "LOGISTICS_FAILURE", Name = "物流失败", Description = String.Empty };
    }
}
