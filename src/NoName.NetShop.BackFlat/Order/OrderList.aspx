<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Order.OrderList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <div id="data-list">
        <div>
        订单ID：<asp:TextBox runat="server" ID="txtOrderId"></asp:TextBox>
        <asp:Button runat="server" Text="· 查询 ·" ID="btnSearch"
         onclick="btnSearch_Click" />
        </div>

           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="orderid" HeaderText="订单ID" />            
                    <asp:BoundField DataField="productname" HeaderText="收货人" />
                    <asp:TemplateField HeaderText="物流状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.OrderStatus),Convert.ToInt32(Eval("orderstatus"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="支付状态">
                        <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.PayStatus),Convert.ToInt32(Eval("paystatus"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="支付方式">
                        <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.PayMethType),Convert.ToInt32(Eval("paymethod"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="配送方式">
                        <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.ShipMethodType),Convert.ToInt32(Eval("shipmethod"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="paysum" HeaderText="总金额" />
                    <asp:BoundField DataField="createtime" HeaderText="生成时间" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowOrder.aspx?orderid="+Eval("OrderID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager  ID="pageNav" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString='' onpagechanged="pageNav_PageChanged">
            </cc1:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
