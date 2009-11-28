using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member.Model;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class GiftShopping : ShopBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //可以在页面加载时设置页面的缓存为“SetNoStore()”，即无缓存 
            Response.Cache.SetNoStore();
            if (CurrentShopCart == null || CurrentShopCart.OrderProducts.Count == 0)
            {
                Response.Write("购物车已清空，页面将<a href='http://dingding.uncc.cn/'>跳转</a>至商城首页！");
                Response.AddHeader("REFRESH", "3;URL='http://dingding.uncc.cn/'");
                Response.End();
            }

            if (!IsPostBack)
            {
                if (!CurrentShopCart.ValidStep())
                {
                    CurrentShopCart.GoFirst();
                }
                else
                {
                    ucAddress.ShowAddressList(CurrentUser.UserId);
                }

            }
        }


        protected void lbtnDoCreate_Click(object sender, EventArgs e)
        {
            AddressModel addr = ucAddress.GetSelectedAddressInfo(this.CurrentUser.UserId);
            if (addr == null)
            {
                this.ClientAlert("收货人地址信息不完整，请重新填写");
                return;
            }
            if (String.IsNullOrEmpty(CurrentShopCart.OrderId) && !CurrentShopCart.Exists())
            {
                CurrentShopCart.Address = addr;
                CurrentShopCart.ShipMethodId = int.Parse(rbtlShipMethod.SelectedValue);

                if (CurrentShopCart.PreSaveValidate())
                {
                    CurrentShopCart.Save();
                    Context.Items.Add("SavedOrderId", CurrentShopCart.OrderId);
                    CurrentShopCart.RecentSavedOrderId = CurrentShopCart.OrderId;
                    CurrentShopCart.OrderId = String.Empty;
                    CurrentShopCart.OrderProducts.Clear();
                    CurrentShopCart.SaveCartToCookie();
                    CurrentShopCart.GoNext();
                }

            }
        }
    }
}
