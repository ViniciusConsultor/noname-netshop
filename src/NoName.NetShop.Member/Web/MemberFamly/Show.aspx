<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.MemberFamly.Show" Title="��ʾҳ" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		userId
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		truename
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltruename" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		idcard
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblidcard" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Address
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		province
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblprovince" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		city
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		county
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcounty" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Mobile
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMobile" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelePhone
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTelePhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Email
	��</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEmail" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
