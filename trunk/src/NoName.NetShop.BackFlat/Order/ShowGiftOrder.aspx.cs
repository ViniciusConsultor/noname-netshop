using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class ShowGiftOrder : System.Web.UI.Page
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
            GiftOrderModel order = bll.GetModel(orderId);
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

                ShowActions(order);
            }
        }

        /// <summary>
        /// 显示允许管理员操作的按钮
        /// 支付成功，—— 审核通过，开始备货 
        /// 支付成功，—— 退还积分给买家，交易失败
        /// 开始备货，—— 发货
        /// 开始备货 —— 退还积分给买家，交易失败
        /// 已发货，—— 物流确认到货，交易完成
        /// 已发货，—— 买家拒收，退还积分给买家，交易失败
        /// </summary>
        /// <param name="order"></param>
        private void ShowActions(GiftOrderModel order)
        {
            btnPrepareGoods.Visible = false;
            btnFail.Visible = false;
            btnSend.Visible = false;
            btnFinish.Visible = false;

            if (order.OrderStatus == OrderStatus.交易完成 || order.OrderStatus == OrderStatus.交易失败)
            {
                txtActionRemark.Visible = false;
            }

            if (order.OrderStatus == OrderStatus.已创建)
            {
                btnFail.Visible = true;
                btnPrepareGoods.Visible = true;
            }
            else if (order.OrderStatus == OrderStatus.备货中)
            {
                btnFail.Visible = true;
                btnSend.Visible = true;
            }
            else if (order.OrderStatus == OrderStatus.已发货)
            {
                btnFail.Visible = true;
                btnFinish.Visible = true;
            }
        }

        /// <summary>
        /// 发货，前置条件为：订单处于备货状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            GiftOrderBll obll = new GiftOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            GiftOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.备货中)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.已发货);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.已发货.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }

        }
 
        /// <summary>
        /// 置为备货状态，前置条件为：订单为初始创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrepareGoods_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.已创建)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.备货中);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.备货中.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

        /// <summary>
        /// 置为交易失败，前置条件为：货到付款订单，已发货；其他订单，已退款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFail_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && 
                (order.OrderStatus== OrderStatus.已创建 || order.OrderStatus== OrderStatus.备货中 
                || order.OrderStatus== OrderStatus.已发货))
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.交易失败);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.交易失败.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

 
        /// <summary>
        /// 置为订单完成，前置条件：物流已到货，且支付成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.已发货)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.交易完成);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.交易完成.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

    }
}
