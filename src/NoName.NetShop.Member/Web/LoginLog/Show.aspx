<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.LoginLog.Show" Title="ÏÔÊ¾Ò³" %>
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
		LoginTime
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLoginTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IP
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIP" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
