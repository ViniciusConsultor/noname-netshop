using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;

namespace NoName.NetShop.CMS.Utility
{
    public class PublishUtil
    {
        /// <summary>
        /// 发送一个GET请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="parameters">请求的参数集合</param>
        /// <param name="reqencode">请求的编码格式</param>
        /// <param name="resencode">接收的编码格式</param>
        /// <returns></returns>
        public static string SendGetRequest(string baseurl, NameValueCollection parameters, Encoding reqencode, Encoding resencode)
        {
            StringBuilder parassb = new StringBuilder();
            if (null != parameters)
            {
                foreach (string key in parameters.Keys)
                {
                    if (parassb.Length > 0)
                        parassb.Append("&");
                    parassb.AppendFormat("{0}={1}", HttpUtility.UrlEncode(key, reqencode), HttpUtility.UrlEncode(parameters[key], reqencode));
                }
            }
            if (parassb.Length > 0)
            {
                baseurl += "?" + parassb;
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseurl);
            req.Method = "GET";
            req.MaximumAutomaticRedirections = 3;
            req.Timeout = 300000;

            string result = String.Empty;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), resencode))
            {
                result = reader.ReadToEnd();
            }
            return result;

        }

    }
}
