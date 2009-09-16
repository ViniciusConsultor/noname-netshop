<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="NoName.NetShop.Web.OrderModel.Modify" Title="修改页" %>
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
		OrderId
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblOrderId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderStatus
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOrderStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayMethod
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPayMethod" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ShipMethod
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtShipMethod" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayStatus
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPayStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Paysum
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPaysum" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ShipFee
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtShipFee" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProductFee
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtProductFee" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DerateFee
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDerateFee" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddressId
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAddressId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverName
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecieverName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverEmail
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecieverEmail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverPhone
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecieverPhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Postalcode
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPostalcode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverCity
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecieverCity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecieverProvince
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecieverProvince" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddressDetial
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAddressDetial" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ChangeTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtChangeTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PayTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtPayTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateTime
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtCreateTime" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderType
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOrderType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
