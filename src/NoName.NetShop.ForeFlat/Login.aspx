<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
  
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">会员登录</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="login_mainbody clearfix">
		<div class="loginTitle"></div>
		<div class="loginBox">
        	<ul class="form">
            	<li>
                    <span class="field">用户名：</span>
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="textField1"></asp:TextBox>
                </li>
                <li>
                	<span class="field">密　码：</span>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="textField1" TextMode="Password"></asp:TextBox>
                </li>
                <li class="submit">
                    <asp:Button ID="btnLogin" runat="server" Text="登　录" CssClass="button_blue2" 
                        onclick="btnLogin_Click" />
                </li>
                <li class="links">
                	<span>忘记密码? <a href="ResetPassword.aspx">点击这里</a></span>
                    <span>还不是鼎鼎会员? <a href="Register.aspx">立即注册</a></span>
                </li>
            </ul>
         
        </div>
        <div class="infoBox">
        	<ul>
            	<li>
                	<span class="title">我们的会员</span>
                    <span>抢先掌握最新的影音多媒体资讯、影音商品降价信息。享受更低的折扣。</span>
                
                </li>
                <li><span class="title">我们的服务</span> <span>种类齐全的影音多媒体产品，满足您的事务要求。完美周密的影音多媒体解决方案，解决您的所想所需。贴心的售后服务，保证您满意。</span>
                </li>
            </ul>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>
