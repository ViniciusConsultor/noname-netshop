<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="NoName.NetShop.UserManager.Web.Member.Show" Title="显示页" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		userId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserEmail
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserEmail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Password
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPassword" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NickName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNickName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AllScore
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAllScore" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CurScore
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCurScore" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastLogin
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLastLogin" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LoginIP
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLoginIP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RegisterTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRegisterTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ModifyTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblModifyTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		0 未设定 1 个人会员 2 家庭会员 3 学校会员 4 企业会员
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		0 初始注册 1 激活 2 冻结
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstatus" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
