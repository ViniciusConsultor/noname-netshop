<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentLogList.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Rent.RentLogList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
    
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="topContent">
    您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; <a href="#">我提交的出租申请</a>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="rightContent">

    <div class="rightColumnContainer">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>我提交的出租申请</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="table1">
                    <table>
                        <tr>
                            <th><span>商品名称</span></th>
                            <th><span>租赁时间（月）</span></th>
                            <th><span>押金</span></th>
                            <th><span>总租金</span></th>
                            <th><span>申请时间</span></th>
                            <th><span>审批状态</span></th>
                        </tr>
                        <asp:Repeater runat="server" ID="Repeater_LogList">
                            <ItemTemplate>
                                <tr>
                                    <td><a href="/magic/rent.aspx?pid=<%# Eval("rentid") %>" target="_blank"><%# Eval("rentname")%></a></td>
                                    <td><%# Eval("rentmonths")%></td>
                                    <td><%# Eval("cashpledge")%></td>
                                    <td><%# Eval("paysum")%></td>
                                    <td><%# Eval("applytime")%></td>
                                    <td><%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.RentLogStatus), Eval("status"))%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>                    
                        <tr>
                            <td colspan="6">
                                <div class="pagination floatRight">
                                    <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                                        UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                        LastPageText='末页' NextPageText='下一页'
                                        PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                        ShowPrevNext="True" SubmitButtonClass="buttom" 
                                        NumericButtonTextFormatString=''>
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