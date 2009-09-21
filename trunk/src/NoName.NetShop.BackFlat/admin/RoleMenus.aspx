<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleMenus.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.RoleMenus" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色授权</title>
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
                <td colspan="2">
        <asp:DropDownList ID="ddlRoles" runat="server" Width="165px" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除角色" />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label><br />
        <asp:TextBox ID="txtRoleName" runat="server" Width="159px"></asp:TextBox>
        <asp:Button ID="btnInsert" runat="server" Text="添加角色" OnClick="btnInsert_Click" />
        <asp:Button ID="btnApp" runat="server" OnClick="btnApp_Click" Text="应用修改" /><br />
                </td>
            </tr>
            <tr>
                <td style="height: 21px; width: 300px;">
                    菜单授权</td>
                <td style="height: 21px">
                    添加用户</td>
            </tr>
            <tr>
                <td style="width: 300px; vertical-align:top">
                    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        
                    <asp:TreeView ID="tvMenus" runat="server"   ImageSet="Inbox" ShowCheckBoxes="All" OnPreRender="tvMenus_PreRender">
                        <ParentNodeStyle Font-Bold="False"  />
                        <HoverNodeStyle Font-Underline="True" />
                        <SelectedNodeStyle
                            Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                    
                    <asp:Button ID="btnSaveMenusOfRole" runat="server" Text="保存授权信息" OnClick="btnSaveMenusOfRole_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td style="text-align: left; vertical-align:top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            &nbsp;<asp:CheckBoxList ID="chkUserList" runat="server" RepeatColumns="4" Repeatdirection="Horizontal">
                            </asp:CheckBoxList><br />
                        <asp:Button ID="btnSaveUsersToRole" runat="server"   Text="保存角色用户" OnClick="btnSaveUsersToRole_Click" />
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
