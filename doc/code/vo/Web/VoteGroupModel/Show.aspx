<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.VoteGroupModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		VoteGroupId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteGroupId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GroupType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGroupType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Subject
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSubject" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Content
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
