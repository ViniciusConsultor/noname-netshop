<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Add" %>

<%@ Register src="../Controls/CategorySelect.ascx" tagname="CategorySelect" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        var categoryInfo = [{ "name": "category1", "title": "", "required": "true" },
    { "name": "category2", "title": "", "required": "true" },
    { "name": "category3", "title": "", "required": "false"}];
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h3>商品添加</h3>
        <table>
            <tr>
                <td>产品名称：</td>
                <td><asp:TextBox id="txtProductName" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>产品编号：</td>
                <td><asp:TextBox id="txtProductCode" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>所属分类：</td>
                <td><uc1:CategorySelect ID="CategorySelect1" runat="server" /></td>
            </tr>
            <tr>
                <td>市场价：</td>
                <td><asp:TextBox id="txtTradePrice" runat="server" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>销售价：</td>
                <td><asp:TextBox id="txtMerchantPrice" runat="server" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>促销价：</td>
                <td><asp:TextBox id="txtReducePrice" runat="server" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>库存：</td>
                <td><asp:TextBox id="txtStock" runat="server" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>状态：</td>
                <td><asp:DropDownList runat="server" ID="drpStatus"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>关键字：</td>
                <td><asp:TextBox id="txtKeywords" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>简介：</td>
                <td><FCKeditorV2:FCKeditor ID="fckBrief" runat="server" /></td>
            </tr>
            <tr>
                <td>商品图片：</td>
                <td><asp:FileUpload runat="server" ID="fulImage" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" ></asp:Button></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
