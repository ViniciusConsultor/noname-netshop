using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    public class PayServiceType
    {
        private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static PayServiceType()
        {
            dict.Add(create_direct_pay_by_user.Key, create_direct_pay_by_user);
            dict.Add(create_partner_trade_by_buyer.Key, create_partner_trade_by_buyer);
            dict.Add(trade_create_by_buyer.Key, trade_create_by_buyer);
            dict.Add(notify_verify.Key, notify_verify);
        }
        /// <summary>
        /// 即时到账交易
        /// </summary>
        public readonly static FlagInfo create_direct_pay_by_user = new FlagInfo { Key = "create_direct_pay_by_user", Name = "即时到账交易", Description = String.Empty };
        /// <summary>
        /// 担保交易
        /// </summary>
        public readonly static FlagInfo create_partner_trade_by_buyer = new FlagInfo { Key = "create_partner_trade_by_buyer", Name = "担保交易", Description = String.Empty };
        /// <summary>
        /// 标准双接口
        /// </summary>
        public readonly static FlagInfo trade_create_by_buyer = new FlagInfo { Key = "trade_create_by_buyer", Name = "标准双接口", Description = String.Empty };
        /// <summary>
        /// 通知验证
        /// </summary>
        public readonly static FlagInfo notify_verify = new FlagInfo { Key = "notify_verify", Name = "通知验证", Description = String.Empty };
    }
}