<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoName.NetShop.BackFlat.Security.Login" %>
<html>
<head runat="server">
    <title>用户登录—鼎鼎商城</title>
<style type="text/css">
BODY,TD
{
 	MARGIN:0;
    FONT-SIZE: 12px;
    LINE-HEIGHT:19px;
}
.whitetext{
	text-align:right;
	font-size:14px;
	color:#FFFFFF;
	font-weight:bolder;
}

.input_t{
	width:120px;
	height:22px;
	border:1px solid #666666;
}
.whitefont,.whitefont A:link{
	color:#FFFFFF;
}
.title{
	text-align:center;
	color:white;
	font-size:16px;
	line-height::22px;
	font-weight:bolder;
}
.list{
	color:#ffffff;
	font-size:16px;
	font-weight:bolder;
}
a{color:#ffffff}
a:hover{color:#00ff00}
</style>
</head>
<body>

<TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TBODY>
  <TR bgColor=#003366>
    <TD height="120" class="title">&nbsp;
	</TD>
  </TR>
  <TR bgColor=#336699>
    <TD Align=center>
		<TABLE width="300">
		<TR>
			<TD height="30" align="center" class="list">欢迎使用鼎鼎商城管理系统</TD>
		</TR>
		<TR>
			<TD valign="top" height="100" class="whitefont" align="center">
    <form id="form1" runat="server">
                    <asp:Login ID="Login2" runat="server" DisplayRememberMe=false Width="453px">
                    <LayoutTemplate>

                                    <table border="0" cellpadding="0" width="80%" align="center">
                                        <tr>
                                            <td align="right" style="width:80;font-weight:bold; color:White" >
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label></td>
                                            <td align="left" >
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login2">* 必须填写“用户名</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width:80;font-weight:bold; color:White ">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label></td>
                                            <td align="left" >
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login2">* 必须填写“密码”</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:White">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td></td>
                                            <td align="center">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="Login2" Height="24px" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>

                    </LayoutTemplate>
                </asp:Login>
</form>
			</TD>
		</TR>
		</TABLE>
  	  </TD>
    </TR>
  <TR bgColor=#003366>
    <TD style="line-height:20px" height="120" align=center class="whitefont">
	 鼎鼎商城管理系统</TD>
  </TR></TBODY></TABLE>
 
 </body>   
    
</html>
