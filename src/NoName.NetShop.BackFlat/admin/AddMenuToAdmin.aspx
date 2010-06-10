<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenuToAdmin.aspx.cs" Inherits="NoName.NetShop.BackFlat.admin.AddMenuToAdmin" %>


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
        <asp:DropDownList ID="ddlAdmins" runat="server" Width="165px" AutoPostBack="True" 
                        onselectedindexchanged="ddlAdmins_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="btnApp" runat="server" OnClick="btnAdd_Click" Text="提交" /><br />
                </td>
            </tr>
            <tr>
                <td style="height: 21px; width: 300px;">
                    菜单授权</td>
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
                    
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRoles" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        

	 </form>
</body>
</html>
