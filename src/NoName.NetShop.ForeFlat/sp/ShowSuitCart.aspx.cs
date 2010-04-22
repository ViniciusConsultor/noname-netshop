using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class ShowSuitCart : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CurrentShopCart = CartFactory.Instance().GetCart("suit") as ShopCart;
            if (CurrentShopCart == null)
            {
                panNoData.Visible = true;
                Response.AddHeader("REFRESH", "3;URL='http://dingding.uncc.cn/'");
            }

            if (!IsPostBack)
            {
                //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
                Response.Cache.SetNoStore();
                CurrentShopCart.Reset();

                if (!IsPostBack)
                {
                    BindCartData();
                } 
            }

        }

        private void BindCartData()
        {
            panNoData.Visible = false;
            gvList.DataSource = CurrentShopCart.OrderProducts;
            gvList.DataBind();
            //litPaysum.Text = String.Format("商品金额：{0} - 优惠金额：{1}= 订单金额：{2}",
            //    CurrentShopCart.ProductSum, CurrentShopCart.DerateFee, CurrentShopCart.TotalSum);
            if (CurrentShopCart.OrderProducts.Count == 0)
            {
                panNoData.Visible = true;
                Response.AddHeader("REFRESH", "3;URL='http://dingding.uncc.cn/'");
            }
            else
            {
                panNoData.Visible = false;
            }
        }

        protected void gvList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                string opkey = (string)e.CommandArgument;
                OrderProduct op = CurrentShopCart.OrderProducts.Find(c => c.Key == opkey);
                op.SetQuantiy(0);
                CurrentShopCart.SaveCartToCookie();
            }
            BindCartData();
        }

        protected void lbtnClear_Click(object sender, EventArgs e)
        {
            CurrentShopCart.OrderProducts.Clear();
            BindCartData();
        }

        protected void lbtnGoPay_Click(object sender, EventArgs e)
        {
            CurrentShopCart.SaveCartToCookie();
            CurrentShopCart.GoNext();
        }

    }
}
