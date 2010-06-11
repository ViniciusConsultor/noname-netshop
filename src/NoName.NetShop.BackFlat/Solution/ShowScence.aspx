<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowScence.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ShowScence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ScenceId
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Label ID="lblScenceId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		场景名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScenceName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		场景描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		场景类型：
	：</td>
	<td height="25" width="*" align="left">
	<asp:RadioButtonList runat="server" ID="rblScenceType" RepeatDirection="Horizontal">
	<asp:ListItem Text="推荐" Value="0"></asp:ListItem>
	<asp:ListItem Text="经典" Value="1"></asp:ListItem>
	</asp:RadioButtonList>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否激活
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsActive" Text="是否激活" runat="server" Checked="False" />
	</td></tr>
		<tr style="display:none">
	<td height="25" width="30%" align="right">
		场景图片
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Image ID="imgScence" runat="server" />
        <asp:FileUpload runat="server" ID="fulImage" />
	</td></tr>

	<tr>
	<td height="25" colspan="2"><div align="center"> 
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
	</div></td></tr>
</table>

</form>
</body>
</html>