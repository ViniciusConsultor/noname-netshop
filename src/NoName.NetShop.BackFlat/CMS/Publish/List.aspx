<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Publish.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/cms.list.js" type="text/javascript"></script>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="newPanel" class="panel">
        <div class="title"><span>新建发布页</span></div>
        <div class="content">
            <table>
                <tr>
                    <td>页面名称：</td>
                    <td><asp:TextBox CssClass="textbox" Width="240" ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>页面标题：</td>
                    <td><asp:TextBox CssClass="textbox" Width="240" ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>所属类别：</td>
                    <td>
                        <asp:DropDownList runat="server" ID="SelectCategory">
                            <asp:ListItem Text="首页" Value="1" />
                            <asp:ListItem Text="二级页" Value="2" />
                            <asp:ListItem Text="专题页" Value="3" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>模板选择：</td>
                    <td>
                        <asp:DropDownList runat="server" ID="SelectTemplate">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br/>
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
            <input class="button" id="Button2" type="button" value="取消" />
        </div>
        
    </div>
    <div>
        <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" CssClass="listGrid" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="pagetitle" HeaderText="页面标题" />
                <asp:BoundField DataField="pagename" HeaderText="名称" />
                <asp:BoundField DataField="author" HeaderText="创建者" />
                <asp:BoundField DataField="createtime" HeaderText="创建时间" />
                <asp:BoundField DataField="lastmodify" HeaderText="最后修改" />
                <asp:BoundField DataField="updatetime" HeaderText="修改时间" />                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Edit.aspx?pid="+ Eval("id") %>' Text="编辑" />
                        <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%# Eval("id") %>' CommandName='d' Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
