<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.Add" Title="����ҳ" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">    
    <table>
	    <tr>
	        <td height="25" width="30%" align="right">�������ƣ�</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtCateName" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">״̬��</td>
	        <td height="25" width="*" align="left">
	            <asp:DropDownList runat="server" ID="drpStatus" ></asp:DropDownList>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">�۸����䣺</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtPriceRange" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">�Ƿ����أ�</td>
	        <td height="25" width="*" align="left">
		        <asp:CheckBox ID="chkIsHide" Text="IsHide" runat="server" Checked="False" />
	        </td>
	    </tr>
	    <tr>
	        <td height="25" width="30%" align="right">�������ࣺ</td>
	        <td height="25" width="*" align="left">
                <asp:ListBox ID="lbxCategory1" runat="server" AutoPostBack="true" onselectedindexchanged="lbxCategory1_SelectedIndexChanged"></asp:ListBox>
                <asp:ListBox ID="lbxCategory2" runat="server" Visible="false"></asp:ListBox>
                <asp:ListBox ID="lbxCategory3" runat="server" Visible="false"></asp:ListBox>
	        </td>
	    </tr>
	    <tr>
	        <td height="25" colspan="2">
		        <asp:Button ID="btnAdd" runat="server" Text="�ύ" OnClick="btnAdd_Click" ></asp:Button>
	        </td>
	    </tr>
</table>

</asp:Content>
