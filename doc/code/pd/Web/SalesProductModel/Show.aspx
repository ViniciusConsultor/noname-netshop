<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.SalesProductModel.Show" Title="��ʾҳ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ProductId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SaleType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSaleType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SiteId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSiteId" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
