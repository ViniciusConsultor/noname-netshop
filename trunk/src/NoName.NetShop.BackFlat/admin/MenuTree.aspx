<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuTree.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.MenuTree" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>功能菜单维护</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />

</head>
<body  topmargin=5 leftmargin=5>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <div>正在执行操作，请稍候……</div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    <table style="border-width:1px; border-style:solid; width:100%; border-color:#99ccff;" border=1>
        <tr>
            <td bgcolor="#99ccff" style="vertical-align: top; width: 250px">
                系统功能菜单树</td>
            <td bgcolor="#99ccff" style="vertical-align: top">
                功能菜单操作（更新或添加）</td>
        </tr>
    <tr>
    <td style="width:250px; vertical-align:top;">        
    <asp:UpdatePanel ID="upMenuTree" runat="server">
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
        </Triggers>
            <ContentTemplate>
        <asp:TreeView ID="tvMenu" runat="server" EnableViewState=true OnSelectedNodeChanged="tvMenu_SelectedNodeChanged" ShowLines="False">
        </asp:TreeView>
                <asp:Button ID="btnRenewTree" runat="server" Text="更新菜单树" OnClick="btnRenewTree_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    <td style="vertical-align:top" >
<asp:UpdatePanel ID="upDetail" runat="server">
            <ContentTemplate>
                <table style="width: 552px; vertical-align:top">
                    <tr>
                        <td style="width: 86px" align="right">
                            当前菜单ID</td>
                        <td style="height:20px">
                            <asp:Label ID="lblMenuId" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 86px" align="right">
                            父级菜单ID</td>
                        <td style=" height:20px">
                            <asp:Label ID="lblFatherId" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 86px; height: 30px;" align="right">
                            菜单名称</td>
                        <td style="height:30px">
                            <asp:TextBox ID="txtMenuName" runat="server" Width=200 Height=20></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 86px" align="right">
                            菜单链接</td>
                        <td style=" height:20px">
                            <asp:TextBox ID="txtUrl" runat="server" Width=200 Height=20></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 86px; height: 22px;" align="right">
                            菜单类型</td>
                        <td style="height:22px">
                            <asp:RadioButtonList ID="rblItemType" runat="server" Repeatdirection="Horizontal">
                                <asp:ListItem Value="0" Selected=true>菜单项（可显示）</asp:ListItem>
                                <asp:ListItem Value="1">功能项（不显示）</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td style="width: 86px" align="right">
                            菜单路径</td>
                        <td style=" height:20px">
                            <asp:Label ID="lblPath" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 86px" align="right">
                            菜单说明</td>
                        <td style=" height:20px">
                            <asp:TextBox ID="txtdescription" runat="server" Width=200 Height=20></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 86px" align="right">
                            关键词</td>
                        <td style=" height:20px">
                            <asp:TextBox ID="txtMenuKeys" runat="server" Width=200 Height=20></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 86px; height: 33px; vertical-align:top">
                            授权分配</td>
                        <td style="height: 33px">
                            <asp:RadioButtonList ID="rblAuthType" runat=server AutoPostBack="True" OnSelectedIndexChanged="rblAuthType_SelectedIndexChanged">
                                <asp:ListItem Text="不启用（不参与授权验证）" Value="0" ></asp:ListItem>
                                <asp:ListItem Text="允许匿名访问" Value="1" ></asp:ListItem>
                                <asp:ListItem Text="允许登录用户访问" Value="2" ></asp:ListItem>
                                <asp:ListItem Text="禁止访问" Value="4" ></asp:ListItem>
                                <asp:ListItem Text="允许特定用户组访问" Value="3" ></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:CheckBoxList ID="chkRoles" runat="server" RepeatColumns="2" Repeatdirection="Horizontal"></asp:CheckBoxList>&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td align="right" style=" width: 86px; height: 33px">
                            是否强制执行</td>
                        <td style="height: 33px">
                        <asp:CheckBox ID="chkIsForced" Text="如果有授权冲突则用当前菜单权限覆盖；如果删除则同时删除子菜单" runat=server Checked=false ForeColor="blue" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: left">
                            <asp:Label ID="lblResult" runat="server" SkinID=result EnableViewState=false></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: center">
                            <asp:Button ID="btnInserRootMenu" runat="server" Text="添加顶级菜单" OnClick="btnInserRootMenu_Click" />
                            <asp:Button ID="btnInsert" runat="server" Text="当前菜单添加子菜单" OnClick="btnInsert_Click" />&nbsp;
                            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" /></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tvMenu" EventName="SelectedNodeChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </td>
    </tr>
    </table>


    
    </div>
        <br />
        &nbsp;
    </form>
</body>
</html>
