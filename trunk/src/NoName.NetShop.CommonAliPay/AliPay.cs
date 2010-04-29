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
    /// 支付宝接口
    /// </summary>
    public class AliPay
    {
        /// <summary>
        /// 事件委托列表
        /// </summary>
        protected EventHandlerList eventList = new EventHandlerList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ProcessNotifyEventHandler(object sender, NotifyEventArgs e);
        #region 实现交易状态枚举的事件
      

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
        /// 议价
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
        /// 等待买家付款
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
        /// 交易已创建，等待卖家确认
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
        /// 确认买家付款中，暂勿发货
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
        /// 支付宝收到买家付款，请卖家发货
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
        /// 确认买家付款中，暂勿发货
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
        /// 买家确认收到货，等待支付宝打款给卖家
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
        /// 交易成功结束
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
        /// 交易中途关闭（未完成）
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
        #region 实现退款状态枚举的事件
        /// <summary>
        /// 买家申请退款
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
        /// 退款成功
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
        /// 退款关闭
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
        #region 返回用户支付宝Notify信息的事件
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
        /// 创建虚拟交易
        /// </summary>
        /// <param name="gatewayUrl">提交支付宝的地址</param>
        /// <param name="digitalGoods">交易参数</param>
        /// <param name="page">Page对象</param>
        public void CreateDigitalTrade(string gatewayUrl, DigitalGoods digitalGoods, Page page)
        {

            HttpResponse Response = page.Response;
            string t = gatewayUrl + "?" + Md5SignParam(digitalGoods);
            string url = string.Format("<script language='javascript'>window.open(\"{0}\") </script>", t);
            Response.Write(url);

        }
        /// <summary>
        /// 创建标准交易，包含虚拟交易
        /// </summary>
        /// <param name="gatewayUrl">提交支付宝的地址</param>
        /// <param name="standardGoods">交易参数</param>
        /// <param name="page">Page对象</param>
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
        /// 处理返回的Notify
        /// </summary>
        /// <param name="page">传如Page对象</param>
        /// <param name="verifyUrl">验证的地址，如：https://www.alipay.com/cooperate/gateway.do</param>
        /// <param name="key">账户的交易安全校验码（key）</param>
        /// <param name="verify">verify对象</param>
        /// <param name="encode">编码</param>
        /// <exception cref="SignVerifyFailedException">支付宝通知签名验证失败</exception>
        /// <exception  cref="CommonAliPayBaseException">支付宝通知验证失败</exception>
        public void CommonProcessNotify(Page page, string verifyUrl, string key, Verify verify, string encode)
        {
            if (VerifyNotify(verifyUrl, verify))  //验证成功
            {
                NotifyEventArgs dn = new NotifyEventArgs();
                dn = ParseNotify(page.Request.Form, dn);//构造事件参数
                SortedList<string, string> sortedList = GetParam(dn);
                string param = GetUrlParam(sortedList, false);
#if (DEBUG)
                Log4net.log.Error(param + "param");
#endif
                string sign = GetMd5Sign(encode, param + key);
                if (sign == dn.Sign)//验证签名
                {
                   OnNotifyEvent(dn);
                }
                else
                {
                    throw new SignVerifyFailedException("支付宝通知签名验证失败", 102);
                }

            }
            else
            {                     
                throw new CommonAliPayBaseException("支付宝通知验证失败", 101);
            }
        }
        /// <summary>
        /// 处理返回的Notify
        /// </summary>
        /// <param name="page">传如Page对象</param>
        /// <param name="verifyUrl">验证的地址，如：https://www.alipay.com/cooperate/gateway.do</param>
        /// <param name="key">账户的交易安全校验码（key）</param>
        /// <param name="verify">verify对象</param>
        /// <param name="encode">编码</param>
        /// <exception cref="SignVerifyFailedException">支付宝通知签名验证失败</exception>
        /// <exception  cref="CommonAliPayBaseException">支付宝通知验证失败</exception>
        public void ProcessNotify(Page page, string verifyUrl, string key, Verify verify, string encode)
        {

            if (VerifyNotify(verifyUrl, verify))  //验证成功
            {
                NotifyEventArgs dn = new NotifyEventArgs();
                dn = ParseNotify(page.Request.Form, dn);//构造事件参数
                SortedList<string, string> sortedList = GetParam(dn);
                string param = GetUrlParam(sortedList, false);
#if (DEBUG)
                Log4net.log.Error(param + "param");
#endif


                string sign = GetMd5Sign(encode, param + key);
                if (sign == dn.Sign)//验证签名
                {
                    // 交易状态处理
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
                    // 退款状态处理
                    switch (dn.Refund_Status)
                    {
                        case "REFUND_CLOSED":
                            OnRefundClose(dn);
                            break;
                        case "REFUND_SUCCESS":
                            OnRefundSuccess(dn);
                            break;
                        case "WAIT_SELLER_AGREE":
                            OnRefundSuccess(dn);
                            break;
                    }


                    page.Response.Write("success");
                }

               else
                {

                    page.Response.Write("fail");
                    throw new CommonAliPayBaseException("支付宝通知签名验证失败", 102);
                }

            }
            else
            {

                page.Response.Write("fail");
                throw new CommonAliPayBaseException("支付宝通知验证失败", 101);
            }

        }


        #endregion
        #region private
        /// <summary>
        /// 通知验证接口
        /// </summary>
        /// <param name="verifyUrl"></param>
        /// <param name="verify">验证参数</param>
        /// <returns>true，通过验证</returns>
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
            //解析result
            return bool.Parse(result); ;

        }
        /// <summary>
        ///  解析Form集合到DigitalNotifyEventArgs,值类型会被初始化为null
        /// </summary>
        /// <param name="nv"></param>
        /// <param name="obj"></param>
        /// <remarks>为防止值类型的默认值污染参数集合,用了nullable范型</remarks>
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
                        //转型失败会抛出异常
                        pi.SetValue(obj, v, null);
                    }
                }

            }
            return (NotifyEventArgs)obj;

        }
        /// <summary>
        /// 获取Md5sign后的参数
        /// </summary>
        /// <param name="digitalGoods"></param>
        /// <returns></returns>
        private string Md5SignParam(DigitalGoods digitalGoods)
        {
            if (digitalGoods.Sign_Type.ToLower() != "md5")
            {
                throw new CommonAliPayBaseException("Sign_Type不支持MD5", 100);
            }

            SortedList<string, string> goods = GetParam(digitalGoods);

            string param = GetUrlParam(goods, false) + digitalGoods.Sign;
            string encodeParam = GetUrlParam(goods, true) + "&";
            string sign = GetMd5Sign(digitalGoods._Input_Charset, param);
            return encodeParam + string.Format("sign={0}&sign_type={1}", HttpUtility.HtmlEncode(sign),
                HttpUtility.HtmlEncode(digitalGoods.Sign_Type));

        }
        /// <summary>
        /// 获取排序后的参数
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
/*/https://www.alipay.com/cooperate/gateway.do?
            _input_charset
             body
            logistics_fee
                logistics_fee_ 
 * logistics_payment= 
 * logistics_payment_1
 * logistics_type
 * logistics_type_1
 * notify_url
 * out_trade_no=10012203000001
 * partner=2088202913438402
 * payment_type
 * price
 * &quantity=1
 * &return_url=http%3a%2f%2fdingding.uncc.cn%2falipay%2fShowPayReturn.aspx
 * &seller_email=dingding360%40yahoo.cn
 * &service=trade_create_by_buyer
 * &show_url=http%3a%2f%2fdingding.uncc.cn%2f
 * &subject=test+product&sign=2235faf7ce3423bacc915e1494283e7f
 * &sign_type=MD5
 */
        }



        /// <summary>
        /// 获取Url的参数
        /// </summary>
        /// <param name="sortedList"></param>
        /// <param name="isEncode">参数是否经过编码,被签名的参数不用编码,Post的参数要编码</param>
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
        /// 获取字符串的MD5签名
        /// </summary>
        /// <param name="encode">签名时用的编码</param>
        /// <param name="param">要签名的字符串</param>
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
