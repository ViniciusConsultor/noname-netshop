<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CateId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCateId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CateName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCateName" runat="server"></asp:Label>
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
		Status
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PriceRange
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPriceRange" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsHide
	</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsHide" Text="IsHide" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CateLevel
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCateLevel" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
