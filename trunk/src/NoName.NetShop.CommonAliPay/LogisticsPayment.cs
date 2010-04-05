using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// 物流支付类型
    /// </summary>
    public class LogisticsPayment
    {
        private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static LogisticsPayment()
        {
            dict.Add(SELLER_PAY.Key, SELLER_PAY);
            dict.Add(BUYER_PAY.Key, BUYER_PAY);
        }
        /// <summary>
        /// 卖家支付,由卖家支付物流费用（费用不用计算到总价内）
        /// </summary>
        public readonly static FlagInfo SELLER_PAY = new FlagInfo { Key = "SELLER_PAY", Name = "卖家支付", Description = "由卖家支付物流费用（费用不用计算到总价内）" };
        /// <summary>
        /// 买家支付,买家支付物流费用（费用需要计算到总价内）
        /// </summary>
        public readonly static FlagInfo BUYER_PAY = new FlagInfo { Key = "BUYER_PAY", Name = "买家支付", Description = "买家支付物流费用（费用需要计算到总价内）" };
    }
}