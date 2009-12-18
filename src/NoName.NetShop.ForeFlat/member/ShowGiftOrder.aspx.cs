using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class ShowGiftOrder : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderId = NoName.Utility.input.Filter(Request.QueryString["orderId"]);
            if (!String.IsNullOrEmpty(orderId))
            {
                ShowOrderInfo(orderId);
            }
        }

        private void ShowOrderInfo(string orderId)
        {
            GiftOrderBll bll = new GiftOrderBll();
            GiftOrderModel order = bll.GetModel(orderId,this.CurrentUser.UserId);
            if (order != null)
            {
                gvProducts.DataSource = bll.GetOrderItems(orderId);
                gvProducts.DataBind();
                gvActionLog.DataSource = bll.GetChangeLogs(orderId);
                gvActionLog.DataBind();

                lblOrderId.Text = order.OrderId;
                lblUserId.Text = order.UserId;
                lblOrderStatus.Text = order.OrderStatus.ToString();
                lblCreateTime.Text = order.CreateTime.ToString("yyyy-MM-dd HH:mm");
                lblShipMethod.Text = order.ShipMethod.ToString();
                lblAddress.Text = order.RecieverProvince + order.RecieverCity + order.RecieverCounty + " " + order.AddressDetial;
                lblPostcode.Text = order.Postalcode;
                lblUserNotes.Text = order.UserNotes;
                lblTelePhone.Text = order.RecieverPhone;
                lblReceName.Text = order.RecieverName;
                lblEmail.Text = order.RecieverEmail;
                lblTotalScore.Text = order.TotalScore.ToString();
            }
        }

    }
}
