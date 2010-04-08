<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.News.Category.Add" %>
<%@ Register src="../../Controls/NewsCategoryTree.ascx" tagname="NewsCategoryTree" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <a href="List.aspx">返回列表</a>
                <table>
                    <tr>
                        <td>名称：</td>
                        <td><asp:TextBox ID="TextBox_CategoryName" runat="server"></asp:TextBox></td>
                    </tr>
                   <%--<tr>
                        <td>状态：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DropDownList_Status">
                                <asp:ListItem Text="状态1" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>是否隐藏：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DropDownList_IsHide">
                                <asp:ListItem Text="显示" Value="0" />
                                <asp:ListItem Text="隐藏" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>父分类：</td>
                        <td>                            
                            <uc1:NewsCategoryTree ID="NewsCategoryTree1" runat="server" />
                            <asp:LinkButton ID="LinkButton_SelectParentCategory" runat="server" onclick="LinkButton_SelectParentCategory_Click">选择</asp:LinkButton>
                            <asp:Label runat="server" ID="Label_ParentCategory" Text="无从属父类" />
                            <input type="hidden" runat="server" id="Input_ParentCategoryID" value="0" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button_Submit" runat="server" Text="添加" onclick="Button_Submit_Click" />
        
    </form>
</body>
</html>
