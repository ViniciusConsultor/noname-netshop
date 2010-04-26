using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;
using System.Data;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class ShowCart : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentShopCart = CartFactory.Instance().GetCart("commcart") as ShopCart;
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
                    BindSalesData();
                } 
            }

        }

        private void BindCartData()
        {
            panNoData.Visible = false;
            gvList.DataSource = CurrentShopCart.OrderProducts;
            gvList.DataBind();
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

        private void BindSalesData()
        {
            DataSet ds = new SalesProductModelBll().GetListForShoppingProcedure();

            foreach (DataTable dt in ds.Tables)
                foreach (DataRow row in dt.Rows)
                    row["mediumimage"] = ProductMainImageRule.GetMainImageUrl(row["mediumimage"].ToString());

            Repeater_Reduce.DataSource = ds.Tables[0];
            Repeater_Reduce.DataBind();
            Repeater_Recommend.DataSource = ds.Tables[1];
            Repeater_Recommend.DataBind();
            Repeater_HotSale.DataSource = ds.Tables[2];
            Repeater_HotSale.DataBind();
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
