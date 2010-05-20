<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegCompany.aspx.cs" Inherits="NoName.NetShop.ForeFlat.RegCompany" %>

<%@ Register src="uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">

    <script type="text/javascript">
    function reloadimg() {
        $("#imgcode").attr("src", $("#imgcode").attr("src") + "?" + Math.random());
    }

    $(document).ready(function() {
        $("input[name$='txtUserId']").blur(function() {
            var $txtUserId = $(this);
            if ($txtUserId.val() == "") {
                $txtUserId.next(".tip").html("必须提供帐号").css({ color: "red" });
            }
            else if (!(/^\w+$/.test($txtUserId.val()))) {
                $txtUserId.next(".tip").html("限定为字母或数字").css({ color: "red" });
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "api/CartOpenApi.ashx",
                    data: "action=regexistuserid&userId=" + $txtUserId.val(),
                    dataType: "json",
                    success: function(data) {
                        if (data == true) {
                            $txtUserId.select();
                            $txtUserId.next(".tip").html("此帐号已被注册").css({ color: "red" });
                        }
                        else {
                            $txtUserId.next(".tip").html("您可以使用此用户ID").css({ color: "gray" });
                        }
                    }
                });
            }
        });

        $("input[name$='txtUserEmail']").blur(function() {
            var $txtUserEmail = $(this);
            if ($txtUserEmail.val() == "") {
                $txtUserEmail.next(".tip").html("必须提供邮箱地址").css({ color: "red" });
            }
            else if (!(/^[\w\.-]+@([\w-]+\.)+[a-zA-Z]{2,4}$/.test($txtUserEmail.val()))) {
                $txtUserEmail.next(".tip").html("必须为有效的邮箱地址").css({ color: "red" });
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "api/CartOpenApi.ashx",
                    data: "action=regexistemail&email=" + $txtUserEmail.val(),
                    dataType: "json",
                    success: function(data) {
                        if (data == true) {
                            $txtUserEmail.select();
                            $txtUserEmail.next(".tip").html("此邮箱已被注册").css({ color: "red" });
                        }
                        else {
                            $txtUserEmail.next(".tip").html("邮箱通过验证").css({ color: "gray" });
                        }
                    }
                });
            }
        });

        $('#chkUserProtocol').click(function() {
            if ($(this).attr('checked') == true) {
                $('#<%= btnRegister.ClientID %>').removeAttr('disabled');
            }
            else {
                $('#<%= btnRegister.ClientID %>').attr('disabled', 'true');
            }
        });

    }); 
    
    </script>

    <!--Position Begin-->
    <div class="currentPosition">
        您现在的位置: <a href="http://dingding.cncc.cn">首页</a> &gt;&gt; 用户注册
    </div>
    <!--Position End-->
    <!--MainBody Begin-->
    <div class="register_mainbody clearfix">
        <div class="regTitle">
        </div>
        <asp:Panel ID="panReg" runat="server">
            <asp:Label ID="lblPrompt" EnableViewState="false" ForeColor="Red" runat="server"></asp:Label>
            <ul class="form">
                <li><span class="field">用户类型：</span>
                <span  style="text-align:left">
                <input type="radio" id="rutPerson" name="userType" value="1" onclick="window.location='RegPerson.aspx'"/>个人用户
                <input type="radio" id="rutCompany" name="userType" value="2"  checked="checked" />企业用户
                <input type="radio" id="rutFamly" name="userType" value="3" onclick="window.location='RegFamly.aspx'" />家庭用户
                <input type="radio" id="rutSchool" name="userType" value="4" onclick="window.location='RegSchool.aspx'" />学校用户
                 </span>   </li>
                <li><span class="field">用户帐号：</span>
                    <asp:TextBox ID="txtUserId" runat="server" CssClass="textField1" ></asp:TextBox>
                    <span class="tip">您的登录帐号</span> </li>
                <li><span class="field">用 户 名：</span>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip">您在本站的昵称</span> </li>
                <li><span class="field">EMail地址：</span>
                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="textField1"></asp:TextBox>
                     <span class="tip"></span>
                   <span class="newlineTip">请填写有效的Emai地址，我们也会给这个地址发送帐户信息、订单通知等 使用 Email 地址，以便记忆</span>
                </li>
                
                <li><span class="field">密 码：</span>
                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="textField1" TextMode="Password"></asp:TextBox>
                    <span class="tip">建议采用6位以上复杂密码，可由数字、英文字母、下划线组成</span> </li>
                <li><span class="field">确认密码：</span>
                    <asp:TextBox ID="txtPassword2" runat="server" CssClass="textField1" TextMode="Password"></asp:TextBox>
                    <span class="tip">再次输入密码</span> </li>
                <li><span class="field">验 证 码：</span>
                    <asp:TextBox ID="txtValidCode" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip">输入下面图片中的文本</span>
                    <div class="verifyCode">
                        <img id="imgcode" alt="验证码" src="ValiateCode.aspx" />
                        <span onclick="reloadimg()" style="cursor: hand; color: #1E51A4;">看不清楚，换一张</span>
                    </div>
                </li>
                <li><span class="field">公司名称：</span>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li><span class="field">所在地区：</span>
                <uc1:RegionSelect ID="ucRegion" runat="server" />
&nbsp;</li>
                <li><span class="field">详细地址：</span>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li><span class="field">电话号码：</span>
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li><span class="field">手机：</span>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li><span class="field">传真：</span>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li><span class="field">身份证：</span>
                    <asp:TextBox ID="txtIdCard" runat="server" CssClass="textField1"></asp:TextBox>
                    <span class="tip"></span> </li>
                <li>
                    <input type="checkbox" id="chkUserProtocol" /> 我同意<a href="/help/UserProrocol.shtml" target="_blank">《鼎鼎商城用户协议》</a>
                </li>
                <li class="submit">
                    <asp:Button runat="server" ID="btnRegister" Text="注　册" Enabled="false" CssClass="button_blue2" OnClick="btnRegister_Click" />
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
