<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.SendMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
    <td>接收对象</td>
    <td>
    <asp:CheckBoxList runat="server" ID="cblUsers">
    </asp:CheckBoxList>
    </td>
    </tr>
    <tr>
    <td>内容：</td>
    <td><asp:TextBox runat="server"  ID="txtContent" TextMode="MultiLine"></asp:TextBox></td>
    </tr>    </tbody>
    <tfoot>
<tr><td colspan="2">
<asp:Button runat="server" ID="btnSave" Text="发布" onclick="btnSave_Click" />
</td></tr>
    </tfoot>
    </table>
    </div>
    </form>
</body>
</html>
