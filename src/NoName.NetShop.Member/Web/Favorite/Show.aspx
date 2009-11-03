<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.Favorite.Show" Title="ÏÔÊ¾Ò³" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UserId
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteId
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFavoriteId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteUrl
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFavoriteUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteName
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFavoriteName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InsertTime
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInsertTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentId
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentType
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentType" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
