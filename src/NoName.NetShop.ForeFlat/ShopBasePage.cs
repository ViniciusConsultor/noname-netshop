using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat
{
    public class ShopBasePage:AuthBasePage
    {
        public ShopCart CurrentShopCart
        {
            get { return Session["CurrentShopCart"] as ShopCart; }
            set
            {
                Session["CurrentShopCart"] = value;
            }
        }
    }
}
