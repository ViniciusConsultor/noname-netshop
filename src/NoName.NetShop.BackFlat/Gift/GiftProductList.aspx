<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftProductList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Gift.GiftProductList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .pagerclass
        {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="data-list">
        <div>
        商品ID：<asp:TextBox runat="server" ID="txtProductId"></asp:TextBox>
        
        商品名称：<asp:TextBox runat="server" ID="txtProductName"></asp:TextBox>
        <asp:Button runat="server" Text="· 查询 ·" ID="btnSearch"
         onclick="btnSearch_Click" />
        <input type="button" value="· 添加 ·" onclick="window.location='ShowGiftProduct.aspx'" />
        </div>
            <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
    	                    <asp:CheckBox id="chkItem" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="productid" HeaderText="产品ID" />            
                    <asp:BoundField DataField="productname" HeaderText="产品名称" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.Product.Model.ProductStatus),Convert.ToInt32(Eval("status"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="stock" HeaderText="库存" />            
                    <asp:BoundField DataField="score" HeaderText="积分" />            
                    <asp:BoundField DataField="changetime" HeaderText="更新日期" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkEdit" Text="修改" NavigateUrl='<%# "ShowGiftProduct.aspx?productid="+Eval("ProductID") %>' />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CommandArgument='<%# Eval("ProductID") %>' CommandName="del">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            
            
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager CssClass="pagerclass" ID="pageNav" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString='' onpagechanged="pageNav_PageChanged">
            </cc1:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
