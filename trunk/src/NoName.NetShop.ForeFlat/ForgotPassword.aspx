<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="NoName.NetShop.ForeFlat.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
     <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">忘记密码</a>
    </div>
    <!--Position End-->
   <!--MainBody Begin-->
    <div class="forgotPassword_mainbody clearfix">
		<div class="box1 newline">
            <ul class="title">
                <li class="left"></li>
                <li><span>
                <asp:Literal ID="litOpName" runat="server" Text="找回密码"></asp:Literal>
                </span></li>
                <li class="right"></li>
            </ul>
            
            <div class="content centerText" id="divForgotPwd" runat="server">
            	<div class="tipContainer">
                    <ul class="tip2">
                        <li class="left"></li>
                        <li class="middle"><span>忘记了密码？请输入用户名和注册时填写的邮箱，我们会把重设密码邮件发送到您的邮箱！</span></li>
                        <li class="right"></li>
                    </ul>
                </div>
                <ul class="form">
                 <li>
                    <span class="field">用户ID：</span>
                    <asp:TextBox runat="server" ID="txtUserId" CssClass="textField1"></asp:TextBox>
                </li>
                <li>
                	<span class="field">邮　箱：</span>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="textField1"></asp:TextBox>
                         <span class="tip">请填写邮箱，需要为注册用户时所使用的邮箱</span>
               </li>
                 <li>
                	<span class="field">验证码：</span>
                    <asp:TextBox runat="server" ID="txtValidCode" CssClass="textField1" Width="60px"></asp:TextBox>
                    <img id="imgcode" alt="验证码" src="ValiateCode.aspx" onclick="reloadimg()" style="cursor: hand;" title="看不清楚，换一张" />
                </li>
                 <li>
                <span class="field"></span><asp:Label ForeColor="Red" id="lblPrompt" runat="server" EnableViewState="false"></asp:Label>
                </li>
              <li class="submit">
                    <asp:Button ID="btnLogin" runat="server" Text="确  定" CssClass="button_blue2" 
                        onclick="btnLogin_Click" />
                </li>
                </ul>
            </div>
            
                        <div class="content centerText" id="divSucc" runat="server">
                <div class="sheet1 showResult">
                	<span class="successIcon"></span>
                    <ul>
                    	<li>
                        	<span class="bold">您的新密码已经发送到指定邮箱！</span>
                   		</li>
                        <li>
                        	请在24小时内查看您的重设密码邮件！
                        </li>
                        <li>
							到别的频道去看看吧！
                        </li>
                    </ul>
                 </div>
            </div>
        </div>
        
                    <div class="content centerText" id="divFail" runat="server">
                <div class="sheet1 showResult">
                	<span class="errorIcon"></span>
                    <ul>
                    	<li>
                        	<span class="bold">对不起，您输入的邮箱地址不正确！</span>
                   		</li>
                        <li>
                        	请重新输入！
                        </li>
                        <li>
							到别的频道去看看吧！
                        </li>
                    </ul>
                </div>
            </div>
        </div>



        </div>
    </div>
    <!--MainBody End-->

</asp:Content>
