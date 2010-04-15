<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Rent.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="../Category/Select.aspx?app=Rent">添加出租商品</a>
        <div>
            <asp:GridView runat="server" ID="GridView1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="商品ID" DataField="rentid" />
                    <asp:TemplateField HeaderText="商品名称">
                        <ItemTemplate>
                            <a href="<%# Eval("foreurl") %>" target="_blank"><%# Eval("rentname") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="创建时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("createtime")).ToString("yyyy-MM-dd HH:mm:ss") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品状态">
                        <ItemTemplate>
                            <%# Eval("status") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请记录">
                        <ItemTemplate>
                            <a href='<%# "LogList.aspx?rentid="+Eval("rentid") %>'>查看</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# "Edit.aspx?rentid="+Eval("rentid") %>'>编辑</a>
                            <asp:LinkButton runat="server" ID="Button_Delete" Text="删除" CommandArgument='<%# Eval("rentid") %>' CommandName="d" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>
