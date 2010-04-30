<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Category.Select" %>

<%@ Register src="../../Controls/MagicWorldCategorySelect.ascx" tagname="MagicWorldCategorySelect" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .category-selection{width:90%;}
        .category-selection th{height:40px;}
        .category-selection h3{height:40px;padding-top:10px;margin:0;}
        .category-selection select{width:200px;height:400px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <uc1:MagicWorldCategorySelect ID="MagicWorldCategorySelect1" runat="server" />
        <asp:Button runat="server" CssClass="category-select" ID="Button_OK" OnClick="Button_OK_Click" Text="确  定" />
    </div>
    </form>
</body>
</html>
