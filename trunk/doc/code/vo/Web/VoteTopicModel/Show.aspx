<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.VoteTopicModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		VoteId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentType
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Topic
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTopic" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Remark
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRemark" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		StartTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStartTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EndTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEndTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsRegUser
	</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsRegUser" Text="IsRegUser" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteUserNum
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVoteUserNum" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
