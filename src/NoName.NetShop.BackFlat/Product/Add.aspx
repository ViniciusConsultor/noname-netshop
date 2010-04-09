<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.Add" %>



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
            $('#product-multi-image-upload-add').click(function(){
                var count = $('#product-multi-image-upload-zone input[name^="multiImage"]').length;
                $('#product-multi-image-upload-zone').append($('<div><input type="file" id="multiImageUpload'+(count+1)+'" name="multiImageUpload'+(count+1)+'" /><a style="cursor:pointer" onclick="$(this).parent().remove()">删除</a></div>'));
            });
        
            /*            
                toolbar: [
                        ['Source', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        '/',
                        ['Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'Table', 'JustifyBlock', 'SpecialChar'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor', 'Maximize']
                    ],
            */
            CKEDITOR.replace('<%= TextBox_Description.ClientID %>', {
                height: '400px',
                width: '700px',
                ignoreEmptyParagraph :true,
                forcePasteAsPlainText :false,
                enterMode : CKEDITOR.ENTER_BR
            });
            CKEDITOR.replace('<%= TextBox_Specification.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false
            });
            CKEDITOR.replace('<%= TextBox_Packing.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                ignoreEmptyParagraph :true,
                forcePasteAsPlainText :false
            });
            CKEDITOR.replace('<%= TextBox_Service.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                ignoreEmptyParagraph :true,
                forcePasteAsPlainText :false
            });
            CKEDITOR.replace('<%= TextBox_OfferSet.ClientID %>', {
                height: '200px',
                width: '700px',
                toolbarStartupExpanded: false,
                ignoreEmptyParagraph :true,
                forcePasteAsPlainText :false
            });

            $('#<%= DropDown_Specification.ClientID %>').change(function() {
                CKEDITOR.instances.<%= TextBox_Specification.ClientID %>.setData($(this).val()); 
            });
            $('#<%= DropDown_Packing.ClientID %>').change(function() {                
                CKEDITOR.instances.<%= TextBox_Packing.ClientID %>.setData($(this).val()); 
            });
            $('#<%= DropDown_Service.ClientID %>').change(function() {
                CKEDITOR.instances.<%= TextBox_Service.ClientID %>.setData($(this).val()); 
            });
            $('#<%= DropDown_OfferSet.ClientID %>').change(function() {
                CKEDITOR.instances.<%= TextBox_OfferSet.ClientID %>.setData($(this).val()); 
            });


            $('#<%= btnAddGoOn.ClientID %>').click(validate);
            $('#<%= btnAddGoList.ClientID %>').click(validate);
            $('#<%= btnAdd.ClientID %>').click(validate);

            //changePos();
            //window.onscroll = function() { changePos(); };
            //window.onresize = function() { changePos(); };
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
        if ($('#<%=txtScore.ClientID %>').val() == '' || !$('#<% =txtScore.ClientID %>').val().isInteger()) {
            result = false;
            inform($('#<%=txtScore.ClientID %>'), '请输入正确的积分数字');
        }        
        if ($('#<%=txtKeywords.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=txtKeywords.ClientID %>'), '请输入关键字');
        }
        if ($('#<%= txtWeight.ClientID %>').val() == '' || !$('#<% =txtWeight.ClientID %>').val().isCurrency()) {
            result = false;
            inform($('#<%=txtWeight.ClientID %>'), '请输入正确的重量');            
        }
        if($('#<%= fulImage.ClientID %>').val() == ''){
            result = false;
            inform($('#<%=fulImage.ClientID %>'), '请选择商品图片');            
        }
        
        return result;
    }
    function changePos() {
        $('#always-float').css({
            'position': 'absolute',
            'left': ($('body').width()-600) + 'px',
            'top': (getScrollTop() + window.screen.height - 200)+ 'px'
        });
    }
    function inform(o, message) {
        o.parent().children('span[type=inform]').html(message);
        o.focus();
    }
    function getScrollTop() {
        var scrollTop = 0;
        if (document.documentElement && document.documentElement.scrollTop) {
            scrollTop = document.documentElement.scrollTop;
        }
        else if (document.body) {
            scrollTop = document.body.scrollTop;
        }
        return scrollTop;
    }
    </script>
    <style type="text/css">
        table.parameter{border:0;}
        table.parameter td,th{border:0;}
        table.parameter table{width:550px;border:0;}
        table.parameter table tr{width:100px;border:0;display:block;float:left;}
        table.parameter table td{width:100px;border:0;display:block;float:left;}
        #always-float{position:absolute;float:right;text-align:right;background:white;border:1px solid #eee;}
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <h3>商品添加</h3>
        <table>
            <tr>
                <td>已选择分类：</td>
                <td>
                    <asp:Label runat="server" ID="Label_CategoryNamePath" />
                    <asp:HiddenField runat="server" ID="txtCategoryID" />
                    <a href="CategorySelect.aspx">重新选择</a>
                </td>
            </tr>
            <tr>
                <td>产品名称<span class="red">*</span>：</td>
                <td>
                    <asp:TextBox id="txtProductName" runat="server" Width="400"></asp:TextBox>
                    <asp:Button runat="server" ID="Button_Exists" Text="存在检测" OnClick="Button_Exists_Click" />
                    <span type="inform" class="red"></span>
                </td>
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
                <td>积分：<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtScore" runat="server" Width="200" Text="0"></asp:TextBox><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>库存：</td>
                <td>
                    北京：
                    <asp:RadioButtonList ID="CheckBoxList_BJ" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="有货" Value="1" Selected="True" />
                        <asp:ListItem Text="无货" Value="0" />
                    </asp:RadioButtonList>
                    广州：
                    <asp:RadioButtonList ID="CheckBoxList_GZ" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="有货" Value="1" Selected="True" />
                        <asp:ListItem Text="无货" Value="0" />
                    </asp:RadioButtonList>
                    呼和浩特：
                    <asp:RadioButtonList ID="CheckBoxList_HH" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="有货" Value="1" Selected="True" />
                        <asp:ListItem Text="无货" Value="0" />
                    </asp:RadioButtonList>
                    上海：
                    <asp:RadioButtonList ID="CheckBoxList_SH" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="有货" Value="1" Selected="True" />
                        <asp:ListItem Text="无货" Value="0" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>重量<span class="red">*</span>：</td>
                <td><asp:TextBox id="txtWeight" runat="server" Width="100"></asp:TextBox>g<span type="inform" class="red"></span></td>
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
                <td>关联商品：</td>
                <td><asp:TextBox id="txtRelateProduct" runat="server" Width="400"></asp:TextBox>(以英文逗号隔开)</td>
            </tr>
            <tr>
                <td>评测资讯：</td>
                <td><asp:TextBox id="txtNewsID" runat="server" Width="400"></asp:TextBox></td>
            </tr>
            <tr>
                <td>简介<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Description" /></td>
            </tr>
            <tr>
                <td>规格参数：</td>
                <td>
                    选择规格参数模板：<asp:DropDownList runat="server" ID="DropDown_Specification" /><br/>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Specification" />
                </td>
            </tr>
            <tr>
                <td>包装清单：</td>
                <td>
                    选择包装清单模板：<asp:DropDownList runat="server" ID="DropDown_Packing" /><br/>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Packing" />
                </td>
            </tr>
            <tr>
                <td>优惠套装：</td>
                <td>
                    选择优惠套装模板：<asp:DropDownList runat="server" ID="DropDown_OfferSet" /><br/>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_OfferSet" />
                </td>
            </tr>
            <tr>
                <td>售后服务：</td>
                <td>
                    选择售后服务模板：<asp:DropDownList runat="server" ID="DropDown_Service" /><br/>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox_Service" />
                </td>
            </tr>
            <tr>
                <td>商品图片：<span class="red">*</span>：</td>
                <td><asp:FileUpload runat="server" ID="fulImage" EnableViewState="true" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>检索属性：</td>
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
                <td>规格参数：</td>
                <td>
                    <asp:GridView CssClass="parameter" runat="server" ID="GridView_Specification" AutoGenerateColumns="false">
                        <Columns>                        
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Hidden_SpecificationID" runat="server" Value='<%# Eval("paraid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <b><%# Eval("paraname") %></b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButtonList RepeatDirection="Horizontal" runat="server" ID="RadioList_SpecificationValue" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>商品多图：</td>
                <td>                
                    <div id="product-multi-image-upload-zone">                        
                        <input type="button" value=" 添加多图 " id="product-multi-image-upload-add" />
                        <div><input type="file" id="multiImageUpload1" name="multiImageUpload1" /><a style="cursor:pointer" onclick="$(this).parent().remove()">删除</a></div>                        
                    </div> 
                </td>
            </tr>
        </table>
        <div id="always-float">
            <asp:Button ID="btnAddGoOn" runat="server" Text="提交并继续添加同类产品" OnClick="btnAddGoOn_Click" ></asp:Button>
            <asp:Button ID="btnAdd" runat="server" Text="保存当前" OnClick="btnAdd_Click" ></asp:Button>
            <asp:Button ID="btnAddGoList" runat="server" Text="提交并返回产品列表" OnClick="btnAddGoList_Click" ></asp:Button>
        </div>
    </form>
</body>
</html>