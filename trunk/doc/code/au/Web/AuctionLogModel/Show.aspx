<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.AuctionLogModel.Show" Title="��ʾҳ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		AuctionId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuctionId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AuctionTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuctionTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AutionPrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAutionPrice" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
