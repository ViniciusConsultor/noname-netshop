<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.News.Category.List" %>

<%@ Register src="../../Controls/NewsCategoryTree.ascx" tagname="NewsCategoryTree" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .left{width:200px;}
        .iframe{width:700px;margin-left:10px;}
        .iframe iframe{width:700px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="left">                
                <uc1:NewsCategoryTree ID="NewsCategoryTree1" runat="server" />                
            </div>
            <div class="left iframe">
                <iframe id="NewsCategoryContent" name="NewsCategoryContent" scrolling="no" frameborder="0"></iframe>
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
