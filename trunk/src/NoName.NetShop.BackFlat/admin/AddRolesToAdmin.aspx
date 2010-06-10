<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRolesToAdmin.aspx.cs" Inherits="NoName.NetShop.BackFlat.admin.AddRolesToAdmin" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>角色授权</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                正在处理，请稍候……
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
        <table style="width: 90%">
            <tr>
                <td>
        <asp:DropDownList ID="ddlAdmins" runat="server" Width="165px" 
                        OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    添加用户</td>
            </tr>
            <tr>
                <td style="text-align: left; vertical-align:top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            &nbsp;<asp:CheckBoxList ID="chkRolesList" runat="server" RepeatColumns="4" 
                                Repeatdirection="Horizontal">
                            </asp:CheckBoxList><br />
                        <asp:Button ID="btnSaveUsersToRole" runat="server"   Text="保存管辖角色" 
                                OnClick="btnSaveUsersToRole_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;<br />
                    </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        

	 </form>
</body>
</html>
