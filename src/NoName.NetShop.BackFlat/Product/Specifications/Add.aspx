<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Specifications.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#<%=Button_AddGo.ClientID %>').click(validate);
            $('#<%=Button_AddReturn.ClientID %>').click(validate);


            function validate() {
                if ($('#<%= TextBox_Title.ClientID %>').val() == '') {
                    alert('请输入标题');
                    return false;
                }
                if ($('#<%= TextBox_Content.ClientID %>').val() == '') {
                    alert('请输入内容');
                    return false;
                }
                return true;
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>类型：</td>
                <td>
                    <asp:DropDownList runat="server" ID="DropDown_Type" />
                </td>
            </tr>
            <tr>
                <td>名称：</td>
                <td>
                    <asp:TextBox ID="TextBox_Title" runat="server" Width="400" />
                </td>
            </tr>
            <tr>
                <td>内容：</td>
                <td>
                    <asp:TextBox ID="TextBox_Content" runat="server" TextMode="MultiLine" Width="400" Height="300" />
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_AddGo" OnClick="Button_AddGo_Click" Text=" 提交并继续添加 " />
        <asp:Button runat="server" ID="Button_AddReturn" OnClick="Button_AddReturn_Click" Text=" 提交并返回 " />
        <asp:Button runat="server" ID="Button_Return" OnClick="Button_Return_Click" Text=" 返回 " />
    </div>
    </form>
</body>
</html>
