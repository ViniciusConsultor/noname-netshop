<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyFavorite.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyFavotite" %>

<%@ Register Assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.DynamicData" TagPrefix="cc2" %>

<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
            <div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的收藏</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                	<div class="box6">
                    	<div class="title">我的收藏</div>
   
                           <div class="content noPaddingContentBox">
                            <div class="table2">
                                <table>
                                  <tr>
                                    <th class="first checkBox"><span>选择</span></th>
                                    <th><span>收藏内容</span></th>
                                    <th><span>收藏时间</span></th>
                                    <th class="last actions"><span>操作</span></th>
                                  </tr>
                                  <asp:Repeater runat="server" ID="rpList" onitemcommand="rpList_ItemCommand">
                                  <ItemTemplate>
                                  <tr class="odd">
                                    <td><input type="checkbox" name="favid" value='<%#Eval("FavoriteId") %>' /></td>
                                    <td><a href='<%#Eval("FavoriteUrl") %>'><%#Eval("FavoriteName") %></a></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td>
                                    	<a href='<%#Eval("FavoriteUrl") %>' class="iconButton viewMessage"></a>
                                        <asp:LinkButton  runat="server" CommandName="delete" CommandArgument='<%# Eval("FavoriteId") %>' CssClass="iconButton delete"></asp:LinkButton>
                                    </td>
                                  </tr>
                                  </ItemTemplate>
                                  <AlternatingItemTemplate>
                                  <tr class="even">
                                    <td><input type="checkbox" name="favid" value='<%#Eval("FavoriteId") %>' /></td>
                                    <td><a href='<%#Eval("FavoriteUrl") %>'><%#Eval("FavoriteName") %></a></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td>
                                    	<a href='<%#Eval("FavoriteUrl") %>' class="iconButton viewMessage"></a>
                                        <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="delete" CommandArgument='<%# Eval("FavoriteId") %>' CssClass="iconButton delete"></asp:LinkButton>
                                    </td>
                                  </tr>
                                  </AlternatingItemTemplate>
                                  </asp:Repeater>
                                  <tr class="bottom">
                                  	<td><a href="javascript:void(0)" onclick="selectAll(this,this.parentNode.parentNode.parentNode)">全选</a></td>
                                    <td colspan="3">
                                    	<asp:LinkButton CssClass="button_blue" ID="btnBatDelete" runat="server" Text="删　除" 
                                            onclick="btnBatDelete_Click"></asp:LinkButton>
                                        <div class="pagination">
                                    <cc1:AspNetPager ID="pageNav"  runat="server" HorizontalAlign="Center" 
                                                CssClass="pageNum" onpagechanged="pageNav_PageChanged">
                                    </cc1:AspNetPager>

                                        </div>
                                    </td>
                                  </tr>
                                </table>
                            </div>
                        </div>                 	
                    	
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
