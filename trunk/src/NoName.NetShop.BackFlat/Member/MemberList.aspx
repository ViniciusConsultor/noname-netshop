<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Member.MemberList" %>

<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
    登录帐号：<asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
    &nbsp;用户类型：
    <asp:DropDownList ID="ddlUserType" runat="server">
    <asp:ListItem Text="初始会员" Value="0"></asp:ListItem>
    <asp:ListItem Text="个人会员" Value="1"></asp:ListItem>
    <asp:ListItem Text="企业会员" Value="2"></asp:ListItem>
    <asp:ListItem Text="家庭会员" Value="3"></asp:ListItem>
    <asp:ListItem Text="学校会员" Value="4"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;<asp:Button ID="doSearch" runat="server" Text="查找" onclick="doSearch_Click" />
    </div>
<asp:gridview runat="server" ID="gvList" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" AllowSorting="True" 
            onrowcommand="gvList_RowCommand" Width="96%" >
    <RowStyle BackColor="White" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="UserId" HeaderText="用户ID" />
        <asp:BoundField DataField="UserEmail" HeaderText="登录帐号" />
        <asp:BoundField DataField="NickName"  HeaderText="昵称"/>
        <asp:BoundField DataField="Status"  HeaderText="状态"/>
        <asp:BoundField DataField="UserType"  HeaderText="用户类型" />
        <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
            <asp:LinkButton runat="server" Id="lbtnDelete" CommandName="delete" Text="删除" CommandArgument='<%# Eval("userId") %>' ></asp:LinkButton>
            <asp:LinkButton runat="server" Id="lbtnEdit" CommandName="show" Text="查看" CommandArgument='<%# Eval("userId") %>'></asp:LinkButton>
            <asp:LinkButton runat="server" Id="lbtnLock" CommandName="lock" Text="锁定"  CommandArgument='<%# Eval("userId") %>' Enabled='<%# Eval("status").ToString()=="1" %>'></asp:LinkButton>
            <asp:LinkButton runat="server" Id="lbtnActive" CommandName="active" Text="激活" CommandArgument='<%# Eval("userId") %>' Enabled='<%# Eval("status").ToString()=="2" %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
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
