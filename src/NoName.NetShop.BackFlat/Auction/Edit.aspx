<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.Auction.Edit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
            //$('#<%=TextBox_StartTime.ClientID %>').datepicker({dateFormat:'yyyy-MM-dd hh:mm:ss'});
        //$('#<%=TextBox_EndTime.ClientID %>').datepicker({ dateFormat: 'yyyy-MM-dd hh:mm:ss' });
            
        });

        function validate() {
            $('table td span[type=inform]').html('');
            
            var result = true;

            if ($('#<%=TextBox_AuctionProductName.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_AuctionProductName.ClientID %>'), '请输入产品名称');
            }
            if ($('#<%=TextBox_StartPrice.ClientID %>').val() == '' || !$('#<% =TextBox_StartPrice.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_StartPrice.ClientID %>'), '请输入正确的价格');
            }
            if ($('#<%=TextBox_AddPrice.ClientID %>').val() == '' || !$('#<% =TextBox_AddPrice.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_AddPrice.ClientID %>'), '请输入正确的价格');
            }
            if ($('#<%=TextBox_StartTime.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_StartTime.ClientID %>'), '请输入拍卖开始时间');
            }
            if ($('#<%=TextBox_EndTime.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_EndTime.ClientID %>'), '请输入拍卖结束时间');
            }
            if ($('#<%=FileUpload_ProductImage.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_AuctionProductName.ClientID %>'), '请选择产品图片');
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
                    <td>拍品名称<span class="red">*</span>：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_AuctionProductName" Width="400" /><span type="inform" class="red"></span></td>
                </tr>
                <tr>
                    <td>起拍价<span class="red">*</span>：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_StartPrice" /><span type="inform" class="red"></span></td>
                </tr>
                <tr>
                    <td>每次加价<span class="red">*</span>：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_AddPrice" /><span type="inform" class="red"></span></td>
                </tr>
                <tr>
                    <td>开始时间<span class="red">*</span>：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_StartTime" />(格式：yyyy-MM-dd hh:mm:ss)<span type="inform" class="red"></span></td>
                </tr>
                <tr>
                    <td>结束时间<span class="red">*</span>：</td>
                    <td><asp:TextBox runat="server" ID="TextBox_EndTime" />(格式：yyyy-MM-dd hh:mm:ss)<span type="inform" class="red"></span></td>
                </tr>
                <tr>
                    <td>简介：</td>
                    <td><FCKeditorV2:FCKeditor ID="TextEditor_Brief" runat="server" width="500" height="400" /></td>
                </tr>
                <tr>
                    <td>产品图片<span class="red">*</span>：</td>
                    <td>
                        <asp:Image runat="server" ID="Image_MainImage" />
                        <asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="Button_Edit" OnClientClick="return validate()" OnClick="Button_Edit_Click" Text="提交" />
        </div>
    </form>
</body>
</html>
