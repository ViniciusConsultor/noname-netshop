﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/validate.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Controls/ckEditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(function() {
            CKEDITOR.replace('<%= TextBox_Brief.ClientID %>', {
                height: '400px',
                width: '700px'
            });
            CKEDITOR.replace('<%= TextBox_Spe.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                toolbar: [
                        ['Source', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        '/',
                        ['Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'Table', 'JustifyBlock', 'SpecialChar'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor', 'Maximize']
                    ]
            });
            CKEDITOR.replace('<%= TextBox_Packing.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                toolbar: [
                        ['Source', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        '/',
                        ['Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'Table', 'JustifyBlock', 'SpecialChar'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor', 'Maximize']
                    ]
            });
            CKEDITOR.replace('<%= TextBox_Service.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                toolbar: [
                        ['Source', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        '/',
                        ['Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'Table', 'JustifyBlock', 'SpecialChar'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor', 'Maximize']
                    ]
            }); 
        });
    function validate() {
        $('table td span[type=inform]').html('');
    
        var result = true;

        if ($('#<%=txtProductName.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=txtProductName.ClientID %>'),'请输入产品名称');
        }
        if ($('#<%=txtTradePrice.ClientID %>').val() == '' || !$('#<% =txtTradePrice.ClientID %>').val().isCurrency()) {
            result = false;
            inform($('#<%=txtTradePrice.ClientID %>'),'请输入正确的价格');
        }
        if ($('#<%=txtMerchantPrice.ClientID %>').val() == '' || !$('#<% =txtMerchantPrice.ClientID %>').val().isCurrency()) {
            result = false;
            inform($('#<%=txtMerchantPrice.ClientID %>'), '请输入正确的价格');
        }
        if ($('#<%=txtReducePrice.ClientID %>').val() == '' || !$('#<% =txtReducePrice.ClientID %>').val().isCurrency()) {
            result = false;
            inform($('#<%=txtReducePrice.ClientID %>'), '请输入正确的价格');
        }
        if ($('#<%=txtStock.ClientID %>').val() == '' || !$('#<% =txtStock.ClientID %>').val().isInteger()) {
            result = false;
            inform($('#<%=txtStock.ClientID %>'), '请输入正确的数字');
        }
        if ($('#<%=txtKeywords.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=txtKeywords.ClientID %>'), '请输入关键字');
        }        
        
        return result;
    }
    function inform(o, message) {
        o.parent().children('span[type=inform]').html(message);
        o.focus();
    }
    </script>
    <style type="text/css">
        table.parameter{border:0;}
        table.parameter td,th{border:0;}
        table.parameter table{width:550px;border:0;}
        table.parameter table tr{width:100px;border:0;display:block;float:left;}
        table.parameter table td{width:100px;border:0;display:block;float:left;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3>商品修改</h3>
        <table>
            <tr>
                <td>已选择分类：</td>
                <td>
                    <asp:Label runat="server" ID="Label_CategoryNamePath" />
                    <asp:HiddenField runat="server" ID="txtCategoryID" />
                    <a runat="server" id="ReselectCategory" href="CategorySelect.aspx">重新选择</a>
                </td>
            </tr>
            <tr>
                <td>产品名称<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtProductName" runat="server" Width="400"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>品牌<span class="red">*</span>：</td>
                <td><asp:DropDownList runat="server" ID="DropDown_Brand" /></td>
            </tr>
            <tr>
                <td>产品编号：</td>
                <td><asp:TextBox id="txtProductCode" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>市场价<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtTradePrice" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>销售价<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtMerchantPrice" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>直降：<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtReducePrice" runat="server" Width="200" Text="0"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>库存<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtStock" runat="server" Width="200"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>状态<span class="red">*</span>：</td>
                <td><asp:DropDownList runat="server" ID="drpStatus"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>关键字<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtKeywords" runat="server" Width="400"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>简介<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Brief" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td>规格参数：</td>
                <td><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Spe" /></td>
            </tr>
            <tr>
                <td>包装列表：</td>
                <td><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Packing" /></td>
            </tr>
            <tr>
                <td>售后服务：</td>
                <td><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Service" /></td>
            </tr>
            <tr>
                <td>商品图片<span class="red">*</span>：</td>
                <td>
                    <asp:Image runat="server" ID="imgProduct" />
                    <asp:FileUpload runat="server" ID="fulImage" />
                </td>
            </tr>
            <tr>
                <td>属性</td>
                <td>
                    <asp:GridView CssClass="parameter" runat="server" ID="GridView_Parameter" AutoGenerateColumns="false">
                        <Columns>                        
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Hidden_ParameterID" runat="server" Value='<%# Eval("paraid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <b><%# Eval("paraname") %></b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server" ID="RadioList_ParameterValue" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div id="always-float"><asp:Button ID="btnEdit" runat="server" Text="提交" OnClick="btnEdit_Click" ></asp:Button></div>
    </form>
</body>
</html>
