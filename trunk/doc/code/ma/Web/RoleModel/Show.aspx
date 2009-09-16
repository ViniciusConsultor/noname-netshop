<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.RoleModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		RoleId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRoleId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RoleName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRoleName" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
