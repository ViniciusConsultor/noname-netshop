<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户信息维护</title>
<style type="text/css">
     td{ text-align:left;}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="margin:10px 10px 10px 10px">
   <div>
    <span class="maintitle">管理员信息维护</span>
        <asp:LinkButton ID="lbtnChangeBrands" runat="server" OnClick="lbtnChangeBrands_Click">修改用户管理的品牌</asp:LinkButton>
        </div>
    </div>
    <div class="splitbar" ></div>
    
    <div style="margin:10px 10px 10px 10px">
            <div class="subtitle">修改基本信息</div>
       
        <table style="width: 540">
            <tr>
              <td style="height: 30px; text-align:right">用　户　名：</td>
              <td style="width: 424px">
                    <asp:Label ID="lblUserId" runat="server" CssClass="middleinput"></asp:Label>
                  </td>
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
                <td colspan="2" style="height: 26px">
                    &nbsp;<asp:Button ID="btnSaveUserInfo" runat="server" Text="修改用户基本信息" OnClick="btnSaveUserInfo_Click" />&nbsp;
                    <asp:Label ID="lblSaveUserInfoResult" runat="server" SkinID="Result"  EnableViewState="false"></asp:Label></td>
            </tr>
        </table>
    </div>
     <div class="splitbar" ></div>
   
    <div style="margin:10px 10px 10px 10px" >
    <div class="subtitle">修改用户状态</div>
    <div>
        <asp:CheckBox ID="chkIsLocked" runat="server" Text="锁定" />&nbsp;
        <asp:CheckBox ID="chkIsApproved" runat="server" Text="启用" />
        <asp:Button ID="btnSetStatus"
            runat="server"  Text="修改用户状态" OnClick="btnSetStatus_Click" /><asp:Label ID="lblSetStatusResult" runat="server" SkinID="Result" EnableViewState="false"></asp:Label>
            
    </div>
    </div>

     <div class="splitbar" ></div>
   
    <div style="margin:10px 10px 10px 10px">
    <div class="subtitle">重置用户密码</div>
    <div>
        新密码：<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" EnableViewState="False" CssClass="middleinput" /><asp:Label runat="server" ID="lblSavePwdResult" SkinID=Result  EnableViewState="false"/>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" EnableClientScript="true" ValidationGroup="ChangePasswd" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
        <br />
    <asp:Button ID="btnSavePwd" runat="server" Text="重置用户密码" OnClick="btnSavePwd_Click" ValidationGroup="ChangePasswd" />
    </div>
    </div>
      <div class="splitbar" ></div>
   
    <div style="margin:10px 10px 10px 10px">
    <div class="subtitle">修改用户所属用户组</div>
    <div>
        <asp:CheckBoxList ID="clsRoleList" Repeatdirection="Horizontal" RepeatColumns="4" runat="server">
        </asp:CheckBoxList>
        <asp:Button ID="btnSaveRolesToUser" runat="server" Text="保存用户所属角色" OnClick="btnSaveRolesToUser_Click" />
        <asp:Label ID="lblSaveRolesResult" EnableViewState="false" runat="server" SkinID="result"></asp:Label>
    
    </div>
</div>
         <div class="splitbar" ></div>
    </form>
</body>
</html>
