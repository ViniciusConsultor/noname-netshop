<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyTopic.aspx.cs" Inherits="NoName.NetShop.BackFlat.vote.Modify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" media="screen" href="../css/datePicker.css" />
<script type="text/javascript" src="../js/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../js/date.js"></script>
<script type="text/javascript" src="../js/jquery.datePicker.js"></script>    
<script type="text/javascript" charset="utf-8">
    $(function() {
        var now = new Date();
        var enddate = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate();
        $('.date-pick').datePicker({ startDate: '2009-01-01', createButton: false, clickInput: true });
    });
</script>
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
                            <asp:Label ID="lblVoteId" runat="server" Width="200px"></asp:Label>
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
                            <asp:TextBox ID="txtTopic" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:TextBox ID="txtRemark" runat="server" Width="200px" 
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开始时间 ：
                        </td>
                        <td height="25" width="*" align="left">
  <asp:TextBox Width="71" runat="server" ID="txtStartDate" CssClass="date-pick"></asp:TextBox>
                        </td>
                        <td height="25" width="30%" align="right">
                            结束时间 ：
                        </td>
                        <td height="25" width="*" align="left">
  <asp:TextBox Width="71" runat="server" ID="txtEndDate" CssClass="date-pick"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            限制条件 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <asp:CheckBox ID="chkIsRegUser" Text="限制为会员" runat="server" Checked="False" />
                            <asp:CheckBox ID="chkIsMulti" Text="允许多选" runat="server" Checked="False" />
                            <asp:CheckBox ID="chkStatus" Text="启用" runat="server" Checked="False"  />
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td height="25" colspan="4">
                            <div align="center">
                                <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
            
           
        </div>
    </div>
    </form>
</body>
</html>
