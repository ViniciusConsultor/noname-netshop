<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.Address.Show" Title="ÏÔÊ¾Ò³" %>
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
		AddressId
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddressId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Province
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProvince" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		City
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddressDetail
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddressDetail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverName
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecieverName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Mobile
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMobile" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Telephone
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTelephone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Postalcode
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPostalcode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsDefault
	£º</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsDefault" Text="IsDefault" runat="server" Checked="False" />
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
		ModifyTime
	£º</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblModifyTime" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
