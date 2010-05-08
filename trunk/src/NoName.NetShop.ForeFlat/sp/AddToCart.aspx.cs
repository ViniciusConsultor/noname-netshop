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
using System.Web.Configuration;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class AddToCart : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
            Response.Cache.SetNoStore();

            // 购买时传入的参数：
            // 需要区分的购物车商品类型：
            // 通用商品购物车：可以修改数量:pids=pid-qua,pid-qua&opt=类型
            // 积分兑换购物车：没有金额，仅有积分:pids=pid-qua,pid-qua&opt=类型
            // 推荐套装购物车：套装商品不可以修改，只有一个套装价格，没有单品价格，但所含商品需要展示:suitid=suitid&opt=类型
            // 经典套装购物车：选中的套装商品不可以修改，价格根据商品价格计算:pids=pid-qua,pid-qua&opt=类型
            SetCurrentShopCart();

            if (CurrentShopCart != null)
            {
                if (!String.IsNullOrEmpty(ReqParas["pid"])&& Regex.IsMatch(ReqParas["pid"], @"(\d+(\-\d+)?,)*(\d+(\-\d+)?)"))
                {
                    ProcessCommProduct();
                }
                else if (!String.IsNullOrEmpty(ReqParas["suitId"]) && Regex.IsMatch(ReqParas["suitId"], @"\d+"))
                {
                    ProcessSuitCommProduct();
                }
            }

            if (CurrentShopCart.ProductNum > 0)
            {
                CurrentShopCart.SaveCartToCookie();
                CurrentShopCart.GoFirst();
            }
            else
            {
                //string script = "<script type='text/javascript'>alert('此商品暂时无法购买');window.go(-1);</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "clientAlert", script);
                Response.Write("此商品暂时无法购买");
                Response.AddHeader("REFRESH", "3;URL='http://dingding.uncc.cn/'");
            }

        }

        private OrderType GetOpType()
        {
            int opval;
            OrderType opType;
            if (!int.TryParse(ReqParas["opt"], out opval))
            {
                opval = 0;
            }
            opType = (OrderType)opval;
            return opType;
        }

        private void ProcessSuitCommProduct()
        {
            OrderType opType = GetOpType();
            int suitId = int.Parse(ReqParas["suitId"]);
            OrderProduct op = CurrentShopCart.AddToCart(opType, suitId, 1, ReqParas);
        }

        // 通用商品购物车：可以修改数量:pids=pid-qua,pid-qua&opt=类型
        private void ProcessCommProduct()
        {
            OrderType opType = GetOpType();
            string[] pids = ReqParas["pid"].Split(',');
            foreach (string pidstr in pids)
            {
                string[] pd = pidstr.Split('-');
                int pid = int.Parse(pd[0]);
                int quantity = 1;
                if (pd.Length == 2)
                {
                    quantity = int.Parse(pd[1]);
                }
                OrderProduct op = CurrentShopCart.AddToCart(opType, pid, quantity, ReqParas);
                if (op != null)
                {
                    //CurrentShopCart.ContinueShopUrl = op.ProductUrl;
                    CurrentShopCart.ContinueShopUrl = WebConfigurationManager.AppSettings["foreFlatRootUrl"];
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
            CurrentShopCart.UserId = this.CurrentUser.UserId;
        }


    }
}
