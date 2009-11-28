using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace NoName.NetShop.ShopFlow
{
    public class SpCartKeyHelper
    {
        private string cartKey;
        private string orderProductKey;

        private ShopCart spCart;
        private OrderProduct spOrderProduct;

        public string CartKey
        {
            get { return cartKey; }
        }

        public string OrderProductKey { get { return orderProductKey; } }

        public ShopCart SpCart { get { return spCart; } }
        public OrderProduct SpOrderProduct { get { return spOrderProduct; } }

        public SpCartKeyHelper(string opKey)
        {
            string[] keys = opKey.Split('_');
            spCart = CartFactory.Instance().GetShopCart(keys[0]);

            if (keys.Length==2)
            {
                spOrderProduct = spCart.GetOrderProduct(opKey);
            }
        }

        public string GetJsonData()
        {
            StringBuilder sb = new StringBuilder(100);
            StringWriter sw = new StringWriter(sb);
            JsonWriter js = new JsonWriter(sw);
            js.WriteStartObject();

            if (spOrderProduct != null)
            {
                js.WritePropertyName("opnum");
                js.WriteValue(spOrderProduct.Quantity);
                js.WritePropertyName("opsum");
                js.WriteValue(spOrderProduct.ProductSum);
                js.WritePropertyName("opscore");
                js.WriteValue(spOrderProduct.TotalScore);
            }
            js.WritePropertyName("carttsum");
            js.WriteValue(spCart.TotalSum);
            js.WritePropertyName("cartpsum");
            js.WriteValue(spCart.ProductSum);
            js.WriteEndObject();
            js.Close();
            return sb.ToString();
        }
    }
}
