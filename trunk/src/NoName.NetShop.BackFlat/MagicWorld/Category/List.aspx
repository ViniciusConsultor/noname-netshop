﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Category.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
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
                <div class="left control">
                    <asp:LinkButton runat="server" OnClick="Button_MoveUp_Click" ID="Button_MoveUp" Text="上移" />
                    <asp:LinkButton runat="server" OnClick="Button_MoveDown_Click" ID="Button_MoveDown" Text="下移" />
                    <asp:LinkButton runat="server" OnClick="Button_New_Click" ID="Button_New" Text="新建子类" />
                    <asp:LinkButton runat="server" OnClick="Button_Edit_Click" ID="Button_Edit" Text="编辑" />
                    <asp:LinkButton runat="server" OnClick="Button_Delete_Click" ID="Button_Delete" Text="删除" />
                </div>
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" SelectedNodeStyle-Font-Underline="True">
                    <SelectedNodeStyle Font-Underline="True" Font-Bold="True" ForeColor="#990033"/>
                    <NodeStyle Font-Underline="True" ForeColor="#003399" />
                </asp:TreeView>        
            </div>
            <div class="left iframe">
                <iframe id="IFrame_Edit" frameborder="0" src="about:blank" scrolling="no"></iframe>
            </div>    
        </div>
    </form>
</body>
</html>
