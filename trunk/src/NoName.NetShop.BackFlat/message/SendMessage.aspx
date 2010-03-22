<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.SendMessage" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" media="screen" href="../css/datePicker.css" />
<script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../js/date.js"></script>
<script type="text/javascript" src="../js/jquery.datePicker.js"></script>    
<script type="text/javascript" charset="utf-8">
    $(function() {
        var now = new Date();
        var enddate = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate();
        $('.date-pick').datePicker({ startDate: '2009-01-01', endDate: enddate, createButton: false, clickInput: true });
    });
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
        <div>正在执行操作，请稍候……</div>
        </ProgressTemplate>
        </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
    <table width="90%">
    <thead>
    <tr>
    <td colspan="2">消息发送</td>
    </tr>
    </thead>
    <tbody>
    <tr>
    <td>标题：
     </td>
    <td>
    <asp:TextBox runat="server" MaxLength="100" ID="txtSubject"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>接收对象：</td>
    <td>
    <asp:RadioButtonList runat="server" ID="rblUserType" RepeatDirection="Horizontal" 
            AutoPostBack="true" onselectedindexchanged="rblUserType_SelectedIndexChanged"
            >
    <asp:ListItem Text="前台用户" Value="0"></asp:ListItem>
    <asp:ListItem Text="后台用户" Value="1"></asp:ListItem>
    </asp:RadioButtonList></td>
    </tr>
    <tr>
    <td>消息类型：</td>
    <td>
    <asp:RadioButtonList runat="server" ID="rblMsgType" RepeatDirection="Horizontal" 
            AutoPostBack="true" onselectedindexchanged="rblMsgType_SelectedIndexChanged">
    <asp:ListItem Text="用户消息" Value="0"></asp:ListItem>
    <asp:ListItem Text="组消息" Value="2"></asp:ListItem>
    <asp:ListItem Text="站内公告" Value="1"></asp:ListItem>
    </asp:RadioButtonList></td>
    </tr>
    <tr>
    <td>接收对象</td>
    <td>
    <asp:CheckBoxList runat="server" ID="cblUsers" RepeatDirection="Horizontal" RepeatColumns="5">
    </asp:CheckBoxList>
    </td>
    </tr>
    <tr>
    <td>过期时间：</td>
    <td><asp:TextBox runat="server"  ID="txtExpireTime" CssClass="date-pick" ></asp:TextBox></td>
    </tr>    
    <tr>
    <td>内容：</td>
    <td><asp:TextBox runat="server"  ID="txtContent" TextMode="MultiLine"></asp:TextBox></td>
    </tr>    
    </tbody>
    <tfoot>
<tr><td colspan="2">
<asp:Button runat="server" ID="btnSave" Text="发布" onclick="btnSave_Click" />
</td></tr>
    </tfoot>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
