﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Specifications.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#<%=Button_Add.ClientID %>').click(function() {
                if ($('#<%= TextBox_Content.ClientID %>').val() == '') {
                    alert('请输入内容');
                    return false;
                }
                else {
                    return true;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>规格参数内容：</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox_Content" runat="server" TextMode="MultiLine" Width="400" Height="300" />
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" OnClick="Button_Add_Click" Text=" 提交 " />
        <asp:Button runat="server" ID="Button_Return" OnClick="Button_Return_Click" Text=" 返回 " />
    </div>
    </form>
</body>
</html>
