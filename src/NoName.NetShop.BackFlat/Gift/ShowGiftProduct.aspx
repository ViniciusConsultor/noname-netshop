<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowGiftProduct.aspx.cs" Inherits="NoName.NetShop.BackFlat.Gift.ShowGiftProduct" %>

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
	<td height="25" width="30%" align="right">
		赠品Id
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Literal id="litProductId" runat="server"></asp:Literal>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		赠品名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtProductName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		库存
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtStock" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		关键词
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtKeywords" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品图片
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Image ID="imgProduct" runat="server" />
        <asp:FileUpload runat="server" ID="fulImage" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		简要描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBrief" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		添加时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Literal ID="litInsertTime" runat="server"></asp:Literal></td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		更新时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Literal ID="litChangeTime" runat="server"></asp:Literal></td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		当前状态
	：</td>
	<td height="25" width="*" align="left">
	    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
	    <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
	    <asp:ListItem Text="启用" Value="1"></asp:ListItem>
	    </asp:RadioButtonList>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		可兑换积分
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScore" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDecription" runat="server" Width="200px"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnSave" runat="server" Text="· 保存 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnDelete" runat="server" Text="· 删除 ·" 
            onclick="btnDelete_Click"></asp:Button>
		<input type="reset" value="· 取消 ·" />
		<input type="button" value="· 返回 ·" onclick="window.location='GiftProductList.aspx'" />
	</div></td></tr>
</table>

    </div>
    </form>
</body>

</html>
