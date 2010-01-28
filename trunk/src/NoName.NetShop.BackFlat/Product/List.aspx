<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/ui.core.js" type="text/javascript"></script>
    <script src="/js/ui.datepicker.js" type="text/javascript"></script>
    <script src="/js/validate.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function() {
            $('#select-all').click(function() {
                var checked = $(this).attr('checked');
                $('#<%= GridView1.ClientID %>').find('input[type=checkbox]').each(function() {
                    $(this).attr('checked', checked);
                });
            });

            $('#<%=TextBox3.ClientID %>').datepicker();
            $('#<%=TextBox4.ClientID %>').datepicker();
        });

        function validate() {
            debugger;
            var result = false;
            var errorMessage = '';
            if ($('#<%= CheckBox2.ClientID %>').attr('checked')) {
                if ($('#<%=TextBox1.ClientID %>').val() != '' && $('#<%=TextBox1.ClientID %>').val().isNumber())
                    result = true;
                else
                    errorMessage = '请输入产品ID\n';
            }
            if ($('#<%= CheckBox4.ClientID %>').attr('checked')) {
                if ($('#<%=TextBox2.ClientID %>').val() != '')
                    result = true;
                else
                    errorMessage = '请输入产品名称\n';

            }
            if ($('#<%= CheckBox5.ClientID %>').attr('checked')) {
                if ($('#<%=TextBox3.ClientID %>').val() != '' || $('#<%=TextBox4.ClientID %>').val() != '')
                    result = true;
                else
                    errorMessage = '请至少输入起始或者结束日期\n';                
            }

            if (errorMessage != '') alert(errorMessage);
            if (!result) alert('请至少选择一个搜索条件');
            
            return result;
        }

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
                    <td colspan="2"><asp:Button runat="server" ID="ButtonSearch" OnClientClick="return validate();" OnClick="ButtonSearch_Click" Text="搜索" /></td>
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
            <asp:GridView runat="server" CssClass="GridView" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
    	                    <asp:CheckBox id="chkItem" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="productid" HeaderText="产品ID" />          
                    <asp:TemplateField HeaderText="产品名称">
                        <ItemTemplate>
                            <a href='<%# Eval("producturl") %>' target="_blank"><%# Eval("productname")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.Product.Model.ProductStatus),Convert.ToInt32(Eval("status"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="merchantprice" HeaderText="销售价格" />            
                    <asp:BoundField DataField="changetime" HeaderText="更新日期" />
                    <%--<asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkMultiImage" Text="添加多图" NavigateUrl='<%# "multiimage.aspx?productid="+Eval("ProductID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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
