<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyProfile" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的个人资料</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>个人资料</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="form">
                        <li>
			    <span class="field">用 户 名：</span>
                            <span><asp:Label id="lbluserId" runat="server"></asp:Label></span>
                        </li>
                        <li>
			<span class="field">用户姓名：</span>
				<asp:TextBox id="txtUserName" runat="server" CssClass="textField1"></asp:TextBox>
                            <span class="tip">请填写您的真实姓名</span>
                        </li>
                        <li>
			<span class="field">电子邮箱：</span>
                            <asp:Label id="lblUserEmail" runat="server"></asp:Label>
                        </li>
                        <li>
			<span class="field">当前积分：</span>
                            <span><asp:Label id="lblCurScore" runat="server"></asp:Label></span>
                        </li>
                        <li>
			<span class="field">注册时间：</span>
                            <span><asp:Label id="lblRegTime" runat="server"></asp:Label></span>
                        </li>
                        <li>
			<span class="field">会员状态：</span>
                            <span><asp:Label id="lblStatus" runat="server"></asp:Label></span>
                        </li>
                        <li>
			<span class="field">会员类型：</span>
                            <span><asp:Label id="lblUserType" runat="server"></asp:Label></span>
                        </li>
	<asp:PlaceHolder ID="phExtentInfo" runat="server"></asp:PlaceHolder>
                        <li class="submit">
                            <asp:LinkButton runat="server" ID="btnSave" Text="保　存" CssClass="button_blue" 
                                onclick="btnSave_Click"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
