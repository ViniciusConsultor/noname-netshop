<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMemberInfo.aspx.cs" Inherits="NoName.NetShop.BackFlat.Member.ShowMemberInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		登录帐号
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lbluserId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		邮箱地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserEmail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		总积分
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAllScore" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		当前积分
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCurScore" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		上次登录时间
	：</td>
	<td height="25" width="*" align="left">
		 <asp:TextBox runat="server" Width="200px" id="txtLastLogin"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		上次登录IP
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLoginIP" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		注册时间
	：</td>
	<td height="25" width="*" align="left">
		 <asp:TextBox runat="server" Width="200px" id="txtRegisterTime"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		上次修改时间
	：</td>
	<td height="25" width="*" align="left">
		 <asp:TextBox runat="server" Width="200px" id="txtModifyTime"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		        会员类型：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		会员状态：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtstatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>

</table>
<div style="padding-top:10px; padding-bottom:10px">会员扩展信息</div>
	<asp:PlaceHolder ID="phExtentInfo" runat="server"></asp:PlaceHolder>

    </div>
    </form>
</body>
</html>
