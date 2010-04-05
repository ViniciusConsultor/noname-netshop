using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    class LogisticsType
    {
         private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static LogisticsType()
        {
            dict.Add(POST.Key, POST);
            dict.Add(EMS.Key, EMS);
            dict.Add(EXPRESS.Key, EXPRESS);
        }
        /// <summary>
        /// 平邮
        /// </summary>
        public readonly static FlagInfo POST = new FlagInfo { Key = "POST", Name = "平邮", Description = String.Empty };
        /// <summary>
        /// EMS
        /// </summary>
        public readonly static FlagInfo EMS = new FlagInfo { Key = "EMS", Name = "EMS", Description = String.Empty };
        /// <summary>
        /// 其他快递
        /// </summary>
        public readonly static FlagInfo EXPRESS = new FlagInfo { Key = "EXPRESS", Name = "其他快递", Description = String.Empty };
    }
}
