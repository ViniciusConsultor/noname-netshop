using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class FinishOrder : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
            Response.Cache.SetNoStore();

            if (CurrentShopCart == null)
            {
                Response.Write("购物车已清空，页面将<a href='../member/MyOrderList.aspx'>跳转</a>至账户中心！");
                Response.AddHeader("REFRESH", "3;URL='../member/MyOrderList.aspx'");
                Response.End();
            }

            if (!IsPostBack)
            {
                litSavedOrderId.Text = CurrentShopCart.RecentSavedOrderId.ToString();
                Context.Items.Remove("SavedOrderId");

                CommOrderBll cobll = new CommOrderBll();
                CommOrderModel model = cobll.GetModel(litSavedOrderId.Text);
                if (model != null && String.IsNullOrEmpty(model.PayorderId) && model.PayMethod == PayMethType.支付宝)
                {
                    string url = "../alipay/StandardPay.aspx?orderId=" + litSavedOrderId.Text;
                    Response.Write("订单已生成，页面将<a href='" + url + "'>跳转</a>支付页面！");
                    Response.AddHeader("REFRESH", "3;URL='" + url + "'");
                }
                
            }
        }

    }
}
