<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.PagesModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PageId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPageId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TemplateFile
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTemplateFile" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPageUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PagePhyPath
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPagePhyPath" runat="server"></asp:Label>
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
		LastPubTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLastPubTime" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
