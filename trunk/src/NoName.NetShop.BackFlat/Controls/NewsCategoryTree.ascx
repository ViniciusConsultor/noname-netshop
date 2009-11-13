<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategoryTree.ascx.cs" Inherits="NoName.NetShop.BackFlat.Controls.NewsCategoryTree" %>
        
<asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" SelectedNodeStyle-Font-Underline="True">
    <SelectedNodeStyle Font-Underline="True" Font-Bold="True" ForeColor="#990033"/>
    <NodeStyle Font-Underline="True" ForeColor="#003399" />
</asp:TreeView>
<input type="hidden" id="Input_Value" runat="server" />