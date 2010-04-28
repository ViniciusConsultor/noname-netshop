﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberChangeList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Member.MemberChangeList" %>

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
    登录帐号：<asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
    &nbsp;用户类型：
    <asp:DropDownList ID="ddlUserType" runat="server">
    <asp:ListItem Text="全部会员" Value=""></asp:ListItem>
    <asp:ListItem Text="个人会员" Value="1"></asp:ListItem>
    <asp:ListItem Text="企业会员" Value="2"></asp:ListItem>
    <asp:ListItem Text="家庭会员" Value="3"></asp:ListItem>
    <asp:ListItem Text="学校会员" Value="4"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;用户级别：
    <asp:DropDownList ID="ddlUserLevel" runat="server">
    <asp:ListItem Text="全部级别" Value=""></asp:ListItem>
    <asp:ListItem Text="登鼎会员" Value="0"></asp:ListItem>
    <asp:ListItem Text="铁鼎会员" Value="1"></asp:ListItem>
    <asp:ListItem Text="铜鼎会员" Value="2"></asp:ListItem>
    <asp:ListItem Text="银鼎会员" Value="3"></asp:ListItem>
    <asp:ListItem Text="金鼎会员" Value="4"></asp:ListItem>
    <asp:ListItem Text="宝鼎会员" Value="5"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;<asp:Button ID="doSearch" runat="server" Text="查找" onclick="doSearch_Click" />
    </div>
<asp:gridview runat="server" ID="gvList" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" AllowSorting="True" 
            onrowcommand="gvList_RowCommand" Width="96%" DataKeyNames="UserId,UserEmail"
            onrowdatabound="gvList_RowDataBound" >
    <RowStyle BackColor="White" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="UserId" HeaderText="用户ID" />
        <asp:BoundField DataField="UserName"  HeaderText="昵称"/>
        <asp:BoundField DataField="allscore"  HeaderText="总积分"/>
        <asp:BoundField DataField="curscore"  HeaderText="当前积分"/>
        <asp:BoundField DataField="allmoney"  HeaderText="总消费金额"/>
        <asp:TemplateField HeaderText="用户类型">
            <ItemTemplate>
                <asp:Label ID="lblUserType" runat="server"></asp:Label>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="用户级别">
            <ItemTemplate>
                <asp:Label ID="lblUserLevel" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="申请用户类型">
            <ItemTemplate>
                <asp:Label ID="lblNewUserType" runat="server"></asp:Label>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="申请用户级别">
            <ItemTemplate>
                <asp:Label ID="lblNewUserLevel" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>  
        
        <asp:TemplateField HeaderText="申请变更类型">
            <ItemTemplate>
                <asp:Label ID="lblChangeType" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
            <asp:LinkButton runat="server" Id="lbtnEdit" CommandName="show" Text="查看" CommandArgument='<%# Eval("userId") %>'></asp:LinkButton>
            <asp:LinkButton runat="server" Id="lbtnAgree" CommandName="agree" Text="通过" CommandArgument='<%# Eval("userId") %>'></asp:LinkButton>
            <asp:LinkButton runat="server" Id="lbtnReject" CommandName="reject" Text="驳回" CommandArgument='<%# Eval("userId") %>'></asp:LinkButton>
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
