<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowClassicalDetail.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ShowClassicalDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
<tr>
<td colspan="2" height="25" >基本信息</td>
</tr>
	<tr>
	<td height="25" width="30%" align="right">
		场景ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblSenceId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		分类ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblCateId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否显示
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsShow" Text="是否显示在场景中(如果不显示，则描述信息、示例图片、呈现位置)" runat="server" Checked="False" />
	</td></tr>

	<td height="25" width="30%" align="right">
		描述信息
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		位置信息
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPosition" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>	
	<td height="25" width="30%" align="right">
		示例图片
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Image ID="imgCate" runat="server" />
        <asp:FileUpload runat="server" ID="fulImage" />
	</td></tr>
	<tr>
<tr>
<td colspan="2" height="25" >筛选条件</td>
</tr>
	<tr>
	<td height="25" width="30%" align="right">
		价格区间（元）
	：</td>
	<td height="25" width="*" align="left">
		从<asp:TextBox id="txtMinPrice" runat="server" Width="30px"></asp:TextBox>
		到
		<asp:TextBox id="txtMaxPrice" runat="server" Width="30px"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td height="25" width="30%" align="right">
		相关品牌
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBoxList runat="server" ID="cblBrands" RepeatDirection="Horizontal"></asp:CheckBoxList>
	</td>
	</tr>
<asp:Repeater runat="server" ID="rpItems" onitemdatabound="rpItems_ItemDataBound">
<ItemTemplate>
	<tr>
	<td height="25" width="30%" align="right">
		<asp:Label ID="lblPropName" runat="server"></asp:Label>
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBoxList runat="server" ID="cblPara" RepeatDirection="Horizontal"></asp:CheckBoxList>
	</td>
	</tr>
</ItemTemplate>
</asp:Repeater>		
<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnUpdate" runat="server" Text="· 提交 ·" OnClick="btnUpdate_Click" ></asp:Button>
	</div></td></tr>
</table>
    </div>
    </form>
</body>
</html>
