using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// 错误类型
    /// </summary>
    class ErrorStatus
    {
        private static Dictionary<string, FlagInfo> dict = new Dictionary<string, FlagInfo>();
        public static FlagInfo GetFlag(string key)
        {
            return dict[key];
        }
        static ErrorStatus()
        {
            dict.Add(ILLEGAL_SIGN.Key, ILLEGAL_SIGN);
            dict.Add(ILLEGAL_ARGUMENT.Key, ILLEGAL_ARGUMENT);
            dict.Add(HASH_NO_PRIVILEGE.Key, HASH_NO_PRIVILEGE);
            dict.Add(ILLEGAL_SERVICE.Key, ILLEGAL_SERVICE);
            dict.Add(ILLEGAL_PARTNER.Key, ILLEGAL_PARTNER);
            dict.Add(HAS_NO_PUBLICKEY.Key, HAS_NO_PUBLICKEY);
            dict.Add(USER_NOT_EXIST.Key, USER_NOT_EXIST);
            dict.Add(OUT_TRADE_NO_EXIST.Key, OUT_TRADE_NO_EXIST);
            dict.Add(TRADE_NOT_EXIST.Key, TRADE_NOT_EXIST);
            dict.Add(ILLEGAL_PAYMENT_TYPE.Key, ILLEGAL_PAYMENT_TYPE);
            dict.Add(BUYER_NOT_EXIST.Key, BUYER_NOT_EXIST);
            dict.Add(SELLER_NOT_EXIST.Key, SELLER_NOT_EXIST);
            dict.Add(BUYER_SELLER_EQUAL.Key, BUYER_SELLER_EQUAL);
            dict.Add(ILLEGAL_SIGN_TYPE.Key, ILLEGAL_SIGN_TYPE);
            dict.Add(COMMISION_ID_NOT_EXIST.Key, COMMISION_ID_NOT_EXIST);
            dict.Add(COMMISION_SELLER_DUPLICATE.Key, COMMISION_SELLER_DUPLICATE);
            dict.Add(COMMISION_FEE_OUT_OF_RANGE.Key, COMMISION_FEE_OUT_OF_RANGE);
            dict.Add(ILLEGAL_LOGISTICS_FORMAT.Key, ILLEGAL_LOGISTICS_FORMAT);
            dict.Add(TOTAL_FEE_LESSEQUAL_ZERO.Key, TOTAL_FEE_LESSEQUAL_ZERO);
            dict.Add(TOTAL_FEE_OUT_OF_RANGE.Key, TOTAL_FEE_OUT_OF_RANGE);
            dict.Add(ILLEGAL_FEE_PARAM.Key, ILLEGAL_FEE_PARAM);
            dict.Add(DONATE_GREATER_THAN_MAX.Key, DONATE_GREATER_THAN_MAX);
            dict.Add(DIRECT_PAY_AMOUNT_OUT_OF_RANGE.Key, DIRECT_PAY_AMOUNT_OUT_OF_RANGE);
            dict.Add(DIGITAL_FEE_GREATER_THAN_MAX.Key, DIGITAL_FEE_GREATER_THAN_MAX);
            dict.Add(SELF_TIMEOUT_NOT_SUPPORT.Key, SELF_TIMEOUT_NOT_SUPPORT);
            dict.Add(COMMISION_NOT_SUPPORT.Key, COMMISION_NOT_SUPPORT);
            dict.Add(VIRTUAL_NOT_SUPPORT.Key, VIRTUAL_NOT_SUPPORT);
            dict.Add(ILLEGAL_CHARSET.Key, ILLEGAL_CHARSET);
        }
        /// <summary>
        /// 签名验证出错
        /// </summary>
        public readonly static FlagInfo ILLEGAL_SIGN = new FlagInfo { Key = "ILLEGAL_SIGN", Name = "签名验证出错", Description = String.Empty };
        /// <summary>
        /// 参数不正确
        /// </summary>
        public readonly static FlagInfo ILLEGAL_ARGUMENT = new FlagInfo { Key = "ILLEGAL_ARGUMENT", Name = "参数不正确", Description = String.Empty };
        /// <summary>
        /// 没有权限访问该服务
        /// </summary>
        public readonly static FlagInfo HASH_NO_PRIVILEGE = new FlagInfo { Key = "HASH_NO_PRIVILEGE", Name = "没有权限访问该服务", Description = String.Empty };
        /// <summary>
        /// Service参数不正确
        /// </summary>
        public readonly static FlagInfo ILLEGAL_SERVICE = new FlagInfo { Key = "ILLEGAL_SERVICE", Name = "Service参数不正确", Description = String.Empty };
        /// <summary>
        /// 商户ID不正确
        /// </summary>
        public readonly static FlagInfo ILLEGAL_PARTNER = new FlagInfo { Key = "ILLEGAL_PARTNER", Name = "商户ID不正确", Description = String.Empty };
        /// <summary>
        /// 没有上传公钥
        /// </summary>
        public readonly static FlagInfo HAS_NO_PUBLICKEY = new FlagInfo { Key = "HAS_NO_PUBLICKEY", Name = "没有上传公钥", Description = String.Empty };
        /// <summary>
        /// 会员不存在
        /// </summary>
        public readonly static FlagInfo USER_NOT_EXIST = new FlagInfo { Key = "USER_NOT_EXIST", Name = "会员不存在", Description = String.Empty };
        /// <summary>
        /// 外部交易号已经存在
        /// </summary>
        public readonly static FlagInfo OUT_TRADE_NO_EXIST = new FlagInfo { Key = "OUT_TRADE_NO_EXIST", Name = "外部交易号已经存在", Description = String.Empty };
        /// <summary>
        /// 交易不存在
        /// </summary>
        public readonly static FlagInfo TRADE_NOT_EXIST = new FlagInfo { Key = "TRADE_NOT_EXIST", Name = "交易不存在", Description = String.Empty };
        /// <summary>
        /// 无效支付类型
        /// </summary>
        public readonly static FlagInfo ILLEGAL_PAYMENT_TYPE = new FlagInfo { Key = "ILLEGAL_PAYMENT_TYPE", Name = "无效支付类型", Description = String.Empty };
        /// <summary>
        /// 买家不存在
        /// </summary>
        public readonly static FlagInfo BUYER_NOT_EXIST = new FlagInfo { Key = "BUYER_NOT_EXIST", Name = "买家不存在", Description = String.Empty };
        /// <summary>
        /// 卖家不存在
        /// </summary>
        public readonly static FlagInfo SELLER_NOT_EXIST = new FlagInfo { Key = "SELLER_NOT_EXIST", Name = "卖家不存在", Description = String.Empty };
        /// <summary>
        /// 买家、卖家是同一帐户
        /// </summary>
        public readonly static FlagInfo BUYER_SELLER_EQUAL = new FlagInfo { Key = "BUYER_SELLER_EQUAL", Name = "买家、卖家是同一帐户", Description = String.Empty };
        /// <summary>
        /// 签名类型不正确
        /// </summary>
        public readonly static FlagInfo ILLEGAL_SIGN_TYPE = new FlagInfo { Key = "ILLEGAL_SIGN_TYPE", Name = "签名类型不正确", Description = String.Empty };
        /// <summary>
        /// 佣金收取帐户不存在
        /// </summary>
        public readonly static FlagInfo COMMISION_ID_NOT_EXIST = new FlagInfo { Key = "COMMISION_ID_NOT_EXIST", Name = "佣金收取帐户不存在", Description = String.Empty };
        /// <summary>
        /// 收取佣金帐户和卖家是同一帐户
        /// </summary>
        public readonly static FlagInfo COMMISION_SELLER_DUPLICATE = new FlagInfo { Key = "COMMISION_SELLER_DUPLICATE", Name = "收取佣金帐户和卖家是同一帐户", Description = String.Empty };
        /// <summary>
        /// 佣金金额超出范围
        /// </summary>
        public readonly static FlagInfo COMMISION_FEE_OUT_OF_RANGE = new FlagInfo { Key = "COMMISION_FEE_OUT_OF_RANGE", Name = "佣金金额超出范围", Description = String.Empty };
        /// <summary>
        /// 无效物流格式
        /// </summary>
        public readonly static FlagInfo ILLEGAL_LOGISTICS_FORMAT = new FlagInfo { Key = "ILLEGAL_LOGISTICS_FORMAT", Name = "无效物流格式", Description = String.Empty };
        /// <summary>
        /// 交易总金额小于等于0
        /// </summary>
        public readonly static FlagInfo TOTAL_FEE_LESSEQUAL_ZERO = new FlagInfo { Key = "TOTAL_FEE_LESSEQUAL_ZERO", Name = "交易总金额小于等于0", Description = String.Empty };
        /// <summary>
        /// 交易总金额超出范围
        /// </summary>
        public readonly static FlagInfo TOTAL_FEE_OUT_OF_RANGE = new FlagInfo { Key = "TOTAL_FEE_OUT_OF_RANGE", Name = "交易总金额超出范围", Description = String.Empty };
        /// <summary>
        /// 非法交易金额格式
        /// </summary>
        public readonly static FlagInfo ILLEGAL_FEE_PARAM = new FlagInfo { Key = "ILLEGAL_FEE_PARAM", Name = "非法交易金额格式", Description = String.Empty };
        /// <summary>
        /// 小额捐赠总金额超出最大值限制
        /// </summary>
        public readonly static FlagInfo DONATE_GREATER_THAN_MAX = new FlagInfo { Key = "DONATE_GREATER_THAN_MAX", Name = "小额捐赠总金额超出最大值限制", Description = String.Empty };
        /// <summary>
        /// 快速付款交易总金额超出最大值限制
        /// </summary>
        public readonly static FlagInfo DIRECT_PAY_AMOUNT_OUT_OF_RANGE = new FlagInfo { Key = "DIRECT_PAY_AMOUNT_OUT_OF_RANGE", Name = "快速付款交易总金额超出最大值限制", Description = String.Empty };
        /// <summary>
        /// 虚拟物品交易总金额超出最大值限制
        /// </summary>
        public readonly static FlagInfo DIGITAL_FEE_GREATER_THAN_MAX = new FlagInfo { Key = "DIGITAL_FEE_GREATER_THAN_MAX", Name = "虚拟物品交易总金额超出最大值限制", Description = String.Empty };
        /// <summary>
        /// 不支持自定义超时
        /// </summary>
        public readonly static FlagInfo SELF_TIMEOUT_NOT_SUPPORT = new FlagInfo { Key = "SELF_TIMEOUT_NOT_SUPPORT", Name = "不支持自定义超时", Description = String.Empty };
        /// <summary>
        /// 不支持佣金
        /// </summary>
        public readonly static FlagInfo COMMISION_NOT_SUPPORT = new FlagInfo { Key = "COMMISION_NOT_SUPPORT", Name = "不支持佣金", Description = String.Empty };
        /// <summary>
        /// 不支持虚拟发货方式
        /// </summary>
        public readonly static FlagInfo VIRTUAL_NOT_SUPPORT = new FlagInfo { Key = "VIRTUAL_NOT_SUPPORT", Name = "不支持虚拟发货方式", Description = String.Empty };
        /// <summary>
        /// 字符集不合法
        /// </summary>
        public readonly static FlagInfo ILLEGAL_CHARSET = new FlagInfo { Key = "ILLEGAL_CHARSET", Name = "字符集不合法", Description = String.Empty };


    }
}
