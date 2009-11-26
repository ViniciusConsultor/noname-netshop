<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.PawnShop.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>收当</b>
    <table>
        <tr>
            <td>产品名称<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_ProductName" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>收当价格：</td>
            <td><asp:TextBox runat="server" ID="TextBox_PawnPrice" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>销售价格：</td>
            <td><asp:TextBox runat="server" ID="TextBox_SellingPrice" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>数量<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Count" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>关键词<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_Keyword" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>描述：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_Brief" TextMode="MultiLine" Height="400" /></td>
        </tr>
        <tr>
            <td>图片<span class="red">*</span>：</td>
            <td>
                <asp:Image Width="200" Height="200" runat="server" ID="Image_ProductImage" />
                <asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="Button_OK" OnClick="Button_OK_Click" Text="提交" />
    </div>
    </form>
</body>
</html>
