<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.PublicContent.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" CssClass="pagelist" ID="GridView1" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Key" DataField="key" />
                    <asp:BoundField HeaderText="内容名称" DataField="name" />
                    <asp:BoundField HeaderText="内容地址" DataField="path" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <a href='<%# "Edit.aspx?k="+ Eval("key") %>'>编辑</a>
                        </ItemTemplate>
                    </asp:TemplateField>            
                </Columns>            
            </asp:GridView>    
        
        </div>
    </form>
</body>
</html>
