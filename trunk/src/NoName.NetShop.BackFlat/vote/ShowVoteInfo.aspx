<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVoteInfo.aspx.cs" Inherits="NoName.NetShop.BackFlat.vote.ShowVoteInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <thead>
                    <tr>
                        <th colspan="4">
                            投票主题信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td height="25" width="30%" align="right">
                            投票Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblVoteId" runat="server"></asp:Label>
                        </td>
                        <td height="25" width="30%" align="right">
                            当前投票人数 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblVoteUserNum" runat="server" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblTopic" runat="server" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblRemark" runat="server" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开始时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label runat="server" ID="lblStartDate"></asp:Label>
                        </td>
                        <td height="25" width="30%" align="right">
                            结束时间 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label runat="server" ID="lblEndDate"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            限制条件 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:CheckBox ID="chkIsRegUser" Text="限制为会员" runat="server" Enabled="false" />
                            &nbsp;
                            <asp:CheckBox ID="chkIsMulti" Text="允许多选" runat="server" Enabled="false" />
                            &nbsp;
                            <asp:CheckBox ID="chkStatus" Text="启用" runat="server" Enabled="false" />
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td height="25" colspan="4">
                            <div align="center">
                                <asp:Button ID="btnSave" runat="server" Text="· 修改基本信息 ·" OnClick="btnAdd_Click"></asp:Button>
                                <asp:Button ID="btnAddGroup" runat="server" Text="· 添加新分组 ·" OnClick="btnAddGroup_Click"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <thead>
                    <tr>
                        <th colspan="3">
                            分组信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rpGroups" 
                        onitemdatabound="rpGroups_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td height="25" width="30%" align="right">
                                    分组Id ：
                                </td>
                                <td height="25" width="*" align="left">
                                    <%# Eval("ItemGroupId") %>
                                </td>
                                <td height="25" width="30%" align="right" colspan="2">
                                    <a href="ModifyGroup.aspx?groupId=<%#Eval("ItemGroupId") %>&voteId=<%#Eval("voteId") %>">修改</a>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" width="30%" align="right">
                                    标题 ：
                                </td>
                                <td height="25" width="*" align="left" colspan="3">
                                    <%# Eval("Subject") %>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" width="30%" align="right">
                                    内容 ：
                                </td>
                                <td height="25" width="*" align="left" colspan="3">
                                    <%# Eval("Content") %>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView runat="server" ID="gvItems" AutoGenerateColumns="false" Width="100%"
                                        Caption="投票选项">
                                        <Columns>
                                            <asp:BoundField DataField="ItemId" HeaderText="Id" />
                                            <asp:BoundField DataField="VoteCount" HeaderText="票数" />
                                            <asp:BoundField DataField="ItemContent" HeaderText="题目" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
