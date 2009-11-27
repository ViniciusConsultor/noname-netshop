<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySelect.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.CategorySelect" %>

<%@ Register src="../Controls/CategoryListBox.ascx" tagname="CategoryListBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        input.category-select{display:block;margin:0 auto;border:1px solid #ccc;background:#fff;width:160px;height:40px;border-left:3px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:CategoryListBox ID="CategoryListBox1" runat="server" />
        
        <table class="pdcategory">    
            <tr>
                <td><asp:Button runat="server" CssClass="category-select" ID="Button_OK" OnClick="Button_OK_Click" Text="确  定" /></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
