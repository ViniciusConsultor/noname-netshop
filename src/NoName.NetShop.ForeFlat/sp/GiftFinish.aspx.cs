using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class GiftFinish : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
            Response.Cache.SetNoStore();

            if (CurrentShopCart == null)
            {
                Response.Write("购物车已清空，页面将<a href='../member/MyGiftOrders.aspx'>跳转</a>至账户中心！");
                Response.AddHeader("REFRESH", "3;URL='../member/MyGiftOrders.aspx'");
                Response.End();
            }

            if (!IsPostBack)
            {
                litSavedOrderId.Text = CurrentShopCart.RecentSavedOrderId.ToString();
            }
        }
    }
}
