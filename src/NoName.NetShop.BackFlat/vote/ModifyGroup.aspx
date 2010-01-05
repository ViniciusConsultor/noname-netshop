<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyGroup.aspx.cs" Inherits="NoName.NetShop.BackFlat.vote.ModifyGroup" %>

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
                            分组信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td height="25" width="30%" align="right">
                            组Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblGroupId" runat="server" ></asp:Label>
                        </td>
                        <td height="25" width="30%" align="right">
                            所属投票Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblVoteId" runat="server" Width="200px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:TextBox ID="txtSubject" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:TextBox ID="txtContent" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="4">
                    <asp:GridView runat="server" ID="gvItems" DataKeyNames="ItemId" 
                            AutoGenerateColumns="false" Width="100%" Caption="投票选项" 
                            onrowdeleting="gvItems_RowDeleting">
                    <Columns>
                    <asp:BoundField DataField="ItemId" HeaderText="Id" />
                    <asp:BoundField DataField="VoteCount" HeaderText="票数" />
                    <asp:TemplateField HeaderText="题目">
                    <ItemTemplate>
                    <asp:TextBox ID="txtContent" runat="server" Text='<%#Eval("ItemContent") %>'></asp:TextBox>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField DeleteText="删除" HeaderText="删除" ShowDeleteButton="true"  />
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td height="25" colspan="4">
                            <div align="center">
                                <asp:Button ID="btnAddNew" runat="server" Text="· 添加新选项 ·" OnClick="btnAdd_Click"></asp:Button>
                                <asp:Button ID="btnSave" runat="server" Text="· 保存 ·" OnClick="btnSave_Click"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
     </div>
    </form>
</body>
</html>
