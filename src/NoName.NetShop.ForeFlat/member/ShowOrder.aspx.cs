using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class ShowOrder : AuthBasePage
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
            NoName.NetShop.ShopFlow.CommOrderBll bll = new NoName.NetShop.ShopFlow.CommOrderBll();
            CommOrderModel order = bll.GetModel(orderId, CurrentUser.UserId);
            if (order != null)
            {
                gvProducts.DataSource = bll.GetOrderItems(orderId);
                gvProducts.DataBind();
                gvActionLog.DataSource = bll.GetChangeLogs(orderId);
                gvActionLog.DataBind();

                lblOrderId.Text = order.OrderId;
                lblUserId.Text = order.UserId;
                lblOrderStatus.Text = order.OrderStatus.ToString();
                lblPayStatus.Text = order.PayStatus.ToString();
                lblCreateTime.Text = order.CreateTime.ToString("yyyy-MM-dd HH:mm");
                lblPayTime.Text = order.PayTime == null ? "" : (order.PayTime ?? default(DateTime)).ToString("yyyy-MM-dd HH:mm");
                lblPayMethod.Text = order.PayMethod.ToString();
                lblShipMethod.Text = order.ShipMethod.ToString();
                lblProductFee.Text = order.ProductFee.ToString("F2");
                lblShipFee.Text = order.ShipFee.ToString("F2");
                lblDerateFee.Text = order.DerateFee.ToString("F2");
                lblPaySum.Text = order.Paysum.ToString("F2");
                lblAddress.Text = order.RecieverProvince + order.RecieverCity + order.RecieverCounty + " " + order.AddressDetial + " 邮编：" + order.Postalcode;
                lblInvoice.Text = order.IsNeedInvoice ? "需要发票，抬头为：" + order.InvoiceTitle : "不需要发票";
                lblUserNotes.Text = order.UserNotes;
                lblTelePhone.Text = order.RecieverPhone;
                lblReceName.Text = order.RecieverName;
                lblEmail.Text = order.RecieverEmail;

                ShowActions(order);
            }
        }

        /// <summary>
        /// 显示允许管理员操作的按钮
        /// 在线支付
        /// 未支付 —— 关闭订单 
        /// 支付成功，—— 审核通过，开始备货 
        /// 支付成功，—— 退款给买家，交易失败
        /// 开始备货，—— 发货
        /// 开始备货 —— 退款给买家，交易失败
        /// 已发货，—— 物流确认到货
        /// 已发货，—— 买家拒收，退款给买家，交易失败
        /// 物流确认到货，买家确认收货或超时 —— 交易完成
        /// 
        /// 银行转帐，邮件汇款
        /// 未支付 —— 关闭订单
        /// 未支付 —— 买家付款成功
        /// 支付成功，—— 审核通过，开始备货 
        /// 支付成功，—— 退款给买家，交易失败
        /// 开始备货，—— 发货
        /// 开始备货 —— 退款给买家，交易失败
        /// 已发货，—— 物流确认到货，交易完成
        /// 已发货，—— 买家拒收，退款给买家，交易失败
        /// 货到付款
        /// 未支付 —— 关闭订单
        /// 未支付 —— 审核通过，备货
        /// 备货中 —— 发货
        /// 发货中 —— 物流确认收货收款，交易成功
        /// 发货中 —— 买家未签收，交易失败
        /// </summary>
        /// <param name="order"></param>
        private void ShowActions(CommOrderModel order)
        {
            btnAskRefund.Visible = false;
            btnCherrys.Visible = false;
            btnGoPay.Visible = false;
            txtActionRemark.Visible = false;

            if ((order.OrderStatus == OrderStatus.交易关闭 || order.OrderStatus == OrderStatus.交易失败
                || order.OrderStatus == OrderStatus.交易完成)
                && (order.PayStatus == PayStatus.支付成功))
            {
                return;
            }

            if (order.PayMethod == PayMethType.支付宝)
            {
                if (order.PayStatus == PayStatus.等待付款)
                {
                    btnGoPay.Visible = true;
                }
            }

            if (order.PayStatus == PayStatus.支付成功)
            {
                btnAskRefund.Visible = true;
                txtActionRemark.Visible = true;
            }

            if (order.OrderStatus == OrderStatus.已发货)
            {
                btnCherrys.Visible = true;
            }
        }

        /// <summary>
        /// 前往支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/alipay/StandardPay.aspx?orderId=" + this.lblOrderId.Text);
        }

        /// <summary>
        /// 置为买家签收（买家确认），隐含实现，如果为线上支付，则同时跳转至结算页面，前置条件：订单已发货
        /// 如果是货到付款订单，同时设置订单支付状态为已支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCherrys_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order.OrderStatus == OrderStatus.已发货 || order.OrderStatus == OrderStatus.物流到货)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.买家确认);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.买家确认.ToString(),
                    Context.User.Identity.Name);

                if (order.PayMethod == PayMethType.支付宝)
                {
                    // 转向支付结算页面
                }
                ShowOrderInfo(lblOrderId.Text);

            }
        }


        /// <summary>
        /// 置为退款完成，前置条件：退款申请中订单，不包括货到付款订单
        /// 如果是线上支付订单，需要调用接口完成退款操作（目前暂无接口）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAskRefund_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.PayMethod != PayMethType.货到付款 && order.PayStatus == PayStatus.支付成功)
            {
                obll.ChangePayStatus(order.OrderId, PayStatus.退款申请中);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), PayStatus.退款申请中.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }
    }
}
