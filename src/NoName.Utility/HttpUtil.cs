using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.IO;
using System.Net;

namespace NoName.Utility
{
        public class HttpUtil
        {
            public static string SendGetRequest(string uri)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "GET";
                req.MaximumAutomaticRedirections = 3;
                req.Timeout = 5000;

                string result = String.Empty;
                using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }

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
                req.Timeout = 5000;

                string result = String.Empty;
                using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), resencode))
                {
                    result = reader.ReadToEnd();
                }
                return result;

            }

            /// <summary>
            /// 根据指定的编码格式返回请求的参数集合
            /// </summary>
            /// <param name="request">请求的字符串</param>
            /// <param name="encode">编码模式</param>
            /// <returns></returns>
            public static NameValueCollection GetRequestParameters(HttpRequest request, Encoding encode)
            {
                NameValueCollection nv = null;
                if (request.HttpMethod == "POST")
                {
                    if (null != encode)
                    {
                        Stream resStream = request.InputStream;
                        byte[] filecontent = new byte[resStream.Length];
                        resStream.Read(filecontent, 0, filecontent.Length);
                        string postquery = Encoding.Default.GetString(filecontent);
                        nv = HttpUtility.ParseQueryString(postquery, encode);
                    }
                    else
                        nv = request.Form;
                }
                else
                {
                    if (null != encode)
                    {
                        nv = System.Web.HttpUtility.ParseQueryString(request.Url.Query, encode);
                    }
                    else
                    {
                        nv = request.QueryString;
                    }
                }
                return nv;
            }

            public static NameValueCollection GetParameters(string ParameterString)
            {
                NameValueCollection nv = null;

                if (ParameterString.Contains("&"))
                {
                    nv = new NameValueCollection();
                    foreach (string p in ParameterString.Split('&'))
                    {
                        if (p.Contains("="))
                            nv.Add(p.Split('=')[0], p.Split('=')[1]);
                    }
                }
                else
                {
                    if (ParameterString.Contains("="))
                    {
                        nv = new NameValueCollection();
                        nv.Add(ParameterString.Split('=')[0], ParameterString.Split('=')[1]);
                    }
                }

                return nv;
            }

            public static string GetParameterString(NameValueCollection parm)
            {
                string s = String.Empty;
                int i = 0;

                foreach (string k in parm.Keys)
                {
                    if (i != parm.Count - 1)
                    {
                        s = s + k + "=" + parm[k] + "&";
                    }
                    else
                    {
                        s = s + k + "=" + parm[k];
                    }
                    i++;
                }
                return s;
            }
        }
    
}
