using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NoName.NetShop.ForeFlat.pay;
using NoName.NetShop.ShopFlow;
using System.Collections.Generic;
using System.Linq;
using NoName.NetShop.CommonAliPay;

namespace NoName.NetShop.ForeFlat
{
    public partial class GoPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            string orderId = Request.QueryString["orderId"];

            CommOrderModel model = obll.GetModel(orderId);
            List<CommOrderItemModel> items = obll.GetOrderItems(orderId);
            string subject = "test product";
            int quantity = 1;
            string paymethod = (model.ShipMethod == ShipMethodType.EMS ? "EMS" : "EXPRESS");

            //        StandardGoods bp = new StandardGoods(PayServiceType.trade_create_by_buyer.Key, AlipaySetting.Partner,
            //AlipaySetting.Key,
            //AlipaySetting.SignType,
            //subject, model.OrderId, model.Paysum, quantity, AlipaySetting.SellerEmail, AlipaySetting.SellerId,
            //"POST", model.ShipFee, LogisticsPayment.BUYER_PAY.Key, "1");


            //string logistics_type = "POST";
            //string logistics_fee = TextBox2.Text;
            //string logistics_payment = "BUYER_PAY";
            //string logistics_type_1 = "EXPRESS";
            //string logistics_fee_1 = TextBox3.Text;
            //string logistics_payment_1 = "BUYER_PAY";


            //bp.Notify_Url = AlipaySetting.NotifyUrl;
            //bp.Return_Url = AlipaySetting.ReturnUrl;

            //��ʱ���충���ţ�

            string out_trade_no = model.OrderId;
            //ҵ�������ֵ��
            string gateway = AlipaySetting.PushUrl;	//'֧���ӿ�
            string service = PayServiceType.trade_create_by_buyer.Key;
            string partner = AlipaySetting.Partner;		//partner		�������ID			�����ֶ�
            string sign_type = AlipaySetting.SignType;
            string body = "test order";		//body			��Ʒ����    
            string payment_type = "1";                  //֧������	
            string price = model.Paysum.ToString("f2");
            string show_url = "http://dingding.uncc.cn/";
            string seller_email =AlipaySetting.SellerEmail;             //�����˺�
            string key = AlipaySetting.Key;              //partner�˻���֧������ȫУ����
            string return_url = AlipaySetting.ReturnUrl; //������֪ͨ���ؽӿ�
            string notify_url = AlipaySetting.NotifyUrl; //������֪ͨ���ؽӿ�
            string _input_charset = AlipaySetting.EncodeType;
            string logistics_type = "POST";
            string logistics_fee = model.ShipFee.ToString("f2");
            string logistics_payment = LogisticsPayment.BUYER_PAY.Key;
            string logistics_type_1 =null;
            string logistics_fee_1 = null;
            string logistics_payment_1 = null;


            MyAliPay ap = new MyAliPay();
            string aliay_url = ap.CreatUrl(
                gateway,
                service,
                partner,
                sign_type,
                out_trade_no,
                subject,
                body,
                payment_type,
                price,
                show_url,
                seller_email,
                key,
                return_url,
                _input_charset,
                notify_url,
                logistics_type,
                logistics_fee,
                logistics_payment,
                logistics_type_1,
                logistics_fee_1,
                logistics_payment_1,
                quantity.ToString()
                );

            Response.Redirect(aliay_url);
        }
 
    }
}