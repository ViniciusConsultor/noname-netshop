<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="ShowOrder.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.ShowOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">

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
	<td>支付状态</td>
	<td><asp:Label ID="lblPayStatus" runat="server"></asp:Label></td>
</tr>	
<tr>
	<td>订单生成时间</td>
	<td><asp:Label ID="lblCreateTime" runat="server"></asp:Label>
	</td>
	<td>订单支付时间</td>
	<td><asp:Label ID="lblPayTime" runat="server"></asp:Label></td>
</tr>	<tr>
	<td>订单支付方式</td>
	<td><asp:Label ID="lblPayMethod" runat="server"></asp:Label>
	</td>
	<td>订单配送方式</td>
	<td><asp:Label ID="lblShipMethod" runat="server"></asp:Label></td>
</tr>
    <tr>
	<td>商品金额</td>
	<td>配送费用</td>
	<td>减免费用</td>
	<td>总金额</td>
</tr>
    <tr>
	<td><asp:Label runat="server" ID="lblProductFee"></asp:Label></td>
	<td><asp:Label runat="server" ID="lblShipFee"></asp:Label></td>
	<td><asp:Label runat="server" ID="lblDerateFee"></asp:Label></td>
	<td><asp:Label runat="server" ID="lblPaySum"></asp:Label></td>
</tr>
    <tr>
	<td colspan="4">
	<asp:GridView ID="gvProducts" runat="server" Width="100%" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="ProductId" HeaderText="商品ID" />
	<asp:BoundField DataField="ProductName" HeaderText="商品名称" />
	<asp:BoundField DataField="Quantity" HeaderText="商品数量" />
	<asp:BoundField DataField="FactPrice" HeaderText="单价" />
	<asp:BoundField DataField="Score" HeaderText="产生积分" />
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
	<td>发票</td>
	<td><asp:Label ID="lblInvoice" runat="server"></asp:Label></td>
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
	<asp:BoundField DataField="ActInfo" HeaderText="状态改变" />
	<asp:BoundField DataField="ChangeTime" HeaderText="操作时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
   </Columns>
	</asp:GridView>
</td>
</tr>
<tr>
<td colspan="4">
<asp:TextBox ID="txtActionRemark" runat="server" MaxLength="100"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ID="rfvActionRemark" ControlToValidate="txtActionRemark"
 Display="Dynamic" ErrorMessage="请填写操作备注" EnableClientScript="true"></asp:RequiredFieldValidator>  
<asp:Button runat="server" ID="btnGoPay" onclick="btnGoPay_Click" Text="付款"   />
<asp:Button runat="server" ID="btnAskRefund" onclick="btnAskRefund_Click" Text="申请退款"   />
<asp:Button runat="server" ID="btnCherrys" onclick="btnCherrys_Click" Text="确认收货"   />
</td>
</tr>
</table>


</asp:Content>
