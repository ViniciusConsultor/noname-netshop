using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace NoName.Utility
{
    public class CommUtil
    {
        /// <summary>
        /// ת������Ϊ��������
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertNumberToCHS(int number)
        {
            string[] nums = new string[]{
                "��","һ","��","��","��","��","��","��","��","��"
            };
            int zero = '0';
            string numstr = number.ToString();
            StringBuilder result = new StringBuilder();
            for(int i=0;i<numstr.Length;i++)
            {
                result.Append(nums[numstr[i]-zero]);
            }
            return result.ToString();
        }

        /// <summary>
        /// �������ַ���ת��Ϊ���������ַ���
        /// </summary>
        /// <param name="numberstr"></param>
        /// <returns></returns>
        public static string ConvertNumberStringToCHS(string numberstr)
        {
            string[] nums = new string[]{
                "��","һ","��","��","��","��","��","��","��","��"
            };
            int zero = '0';
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < numberstr.Length; i++)
            {
                if (Char.IsDigit(numberstr[i]))
                {
                    result.Append(nums[numberstr[i] - zero]);
                }
                else
                {
                    throw new ArithmeticException("����������ַ����к��з������ַ���" + numberstr[i].ToString());
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// ����ָ���ı����ʽ��������Ĳ�������
        /// </summary>
        /// <param name="request">������ַ���</param>
        /// <param name="encode">����ģʽ</param>
        /// <returns></returns>
        public static NameValueCollection GetRequestParameters(HttpRequest request,string encode)
        {
            NameValueCollection nv = null;
            Encoding destEncode = null;
            if (!String.IsNullOrEmpty(encode))
            {
                try
                {
                    destEncode = Encoding.GetEncoding(encode);
                }
                catch { }
            }

            if (request.HttpMethod == "POST")
            {
                if (null != destEncode)
                {
                    Stream resStream = request.InputStream;
                    byte[] filecontent = new byte[resStream.Length];
                    resStream.Read(filecontent, 0, filecontent.Length);
                    string postquery = Encoding.Default.GetString(filecontent);
                    nv = HttpUtility.ParseQueryString(postquery, destEncode);
                }
                else
                    nv = request.Form;
            }
            else
            {
                if (null != destEncode)
                {
                    nv = System.Web.HttpUtility.ParseQueryString(request.Url.Query, destEncode);
                }
                else
                {
                    nv = request.QueryString;
                }
            }
            return nv;
        }

        /// <summary>
        /// ����ָ���ı����ʽ��������Ĳ�������
        /// </summary>
        /// <param name="request">������ַ���</param>
        /// <param name="encode">����ģʽ</param>
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


        /// <summary>
        /// ����һ��POST����
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paras"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static byte[] SendPostRequest(string url, string paras, string encodetype)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/x-www-form-urlencoded";

            Encoding encode = Encoding.Default;
            if (!String.IsNullOrEmpty(encodetype))
            {
                try
                {
                    encode = Encoding.GetEncoding(encodetype);
                }
                catch { }
            }

            byte[] data = encode.GetBytes(paras.ToString());
            Stream reqstream = req.GetRequestStream();

            reqstream.Write(data, 0, data.Length);
            reqstream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream resst = res.GetResponseStream();
            byte[] result = new byte[8092];
            resst.Read(result, 0, result.Length);
            resst.Close();
            res.Close();
            return result;
        }

        /// <summary>
        /// ����һ��GET����
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] SendGetRequest(string url,string encodetype)
        {
            Encoding encode = Encoding.Default;
            if (!String.IsNullOrEmpty(encodetype))
            {
                try
                {
                    encode = Encoding.GetEncoding(encodetype);
                }
                catch { }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.MaximumAutomaticRedirections = 3;
            req.Timeout = 5000;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            
            Stream resst = res.GetResponseStream();
            byte[] result = new byte[8096];
            resst.Read(result, 0, result.Length);
            resst.Close();
            res.Close();
            return result;
        }


        /// <summary>
        /// ʹ��ָ�������ʽ����һ��POST���󣬲�ͨ��Լ���ı����ʽ��ȡ���ص�����
        /// </summary>
        /// <param name="url">�����url��ַ</param>
        /// <param name="parameters">����Ĳ�������</param>
        /// <param name="reqencode">����ı����ʽ</param>
        /// <param name="resencode">���յı����ʽ</param>
        /// <returns></returns>
        public static string SendPostRequest(string url, NameValueCollection parameters, Encoding reqencode, Encoding resencode)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/x-www-form-urlencoded";

            StringBuilder parassb = new StringBuilder();
            if (null != parameters)
            {
                foreach (string key in parameters.Keys)
                {
                    if (parassb.Length > 0)
                        parassb.Append("&");
                    parassb.AppendFormat("{0}={1}", key, parameters[key]);
                }
            }
            byte[] data = reqencode.GetBytes(parassb.ToString());
            Stream reqstream = req.GetRequestStream();

            reqstream.Write(data, 0, data.Length);
            reqstream.Close();

            string result = String.Empty;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), resencode))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        /// <summary>
        /// ʹ��ָ�������ʽ����һ��POST���󣬲�ͨ��Լ���ı����ʽ��ȡ���ص�����
        /// </summary>
        /// <param name="url">�����url��ַ</param>
        /// <param name="paras">����Ĳ��� ������XML</param>
        /// <param name="reqencode">����ı����ʽ</param>
        /// <param name="resencode">���յı����ʽ</param>
        /// <returns></returns>
        public static string SendPostRequestWithCredentials(string url, string paras, string username, string password, string reqencode, string resencode)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Credentials = new NetworkCredential(username, password);

            Encoding reqCode = Encoding.Default;
            Encoding resCode = Encoding.Default;
            if (!String.IsNullOrEmpty(reqencode)){
                try{
                    reqCode = Encoding.GetEncoding(reqencode);
                }
                catch { }
            }
            if (!String.IsNullOrEmpty(resencode))
            {
                try{
                    resCode = Encoding.GetEncoding(resencode);
                }
                catch { }
            }

            byte[] data = reqCode.GetBytes(paras.ToString());
            Stream reqstream = req.GetRequestStream();
            reqstream.Write(data, 0, data.Length);
            reqstream.Close();

            string result = String.Empty;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), resCode))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Post�������ض���
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="context"></param>
        public static void PostAndRedirect(string url,NameValueCollection parameters,HttpContext context)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("<form name=redirpostform action='{0}' method='post'>",url);
            if (null != parameters)
            {
                foreach (string key in parameters.Keys)
                {
                    script.AppendFormat("<input type='hidden' name='{0}' value='{1}'>",
                        key, parameters[key]);
                }
            }
            script.Append("</form>");
            script.Append("<script language='javascript'>redirpostform.submit();</script>");
            context.Response.Write(script);
            context.Response.End();
        }

        /// <summary>
        /// ����һ��GET����
        /// </summary>
        /// <param name="url">�����url��ַ</param>
        /// <param name="parameters">����Ĳ�������</param>
        /// <param name="reqencode">����ı����ʽ</param>
        /// <param name="resencode">���յı����ʽ</param>
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
        /// ����һ��GET����(����)
        /// </summary>
        /// <param name="url">�����url��ַ</param>
        /// <param name="parameters">����Ĳ�������</param>
        /// <param name="reqencode">����ı����ʽ</param>
        /// <param name="resencode">���յı����ʽ</param>
        /// <param name="timeset">��������ʱʱ��</param>
        /// <param name="baseurl">���͵ĵ�ַ</param>
        /// <returns></returns>
        public static string SendGetRequest(string baseurl, NameValueCollection parameters, Encoding reqencode, Encoding resencode,int timeoutset)
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
            req.Timeout = timeoutset;

            string result = String.Empty;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), resencode))
            {
                result = reader.ReadToEnd();
            }
            return result;

        }

        public static string BuilderGetRequestUrl(string baseurl, NameValueCollection parameters, Encoding reqencode)
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
            return baseurl;
        }

        public static string EncodeString(string input,Encoding srcEncoding, Encoding desEncoding)
        {
            if (srcEncoding == null || desEncoding == null)
            {
                throw new Exception("��Ҫ�ṩ��Ӧ��encoding");
            }
            if (srcEncoding == desEncoding)
            {
                return input;
            }
            else
            {
                return desEncoding.GetString(Encoding.Convert(srcEncoding, desEncoding, srcEncoding.GetBytes(input)));
            }
        }

        public static string EncodeString(string input, Encoding desEncoding)
        {
            if (desEncoding == null)
            {
                throw new Exception("��Ҫ�ṩ��Ӧ��encoding");
            }
            if (Encoding.Default == desEncoding)
            {
                return input;
            }
            else
            {
                return desEncoding.GetString(Encoding.Convert(Encoding.Default, desEncoding, Encoding.Default.GetBytes(input)));
            }
        }


        /// <summary>
        /// ���л�һ������
        /// </summary>
        /// <param name="xmlobj">�����л��Ķ���</param>
        public static string SerializeObject(Object xmlobj)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            Type type = xmlobj.GetType();
            XmlSerializer sz = new XmlSerializer(type);
            sz.Serialize(tw, xmlobj);
            tw.Close();
            return sb.ToString();
        }

        public static long Ip2Long(string ipaddress)
        {
            long[] ip = new long[4];
            string[] s = ipaddress.Split('.');
            ip[0] = long.Parse(s[0]);
            ip[1] = long.Parse(s[1]);
            ip[2] = long.Parse(s[2]);
            ip[3] = long.Parse(s[3]);

            return (ip[0] << 24) + (ip[1] << 16) + (ip[2] << 8) + ip[3];

        }

        public static string Long2Ip(long longIP)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(longIP >> 24);
            sb.Append(".");

            //����8λ��0��Ȼ������16Ϊ


            sb.Append((longIP & 0x00FFFFFF) >> 16);
            sb.Append(".");


            sb.Append((longIP & 0x0000FFFF) >> 8);
            sb.Append(".");

            sb.Append((longIP & 0x000000FF));


            return sb.ToString();

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
