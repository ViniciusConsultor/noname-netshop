<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyGroupList.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.MyGroupList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; <a href="/member/mygrouplist.aspx">我的团购</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">

            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的团购列表</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <div class="table1">
                        <table>
                          <tr>
                            <th><span>商品ID</span></th>
                            <th><span>名称</span></th>
                            <th><span>价格</span></th>
                            <th><span>申请时间</span></th>
                            <th><span>状态</span></th>
                          </tr>
                          <asp:Repeater runat="server" ID="Repeater_GroupList">
                            <ItemTemplate>
                              <tr>
                                <td><%# Eval("productid") %></td>
                                <td><a href="/group/Product.aspx?productid=<%# Eval("productid") %>" target="_blank"><%# Eval("productname") %></a></td>
                                <td><%# Convert.ToDecimal(Eval("groupprice")).ToString("0.00") %></td>
                                <td><%# Convert.ToDateTime(Eval("applytime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                <td><%# Enum.GetName(typeof(NoName.NetShop.GroupShopping.Model.GroupProductApplyStatus), Eval("applystatus")) %></td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                          <tr>
                            <td colspan="7">
                                <div class="pagination floatRight">
                                    <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                                        UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                        LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
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
</asp:Content>