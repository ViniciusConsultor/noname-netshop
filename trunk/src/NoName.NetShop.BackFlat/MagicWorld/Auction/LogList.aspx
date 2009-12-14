<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Auction.LogList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="日志ID" DataField="logid" />
                    <asp:BoundField HeaderText="用户" DataField="UserName" />
                    <asp:BoundField HeaderText="出价时间" DataField="AuctionTime" />
                    <asp:BoundField HeaderText="出价" DataField="AutionPrice" />
                </Columns>
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>