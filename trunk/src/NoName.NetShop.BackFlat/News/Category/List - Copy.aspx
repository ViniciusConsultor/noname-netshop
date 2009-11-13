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
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" SelectedNodeStyle-Font-Underline="True">
                    <SelectedNodeStyle Font-Underline="True" Font-Bold="True" ForeColor="#990033"/>
                    <NodeStyle Font-Underline="True" ForeColor="#003399" />
                </asp:TreeView>
            </div>
            <div class="left iframe">
                <a href="Add.aspx">新建分类</a>
                <table>
                    <tr>
                        <td>名称：</td>
                        <td><asp:TextBox ID="TextBox_CategoryName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>状态：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DropDownList_Status">
                                <asp:ListItem Text="状态1" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>是否隐藏：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DropDownList_IsHide">
                                <asp:ListItem Text="隐藏" Value="1" />
                                <asp:ListItem Text="显示" Value="0" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>父分类：</td>
                        <td>                            
                            <uc1:NewsCategoryTree ID="NewsCategoryTree1" runat="server" />
                            <asp:LinkButton ID="LinkButton_SelectParentCategory" runat="server" onclick="LinkButton_SelectParentCategory_Click">选择</asp:LinkButton>
                            <asp:Label runat="server" ID="Label_ParentCategory" />
                            <input type="hidden" runat="server" id="Input_ParentCategoryID" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button_Submit" runat="server" Text="更改" onclick="Button_Submit_Click" />
                <asp:Button ID="Button_Delete" runat="server" Text="删除" onclick="Button_Delete_Click" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
