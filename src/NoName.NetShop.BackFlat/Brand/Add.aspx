<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellSpacing="0" cellPadding="0" border="0">
	    <tr>
	        <td>品牌名称：</td>
	        <td>
		        <asp:TextBox id="txtBrandName" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td>品牌LOGO：</td>
	        <td>
                <asp:FileUpload ID="fulBrandLogo" runat="server" /> logo长宽比保持120:45 (最小长度120px)
	        </td>
	    </tr>
	    <tr>
	        <td>品牌描述：</td>
	        <td>
		        <asp:TextBox id="txtBrief" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td colspan="2">
	            <div align="center">
		            <asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" ></asp:Button>
	            </div>
	        </td>
	    </tr>
    </table>
    </form>
</body>
</html>
