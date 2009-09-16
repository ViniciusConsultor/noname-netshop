<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.Web.AnswerModel.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		QuestionId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQuestionId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AnswerId
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAnswerId" runat="server"></asp:Label>
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
		AnswerTime
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAnswerTime" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
