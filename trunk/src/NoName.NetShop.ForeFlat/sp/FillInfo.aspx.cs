using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using NoName.NetShop.Member.Model;
using NoName.NetShop.IMMessage;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.sp
{
    public partial class FillInfo : ShopBasePage
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
                    ShowPaysumInfo();
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
            if (String.IsNullOrEmpty(CurrentShopCart.OrderId) || !CurrentShopCart.Exists())
            {
                CurrentShopCart.Address = addr;
                CurrentShopCart.UserNotes = txtUserNotes.Text.Trim();
                CurrentShopCart.PayMethodId = int.Parse(this.rbtlPayMethod.SelectedValue); 
                CurrentShopCart.ShipMethodId = int.Parse(this.rbtlShipMethod.SelectedValue);

                if (CurrentShopCart is CommShopCart)
                {
                    CurrentShopCart.ShipFee = ((CommShopCart)CurrentShopCart).CaculateShipFee(CurrentShopCart.ShipMethodId,
                        CurrentShopCart.Address.RegionId);
                }
                else if (CurrentShopCart is SuitShopCart)
                {
                    CurrentShopCart.ShipFee = ((SuitShopCart)CurrentShopCart).CaculateShipFee(CurrentShopCart.ShipMethodId,
                        CurrentShopCart.Address.RegionId);
                }

                string isNeedInvoce = ReqParas["invoice"].Trim();
                if (isNeedInvoce == "1")
                {
                    CurrentShopCart.Invoice = ReqParas["invoiceTitle"].Trim();
                }
                else
                {
                    CurrentShopCart.Invoice = String.Empty;
                }
                if (CurrentShopCart.PreSaveValidate())
                {
                    CurrentShopCart.Save();
                    NotifyHelper.SendMessage(CurrentUser.UserId, "您刚刚提交了一个新订单", "您刚刚提交了一个新订单");
                    NotifyHelper.SendMail(CurrentUser.UserEmail, "您刚刚提交了一个新订单", "您刚刚提交了一个新订单");
                    Context.Items.Add("SavedOrderId", CurrentShopCart.OrderId);
                    CurrentShopCart.RecentSavedOrderId = CurrentShopCart.OrderId;
                    CurrentShopCart.OrderId = String.Empty;
                    CurrentShopCart.OrderProducts.Clear();
                    CurrentShopCart.SaveCartToCookie();
                    CurrentShopCart.GoNext();
                }

            }
        }

        private void ShowPaysumInfo()
        {
            this.lblPaySum.Text = String.Format("订单金额：商品费用：￥{0} + 配送费：￥{1} - 优惠费用：￥{2} = ￥{3}",
                CurrentShopCart.ProductSum, CurrentShopCart.ShipFee, CurrentShopCart.DerateFee, CurrentShopCart.TotalSum);
        }
    }
}
