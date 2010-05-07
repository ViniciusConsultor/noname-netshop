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
using System.Linq;
using NoName.NetShop.ForeFlat.member.PawnShop;
using System.Collections.Generic;

namespace NoName.NetShop.ForeFlat.alipay
{
    public partial class StandardPay : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CommOrderBll obll = new CommOrderBll();
            string orderId = Request.QueryString["orderId"];

            CommOrderModel model = obll.GetModel(orderId);
            List<CommOrderItemModel> items = obll.GetOrderItems(orderId);
            string subject = String.Join(",", (from s in items select s.ProductName).ToArray());
            int quantity = (from s in items select s.Quantity).Sum();
            string paymethod = (model.ShipMethod == ShipMethodType.EMS?"EMS":"Express");

            subject = String.IsNullOrEmpty(subject)?null:subject;
            string agent =null;
            string body = null;
            AliPay ap = new AliPay();
            StandardGoods bp = new StandardGoods(PayServiceType.trade_create_by_buyer.Key, AlipaySetting.Partner, AlipaySetting.NotifyUrl,AlipaySetting.ReturnUrl,
                agent,AlipaySetting.EncodeType,AlipaySetting.Key,AlipaySetting.SignType,subject,body,model.OrderId,
                model.Paysum, quantity, null,AlipaySetting.SellerEmail, null,null,null,null,
                "POST", model.ShipFee, LogisticsPayment.SELLER_PAY.Key, "1");


            bp.Notify_Url = AlipaySetting.NotifyUrl;
            bp.Return_Url = AlipaySetting.ReturnUrl;
            bp.Receive_Address = model.FullAddress;
            bp.Receive_Phone = model.RecieverPhone;
            bp.Receive_Zip = model.Postalcode;
            bp.Receive_Name = model.RecieverName;

            ap.CreateStandardTrade(AlipaySetting.PushUrl, bp, this);
        }
    }

}