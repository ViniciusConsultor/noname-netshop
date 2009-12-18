<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowGiftOrder.aspx.cs" Inherits="NoName.NetShop.BackFlat.Order.ShowGiftOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

<table cellSpacing="0" cellPadding="0" width="100%" border="1"   style="border-color:Black; border-style:solid; border-width:1px;border-collapse:collapse;" >
	<tr>
	<td>订单号</td>
	<td><asp:Label ID="lblOrderId" runat="server"></asp:Label>
	</td>
	<td>用户Id</td>
	<td><asp:Label ID="lblUserId" runat="server"></asp:Label></td>
</tr>
	<tr>
	<td>订单状态</td>
	<td><asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
	</td>
	<td>订单生成时间</td>
	<td><asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
</tr>	
<tr>
	<td>订单配送方式</td>
	<td><asp:Label ID="lblShipMethod" runat="server"></asp:Label>
	</td>
	<td>消耗积分</td>
	<td><asp:Label ID="lblTotalScore" runat="server"></asp:Label>
	</td>
</tr>

    <tr>
	<td colspan="4">
	<asp:GridView ID="gvProducts" runat="server" Width="100%" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="ProductId" HeaderText="商品ID" />
	<asp:BoundField DataField="ProductName" HeaderText="商品名称" />
	<asp:BoundField DataField="Quantity" HeaderText="商品数量" />
	<asp:BoundField DataField="Score" HeaderText="单件所需积分" />
	<asp:BoundField DataField="TotalScore" HeaderText="合计积分" />
	</Columns>
	</asp:GridView>
	</td>
</tr>
    <tr>
	<td colspan="4">收货人信息</td>
</tr>
    <tr>
	<td>姓名</td>
	<td><asp:Label ID="lblReceName" runat="server"></asp:Label></td>
	<td>电话</td>
	<td><asp:Label ID="lblTelePhone" runat="server"></asp:Label></td>
</tr>
    <tr>
	<td>详细地址</td>
	<td colspan="3"><asp:Label runat="server" ID="lblAddress"></asp:Label></td>
	</tr>
    <tr>
	<td>邮编</td>
	<td><asp:Label ID="lblPostcode" runat="server"></asp:Label></td>
	<td>Email</td>
	<td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
</tr>    
<tr>
	<td>用户留言</td>
	<td colspan="3"><asp:Label ID="lblUserNotes" runat="server"></asp:Label></td>
</tr>
<tr>
	<td>订单操作记录</td>
	<td colspan="3">
	<asp:GridView ID="gvActionLog" runat="server" Width="100%" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="ChangeTime" HeaderText="操作时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
	<asp:BoundField DataField="ActInfo" HeaderText="状态改变" />
	<asp:BoundField DataField="remark" HeaderText="操作说明" />
	<asp:BoundField DataField="Operator" HeaderText="操作人" />
   </Columns>
	</asp:GridView>
</td>
</tr>
<tr>
<td colspan="4">
<asp:TextBox ID="txtActionRemark" runat="server" MaxLength="100"></asp:TextBox>
<asp:Button runat="server" ID="btnPrepareGoods" onclick="btnPrepareGoods_Click" Text="开始备货"   />
<asp:Button runat="server" ID="btnSend" onclick="btnSend_Click" Text="发货"  />
<asp:Button runat="server" ID="btnFail" onclick="btnFail_Click" Text="交易失败"   />
<asp:Button runat="server" ID="btnFinish" onclick="btnFinish_Click" Text="交易完成"   />
</td>
</tr>
</table>
    </div>
    </form>
</body>
</html>
