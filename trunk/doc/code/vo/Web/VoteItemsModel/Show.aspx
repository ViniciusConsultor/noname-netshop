<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.VoteItemsModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		VoteGroupId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteGroupId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ItemId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblItemId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ItemContent
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblItemContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteCount
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteCount" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
