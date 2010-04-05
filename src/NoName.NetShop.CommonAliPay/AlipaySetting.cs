using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace NoName.NetShop.CommonAliPay
{
    public class AlipaySetting
    {
        private static readonly Hashtable cfg = (Hashtable)System.Configuration.ConfigurationManager.GetSection("alipaySetting");
        public static string VerifyUrl { get { return (string)cfg["verifyUrl"]; } }
        public static string PushUrl { get { return (string)cfg["verifyUrl"]; } }
        public static string NotifyUrl { get { return (string)cfg["notifyUrl"]; } }
        public static string ReturnUrl { get { return (string)cfg["returnUrl"]; } }
        public static string Partner { get { return (string)cfg["partner"]; } }
        public static string Key { get { return (string)cfg["key"]; } }
        public static string SellerEmail { get { return (string)cfg["seller_email"]; } }
        public static string SellerId { get { return (string)cfg["seller_id"]; } }
        public static string SignType { get { return (string)cfg["sign_type"]; } }
        private static Encoding encode;
        public static Encoding Encode
        {
            get
            {
                if (encode == null)
                {
                    try
                    {
                        encode = Encoding.GetEncoding((string)cfg["encode"]);
                    }
                    catch
                    {
                        encode = Encoding.Default;
                    }
                }
                return encode;
            }
        }
        public static string EncodeType
        {
            get { return (string)cfg["encode"]; } 
        }

    }
}
