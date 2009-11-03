<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">

    <script type="text/javascript">
    function reloadimg() {
        $("#imgcode").attr("src", $("#imgcode").attr("src") + "?" + Math.random());
    }
</script>
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="dingding.cncc.cn">首页</a> &gt;&gt; 用户注册
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="register_mainbody clearfix">
    	<div class="regTitle"></div>
    	<asp:Panel ID="panReg" runat="server">
		<ul class="form">
        	<li>
            	<span class="field">EMail地址：</span>
            	<asp:TextBox ID="txtUserEmail" runat="server" CssClass="textField1"></asp:TextBox>
                <span class="newlineTip">请填写有效的Emai地址作为下次登录的用户名,同时我们也会给这个地址发送帐户信息、订单通知等
使用 Email 地址，以便记忆</span>
            </li>
            <li>
            	<span class="field">用 户 名：</span>
            	<asp:TextBox ID="txtNickName" runat="server" CssClass="textField1"></asp:TextBox>
                <span class="tip">您在本站的昵称</span>
            </li>
            <li>
            	<span class="field">密　　码：</span>
            	<asp:TextBox ID="txtPassword1" runat="server" CssClass="textField1" TextMode="Password"></asp:TextBox>
                <span class="tip">建议采用6位以上复杂密码，可由数字、英文字母、下划线组成</span>
            </li>
            <li>
            	<span class="field">确认密码：</span>
             	<asp:TextBox ID="txtPassword2" runat="server" CssClass="textField1" TextMode="Password"></asp:TextBox>
                <span class="tip">再次输入密码</span>
            </li>
            <li>
            	<span class="field">验 证 码：</span>
            	<asp:TextBox ID="txtValidCode" runat="server" CssClass="textField1"></asp:TextBox>
                <span class="tip">输入下面图片中的文本</span>
                <div class="verifyCode">
                	<img id="imgcode" alt="验证码" src="ValiateCode.aspx" />
                	<span onclick="reloadimg()" style=" cursor:hand; color:#1E51A4; ">看不清楚，换一张</span>
                </div>
            </li>
            <li class="submit">
                <asp:Button runat="server" ID="btnRegister" Text="注　册" CssClass="button_blue2" 
                    onclick="btnRegister_Click" />
            </li>
        </ul>
   </asp:Panel>
   <asp:Panel ID="panRegOk" runat="server">
   <div>
   <asp:Label ID="lblResult" runat="server"></asp:Label>
   </div>
   </asp:Panel>
    </div>
    <!--MainBody End-->

</asp:Content>
