using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Net;
using System.Web;
using NoName.NetShop.CommonAliPay.Result;
using System.Web.UI;
using System.Security.Cryptography;
using System.Diagnostics;
using System.ComponentModel;
namespace NoName.NetShop.CommonAliPay
{
    /// <summary>
    /// ֧�����ӿ�
    /// </summary>
    public class AliPay
    {
        /// <summary>
        /// �¼�ί���б�
        /// </summary>
        protected EventHandlerList eventList = new EventHandlerList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ProcessNotifyEventHandler(object sender, NotifyEventArgs e);
        #region ʵ�ֽ���״̬ö�ٵ��¼�
      

        private static readonly Object waitBuyerPayKey = new object();
        private static readonly Object waitSellerConfirmTradeKey = new object();
        private static readonly Object waitSysConfirmPayKey = new object();
        private static readonly Object waitSellerSendGoodsKey = new object();
        private static readonly Object waitBuyerConfirmGoodsKey = new object();
        private static readonly Object waitSysPaySellerKey = new object();
        private static readonly Object tradeFinishedKey = new object();
        private static readonly Object tradeClosedKey = new object();

        private static readonly Object modifyTradeBaseTotalFeeKey = new object();

        private static readonly Object waitSellerAgreeKey = new object();
        private static readonly Object refundSuccessKey = new object();
        private static readonly Object refundCloseKey = new object();

        /// <summary>
        /// ���
        /// </summary>
        public event ProcessNotifyEventHandler ModifyTradeBaseTotalFee
        {
            add
            {
                eventList.AddHandler(modifyTradeBaseTotalFeeKey, value);
            }
            remove
            {
                eventList.RemoveHandler(modifyTradeBaseTotalFeeKey, value);
            }
        }

        /// <summary>
        /// �ȴ���Ҹ���
        /// </summary>
        public event ProcessNotifyEventHandler WaitBuyerPay
        {
            add
            {
                eventList.AddHandler(waitBuyerPayKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitBuyerPayKey, value);
            }
        }
        /// <summary>
        /// �����Ѵ������ȴ�����ȷ��
        /// </summary>
        public event ProcessNotifyEventHandler WaitSellerConfirmTrade
        {
            add
            {
                eventList.AddHandler(waitSellerConfirmTradeKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitSellerConfirmTradeKey, value);
            }
        }
        /// <summary>
        /// ȷ����Ҹ����У����𷢻�
        /// </summary>
        public event ProcessNotifyEventHandler WaitSysConfirmPay
        {
            add
            {
                eventList.AddHandler(waitSysConfirmPayKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitSysConfirmPayKey, value);
            }
        }
        /// <summary>
        /// ֧�����յ���Ҹ�������ҷ���
        /// </summary>
        public event ProcessNotifyEventHandler WaitSellerSendGoods
        {
            add
            {
                eventList.AddHandler(waitSellerSendGoodsKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitSellerSendGoodsKey, value);
            }
        }
        /// <summary>
        /// ȷ����Ҹ����У����𷢻�
        /// </summary>
        public event ProcessNotifyEventHandler WaitBuyerConfirmGoods
        {
            add
            {
                eventList.AddHandler(waitBuyerConfirmGoodsKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitBuyerConfirmGoodsKey, value);
            }
        }
        /// <summary>
        /// ���ȷ���յ������ȴ�֧������������
        /// </summary>
        public event ProcessNotifyEventHandler WaitSysPaySeller
        {
            add
            {
                eventList.AddHandler(waitSysPaySellerKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitSysPaySellerKey, value);
            }
        }
        /// <summary>
        /// ���׳ɹ�����
        /// </summary>
        public event ProcessNotifyEventHandler TradeFinished
        {
            add
            {
                eventList.AddHandler(tradeFinishedKey, value);
            }
            remove
            {
                eventList.RemoveHandler(tradeFinishedKey, value);
            }
        }


        /// <summary>
        /// ������;�رգ�δ��ɣ�
        /// </summary>
        public event ProcessNotifyEventHandler TradeClosed
        {
            add
            {
                eventList.AddHandler(tradeClosedKey, value);
            }
            remove
            {
                eventList.RemoveHandler(tradeClosedKey, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitSellerSendGoods(NotifyEventArgs e)
        {

            ProcessNotifyEventHandler eventHandler = eventList[waitSellerSendGoodsKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitBuyerPay(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitBuyerPayKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitSysConfirmPay(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitSysConfirmPayKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitSellerConfirmTrade(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitSellerConfirmTradeKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitBuyerConfirmGoods(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitBuyerConfirmGoodsKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWaitSysPaySeller(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitSysPaySellerKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTradeFinished(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[tradeFinishedKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTradeClosed(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[tradeClosedKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        protected virtual void OnModifyTradeBaseTotalFee(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[modifyTradeBaseTotalFeeKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }

        }
        #endregion
        #region ʵ���˿�״̬ö�ٵ��¼�
        /// <summary>
        /// ��������˿�
        /// </summary>
        public event ProcessNotifyEventHandler WaitSellerAgree
        {
            add
            {
                eventList.AddHandler(waitSellerAgreeKey, value);
            }
            remove
            {
                eventList.RemoveHandler(waitSellerAgreeKey, value);
            }
        }

        /// <summary>
        /// �˿�ɹ�
        /// </summary>
        public event ProcessNotifyEventHandler RefundSuccess
        {
            add
            {
                eventList.AddHandler(refundSuccessKey, value);
            }
            remove
            {
                eventList.RemoveHandler(refundSuccessKey, value);
            }
        }
        /// <summary>
        /// �˿�ر�
        /// </summary>
        public event ProcessNotifyEventHandler RefundClose
        {
            add
            {
                eventList.AddHandler(refundCloseKey, value);
            }
            remove
            {
                eventList.RemoveHandler(refundCloseKey, value);
            }
        }
        protected virtual void OnRefundSuccess(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[refundSuccessKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        protected virtual void OnRefundClose(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[refundCloseKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        protected virtual void OnWaitSellerAgree(NotifyEventArgs e)
        {
            ProcessNotifyEventHandler eventHandler = eventList[waitSellerAgreeKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        

        #endregion
        #region �����û�֧����Notify��Ϣ���¼�
        protected static readonly object notifyEventKey= new object();
        public event ProcessNotifyEventHandler NotifyEvent
        {
            add
            {
                eventList.AddHandler(notifyEventKey,value);
            }
            remove
            {
                eventList.RemoveHandler(notifyEventKey,value);
            }
        }
        protected  virtual void OnNotifyEvent(NotifyEventArgs e)

        {
            ProcessNotifyEventHandler eventHandler = eventList[notifyEventKey] as ProcessNotifyEventHandler;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
        #endregion
        #region public
        /// <summary>
        /// �������⽻��
        /// </summary>
        /// <param name="gatewayUrl">�ύ֧�����ĵ�ַ</param>
        /// <param name="digitalGoods">���ײ���</param>
        /// <param name="page">Page����</param>
        public void CreateDigitalTrade(string gatewayUrl, DigitalGoods digitalGoods, Page page)
        {

            HttpResponse Response = page.Response;
            string t = gatewayUrl + "?" + Md5SignParam(digitalGoods);
            string url = string.Format("<script language='javascript'>window.open(\"{0}\") </script>", t);
            Response.Write(url);

        }
        /// <summary>
        /// ������׼���ף��������⽻��
        /// </summary>
        /// <param name="gatewayUrl">�ύ֧�����ĵ�ַ</param>
        /// <param name="standardGoods">���ײ���</param>
        /// <param name="page">Page����</param>
        public void CreateStandardTrade(string gatewayUrl, StandardGoods standardGoods, Page page)
        {
            //HttpResponse Response = page.Response;
            //Response.Redirect(gatewayUrl + "?" + Md5SignParam(standardGoods));
            HttpResponse Response = page.Response;
            string t = gatewayUrl + "?" + Md5SignParam(standardGoods);           
            string url = string.Format("<script language='javascript'>window.open(\"{0}\") </script>", t);
            Response.Write(url);
        }
        /// <summary>
        /// �����ص�Notify
        /// </summary>
        /// <param name="page">����Page����</param>
        /// <param name="verifyUrl">��֤�ĵ�ַ���磺https://www.alipay.com/cooperate/gateway.do</param>
        /// <param name="key">�˻��Ľ��װ�ȫУ���루key��</param>
        /// <param name="verify">verify����</param>
        /// <param name="encode">����</param>
        /// <exception cref="SignVerifyFailedException">֧����֪ͨǩ����֤ʧ��</exception>
        /// <exception  cref="CommonAliPayBaseException">֧����֪ͨ��֤ʧ��</exception>
        public void CommonProcessNotify(Page page, string verifyUrl, string key, Verify verify, string encode)
        {
            if (VerifyNotify(verifyUrl, verify))  //��֤�ɹ�
            {
                NotifyEventArgs dn = new NotifyEventArgs();
                dn = ParseNotify(page.Request.Form, dn);//�����¼�����
                SortedList<string, string> sortedList = GetParam(dn);
                string param = GetUrlParam(sortedList, false);
#if (DEBUG)
                Log4net.log.Error(param + "param");
#endif
                string sign = GetMd5Sign(encode, param + key);
                if (sign == dn.Sign)//��֤ǩ��
                {
                   OnNotifyEvent(dn);
                }
                else
                {
                    throw new SignVerifyFailedException("֧����֪ͨǩ����֤ʧ��", 102);
                }

            }
            else
            {                     
                throw new CommonAliPayBaseException("֧����֪ͨ��֤ʧ��", 101);
            }
        }
        /// <summary>
        /// �����ص�Notify
        /// </summary>
        /// <param name="page">����Page����</param>
        /// <param name="verifyUrl">��֤�ĵ�ַ���磺https://www.alipay.com/cooperate/gateway.do</param>
        /// <param name="key">�˻��Ľ��װ�ȫУ���루key��</param>
        /// <param name="verify">verify����</param>
        /// <param name="encode">����</param>
        /// <exception cref="SignVerifyFailedException">֧����֪ͨǩ����֤ʧ��</exception>
        /// <exception  cref="CommonAliPayBaseException">֧����֪ͨ��֤ʧ��</exception>
        public void ProcessNotify(Page page, string verifyUrl, string key, Verify verify, string encode)
        {

            if (VerifyNotify(verifyUrl, verify))  //��֤�ɹ�
            {
                NotifyEventArgs dn = new NotifyEventArgs();
                dn = ParseNotify(GetReqParas(page), dn);//�����¼�����


                //SortedList<string, string> sortedList = GetParam(dn);
                SortedList<string, string> sortedList = GetParamFromReqPara(GetReqParas(page));

                string param = GetUrlParam(sortedList, false);
#if (DEBUG)
                Log4net.log.Error(param + "param");
#endif

                string sign = GetMd5Sign(encode, param + key);
                if (sign == dn.Sign)//��֤ǩ��
                {
                    // ����״̬����
                    switch (dn.Trade_Status)
                    {
                        case "WAIT_SELLER_SEND_GOODS":
                            OnWaitSellerSendGoods(dn);
                            break;
                        case "WAIT_BUYER_PAY":
                            OnWaitBuyerPay(dn);
                            break;
                        case "WAIT_SELLER_CONFIRM_TRADE":
                            OnWaitSellerConfirmTrade(dn);
                            break;
                        case "WAIT_SYS_CONFIRM_PAY":
                            OnWaitSysConfirmPay(dn);
                            break;
                        case "WAIT_BUYER_CONFIRM_GOODS":
                            OnWaitBuyerConfirmGoods(dn);
                            break;
                        case "WAIT_SYS_PAY_SELLER":
                            OnWaitSysPaySeller(dn);
                            break;

                        case "TRADE_FINISHED":
                            OnTradeFinished(dn);
                            break;
                        case "TRADE_CLOSED":
                            OnTradeClosed(dn);
                            break;
                        case "modify.tradeBase.totalFee":
                            OnModifyTradeBaseTotalFee(dn);
                            break;
                        default:
                            throw new NotImplementedException(dn.Trade_Status);
                    }
                    // �˿�״̬����
                    switch (dn.Refund_Status)
                    {
                        case "REFUND_CLOSED":
                            OnRefundClose(dn);
                            break;
                        case "REFUND_SUCCESS":
                            OnRefundSuccess(dn);
                            break;
                        case "WAIT_SELLER_AGREE":
                            OnWaitSellerAgree(dn);
                            break;
                    }


                    page.Response.Write("success");
                }

               else
                {

                    page.Response.Write("fail");
                    throw new CommonAliPayBaseException("֧����֪ͨǩ����֤ʧ��", 102);
 #if (DEBUG)
                    Log4net.log.Error("֧����֪ͨǩ����֤ʧ��");
#endif
                }

            }
            else
            {

                page.Response.Write("fail");
                throw new CommonAliPayBaseException("֧����֪ͨ��֤ʧ��", 101);
            }

        }


        #endregion
        #region private
        private NameValueCollection GetReqParas(Page page)
        {

            if (page.Request.RequestType == "GET")
            {
                return page.Request.QueryString;
            }
            else
            {
                return page.Request.Form;
            }
        }

        /// <summary>
        /// ֪ͨ��֤�ӿ�
        /// </summary>
        /// <param name="verifyUrl"></param>
        /// <param name="verify">��֤����</param>
        /// <returns>true��ͨ����֤</returns>
        private bool VerifyNotify(string verifyUrl, Verify verify)
        {
            //#if (DEBUG)
            //            {
            //                return true;
            //            }
            //#endif
            string param;
            SortedList<string, string> sl = GetParam(verify);
            param = GetUrlParam(sl, true);
            string result = PostData(verifyUrl, param, "utf-8");
            //����result
            return bool.Parse(result); ;

        }
        /// <summary>
        ///  ����Form���ϵ�DigitalNotifyEventArgs,ֵ���ͻᱻ��ʼ��Ϊnull
        /// </summary>
        /// <param name="nv"></param>
        /// <param name="obj"></param>
        /// <remarks>Ϊ��ֵֹ���͵�Ĭ��ֵ��Ⱦ��������,����nullable����</remarks>
        private NotifyEventArgs ParseNotify(NameValueCollection nv, object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo pi in propertyInfos)
            {
                string v = nv.Get(pi.Name.ToLower());
                if (v != null)
                {
                    if (pi.PropertyType == typeof(string))
                    {
                        pi.SetValue(obj, v, null);
                    }
                    else if (pi.PropertyType == typeof(int?))
                    {
                        pi.SetValue(obj, int.Parse(v), null);
                    }
                    else if (pi.PropertyType == typeof(decimal?))
                    {

                        pi.SetValue(obj, decimal.Parse(v), null);
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {

                        pi.SetValue(obj, DateTime.Parse(v), null);
                    }
                    else if (pi.PropertyType == typeof(bool))
                    {

                        pi.SetValue(obj, bool.Parse(v), null);
                    }
                    else
                    {
                        //ת��ʧ�ܻ��׳��쳣
                        pi.SetValue(obj, v, null);
                    }
                }

            }
            return (NotifyEventArgs)obj;

        }
        /// <summary>
        /// ��ȡMd5sign��Ĳ���
        /// </summary>
        /// <param name="digitalGoods"></param>
        /// <returns></returns>
        private string Md5SignParam(DigitalGoods digitalGoods)
        {
            if (digitalGoods.Sign_Type.ToLower() != "md5")
            {
                throw new CommonAliPayBaseException("Sign_Type��֧��MD5", 100);
            }

            SortedList<string, string> goods = GetParam(digitalGoods);

            string param = GetUrlParam(goods, false) + digitalGoods.Sign;
            string encodeParam = GetUrlParam(goods, true) + "&";
            string sign = GetMd5Sign(digitalGoods._Input_Charset, param);
            return encodeParam + string.Format("sign={0}&sign_type={1}", HttpUtility.HtmlEncode(sign),
                HttpUtility.HtmlEncode(digitalGoods.Sign_Type));

        }
        /// <summary>
        /// ��ȡ�����Ĳ���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private SortedList<string, string> GetParam(object obj)
        {

            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            SortedList<string, string> sortedList = new SortedList<string, string>(StringComparer.CurrentCultureIgnoreCase);
            foreach (PropertyInfo pi in propertyInfos)
            {
                if (pi.GetValue(obj, null) != null)
                {
                    if (pi.Name == "Sign" || pi.Name == "Sign_Type")
                    {
                        continue;
                    }
                    sortedList.Add(pi.Name.ToLower(), pi.GetValue(obj, null).ToString());
                }
            }
            return sortedList;
        }

        private SortedList<string, string> GetParamFromReqPara(NameValueCollection nv)
        {

            SortedList<string, string> sortedList = new SortedList<string, string>(StringComparer.CurrentCultureIgnoreCase);
            foreach (string key in nv.AllKeys)
            {
                if (key.ToLower() == "sign" || key.ToLower() == "sign_type")
                {
                    continue;
                }
                sortedList.Add(key, nv[key]);
            }
            return sortedList;
        }


        /// <summary>
        /// ��ȡUrl�Ĳ���
        /// </summary>
        /// <param name="sortedList"></param>
        /// <param name="isEncode">�����Ƿ񾭹�����,��ǩ���Ĳ������ñ���,Post�Ĳ���Ҫ����</param>
        /// <returns></returns>

        private string GetUrlParam(SortedList<string, string> sortedList, bool isEncode)
        {

            StringBuilder param = new StringBuilder();
            StringBuilder encodeParam = new StringBuilder();
            
            if (isEncode == false)
            {

                foreach (KeyValuePair<string, string> kvp in sortedList)
                {
                    string t = string.Format("{0}={1}", kvp.Key, kvp.Value);
                    param.Append(t + "&");
                }
                return param.ToString().TrimEnd('&');
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in sortedList)
                {
                    string et = string.Format("{0}={1}", HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value));
                    encodeParam.Append(et + "&");
                }
                return encodeParam.ToString().TrimEnd('&');
            }

        }

        /// <summary>
        /// ��ȡ�ַ�����MD5ǩ��
        /// </summary>
        /// <param name="encode">ǩ��ʱ�õı���</param>
        /// <param name="param">Ҫǩ�����ַ���</param>
        /// <returns></returns>
        private string GetMd5Sign(string encode, string param)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.GetEncoding(encode).GetBytes(param));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private string PostData(string url, string data, string encode)
        {
            CookieContainer cc = new CookieContainer();
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cc;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            Stream requestStream = request.GetRequestStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Uri responseUri = response.ResponseUri;
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(encode));
            string result = readStream.ReadToEnd();
            return result;

        }
        #endregion
    }
}
