using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using NoName.NetShop.ShopFlow;
using System.Text.RegularExpressions;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class AddToCart : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
            Response.Cache.SetNoStore();

            NameValueCollection paras = Request.QueryString;

            

            int  quantity=1;
            int opval;
            OrderType opType;
            // 必须的参数
            if (!Regex.IsMatch(paras["pid"],@"(\d+,)*(\d+)"))
            {
                throw new ShopException("传入的数据有误", true);
            }

            if (!int.TryParse(paras["opt"], out opval))
            {
                opval = 0;
            }
            opType = (OrderType)opval;
            SetCurrentShopCart();

            if (CurrentShopCart != null)
            {
                string[] pids = paras["pid"].Split(',');
                foreach(string pid in pids)
                {
                    OrderProduct op = CurrentShopCart.AddToCart( opType, int.Parse(pid), quantity, paras);
                    if (op != null)
                    {
                        CurrentShopCart.ContinueShopUrl = op.ProductUrl;
                    }
                }
                if (CurrentShopCart.ProductNum > 0)
                {
                    CurrentShopCart.SaveCartToCookie();
                    CurrentShopCart.GoFirst();
                }
                else
                {
                    Response.Write("此商品暂时无法购买!");
                }
            }
        }



        private void SetCurrentShopCart()
        {
            string cartName = String.Empty;
            if (!String.IsNullOrEmpty(ReqParas["cname"]))
                cartName = ReqParas["cname"];
            else
                cartName = "commcart";

            CurrentShopCart = CartFactory.Instance().GetCart(cartName) as ShopCart;
        }


    }
}
