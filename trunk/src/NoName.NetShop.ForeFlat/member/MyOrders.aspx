<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true"
    CodeBehind="MyOrders.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyOrders" %>

<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <div class="rightColumnContainer">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>我的订单</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="topButtons_left">
                    <asp:LinkButton runat="server" CssClass="button_blue" ID="lbtnSearAll" 
                        onclick="lbtnSearAll_Click">所有订单</asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="button_blue" ID="lbtnSearRecent" 
                        onclick="lbtnSearRecent_Click">近一月订单</asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="button_blue" ID="lbtnSearCancel" 
                        onclick="lbtnSearCancel_Click">已取消订单</asp:LinkButton>
                </div>
                <div class="table1">
                    <table>
                        <tr>
                            <th>
                                <span>订单编号</span>
                            </th>
                            <th>
                                <span>产品名称</span>
                            </th>
                            <th>
                                <span>数量</span>
                            </th>
                            <th>
                                <span>订单金额</span>
                            </th>
                            <th>
                                <span>支付方式</span>
                            </th>
                            <th>
                                <span>下单时间</span>
                            </th>
                            <th>
                                <span>状态</span>
                            </th>
                            <th>
                                <span>操作</span>
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpOrders" 
                            onitemdatabound="rpOrders_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("OrderId") %>
                                    </td>
                                    <td colspan="2">
                                        <table>
                                            <asp:Repeater runat="server" ID="rpProducts">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("ProductName") %>
                                                        </td>
                                                        <td><%#Eval("Quantity") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                    <td>
                                        <%#Eval("paysum") %>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="litPayMethod"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="litCreateTime"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="litStatus"></asp:Literal>
                                    </td>
                                    <td>
                                        <a href="#">查看</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Panel runat="server" ID="panNoResult">
                            <tr>
                            <td colspan="8">
                                没有查询到相关订单
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td colspan="8">
                                <div align="left">
                                    <cc1:AspNetPager ID="pageNav"  runat="server" HorizontalAlign="Center">
                                    </cc1:AspNetPager>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ul class="bottom">
                <li class="left"></li>
                <li class="right"></li>
            </ul>
        </div>
    </div>
</asp:Content>
