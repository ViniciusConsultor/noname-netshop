<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCommendDetail.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ShowCommendDetail" %>

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
	<td height="25" colspan="2">
		套装基本信息
		</td>
    </tr>
		<tr>
	<td height="25" width="30%" align="right">
		场景Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblScenceId" runat="server"></asp:label>
	</td></tr>
		<tr>
	<td height="25" width="30%" align="right">
		套装Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblSuiteId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		套装名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSuiteName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品图片
	：</td>
	<td height="25" width="*" align="left">
	    <asp:Image ID="imgSuite" runat="server" />
        <asp:FileUpload runat="server" ID="fulImage" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		套装总价
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPrice" runat="server" Width="200px"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		套装描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		套装积分
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScore" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2">
		套装商品信息
		</td>
    </tr>
	 <tr>
                    <td colspan="2">
                    <asp:GridView runat="server" ID="gvItems" DataKeyNames="ProductId" 
                            AutoGenerateColumns="false" Width="100%" 
                            onrowdeleting="gvItems_RowDeleting">
                    <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="商品Id" />
                    <asp:BoundField DataField="ProductName" HeaderText="商品名称" />
                    <asp:CommandField DeleteText="删除" HeaderText="删除" ShowDeleteButton="true"  />
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    
	<tr>
	<td height="25" colspan="2"><div align="center">
        <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
		<asp:Button ID="btnAddProduct" runat="server" Text="· 添加商品 ·" 
            OnClick="btnAddProduct_Click" ></asp:Button>
	&nbsp;<asp:Button ID="btnSave" runat="server" Text="· 保存 ·" 
            OnClick="btnSave_Click" ></asp:Button>
	</div></td></tr>
</table>
    </div>
    </form>
</body>
</html>
