﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPersonMemberInfo.ascx.cs" Inherits="NoName.NetShop.BackFlat.Member.UCPersonMemberInfo" %>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		身份证号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIdCard" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		移动电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMobile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		固定电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelePhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户级别
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserLevel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	</table>
