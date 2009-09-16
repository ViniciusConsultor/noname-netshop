<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.OrderItemModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		OrderId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderItem
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderItem" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductFee
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductFee" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Quantity
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQuantity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DerateFee
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDerateFee" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MerchantPrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMerchantPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TotalFee
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTotalFee" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
