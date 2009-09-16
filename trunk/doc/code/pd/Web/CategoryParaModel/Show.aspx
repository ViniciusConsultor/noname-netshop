<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.CategoryParaModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ParaId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParaId" runat="server"></asp:Label>
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
		ParaName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParaName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ParaType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParaType" runat="server"></asp:Label>
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
		ParaGroupId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParaGroupId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ParaValues
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblParaValues" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DefaultValue
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDefaultValue" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
