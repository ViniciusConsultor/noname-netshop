<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Auction.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我添加的拍卖商品</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <div class="table1">
                        <asp:Repeater runat="server" ID="Repeater_AuctionList">
                            <HeaderTemplate>
                                <table>
                                  <tr>
                                    <th><span>拍品ID</span></th>
                                    <th><span>名称</span></th>
                                    <th><span>起拍价</span></th>
                                    <th><span>当前价</span></th>
                                    <th><span>起拍时间</span></th>
                                    <th><span>结束时间</span></th>
                                    <th><span>状态</span></th>
                                    <th><span>操作</span></th>
                                  </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                              <tr>
                                <td><%# Eval("AuctionId")%></td>
                                <td><a target="_blank" href='<%# "/Magic/Auction.aspx?pid="+Eval("AuctionId") %>'><%# Eval("ProductName")%></a></td>
                                <td><%# Convert.ToDecimal(Eval("StartPrice")).ToString("0.00") %></td>
                                <td><%# Convert.ToDecimal(Eval("CurPrice")).ToString("0.00") %></td>
                                <td><%# Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                <td><%# Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                <td><%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.AuctionProductStatus), Eval("status")) %></td>
                                <td>
                        	        <div class="inlineIconButton">
                        	            <a title="编辑" class="iconButton edit" href='<%# ((NoName.NetShop.MagicWorld.Model.AuctionProductStatus)Enum.Parse(typeof(NoName.NetShop.MagicWorld.Model.AuctionProductStatus), Eval("status").ToString())) == NoName.NetShop.MagicWorld.Model.AuctionProductStatus.尚未审核 ? "Edit.aspx?productid="+Eval("AuctionId") : "javascript:alert(\"该拍品已通过审核，禁止编辑\")" %>'></a>
                        	        </div>
                                </td>
                              </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                          <tr>
                            <td colspan="8">
                    	        <div class="floatLeft">
                        	        <a class="button_blue3 inlineBlock" href="../CateSelect.aspx?app=Auction">
                                        <span class="left"></span>
                                        <span class="text">添加拍品</span>
                                        <span class="right"></span>
                                    </a>
                                </div>
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
</asp:Content>