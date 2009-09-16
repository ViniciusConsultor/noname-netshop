<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.ActionProductModel.Show" Title="ÏÔÊ¾Ò³" %>
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
		ProductName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SmallIamge
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSmallIamge" runat="server"></asp:Label>
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
		OutLinkUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOutLinkUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		StartPrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStartPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddPrices
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddPrices" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CurPrice
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCurPrice" runat="server"></asp:Label>
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
		StartTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStartTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EndTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEndTime" runat="server"></asp:Label>
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
