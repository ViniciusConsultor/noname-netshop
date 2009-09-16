<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TagEditor_2.ascx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Controls.TagEditor_2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


产品ID：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<br/>
是否使用默认内容：<asp:CheckBox ID="CheckBox1" runat="server" />
<br/>
生成代码：
<FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server">
</FCKeditorV2:FCKeditor>