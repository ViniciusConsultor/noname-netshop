using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CommonAliPay;

namespace NoName.NetShop.ForeFlat.alipay
{
    public partial class ShowPayReturn : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string key = AlipaySetting.Key; //填写自己的key
            string partner = AlipaySetting.Partner;//填写自己的Partner

            AliPay ap = new AliPay();
            string notifyid = Request.Form["notify_id"];
            Verify v = new Verify("notify_verify", partner, notifyid);
            ap.NotifyEvent += new AliPay.ProcessNotifyEventHandler(ap_NotifyEvent);
            ap.ProcessNotify(this, AlipaySetting.PushUrl, key, v, "utf-8");
            ap.CommonProcessNotify(this,AlipaySetting.VerifyUrl,AlipaySetting.Key,v,AlipaySetting.EncodeType);
        }

        void ap_NotifyEvent(object sender, NotifyEventArgs e)
        {
            Response.Redirect("~/member/ShowOrder.aspx?orderId=" + e.Out_Trade_No);
        }
    }
}
