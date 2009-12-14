﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Category.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table>
	    <tr>
	        <td height="25" width="30%" align="right">已选择父分类：<%--<a href="List.aspx">重新选择</a>--%></td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtParentCate" Enabled="false" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">分类名称<span class="red">*</span>：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtCateName" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">是否隐藏<span class="red">*</span>：</td>
	        <td height="25" width="*" align="left">
		        <asp:CheckBox ID="chkIsHide" Text="IsHide" runat="server" Checked="False" />
	        </td>
	    </tr>
	    <tr>
	        <td height="25" colspan="2">
		        <asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" ></asp:Button>
	        </td>
	    </tr>
    </table>
    </form>
</body>
</html>
