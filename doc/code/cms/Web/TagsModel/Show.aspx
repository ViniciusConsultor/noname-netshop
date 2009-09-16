<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.TagsModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CmsTagId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCmsTagId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CmsTagName
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCmsTagName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagBrief
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTagBrief" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DefaultContent
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDefaultContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTagType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagParas
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTagParas" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
