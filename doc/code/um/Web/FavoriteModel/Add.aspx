<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.Web.FavoriteModel.Add" Title="����ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UserId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFavoriteId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteUrl
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFavoriteUrl" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FavoriteName
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFavoriteName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InsertTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtInsertTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContentId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentType
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContentType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="�� ���� ��" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
