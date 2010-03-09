<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Specifications.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1" OnRowCommand="GridView_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="SpecificationID" />
                <asp:BoundField HeaderText="内容" DataField="Content" />
                <asp:TemplateField  HeaderText="创建时间">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>                        
                        <a href='<%# "Edit.aspx?id="+Eval("SpecificationID") %>'>编辑</a>
                        <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("SpecificationID") %>' CommandName="d" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
