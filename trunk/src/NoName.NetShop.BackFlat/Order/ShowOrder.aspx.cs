using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class ShowOrder : System.Web.UI.Page
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
                CommOrderModel order = bll.GetModel(orderId);
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

                    if (order.SuitId == 0)
                        lblOrderType.Text = "普通订单";
                    else
                        lblOrderType.Text = "套装订单(套装id为：" + order.SuitId + ")";

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
            btnClose.Visible = false;
            btnPrepareGoods.Visible = false;
            btnFail.Visible = false;
            btnSend.Visible = false;
            btnCherrys.Visible = false;
            btnFinish.Visible = false;
            btnPaySucc.Visible = false;
            btnRefund.Visible = false;
            txtActionRemark.Visible = false;

            if (order.OrderStatus == OrderStatus.交易关闭 || order.OrderStatus == OrderStatus.交易失败
                || order.OrderStatus == OrderStatus.交易完成)
            {
                return;
            }

            if (order.PayMethod == PayMethType.货到付款)
            {
                if (order.OrderStatus == OrderStatus.已创建)
                {
                    btnPrepareGoods.Visible = true;
                    btnClose.Visible = true;
                    txtActionRemark.Visible = true;
                }
                else if (order.OrderStatus == OrderStatus.备货中)
                {
                    btnSend.Visible = true;
                    btnClose.Visible = true;
                    txtActionRemark.Visible = true;
                }
                else if (order.OrderStatus == OrderStatus.已发货)
                {
                    btnCherrys.Visible = true;
                    btnFail.Visible = true;
                    txtActionRemark.Visible = true;
                }
                else if (order.OrderStatus == OrderStatus.物流到货)
                {
                    btnFinish.Visible = true;
                    txtActionRemark.Visible = true;
                }
            }

            if (order.PayMethod == PayMethType.银行转账 || order.PayMethod == PayMethType.邮局汇款)
            {
                if (order.PayStatus == PayStatus.等待付款)
                {
                   if (order.OrderStatus == OrderStatus.已创建)
                   { 
                       btnClose.Visible = true;
                       btnPaySucc.Visible = true;
                       txtActionRemark.Visible = true;
                   }
                }
                else if (order.PayStatus == PayStatus.支付成功)
                {
                    if (order.OrderStatus == OrderStatus.已创建)
                    {
                        btnRefund.Visible = true;
                        btnPrepareGoods.Visible = true;
                        txtActionRemark.Visible = true;
                    }
                    else if (order.OrderStatus == OrderStatus.备货中)
                    {
                        btnRefund.Visible = true;
                        btnSend.Visible = true;
                        txtActionRemark.Visible = true;
                    }
                    else if (order.OrderStatus == OrderStatus.已发货)
                    {
                        btnCherrys.Visible = true;
                        txtActionRemark.Visible = true;
                    }
                    else if (order.OrderStatus == OrderStatus.物流到货 || order.OrderStatus == OrderStatus.买家确认)
                    {
                        btnFinish.Visible = true;
                        txtActionRemark.Visible = true;
                    }
                }
                else if (order.PayStatus == PayStatus.退款申请中)
                {
                    btnRefund.Visible = true;
                    txtActionRemark.Visible = true;
                }
                else if (order.PayStatus == PayStatus.退款完成)
                {
                    btnFail.Visible = true;
                    txtActionRemark.Visible = true;
                }
            }

            #region 支付宝
            if (order.PayMethod == PayMethType.支付宝)
            {
                if (order.PayStatus == PayStatus.等待付款 && String.IsNullOrEmpty(order.PayorderId))
                {
                    txtActionRemark.Visible = true;
                    btnClose.Visible = true;
                }
            }

            //if (order.PayMethod == PayMethType.支付宝)
            //{
            //    if (order.PayStatus == PayStatus.等待付款 && String.IsNullOrEmpty(order.PayorderId))
            //    {
            //        txtActionRemark.Visible = true;
            //        btnClose.Visible = true;
            //    }
            //    else if (order.PayStatus == PayStatus.支付成功)
            //    {
                   
            //        btnRefund.Visible = true;

            //        if (order.OrderStatus == OrderStatus.已创建)
            //        {
            //            btnRefund.Visible = true;
            //            btnPrepareGoods.Visible = true;
            //            txtActionRemark.Visible = true;
            //            btnClose.Visible = true;
            //        }
            //        else if (order.OrderStatus == OrderStatus.备货中)
            //        {
            //            btnSend.Visible = true;
            //            txtActionRemark.Visible = true;
            //            if (order.PayStatus == PayStatus.退款申请中)
            //            {
            //                btnRefund.Visible = true;
            //            }
            //        }
            //        else if (order.OrderStatus == OrderStatus.已发货)
            //        {
            //            if (order.PayStatus == PayStatus.退款申请中)
            //            {
            //                btnRefund.Visible = true;
            //            } 
            //            btnCherrys.Visible = true;
            //            txtActionRemark.Visible = true;
            //        }
            //        else if (order.OrderStatus == OrderStatus.物流到货)
            //        {
            //            btnFinish.Visible = true;
            //            txtActionRemark.Visible = true;
            //        }
            //        else if (order.OrderStatus == OrderStatus.买家确认)
            //        {
            //            btnFinish.Visible = true;
            //            txtActionRemark.Visible = true;
            //        }
            //    }
            //    else if (order.PayStatus == PayStatus.退款申请中)
            //    {
            //        txtActionRemark.Visible = true;
            //        btnRefund.Visible = true;
            //    }
            //    else if (order.PayStatus == PayStatus.退款完成)
            //    {
            //        txtActionRemark.Visible = true;
            //        btnFail.Visible = true;
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// 发货，前置条件为：订单处于备货状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.备货中)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.已发货);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.已发货.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }

        }
        /// <summary>
        /// 关闭订单，前置条件为：订单处于初始创建，且未支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.已创建 && order.PayStatus== PayStatus.等待付款)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.交易关闭);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.交易关闭.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

        /// <summary>
        /// 置为备货状态，前置条件为：订单为初始创建，如果是货到付款，不需要判断支付状态，其他的需要为已支付状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrepareGoods_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.已创建 &&
                (order.PayMethod== PayMethType.货到付款 || order.PayStatus == PayStatus.支付成功))
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
                ((order.PayMethod== PayMethType.货到付款 && order.OrderStatus== OrderStatus.已发货) 
                || (order.PayMethod!= PayMethType.货到付款 && order.PayStatus == PayStatus.退款完成)))
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.交易失败);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.交易失败.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

        /// <summary>
        /// 置为买家签收（物流），前置条件：订单已发货
        /// 如果是货到付款订单，同时设置订单支付状态为已支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCherrys_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.OrderStatus == OrderStatus.已发货)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.物流到货);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.物流到货.ToString(),
                    Context.User.Identity.Name);

                if (order.PayMethod == PayMethType.货到付款)
                {
                    obll.ChangePayStatus(order.OrderId, PayStatus.支付成功);
                    lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), PayStatus.支付成功.ToString(),
                        Context.User.Identity.Name);

                }
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
            if (order != null && order.OrderStatus == OrderStatus.物流到货 && order.PayStatus == PayStatus.支付成功)
            {
                obll.ChangeOrderStatus(order.OrderId, OrderStatus.交易完成);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), OrderStatus.交易完成.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }  
      
        /// <summary>
        /// 置为支付成功，前置条件：非线上支付订单且支付状态为等待支付，或者所有订单退款申请中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPaySucc_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null &&               
                ((order.PayMethod != PayMethType.支付宝 && order.PayStatus == PayStatus.等待付款)
                || order.PayStatus == PayStatus.退款申请中))
            {
                obll.ChangePayStatus(order.OrderId, PayStatus.支付成功);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), PayStatus.支付成功.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }

        /// <summary>
        /// 置为退款完成，前置条件：退款申请中订单，不包括货到付款订单
        /// 如果是线上支付订单，需要调用接口完成退款操作（目前暂无接口）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefund_Click(object sender, EventArgs e)
        {
            CommOrderBll obll = new CommOrderBll();
            OrderChangeLogBll lbll = new OrderChangeLogBll();
            CommOrderModel order = obll.GetModel(lblOrderId.Text);
            if (order != null && order.PayMethod!= PayMethType.货到付款 && order.PayStatus == PayStatus.退款申请中)
            {
                obll.ChangePayStatus(order.OrderId, PayStatus.退款完成);
                lbll.Add(order.OrderId, txtActionRemark.Text.Trim(), PayStatus.退款完成.ToString(),
                    Context.User.Identity.Name);
                ShowOrderInfo(lblOrderId.Text);
            }
        }
    }
}
