<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.NewsModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		NewsId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNewsId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NewsType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNewsType" runat="server"></asp:Label>
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
		Title
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SubTitle
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSubTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Brief
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBrief" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Content
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SmallImageUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSmallImageUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Author
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuthor" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		From
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFrom" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VideoUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVideoUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ImageUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblImageUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InsertTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInsertTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ModifyTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblModifyTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Tags
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTags" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
