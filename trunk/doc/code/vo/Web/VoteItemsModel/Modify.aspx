<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="NoName.NetShop.Web.VoteItemsModel.Modify" Title="�޸�ҳ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		VoteGroupId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtVoteGroupId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtVoteId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ItemId
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblItemId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ItemContent
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtItemContent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		VoteCount
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtVoteCount" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="�� ȡ�� ��" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
