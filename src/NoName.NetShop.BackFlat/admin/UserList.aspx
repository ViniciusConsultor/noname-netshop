<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户管理</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class=maintitle style="text-align:center">用户管理<br />
    </div>
    
    <div class=spacebar> </div>
    <div>
    姓名： <asp:TextBox ID= "txtKeyword" runat=server CssClass=middleinput></asp:TextBox> <asp:Button runat=server ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" Width="124px" />
    </div>
        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns=False
         CellPadding="3" CellSpacing=1 CssClass=i_table  BorderWidth=0 Width=98% AllowPaging="True" 
         OnPageIndexChanging="gvUserList_PageIndexChanging" PageSize="20"
         >
        <Columns>
        <asp:CheckBoxField DataField="IsApproved" HeaderText="启用"/>
        <asp:CheckBoxField DataField="IsLocked"  HeaderText="锁定"/>
        <asp:BoundField DataField="UserName" HeaderText="登陆帐号"/>
        <asp:BoundField DataField="TrueName" HeaderText="真实姓名" />
        <asp:BoundField DataField="TelePhone" HeaderText="电话" />
        <asp:BoundField DataField="Mobile" HeaderText="手机" />
        <asp:HyperLinkField ItemStyle-HorizontalAlign=center DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="UserInfo.aspx?username={0}" DataTextField="UserName" DataTextFormatString="修改信息" HeaderText="维护基本信息" />
       </Columns>
            <RowStyle ForeColor="#000066" BackColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
