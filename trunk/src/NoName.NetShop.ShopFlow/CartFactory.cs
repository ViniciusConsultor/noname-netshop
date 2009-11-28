using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Reflection;
using NoName.NetShop.ShopFlow.Config;

namespace NoName.NetShop.ShopFlow
{
    public class CartFactory
    {
        private CartFactory() { 
        }

        private static CartFactory instance = new CartFactory();
        public static CartFactory Instance()
        {
            return instance;
        }

        public BaseCart GetCart(string key)
        {
            if (HttpContext.Current.Session == null)
                return null;

            BaseCart cart = HttpContext.Current.Session[key] as BaseCart;
            if (cart == null)
            {
                ShopStepSection section = ConfigurationManager.GetSection("shopping/steps") as ShopStepSection;
                ShopStepElement element = section.Steps[key];

                if (element != null)
                {
                    cart = Activator.CreateInstance(Type.GetType(element.Type), element.Key) as BaseCart;
                    HttpContext.Current.Session[key] = cart;
                }
            }
            return cart;
        }

        public ShopCart GetShopCart(string key)
        {
            return GetCart(key) as ShopCart;
        }

        public CommShopCart GetCommShopCart(string key)
        {
            return GetCart(key) as CommShopCart;
        }

    }
}
