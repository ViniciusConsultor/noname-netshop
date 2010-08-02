<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMessageList.aspx.cs" Inherits="NoName.NetShop.BackFlat.message.UserMessageList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/css.css" type="text/css" rel="stylesheet" />
    <link href="/css/style.css" type="text/css" rel="stylesheet" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/css/main.css"/>
    <link rel="stylesheet" type="text/css" href="/css/jquery-ui.css"/>    

    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jquery.timers.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="/js/date.js"></script>
    
    
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
<div id="dialog" title="站内信" style="display:none">
	<p>
	</p>
</div>
    <script language="javascript" type="text/javascript">
        function switchbar() {
            if (switchPoint.innerText == 3) {
                switchPoint.innerText = 4
                document.all("frm").style.display = "none"
            } else {
                switchPoint.innerText = 3
                document.all("frm").style.display = ""
            }
        }

        $(document).everyTime(5000, 'controlled', function() {
            $.getJSON("/commapi/ImMessage.ashx", { "action": "getmsglist", "rand": Math.floor(Math.random() * 1000) }, function(json) {
                if (json != null) {
                    $("#msgs").empty();
                    $(json).each(function(index, message) {
                        // $("#msgs").append("<a href='/message/ShowMessage.aspx?msgid=" + message.msgid + "' target='mainFrame'>" + message.subject + "</a>&nbsp;");
                        $("#msgs").append("<a onclick='return showMessage(" + message.msgid + ")'>" + message.subject + "</a>&nbsp;");
                    });
                }
            });
        });

        $.ui.dialog.defaults.bgiframe = true;
        function showMessage(msgId) {
            $.ajax({
                type: "POST",
                url: "/commapi/ImMessage.ashx",
                data: "action=getmessage&msgId=" + msgId,
                dataType: "json",
                success: function(data) {
                    if (data) {
                        var inserttime = eval('new' + data.InsertTime.replace(/\//g, ' '));
                        datastr = inserttime.pattern('yyyy-MM-dd HH:mm');
                        var msg = "<div>" + data.Subject + "（发送时间：" + datastr + "）</div>";
                        msg += "<div>" + data.Content + "</div>";
                        $("#dialog").find("p").html(msg);
                        $("#dialog").dialog({autoOpen: false}).dialog("open");
                    }
                }
            });
            return true;
        }         
    </script>

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
                                   
<asp:gridview runat="server" ID="gvList" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" AllowSorting="True" DataKeyNames="msgId"
              Width="96%"   onrowdeleting="gvList_RowDeleting" >
    <RowStyle BackColor="White" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="Subject" HeaderText="标题" />
        <asp:BoundField DataField="InsertTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"  HeaderText="收件时间"/>
        <asp:BoundField DataField="SenderId"  HeaderText="发件人"/>
        <asp:BoundField DataField="TMsgType" HeaderText="消息类型" />
        <asp:BoundField DataField="TUserType" HeaderText="用户类型" />
        <asp:TemplateField HeaderText="操作">
        <ItemTemplate>
        <a onclick="showMessage(<%# Eval("msgId") %>);return false;">查看</a>
        <asp:LinkButton runat="server" CommandName="delete" Enabled='<%# Eval("msgType").ToString()=="0" %>' CommandArgument='<%#Eval("msgId") %>' Text="删除"></asp:LinkButton>
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
