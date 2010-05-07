using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NoName.NetShop.CommonAliPay;
using NoName.NetShop.ShopFlow;
using System.Text;
using log4net;
using System.Collections.Specialized;

namespace NoName.NetShop.ForeFlat.alipay
{
    public partial class Notify : ShopBasePage
    {
        private CommOrderBll obll = new CommOrderBll();
        private OrderChangeLogBll lbll = new OrderChangeLogBll();
        private static ILog log = log4net.LogManager.GetLogger("AlipayNotify");

        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info(Request.Url.AbsoluteUri);
            LogRequestInfo(this.ReqParas);

            string key = AlipaySetting.Key; //填写自己的key
            string partner = AlipaySetting.Partner;//填写自己的Partner

            AliPay ap = new AliPay();
            string notifyid = ReqParas["notify_id"];
            Verify v = new Verify("notify_verify", partner, notifyid);
            ap.TradeClosed += new AliPay.ProcessNotifyEventHandler(ap_TradeClosed);
            ap.TradeFinished += new AliPay.ProcessNotifyEventHandler(ap_TradeFinished);
            ap.WaitBuyerConfirmGoods += new AliPay.ProcessNotifyEventHandler(ap_WaitBuyerConfirmGoods);
            ap.WaitBuyerPay += new AliPay.ProcessNotifyEventHandler(ap_WaitBuyerPay);
            ap.WaitSellerConfirmTrade += new AliPay.ProcessNotifyEventHandler(ap_WaitSellerConfirmTrade);
            ap.WaitSellerSendGoods += new AliPay.ProcessNotifyEventHandler(ap_WaitSellerSendGoods);
            ap.WaitSysConfirmPay += new AliPay.ProcessNotifyEventHandler(ap_WaitSysConfirmPay);
            ap.WaitSysPaySeller += new AliPay.ProcessNotifyEventHandler(ap_WaitSysPaySeller);
            ap.ModifyTradeBaseTotalFee += new AliPay.ProcessNotifyEventHandler(ap_ModifyTradeBaseTotalFee);
            ap.RefundClose += new AliPay.ProcessNotifyEventHandler(ap_RefundClose);
            ap.RefundSuccess += new AliPay.ProcessNotifyEventHandler(ap_RefundSuccess);
            ap.WaitSellerAgree += new AliPay.ProcessNotifyEventHandler(ap_WaitSellerAgree);
            ap.ProcessNotify(this, AlipaySetting.PushUrl, key, v, "utf-8");
        }
        /// <summary>
        /// 买家申请退款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitSellerAgree(object sender, NotifyEventArgs e)
        {
            log.Info("买家申请退款，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangePayStatus(e.Out_Trade_No, PayStatus.退款申请中);
                lbll.Add(e.Out_Trade_No, e.Trade_Status + " " + e.Refund_Status, PayStatus.退款申请中.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 退款成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_RefundSuccess(object sender, NotifyEventArgs e)
        {
            log.Info("退款成功，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangePayStatus(e.Out_Trade_No, PayStatus.退款完成);
                lbll.Add(e.Out_Trade_No, e.Trade_Status + " " + e.Refund_Status, PayStatus.退款完成.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 退款关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_RefundClose(object sender, NotifyEventArgs e)
        {
            log.Info("退款关闭，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangePayStatus(e.Out_Trade_No, PayStatus.支付成功);
                string remark = "退款关闭，订单重置为支付成功，" + e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No,remark , PayStatus.支付成功.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 修改交易价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_ModifyTradeBaseTotalFee(object sender, NotifyEventArgs e)
        {
            log.Info("修改交易价格，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                if (e.Is_Total_Fee_Adjust == "T")
                {
                    obll.ModifyTotalFee(e.Out_Trade_No, e.Total_Fee ?? 0);
                    string remark = String.Format("修改订单金额，修改前总价为：{0},修改后的的总价为：{1}，相关状态为：{2}",
                        omodel.Paysum, e.Total_Fee, e.Trade_Status + " " + e.Refund_Status);
                    lbll.Add(e.Out_Trade_No, remark, "议价", "alipay");
                }
            }
        }
        /// <summary>
        /// 买家确认收到货，等待支付宝打款给卖家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitSysPaySeller(object sender, NotifyEventArgs e)
        {
            log.Info("买家确认收到货，等待支付宝打款给卖家，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangeOrderStatus(e.Out_Trade_No, OrderStatus.买家确认);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.买家确认.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 确认买家付款中，请勿操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitSysConfirmPay(object sender, NotifyEventArgs e)
        {
            log.Info("确认买家付款中，请勿操作，订单号为：" + e.Out_Trade_No);
        }
        /// <summary>
        /// 交易已创建，等待卖家确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitSellerConfirmTrade(object sender, NotifyEventArgs e)
        {
            log.Info("交易已创建，等待卖家确认，订单号为：" + e.Out_Trade_No);
        }
        /// <summary>
        /// 等待买家确认收货中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitBuyerConfirmGoods(object sender, NotifyEventArgs e)
        {
            log.Info("等待买家确认收货中，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangeOrderStatus(e.Out_Trade_No, OrderStatus.买家确认);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.买家确认.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 交易成功结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_TradeFinished(object sender, NotifyEventArgs e)
        {
            log.Info("交易成功结束，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangeOrderStatus(e.Out_Trade_No, OrderStatus.交易完成);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.交易完成.ToString(), "alipay");
            }
        }

        /// <summary>
        /// 交易中途关闭（未完成）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_TradeClosed(object sender, NotifyEventArgs e)
        {
            log.Info("交易中途关闭（未完成），订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangeOrderStatus(e.Out_Trade_No, OrderStatus.交易关闭);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.交易关闭.ToString(), "alipay");
            }
        }
        /// <summary>
        /// 交易创建，等待买家付款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ap_WaitBuyerPay(object sender, NotifyEventArgs e)
        {
            log.Info("交易创建，等待买家付款，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangeOrderStatus(e.Out_Trade_No, OrderStatus.已创建);
                obll.SetPayOrderId(e.Out_Trade_No, e.Trade_No);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.已创建.ToString(), "alipay");
            }
        }

        /// <summary>
        /// 买家付款成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ap_WaitSellerSendGoods(object sender, NotifyEventArgs e)
        {
            log.Info("买家付款成功，订单号为：" + e.Out_Trade_No);
            CommOrderModel omodel = obll.GetModel(e.Out_Trade_No);
            if (omodel.PayMethod == PayMethType.支付宝)
            {
                obll.ChangePayStatus(e.Out_Trade_No, PayStatus.支付成功);
                string remark = e.Trade_Status + " " + e.Refund_Status;
                lbll.Add(e.Out_Trade_No, remark, OrderStatus.交易关闭.ToString(), "alipay");
            }
        }

        private void LogRequestInfo(NameValueCollection paras)
        {
            StringBuilder parasstr = new StringBuilder();
            foreach (string key in paras.Keys)
            {
                parasstr.AppendFormat("{0}={1}&", key, paras[key]);
            }

            log.Info("订单通知内容：ip: " + Request.UserHostAddress
                + "; httpmethod: " + Request.HttpMethod
                + "; payinfo: " + parasstr);

        }
    }
}