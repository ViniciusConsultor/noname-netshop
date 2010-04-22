<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreTypeSetting.aspx.cs" Inherits="NoName.NetShop.BackFlat.Order.ScoreTypeSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button runat="server" ID="btnSave" Text="保存" onclick="btnSave_Click" />
   <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
     DataKeyNames="actionType" 
            onrowdeleting="gvList_RowDeleting">
    <Columns>
      <asp:BoundField DataField="actionType" HeaderText="积分类型" />
        <asp:TemplateField HeaderText="分值">
            <ItemTemplate>
                <asp:TextBox ID="txtScore" runat="server" Text='<%#Eval("score") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="说明">
            <ItemTemplate>
                <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("remark") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:BoundField DataField="inserttime" DataFormatString="{0:yyyy-MM-dd HH-mm}"  HeaderText="插入时间" />
        <asp:BoundField DataField="updatetime" DataFormatString="{0:yyyy-MM-dd HH-mm}" HeaderText="更新时间" />
        <asp:ButtonField CommandName="delete" HeaderText="删除" Text="删除" />
    </Columns>
    <PagerTemplate>
    </PagerTemplate>
</asp:GridView>
<table>
<tr>
<td>类型：</td>
<td><asp:TextBox runat="server" ID="txtActionType"></asp:TextBox></td>
</tr>
<tr>
<td>积分：</td>
<td><asp:TextBox runat="server" ID="txtScore"></asp:TextBox></td>
</tr>
<tr>
<td>描述：</td>
<td><asp:TextBox runat="server" ID="txtRemark"></asp:TextBox></td>
</tr>
<tr><td colspan="2"></td></tr>
</table>
<asp:Button runat="server" ID="btnAddNew" Text="添加新规则" onclick="btnAddNew_Click" />

    </div>
    </form>
</body>
</html>
