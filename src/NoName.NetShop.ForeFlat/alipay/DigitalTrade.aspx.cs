using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NoName.NetShop.CommonAliPay;
namespace NoName.NetShop.ForeFlat.alipay
{
    public partial class DigitalTrade : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string key = AlipaySetting.Key;//填写自己的key
            //string partner = AlipaySetting.Partner;//填写自己的Partner
            //AliPay ap = new AliPay();
            //DigitalGoods bp = new DigitalGoods("create_digital_goods_trade_p" PayServiceType. , partner, key, "MD5", "卡2", Guid.NewGuid().ToString(), 2.551m, 1, "hao_ding2000@yahoo.com.cn", "hao_ding2000@yahoo.com.cn");
            //bp.Notify_Url = AlipaySetting.NotifyUrl;
            //ap.CreateDigitalTrade( AlipaySetting.PushUrl , bp, this);

        }
    }
}