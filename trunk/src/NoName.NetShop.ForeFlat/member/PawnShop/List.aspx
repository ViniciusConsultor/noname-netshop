<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.PawnShop.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <a href="Add.aspx">添加当品</a>
    <div>
        <asp:GridView runat="server" ID="GridView1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="当品ID" DataField="pawnproductid" />
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <%# Eval("pawnproductname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("pawnprice")).ToString("0.00") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="数量" DataField="stock" />
                <asp:TemplateField HeaderText="创建时间">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("inserttime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Eval("status") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "Edit.aspx?pid="+Eval("pawnproductid") %>'>编辑</a>
                        <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("pawnproductid") %>' CommandName="d" Text="删除" />
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
</asp:Content>