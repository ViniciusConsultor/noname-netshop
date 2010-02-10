<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.MessageList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
     
                                   
<asp:gridview runat="server" ID="gvList" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" AllowSorting="True" DataKeyNames="msgId"
              Width="96%"   onrowdeleting="gvList_RowDeleting" >
    <RowStyle BackColor="White" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Subject" HeaderText="标题" />
        <asp:BoundField DataField="InsertTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"  HeaderText="收件时间"/>
        <asp:BoundField DataField="SenderId"  HeaderText="发件人"/>
        <asp:HyperLinkField Text="查看"   DataNavigateUrlFormatString="ShowMessage.aspx?msgId={0}" HeaderText="查看" DataNavigateUrlFields="msgId" />
        <asp:CommandField DeleteText="删除" ShowDeleteButton="true"  HeaderText="删除" />
    </Columns>
    <EmptyDataTemplate>
    没有找到相关记录
    </EmptyDataTemplate>
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
</asp:gridview>
        <cc1:AspNetPager ID="pageNav" runat="server" 
            onpagechanged="pageNav_PageChanged" >
        </cc1:AspNetPager>

    </div>

    </form>
</body>
</html>
