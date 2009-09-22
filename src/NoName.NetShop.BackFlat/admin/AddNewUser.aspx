<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.AddNewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加管理员</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

<div align="center">
          <table width="540" border="0" cellpadding="0" cellspacing="0">
          	  <tr>
	    <td height="40" style="font-size:14px;text-align:center" colspan=2><b>
            <asp:Label ID="Label1" runat="server" Text="添加管理员"></asp:Label></b></td>
    </tr>
            <tr>
              <td style="height: 30px; text-align:right">管理员姓名：</td>
              <td style="width: 424px"><b>
                    <asp:TextBox ID="txtTrueName" runat="server" CssClass="largeinput"></asp:TextBox>&nbsp;
              </b></td>
            </tr>
            <tr>
              <td style="height: 30px; text-align:right">身份证号码：</td>
              <td style="width: 424px"><asp:TextBox ID="txtIdCard" runat="server" CssClass="largeinput"></asp:TextBox></td>
            </tr>
            <tr>
              <td style="height: 30px; text-align:right">用　户　名：</td>
              <td style="width: 424px"><b>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="middleinput"></asp:TextBox>
                  <asp:LinkButton ID="lbtnCheckExists" runat="server" OnClick="lbtnCheckExists_Click">检查用户是否存在</asp:LinkButton></b></td>
            </tr>
            <tr>
              <td style="height: 30px; text-align:right">密　　　码：</td>
              <td style="width: 424px">
                    <asp:TextBox ID="txtUserPassword" TextMode=Password runat="server" CssClass="middleinput"></asp:TextBox>
              <span style="padding-left:5px; color:Red">6位 默认密码为888888</span> </td>
            </tr>
            <tr>
              <td style="height: 30px; text-align:right">联 系 电 话：</td>
              <td style="width: 424px"><b>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="largeinput"></asp:TextBox>&nbsp;</b></td>
            </tr>
              <tr>
                  <td style="height: 30px;text-align:right">
                      手机：</td>
                  <td style="height: 30px; width: 424px;">
                      <asp:TextBox ID="txtMobile" runat="server" CssClass="largeinput"></asp:TextBox></td>
              </tr>
            <tr>
              <td style="height: 30px; text-align:right">QQ：</td>
              <td style="width: 424px"><asp:TextBox ID="txtQQ" runat="server" CssClass="largeinput"></asp:TextBox>
</td>
            </tr>
              <tr>
                  <td style="height: 30px; text-align:right">
    MSN：</td>
                  <td style="width: 424px">
                      <asp:TextBox ID="txtMSN" runat="server" CssClass="largeinput"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="height: 30px; text-align:right">
                      E-MAIL：</td>
                  <td style="width: 424px">
                     <asp:TextBox ID="txtEmail" runat="server" CssClass="largeinput"></asp:TextBox></td>
              </tr>
              <tr>
                  <td style="height: 30px; text-align:right">
                      用户所属角色：</td>
                  <td style="width: 424px">
                      <asp:CheckBoxList ID="chkRoles" runat="server" RepeatColumns="4" Repeatdirection="Horizontal"
                          RepeatLayout="Flow">
                      </asp:CheckBoxList></td>
              </tr>
              <tr>
                  <td height="30">
                  </td>
                  <td style="width: 424px">
              
              <asp:Label ID="lblResult" runat="server" /></td>
              </tr>
            <tr>
              <td height="30"><div align="right"></div></td>
              <td style="width: 424px"><div align="center"><asp:CheckBox ID="chkSetActive" runat="server"
                        Text="激活用户" />
                  <asp:Button ID="btnSaveUserInfo" runat="server"
                        Text="创建新用户" OnClick="btnSaveUserInfo_Click" />
                  &nbsp;
              </div></td>
            </tr>
            
          </table>
          
</div>

    </form>
</body>
</html>
