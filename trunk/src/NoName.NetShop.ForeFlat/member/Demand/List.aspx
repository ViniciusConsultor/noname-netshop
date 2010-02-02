<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Demand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
            <div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我提交的需求信息</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <div class="table1">
                        <table>
                          <tr>
                            <th><span>ID</span></th>
                            <th><span>名称</span></th>
                            <th><span>价格</span></th>
                            <th><span>过期时间</span></th>
                            <th><span>状态</span></th>
                            <th><span>操作</span></th>
                          </tr>
                            <asp:Repeater runat="server" ID="Repeater_DemandList">
                                <ItemTemplate>
                                      <tr>
                                        <td><%# Eval("demandid")%></td>
                                        <td><a target="_blank" href='<%# "/Magic/Demand.aspx?pid="+Eval("demandid") %>'><%# Eval("demandname")%></a></td>
                                        <td><%# Convert.ToDecimal(Eval("Price")).ToString("0.00") %></td>
                                        <td><%# Convert.ToDateTime(Eval("expirationtime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                        <td><%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.DemandProductStatus), Eval("status")) %></td>
                                        <td>
                            	            <div class="inlineIconButton">
                            	                <a title="编辑" class="iconButton edit" href='<%# ((NoName.NetShop.MagicWorld.Model.DemandProductStatus)Enum.Parse(typeof(NoName.NetShop.MagicWorld.Model.DemandProductStatus), Eval("status").ToString())) == NoName.NetShop.MagicWorld.Model.DemandProductStatus.尚未审核 ? "Edit.aspx?productid="+Eval("AuctionId") : "javascript:alert(\"该需求信息已通过审核，禁止编辑\")" %>'></a>
                            	            </div>
                                        </td>
                                      </tr>
                                </ItemTemplate>
                            </asp:Repeater>                          
                          <tr>
                            <td colspan="6">
                            	<div class="floatLeft">
                                	<a class="button_blue3 inlineBlock" href="../CateSelect.aspx?app=Auction">
                                        <span class="left"></span>
                                        <span class="text">添加需求信息</span>
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
            </div>
</asp:Content>