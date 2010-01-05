<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Auction.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <a href="Add.aspx">添加拍品</a>
    <div>
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="拍品ID" DataField="AuctionId" />
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <a href='<%# "/Magic/Auction.aspx?a="+Eval("AuctionId") %>'><%# Eval("ProductName")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="起拍价">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("StartPrice")).ToString("0.00") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当前价">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("CurPrice")).ToString("0.00") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="起拍时间">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结束时间">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Eval("status")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "Edit.aspx?productid="+Eval("AuctionId") %>'>编辑</a>
                        <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("AuctionId") %>' CommandName="d" Text="删除" />
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