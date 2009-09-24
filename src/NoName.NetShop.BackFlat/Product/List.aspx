<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<%@ Register src="../Controls/CategorySelect.ascx" tagname="CategorySelect" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        var categoryInfo = [{ "name": "category1", "title": "请选择", "required": "true" },
                            { "name": "category2", "title": "请选择", "required": "true" },
                            { "name": "category3", "title": "请选择", "required": "false"}];
                            
        function SelectAll(tempControl) {
            var theBox = tempControl;
            xState = theBox.checked;

            elem = document.getElementById('<%= GridView1.ClientID %>').elements;
            for (i = 0; i < elem.length; i++)
                if (elem[i].type == "checkbox" && elem[i].id != theBox.id)
                if (elem[i].checked != xState) elem[i].click();
            }

            $(function() {
                $('#select-all').change(function() {
                    var checked = $(this).attr('checked');
                    $('#<%= GridView1.ClientID %>').find('input[type=checkbox]').each(function() {
                        $(this).attr('checked', checked);
                    });
                });
            });

        function confirmDelete() {
            return confirm('确认删除？');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="search-panel">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="按商品分类" />
                        <uc1:CategorySelect ID="CategorySelect1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="按商品ID" />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="按商品名称" />
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="按状态" />
                        <asp:DropDownList ID="drpStatus" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="按日期" />
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button runat="server" ID="ButtonSearch" OnClick="ButtonSearch_Click" Text="搜索" /></td>
                </tr>
            </table>
            <hr />
            <div>
    	        <input type="checkbox" class="check" id="select-all" />
    	        <span class="txt">全选</span>
    	        <span class="txt"><asp:LinkButton runat="server" Text="删除" ID="Button_DeleteAll" OnClientClick="confirmDelete();" onclick="Button_DeleteAll_Click"></asp:LinkButton></span>
    	    </div>
        </div>
        <div id="data-list">
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
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
                    <asp:BoundField DataField="merchantprice" HeaderText="销售价格" />            
                    <asp:BoundField DataField="changetime" HeaderText="更新日期" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkEdit" Text="修改" NavigateUrl='<%# "Edit.aspx?productid="+Eval("ProductID") %>' />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CommandArgument='<%# Eval("ProductID") %>' CommandName="d">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            
            
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>
