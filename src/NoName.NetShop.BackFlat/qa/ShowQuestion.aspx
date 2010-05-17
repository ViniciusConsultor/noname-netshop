<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowQuestion.aspx.cs" Inherits="NoName.NetShop.BackFlat.qa.ShowQuestion" %>

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
                            买家提问
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td height="25" width="30%" align="right">
                            问题Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblQuestionId" runat="server" ></asp:Label>
                        </td>
                        <td height="25" width="30%" align="right">
                            用户Id ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Label ID="lblUserId" runat="server" Width="200px"></asp:Label>
                                <asp:Button ID="btnDelete" runat="server" Text="· 删除 ·" 
                                OnClick="btnDelete_Click"></asp:Button>
                        </td>
                    </tr>
                    <!--
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblQTitle" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    -->
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:Label ID="lblQContent" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="rpAnswers" 
                        onitemcommand="rpAnswers_ItemCommand">
                    <ItemTemplate>
                    <tr>
                    <td colspan="3">
                    <%# Eval("AnswerId") %> <%#Eval("Title") %>(<%#Eval("AnswerTime")%>)
                    </td>
                    <td>
                    <asp:LinkButton runat="server" id="lbtnEdit" CommandName="edit" CommandArgument='<%#Eval("answerId") %>'>编辑</asp:LinkButton>
                    <asp:LinkButton runat="server" id="lbtnDelete" CommandName="del" CommandArgument='<%#Eval("answerId") %>'>删除</asp:LinkButton>
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
             <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <thead>
                    <tr>
                        <th colspan="2">
                            回复</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtATitle" runat="server" Width="200px" ></asp:TextBox>
                            
                            &nbsp;ID：<asp:Label ID="lblAnswerId" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAContent" runat="server" Width="496px" ></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td height="25" colspan="2">
                            <div align="center">
                                <asp:Button ID="btnSave" runat="server" Text="· 回复 ·" OnClick="btnSave_Click"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
   </div>
    </form>
</body>
</html>
