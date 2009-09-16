<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.SuitProductModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		SuitProductId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSuitProductId" runat="server"></asp:Label>
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
		SuitName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSuitName" runat="server"></asp:Label>
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
		TradePrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTradePrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Status
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
