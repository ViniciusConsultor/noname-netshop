<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySelect.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.CategorySelect" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        table.pdcategory{width:700px;display:block;margin:1em;}
        .pdcategory select{width:200px;height:300px;background:white;}
        input.category-select{display:block;margin:0 auto;border:1px solid #ccc;background:#fff;width:160px;height:40px;border-left:3px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
<table class="pdcategory">    
    <tr>
        <td colspan="3"><h3>请选择分类：</h3></td>
    </tr>
    <tr>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox1" OnSelectedIndexChanged="ListBox1_SelectChanged" />
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox2" OnSelectedIndexChanged="ListBox2_SelectChanged" />
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox3" OnSelectedIndexChanged="ListBox3_SelectChanged" />
        </td>
    </tr>
</table>
        
        <table class="pdcategory">    
            <tr>
                <td><asp:Button runat="server" CssClass="category-select" ID="Button_OK" OnClick="Button_OK_Click" Text="确  定" /></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
