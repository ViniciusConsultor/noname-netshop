<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Group.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView CssClass="GridView" runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="productid" />
                <asp:BoundField HeaderText="名称" DataField="productname" />
                <asp:TemplateField HeaderText="类型">
                    <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.GroupShopping.Model.GroupShoppingProductType), Eval("ProductType"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="市场价" DataField="MarketPrice" />
                <asp:BoundField HeaderText="团购价" DataField="GroupPrice" />
                <asp:BoundField HeaderText="预付价" DataField="PrePaidPrice" />
                <asp:BoundField HeaderText="成团人数" DataField="succedline" />
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.GroupShopping.Model.GroupShoppingProductStatus),Eval("status")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("status")) != 1 ? true : false %>' runat="server" ID="Button_UnFreeze" CommandArgument='<%# Eval("productid") %>' CommandName="fz" Text="冻结" />
                        <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("status")) == 1 ? true : false %>' runat="server" ID="Button_Freeze" CommandArgument='<%# Eval("productid") %>' CommandName="uf" Text="解冻" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Visible='<%# !Convert.ToBoolean(Eval("isrecommend")) %>' runat="server" ID="Button_SetRecommend" CommandArgument='<%# Eval("productid") %>' CommandName="sr" Text="设为推荐" />
                        <asp:LinkButton Visible='<%# Convert.ToBoolean(Eval("isrecommend")) %>' runat="server" ID="Button_DeSetRecommend" CommandArgument='<%# Eval("productid") %>' CommandName="dr" Text="取消推荐" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="Edit.aspx?productid=<%# Eval("productid") %>">编辑</a>
                        <asp:LinkButton runat="server" ID="Button_Delete" Text="删除" CommandArgument='<%# Eval("productid") %>' CommandName="d" />
                    </ItemTemplate>                
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="Applies.aspx?productid=<%# Eval("productid") %>">查看申请</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>    
    <div id="page">
        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
            UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' ShowInputBox="Always"
            LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
            PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8" 
            ShowPrevNext="True" SubmitButtonClass="buttom" ShowPageIndex="true"
            NumericButtonTextFormatString=''>
        </cc1:AspNetPager>
    </div>
    </form>
</body>
</html>
