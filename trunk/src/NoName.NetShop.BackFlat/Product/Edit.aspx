<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Edit" %>
<%@ Register src="../Controls/CategorySelect.ascx" tagname="CategorySelect" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>商品修改</h3>
        <table>
            <tr>
                <td>产品名称<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtProductName" runat="server" Width="400"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>产品编号：</td>
                <td><asp:TextBox id="txtProductCode" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>所属分类<span class="red">*</span>：</td>
                <td><uc1:CategorySelect ID="CategorySelect1" runat="server" /></td>
            </tr>
            <tr>
                <td>市场价<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtTradePrice" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>销售价<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtMerchantPrice" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>促销价<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtReducePrice" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>库存<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtStock" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>状态<span class="red">*</span>：</td>
                <td><asp:DropDownList runat="server" ID="drpStatus"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>关键字<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtKeywords" runat="server" Width="400"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>简介<span class="red">*</span>：</td>
                <td><FCKeditorV2:FCKeditor ID="fckBrief" runat="server" /></td>
            </tr>
            <tr>
                <td>商品图片<span class="red">*</span>：</td>
                <td>
                    <asp:Image runat="server" ID="imgProduct" />
                    <asp:FileUpload runat="server" ID="fulImage" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnEdit" runat="server" Text="提交" OnClick="btnEdit_Click" ></asp:Button></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
