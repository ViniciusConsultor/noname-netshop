<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTopic.aspx.cs" Inherits="NoName.NetShop.BackFlat.qa.ShowTopic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <thead>
                    <tr>
                        <th colspan="4">
                           用户话题
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td height="25" width="30%" align="right">
                            话题Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblTopicId" runat="server" ></asp:Label>
                        </td>
                        <td height="25" width="30%" align="right">
                            用户Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUserId" runat="server" Width="200px"></asp:Label>
                                <asp:Button ID="btnDelete" runat="server" Text="· 删除 ·" 
                                OnClick="btnDelete_Click" />                              
                                <asp:Button ID="btnToggle" runat="server" Text="·启用 ·" 
                                OnClick="btnToggle_Click" />                              
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblTTitle" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblTContent" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="rpReplys" 
                        onitemcommand="rpReplys_ItemCommand">
                    <ItemTemplate>
                    <tr>
                    <td colspan="3">
                    回复Id：<%# Eval("ReplyId") %> 回复时间：<%#Eval("ReplyTime")%> 回复人：<%#Eval("Title") %>
                    </td>
                    <td>
                    <asp:LinkButton runat="server" id="lbtnDelete" CommandName="del" CommandArgument='<%#Eval("replyId") %>'>删除</asp:LinkButton>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="4">
                    <%# Eval("Title") %>  
                    </td>
                    </tr>
                    <tr>
                    <td colspan="4">
                    <%# Eval("Content") %>  
                    </td>
                    </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </tbody>
           </table>
    </div>
    </form>
</body>
</html>
