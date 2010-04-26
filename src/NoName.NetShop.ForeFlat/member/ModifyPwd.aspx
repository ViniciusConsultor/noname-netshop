<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.ModifyPwd" %>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">修改密码</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>修改密码</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                	<div class="section padding2">
                        <ul class="tip1" style="margin-left:185px;">
                            <li class="left"></li>
                            <li class="middle"><span>修改后请牢记您的个人密码哦！</span></li>
                            <li class="right"></li>
                        </ul>
                    </div>
                    <div class="section padding2">
                        <div class="sheet1">
                            <ul class="form">
                                <li>
                                    <span class="field">旧 密 码</span>
                                    <asp:TextBox ID="txtOldPass" runat="server" CssClass="textField1" TextMode="Password" EnableViewState="false"></asp:TextBox>
                                    <span class="tip">当前密码</span>
                                </li>
                                <li>
                                    <span class="field">新 密 码</span>
                                    <asp:TextBox ID="txtNewPass1"  runat="server" CssClass="textField1" TextMode="Password" EnableViewState="false"></asp:TextBox>
                                    <span class="tip">要修改成的新密码</span>
                                </li>
                                <li>
                                    <span class="field">确认密码</span>
                                    <asp:TextBox ID="txtNewPass2" runat="server" CssClass="textField1" TextMode="Password" EnableViewState="false"></asp:TextBox>
                                    <span class="tip">重复输入新密码</span>
                                </li><asp:Label runat="server" id="lblResult" EnableViewState="false"></asp:Label>
                                <li>
                                </li>
                                <li class="submit">
                                
                                    <asp:Button runat="server" ID="btnDoChange" Text="修　改" CssClass="button_blue" 
                                        onclick="btnDoChange_Click" />
                                </li>
                            </ul>

                        </div>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div></asp:Content>
