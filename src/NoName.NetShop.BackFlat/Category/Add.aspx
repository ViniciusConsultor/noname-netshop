<%@ Page Language="C#" AutoEventWireup="true"  Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.Add" %>
<%@ Register src="../Controls/CategorySelect.ascx" tagname="CategorySelect" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>

    <script src="/js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
	    <tr>
	        <td height="25" width="30%" align="right">分类名称：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtCateName" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">状态：</td>
	        <td height="25" width="*" align="left">
	            <asp:DropDownList runat="server" ID="drpStatus" ></asp:DropDownList>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">价格区间：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtPriceRange" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">是否隐藏：</td>
	        <td height="25" width="*" align="left">
		        <asp:CheckBox ID="chkIsHide" Text="IsHide" runat="server" Checked="False" />
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">从属父类：</td>
	        <td height="25" width="*" align="left">	            
	            <uc1:CategorySelect ID="CategorySelect1" runat="server" />	            
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