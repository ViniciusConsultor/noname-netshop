<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.MemberCompany.Add" Title="����ҳ" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		userid
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuserid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		truename
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttruename" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		idcard
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtidcard" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		companyname
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcompanyname" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		province
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtprovince" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		city
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		county
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcounty" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Mobile
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMobile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelePhone
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelePhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Fax
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFax" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Email
	��</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEmail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" OnClick="btnAdd_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
