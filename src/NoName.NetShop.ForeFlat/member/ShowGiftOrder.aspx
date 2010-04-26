﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="ShowGiftOrder.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.ShowGiftOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="/member/mygiftorders.aspx">我的兑换订单</a> &gt;&gt; 
    	<a href="#">订单详情</a>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
             	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>订单详情</span></li>
                    <li class="right"></li>
                </ul>
                 <div class="content">
              	<div class="table1 fixedTable">

<table>
                          <tr>
                            <th colspan="4"><span>订单信息</span></th>
                          </tr>
	<tr>
	<td>订单号</td>
	<td><asp:Label ID="lblOrderId" runat="server"></asp:Label>
	</td>
	<td>用户Id</td>
	<td><asp:Label ID="lblUserId" runat="server"></asp:Label></td>
</tr>
	<tr>
	<td>订单状态</td>
	<td><asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
	</td>
	<td>订单生成时间</td>
	<td><asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
</tr>	
<tr>
	<td>订单配送方式</td>
	<td><asp:Label ID="lblShipMethod" runat="server"></asp:Label>
	</td>
	<td>消耗积分</td>
	<td><asp:Label ID="lblTotalScore" runat="server"></asp:Label>
	</td>
</tr>

    <tr>
	<td colspan="4">
	<asp:GridView ID="gvProducts" runat="server" Width="100%" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="ProductId" HeaderText="商品ID" />
	<asp:BoundField DataField="ProductName" HeaderText="商品名称" />
	<asp:BoundField DataField="Quantity" HeaderText="商品数量" />
	<asp:BoundField DataField="Score" HeaderText="单件所需积分" />
	<asp:BoundField DataField="TotalScore" HeaderText="合计积分" />
	</Columns>
	</asp:GridView>
	</td>
</tr>
    <tr>
	<td colspan="4">收货人信息</td>
</tr>
    <tr>
	<td>姓名</td>
	<td><asp:Label ID="lblReceName" runat="server"></asp:Label></td>
	<td>电话</td>
	<td><asp:Label ID="lblTelePhone" runat="server"></asp:Label></td>
</tr>
    <tr>
	<td>详细地址</td>
	<td colspan="3"><asp:Label runat="server" ID="lblAddress"></asp:Label></td>
	</tr>
    <tr>
	<td>邮编</td>
	<td><asp:Label ID="lblPostcode" runat="server"></asp:Label></td>
	<td>Email</td>
	<td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
</tr>    
<tr>
	<td>用户留言</td>
	<td colspan="3"><asp:Label ID="lblUserNotes" runat="server"></asp:Label></td>
</tr>
<tr>
	<td>订单操作记录</td>
	<td colspan="3">
	<asp:GridView ID="gvActionLog" runat="server" Width="100%" AutoGenerateColumns="false">
	<Columns>
	<asp:BoundField DataField="ActInfo" HeaderText="状态改变" />
	<asp:BoundField DataField="ChangeTime" HeaderText="操作时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
   </Columns>
	</asp:GridView>
</td>
</tr>

</table>
</div>
</div>
</div>
</asp:Content>
