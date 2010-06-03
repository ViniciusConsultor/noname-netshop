<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Group.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/Controls/ckEditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(function() {
            var editor = CKEDITOR.replace('<%= TextBox_Brief.ClientID %>', {
                height: '400px',
                width: '700px',
                ignoreEmptyParagraph: true,
                forcePasteAsPlainText: false,
                enterMode: CKEDITOR.ENTER_BR
            });

            $('#<%= Button_Add.ClientID %>').click(function() {
                $('table td span[type=inform]').html('');
                var result = true;
                var theObject = null;

                theObject = $('#<%= TextBox_ProductName.ClientID %>');
                if (theObject.val() == '') {
                    result = false;
                    inform(theObject, '请输入产品名称');
                }
                
                theObject = $('#<%= TextBox_MarketPrice.ClientID %>');
                if (theObject.val() == '' || !theObject.val().isCurrency()) {
                    result = false;
                    inform(theObject, '请输入正确的市场价');
                }
                
                theObject = $('#<%= TextBox_GroupPrice.ClientID %>');
                if (theObject.val() == '' || !theObject.val().isCurrency()) {
                    result = false;
                    inform(theObject, '请输入正确的团购价');
                }
                
                theObject = $('#<%= TextBox_PrePaidPrice.ClientID %>');
                if (theObject.val() == '' || !theObject.val().isCurrency()) {
                    result = false;
                    inform(theObject, '请输入正确的预付定金数额');
                }

                theObject = $('#<%= TextBox_SuccedLine.ClientID %>');
                if (theObject.val() == '' || !theObject.val().isInteger()) {
                    result = false;
                    inform(theObject, '请输入正确的成团人数');
                }
                
                theObject = $('#<%= TextBox_Brief.ClientID %>');
                if (editor.getData() == '') {
                    result = false;
                    inform(theObject, '请输入产品简介');
                }
                
                theObject = $('#<%= FileUpload_Image.ClientID %>');
                if (theObject.val() == '') {
                    result = false;
                    inform(theObject, '请选择产品图片');
                }

                return result;
            });

        });
        function inform(o, message) {
            o.parent().children('span[type]').html(message);
            o.focus();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>产品名称：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_ProductName" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>产品类型：<span class="red">*</span></td>
                <td>
                    <asp:DropDownList runat="server" ID="DropDown_ProductType" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>产品编码：</td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_ProductCode" />
                </td>
            </tr>
            <tr>
                <td>市场价：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_MarketPrice" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>团购价格：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_GroupPrice" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>订金：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_PrePaidPrice" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>成团人数：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_SuccedLine" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>是否推荐：<span class="red">*</span></td>
                <td>
                    <asp:CheckBox runat="server" ID="CheclBox_Recommend" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>详细情况：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Detail" /></td>
            </tr>
            <tr>
                <td>描述：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_Brief" TextMode="MultiLine" />
                    <span type="inform" class="red" style="display:block"></span>
                </td>
            </tr>
            <tr>
                <td>产品图片：<span class="red">*</span></td>
                <td>
                    <asp:FileUpload runat="server" ID="FileUpload_Image" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" OnClick="Button_Add_Click" Text="提交" />
    </div>
    </form>
</body>
</html>