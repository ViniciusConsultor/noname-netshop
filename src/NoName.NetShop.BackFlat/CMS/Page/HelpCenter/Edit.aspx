﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.HelpCenter.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>页面名称：</td>
                <td><asp:TextBox runat="server" Enabled="false" ID="TextBox_PageName" />(页面命名，将出现在访问地址中，请使用英文字母和数字的组合)</td>
            </tr>
            <tr>
                <td>页面标题：</td>
                <td><asp:TextBox runat="server" ID="TextBox_PageTitle" />_帮助中心_鼎鼎商城</td>
            </tr>
            <tr>
                <td>模板选择：</td>
                <td><asp:DropDownList runat="server" Enabled="false" ID="DropDownList_Template" /></td>
            </tr>
        </table>
        <br />
        <a href="List.aspx">返回</a>
        <asp:LinkButton runat="server" ID="Button_Edit" Text="确定" OnClick="Button_Edit_Click" />
    </form>
</body>
</html>
