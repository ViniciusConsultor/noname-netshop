<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.MessageList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/main.css"/>
    <link rel="stylesheet" type="text/css" href="/css/jquery-ui.css"/>    
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/ui.core.js" type="text/javascript"></script>
    <script src="/js/ui.datepicker.js" type="text/javascript"></script>
    <script src="/js/validate.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function() {
            $('#<%=TextBox_StartDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });
            $('#<%=TextBox_EndDate.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });

            $('#<%= Button_Search.ClientID %>').click(function() {
                if ($('#<%= Check_Sender.ClientID %>').attr('checked')) {
                    if ($('#<%= TextBox_Sender.ClientID %>').val() == '') {
                        alert('请输入发信人ID');
                        return false;
                    }
                }

                if ($('#<%= Check_Date.ClientID %>').attr('checked')) {
                    if ($('#<%= TextBox_StartDate.ClientID %>').val() == '' && $('#<%= TextBox_EndDate.ClientID %>').val() == '') {
                        alert('请至少输入开始和结束日期中的一个');
                        return false;
                    }
                }
                return true;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:CheckBox runat="server" ID="Check_Sender"/>发信人：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_Sender" /></td>
                    <td><asp:CheckBox runat="server" ID="Check_Type"/>类型：</td>
                    <td>
                        <asp:DropDownList runat="server" ID="DropDown_Type">
                            <asp:ListItem Text="公告" Value="1" />
                            <asp:ListItem Text="组消息" Value="2" />
                            <asp:ListItem Text="用户消息" Value="3" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:CheckBox runat="server" ID="Check_Date"/>发信日期从：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_StartDate" /></td>
                    <td>至：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_EndDate" /></td>
                </tr>
            </table>
            <asp:Button runat="server" ID="Button_Search" Text="查询" OnClick="Button_Search_Click" />
        </div>
        <div>
            <asp:gridview runat="server" ID="gvList" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowSorting="True" DataKeyNames="msgId" Width="96%"  onrowdeleting="gvList_RowDeleting" >
                <RowStyle BackColor="White" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="Subject" HeaderText="标题" />
                    <asp:BoundField DataField="InsertTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"  HeaderText="收件时间"/>
                    <asp:BoundField DataField="SenderId"  HeaderText="发件人"/>
                    <asp:BoundField DataField="TMsgType" HeaderText="消息类型" />
                    <asp:BoundField DataField="TUserType" HeaderText="用户类型" />
                    <asp:HyperLinkField Text="查看"   DataNavigateUrlFormatString="ShowMessage.aspx?msgId={0}" HeaderText="查看" DataNavigateUrlFields="msgId" />
                    <asp:CommandField DeleteText="删除" ShowDeleteButton="true"  HeaderText="删除" />
                </Columns>
                <EmptyDataTemplate>没有找到相关记录</EmptyDataTemplate>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            </asp:gridview>
            <cc1:AspNetPager ID="pageNav" runat="server" onpagechanged="pageNav_PageChanged" ></cc1:AspNetPager>
        </div>
    </form>
</body>
</html>
