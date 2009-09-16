<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.Web.MessageModel.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UserId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MsgId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMsgId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MsgType
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMsgType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Subject
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSubject" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Content
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SenderId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSenderId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InsertTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtInsertTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReadTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtReadTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Status
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
