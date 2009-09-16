<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.ProductModel.Show" Title="ÏÔÊ¾Ò³" %>
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
		ProductName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductCode
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CatePath
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCatePath" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CateId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCateId" runat="server"></asp:Label>
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
		MerchantPrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMerchantPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReducePrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblReducePrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Stock
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStock" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SmallImage
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSmallImage" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MediumImage
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMediumImage" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LargeImage
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLargeImage" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Keywords
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeywords" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Brief
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBrief" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageView
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPageView" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InsertTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInsertTime" runat="server"></asp:Label>
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
		Status
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SortValue
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSortValue" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Score
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScore" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
