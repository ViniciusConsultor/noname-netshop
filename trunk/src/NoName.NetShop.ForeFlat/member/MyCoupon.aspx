<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyCoupon.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyCoupon" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的鼎券</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1 noPadding">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的鼎券</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                	<div class="section padding">
                        <div class="table1">
                            <table>
                              <tr>
                                <th><span>面额</span></th>
                                <th><span>数量</span></th>
                                <th><span>消费积分</span></th>
                                <th><span>有效期</span></th>
                                <th><span>处理状态</span></th>
                              </tr>
                              <tr>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                              </tr>
                              <tr>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                              </tr>
                            </table>
                        </div>
                    </div>
                    <div align="center">
                    	<a class="button_blue" href="#">我要兑换</a>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
