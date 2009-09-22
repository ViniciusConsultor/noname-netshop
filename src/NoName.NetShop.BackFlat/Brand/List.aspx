<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="GridView1"></asp:GridView>
        <div class="page">
            <cc1:AspNetPager ID="AspNetPager" AlwaysShow="true" runat="server" OnPageChanged="AspNetPager_PageChanged" PageSize="10" 
                FirstPageText='首页' LastPageText='末页' NextPageText='下一页' PrevPageText='上一页'
                ShowBoxThreshold="16" NumericButtonCount="8" ShowPrevNext="True" CustomInfoSectionWidth="36%" SubmitButtonClass="buttom">
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>
