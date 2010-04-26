<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyScore.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyScore" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的积分</a>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的积分</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                  <p>您的积分为：<span class="important"><asp:Literal runat="server" ID="litCurScore"></asp:Literal></span></p>
                  <p><a class="linkButton" href="#">如何获取积分？</a></p>
                                  	<div class="section padding">
                        <div class="table1">
                            <table>
                              <tr>
                                <th><span>日期</span></th>
                                <th><span>积分</span></th>
                                <th><span>备注</span></th>
                              </tr>
                        <asp:Repeater runat="server" ID="rpLogs">
                        <ItemTemplate>
                              <tr>
                                <td><%#Convert.ToDateTime(Eval("InsertTime")).ToString("yyyy-MM-dd HH:mm") %></td>
                                <td><%# Eval("Score") %></td>
                                <td><%# Eval("remark") %></td>
                              </tr>                        
                              </ItemTemplate>

                              </asp:Repeater>
                                                      
                       <asp:Panel runat="server" ID="panNoResult">
                            <tr>
                            <td colspan="3">
                                没有相关积分的记录
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td colspan="3">
                                <div align="left">
                                    <cc1:AspNetPager ID="pageNav"  runat="server" HorizontalAlign="Center" 
                                        onpagechanged="pageNav_PageChanged">
                                    </cc1:AspNetPager>
                                </div>
                            </td>
                        </tr>

                            </table>
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
