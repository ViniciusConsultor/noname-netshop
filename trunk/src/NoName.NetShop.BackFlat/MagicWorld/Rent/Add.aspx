<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Rent.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/main.css"/>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/controls/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(function() {
            CKEDITOR.replace('<%=TextBox_Brief.ClientID %>', {
                toolbar: 'Basic',
                width: '500px',
                height: '300px'
            });

            $('#<%= Button_Add.ClientID %>').click(function() {
                return validate();
            });
        });
        function validate() {
            $('table td span[type=inform]').html('');

            var result = true;

            if ($('#<%=TextBox_RentName.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_RentName.ClientID %>'), '请输入产品名称');
            }
            if ($('#<%=TextBox_Stock.ClientID %>').val() == '' || !$('#<%=TextBox_Stock.ClientID %>').val().isNumber()) {
                result = false;
                inform($('#<%=TextBox_Stock.ClientID %>'), '请输入正确的数量');
            }
            if ($('#<%=TextBox_Keywords.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_Keywords.ClientID %>'), '请输入关键词');
            }
            if ($('#<%=TextBox_CashPledge.ClientID %>').val() == '' || !$('#<%=TextBox_CashPledge.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_CashPledge.ClientID %>'), '请输入正确的押金');
            }
            if ($('#<%=TextBox_RentPrice.ClientID %>').val() == '' || !$('#<%=TextBox_RentPrice.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_RentPrice.ClientID %>'), '请输入正确的租金');
            }
            if ($('#<%=TextBox_MaxRentDays.ClientID %>').val() == '' || !$('#<%=TextBox_MaxRentDays.ClientID %>').val().isNumber()) {
                result = false;
                inform($('#<%=TextBox_MaxRentDays.ClientID %>'), '请输入正确的最长租赁时间');
            }
            if ($('#<%=FileUpload_MainImage.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=FileUpload_MainImage.ClientID %>'), '请选择产品图片');
            }
            return result;
        }
        function inform(o, message) {
            o.parent().children('span[type=inform]').html(message);
            o.focus();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>已选择分类：</td>
                <td>
                    <asp:Label runat="server" ID="Label_Category" />
                    <asp:HiddenField runat="server" ID="Hidden_CategoryPath" />
                    <a href="../Category/Select.aspx?app=Rent" >重新选择</a>
                </td>
            </tr>
            <tr>
                <td>商品名称<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_RentName" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>数量<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Stock" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>关键词<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Keywords" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>押金<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_CashPledge" />(元)<span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>租金<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_RentPrice" />(元/月)<span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>最长租赁时间<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_MaxRentDays" />(月)<span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>简介<span class="red">*</span>：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Brief" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td>图片<span class="red">*</span>：</td>
                <td><asp:FileUpload runat="server" ID="FileUpload_MainImage" /><span type="inform" class="red"></span></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" Text="提交" OnClick="Button_Add_Click" />
    </div>
    </form>
</body>
</html>
