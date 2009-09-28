<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/validate.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="BrandId" />
                <asp:BoundField HeaderText="品牌名称" DataField="BrandName" />
                <asp:TemplateField HeaderText="品牌LOGO">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="imgBrandLogo" ImageUrl='<%# Eval("BrandLogo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="品牌简介" DataField="Brief" />
                <asp:TemplateField HeaderText="显示顺序">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButtonMoveDown" CommandArgument='<%# Eval("BrandId") %>' CommandName="movedown" Text="下移"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="LinkButtonMoveUp" CommandArgument='<%# Eval("BrandId") %>' CommandName="moveup" Text="上移"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# "edit.aspx?brandid="+Eval("BrandId") %>' Text="编辑"></asp:HyperLink>
                        <asp:LinkButton runat="server" ID="deleteBrand" CommandArgument='<%# Eval("BrandId") %>' CommandName="d" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="page">
            <cc1:AspNetPager ID="AspNetPager" AlwaysShow="true" runat="server" OnPageChanged="AspNetPager_PageChanged" PageSize="10" 
                FirstPageText='首页' LastPageText='末页' NextPageText='下一页' PrevPageText='上一页'
                ShowBoxThreshold="16" NumericButtonCount="8" ShowPrevNext="True" CustomInfoSectionWidth="36%" SubmitButtonClass="buttom">
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>
