<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.Web.TagsModel.Add" Title="����ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CmsTagName
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCmsTagName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagBrief
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTagBrief" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DefaultContent
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDefaultContent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagType
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTagType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TagParas
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTagParas" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="�� ���� ��" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
