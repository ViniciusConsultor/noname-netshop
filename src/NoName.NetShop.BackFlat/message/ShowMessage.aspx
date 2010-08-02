<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMessage.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.ShowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>

    <script src="../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#btnReturn').click(function() {
                window.location = 'messagelist.aspx?page=' + $(this).attr('page');
            });
        });
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <table style="width: 100%;">
        <tr>
        <td colspan=2>
        消息ID：<asp:Label runat="server" ID="lblMsgId"></asp:Label>&nbsp;
        发送人：<asp:Label runat="server" ID="lblSender"></asp:Label>&nbsp;
        发送时间：<asp:Label runat="server" ID="lblSendTime"></asp:Label>
        </td>
        </tr>
        <tr>
            <td>
               标题：
            </td>
            <td>
                <asp:Label runat="server" ID="lblSubject"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                内容：
            </td>
            <td>
                <asp:Label runat="server" ID="lblContent"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="button" id="btnReturn" page="<%= Request.QueryString["page"] %>" value="返回" />
            </td>
        </tr>
    </table> 
    </div>
    
    </form>
</body>
</html>
