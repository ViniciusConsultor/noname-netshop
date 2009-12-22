<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentLogList.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Rent.RentLogList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
    
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="rightContent">
    <div>
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="rentname" HeaderText="商品名称" />
                <asp:BoundField DataField="rentmonths" HeaderText="租赁时间(月)" />
                <asp:BoundField DataField="cashpledge" HeaderText="押金" />
                <asp:BoundField DataField="paysum" HeaderText="总租金" />
                <asp:BoundField DataField="applytime" HeaderText="申请时间" />
                <asp:TemplateField  HeaderText="审批状态">
                    <ItemTemplate>
                        <%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.RentLogStatus),Eval("status")) %>
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