<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Codebehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.Add" Title="����ҳ" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">    
    <table cellSpacing="0" cellPadding="0" border="0">
	    <tr>
	        <td>Ʒ�����ƣ�</td>
	        <td>
		        <asp:TextBox id="txtBrandName" runat="server" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td>���ࣺ</td>
	        <td>
		        <asp:DropDownList runat="server" ID="drpCategory"></asp:DropDownList>
	        </td>
	    </tr>
	    <tr>
	        <td>Ʒ��LOGO��</td>
	        <td>
                <asp:FileUpload ID="fulBrandLogo" runat="server" />
	        </td>
	    </tr>
	    <tr>
	        <td>Ʒ��������</td>
	        <td>
		        <asp:TextBox id="txtBrief" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td colspan="2">
	            <div align="center">
		            <asp:Button ID="btnAdd" runat="server" Text="�ύ" OnClick="btnAdd_Click" ></asp:Button>
	            </div>
	        </td>
	    </tr>
    </table>
</asp:Content>
