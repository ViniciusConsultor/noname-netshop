<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.Properity.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="List.aspx">返回</a>
        <table>
            <tr>
                <td>属性名称：</td>
                <td><asp:TextBox runat="server" ID="TextBox_ParaName" /></td>
            </tr>
            <tr>
                <td>属性类型：</td>
                <td><asp:DropDownList runat="server" ID="DropDown_ParaType" /></td>
            </tr>
            <tr>
                <td>状态：</td>
                <td>
                    <asp:DropDownList runat="server" ID="DropDownList_Status">
                        <asp:ListItem Text="正常" Value="1" />
                        <asp:ListItem Text="冻结" Value="2" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>属性值：</td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_ParaValue" TextMode="MultiLine" Width="500" Height="400" />
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" OnClick="Button_Add_Click" Text="提交" />
    </div>
    </form>
</body>
</html>
