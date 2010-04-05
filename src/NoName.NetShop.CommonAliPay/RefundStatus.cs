using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// 退款状态枚举
    /// </summary>
    class RefundStatus
    {
         private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static RefundStatus()
        {
            dict.Add(WAIT_SELLER_AGREE.Key, WAIT_SELLER_AGREE);
            dict.Add(REFUND_SUCCESS.Key, REFUND_SUCCESS);
            dict.Add(REFUND_CLOSED.Key, REFUND_CLOSED);
        }
        /// <summary>
        /// 买家申请退款
        /// </summary>
        public readonly static FlagInfo WAIT_SELLER_AGREE = new FlagInfo { Key = "WAIT_SELLER_AGREE", Name = "买家申请退款", Description = String.Empty };
        /// <summary>
        /// 退款成功
        /// </summary>
        public readonly static FlagInfo REFUND_SUCCESS = new FlagInfo { Key = "REFUND_SUCCESS", Name = "退款成功", Description = String.Empty };
        /// <summary>
        /// 退款关闭
        /// </summary>
        public readonly static FlagInfo REFUND_CLOSED = new FlagInfo { Key = "REFUND_CLOSED", Name = "退款关闭", Description = String.Empty };
    }
}
