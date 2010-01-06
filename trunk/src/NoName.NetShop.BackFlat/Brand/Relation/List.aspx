<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.Relation.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .left{width:200px;}
        .iframe{width:700px;margin-left:10px;}
        .iframe iframe{width:700px;}
        .control a{display:block;padding:2px 5px;height:18px;line-height:18px;border:1px solid #eee;float:left;margin:2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="left">
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" SelectedNodeStyle-Font-Underline="True">
                    <SelectedNodeStyle Font-Underline="True" Font-Bold="True" ForeColor="#990033"/>
                    <NodeStyle Font-Underline="True" ForeColor="#003399" />
                </asp:TreeView>        
            </div>
            <div class="left iframe">
                <p><b>品牌列表</b></p>
                <p class="control"><asp:LinkButton runat="server" ID="Button_AddBrand" OnClick="Button_AddBrand_Click" Text="添加关联品牌" /></p>
                <asp:Label runat="server" ID="Label_Informer"></asp:Label>
                
                <asp:Repeater runat="server" ID="Repeater_BrandList">
                    <ItemTemplate>
                        <li><%# Eval("BrandName") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>    
        </div>
    </form>
</body>
</html>
