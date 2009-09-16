<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.OrderModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UserId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderStatus
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayMethod
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPayMethod" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ShipMethod
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblShipMethod" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayStatus
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPayStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Paysum
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPaysum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ShipFee
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblShipFee" runat="server"></asp:Label>
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
		DerateFee
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDerateFee" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddressId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddressId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverEmail
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverEmail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverPhone
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverPhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Postalcode
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPostalcode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverCity
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverCity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverProvince
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverProvince" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddressDetial
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddressDetial" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ChangeTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblChangeTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPayTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderType" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
