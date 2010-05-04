<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandDetail.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.DemandDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>需求信息：</td>
                <td><asp:Literal runat="server" ID="Literal_Demand" /></td>
            </tr>
            <tr>
                <td>场地情况：</td>
                <td><asp:Literal runat="server" ID="Literal_Field" /></td>
            </tr>
            <tr>
                <td>场地图片：</td>
                <td runat="server" id="fieldImages">
                    
                </td>
            </tr>
            <tr>
                <td>效果要求：</td>
                <td><asp:Literal runat="server" ID="Literal_Effect" /></td>
            </tr>
            <tr>
                <td>预算：</td>
                <td><asp:Literal runat="server" ID="Literal_Budget" /></td>
            </tr>
            <tr>
                <td>联系人：</td>
                <td><asp:Literal runat="server" ID="Literal_Contact" /></td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td><asp:Literal runat="server" ID="Literal_Phone" /></td>
            </tr>
            <tr>
                <td>邮政编码：</td>
                <td><asp:Literal runat="server" ID="Literal_Postcode" /></td>
            </tr>
            <tr>
                <td>所在地区：</td>
                <td><asp:Literal runat="server" ID="Literal_Region" /></td>
            </tr>
            <tr>
                <td>详细地址：</td>
                <td><asp:Literal runat="server" ID="Literal_Address" /></td>
            </tr>
            <tr>
                <td>添加时间：</td>
                <td><asp:Literal runat="server" ID="Literal_CreateTime" /></td>
            </tr>
            <tr>
                <td>目前状态：</td>
                <td><asp:Literal runat="server" ID="Literal1_Status" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
