﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.Relation.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .left{width:200px;}
        .iframe{width:500px;margin-left:10px;}
        .iframe iframe{width:500px;}
        .control a{display:block;padding:2px 5px;height:18px;line-height:18px;border:1px solid #eee;float:left;margin:2px;}
        
        .brand-list{width:500px;}
        .brand-list li{float:left;width:120px;}
        .control-list{}
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
                <div class="control-list">
                    <p><b>品牌列表</b></p><br />
                    <p class="control"><asp:LinkButton runat="server" ID="Button_AddBrand" OnClick="Button_AddBrand_Click" Text="添加关联品牌" /></p>
                    <p class="control"><asp:LinkButton runat="server" ID="Button_DeleteBrand" OnClick="Button_DeleteBrand_Click" Text="批量删除品牌" /></p>
                    <asp:Label runat="server" ID="Label_Informer"></asp:Label>
                    <div style="clear:both;"></div>
                </div>
                
                <div class="brand-list">
                    <asp:Repeater runat="server" ID="Repeater_BrandList" OnItemCommand="Repeater_BrandList_ItemCommand">
                        <ItemTemplate>
                            <li>
                                <input type="checkbox" name="deletecheck-<%# Eval("Brandid") %>" />
                                <asp:HyperLink runat="server" ID="Link_BrandPage" NavigateUrl='<%# Eval("brandurl") %>' Text='<%# Eval("BrandName") %>' Target="_blank" />
                                <asp:ImageButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("Brandid") %>' CommandName="d" ImageUrl="/images/window-close.png" OnClientClick="return confirm('确定删除?')" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="clear:both;"></div>
                </div>
            </div>
            <div style="clear:both;"></div> 
        </div>
    </form>
</body>
</html>
