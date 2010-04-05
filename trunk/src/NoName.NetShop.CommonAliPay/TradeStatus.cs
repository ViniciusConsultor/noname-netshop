using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// 订单交易状态枚举
    /// </summary>
    public class TradeStatus
    {
        private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static TradeStatus()
        {
            dict.Add(WAIT_BUYER_PAY.Key, WAIT_BUYER_PAY);
            dict.Add(WAIT_SELLER_SEND_GOODS.Key, WAIT_SELLER_SEND_GOODS);
            dict.Add(WAIT_BUYER_CONFIRM_GOODS.Key, WAIT_BUYER_CONFIRM_GOODS);
            dict.Add(TRADE_FINISHED.Key, TRADE_FINISHED);
            dict.Add(TRADE_CLOSED.Key, TRADE_CLOSED);
            dict.Add(MODIFY_TRADEBASE_TOTALFEE.Key, MODIFY_TRADEBASE_TOTALFEE);
        }
        /// <summary>
        /// 交易创建
        /// </summary>
        public readonly static FlagInfo WAIT_BUYER_PAY = new FlagInfo { Key = "WAIT_BUYER_PAY", Name = "交易创建", Description = String.Empty };
        /// <summary>
        /// 买家付款成功
        /// </summary>
        public readonly static FlagInfo WAIT_SELLER_SEND_GOODS = new FlagInfo { Key = "WAIT_SELLER_SEND_GOODS", Name = "买家付款成功", Description = String.Empty };
        /// <summary>
        /// 卖家发货成功
        /// </summary>
        public readonly static FlagInfo WAIT_BUYER_CONFIRM_GOODS = new FlagInfo { Key = "WAIT_BUYER_CONFIRM_GOODS", Name = "卖家发货成功", Description = String.Empty };
        /// <summary>
        /// 交易成功结束
        /// </summary>
        public readonly static FlagInfo TRADE_FINISHED = new FlagInfo { Key = "TRADE_FINISHED", Name = "交易成功结束", Description = String.Empty };
        /// <summary>
        /// 交易关闭
        /// </summary>
        public readonly static FlagInfo TRADE_CLOSED = new FlagInfo { Key = "TRADE_CLOSED", Name = "交易关闭", Description = String.Empty };
        /// <summary>
        /// 修改交易价格
        /// </summary>
        public readonly static FlagInfo MODIFY_TRADEBASE_TOTALFEE = new FlagInfo { Key = "modify.tradeBase.totalFee", Name = "修改交易价格", Description = String.Empty };

    }
}
