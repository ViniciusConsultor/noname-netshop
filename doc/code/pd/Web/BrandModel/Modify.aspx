<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="NoName.NetShop.Web.BrandModel.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		BrandId
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblBrandId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BrandName
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBrandName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CateId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCateId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CatePath
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCatePath" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BrandLogo
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBrandLogo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Brief
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBrief" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
