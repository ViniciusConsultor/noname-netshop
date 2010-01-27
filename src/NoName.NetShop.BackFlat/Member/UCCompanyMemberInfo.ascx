
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCompanyMemberInfo.ascx.cs" Inherits="NoName.NetShop.BackFlat.Member.UCCompanyMemberInfo" %>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		身份证号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtidcard" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		公司名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcompanyname" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		省
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtprovince" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		市
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		县
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcounty" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		详细地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手机
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMobile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		固定电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelePhone" runat="server" Width="200px" ></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		传真
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFax" runat="server" Width="200px"></asp:TextBox>
	</td></tr>

</table>
