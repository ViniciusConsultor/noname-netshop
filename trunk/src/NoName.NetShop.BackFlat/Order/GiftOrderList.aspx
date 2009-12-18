<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftOrderList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Order.GiftOrderList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" media="screen" href="../css/datePicker.css" />
<script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../js/date.js"></script>
<script type="text/javascript" src="../js/jquery.datePicker.js"></script>    
<script type="text/javascript" charset="utf-8">
    $(function() {
        var now = new Date();
        var enddate = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate();
        $('.date-pick').datePicker({ startDate: '2009-01-01', endDate: enddate, createButton: false, clickInput: true });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <div id="data-list">
        <div>
        订单ID：<asp:TextBox runat="server" ID="txtOrderId"></asp:TextBox>
        &nbsp; 
  订单生成时间：从 
  <asp:TextBox Width="71" runat="server" ID="txtStartDate" CssClass="date-pick"></asp:TextBox>
  到
  <asp:TextBox Width="71" runat="server" ID="txtEndDate" CssClass="date-pick"></asp:TextBox>
            <br />
  物流状态：<asp:DropDownList runat="server" ID="ddlOrderStatus">
  <asp:ListItem Text="请选择……" Value=""></asp:ListItem>
  <asp:ListItem Text="创建" Value="0"></asp:ListItem>
  <asp:ListItem Text="确认" Value="1"></asp:ListItem>
  <asp:ListItem Text="发货" Value="2"></asp:ListItem>
  <asp:ListItem Text="完成" Value="3"></asp:ListItem>
  <asp:ListItem Text="关闭" Value="4"></asp:ListItem>
  </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="· 查询 ·" ID="btnSearch"
         onclick="btnSearch_Click" />
        </div>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="orderid" HeaderText="订单ID" />            
                    <asp:BoundField DataField="userid" HeaderText="用户Id" />
                    <asp:TemplateField HeaderText="物流状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.OrderStatus),Convert.ToInt32(Eval("orderstatus"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="配送方式">
                        <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.ShopFlow.ShipMethodType),Convert.ToInt32(Eval("shipmethod"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TotalScore" HeaderText="消耗积分" />
                    <asp:BoundField DataField="createtime" HeaderText="生成时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowGiftOrder.aspx?orderid="+Eval("OrderID") %>' />
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
