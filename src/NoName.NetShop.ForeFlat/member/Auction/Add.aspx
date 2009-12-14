<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MemberCenter.master" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Auction.Add" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
    <script type="text/javascript" src="/js/ui.core.js"></script>
    <script type="text/javascript" src="/js/ui.datepicker.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/controls/ckeditor/ckeditor.js"></script>

    <script type="text/javascript">

        $(function() {
            //$('#<%=TextBox_StartTime.ClientID %>').datepicker({dateFormat:'yyyy-MM-dd hh:mm:ss'});
            //$('#<%=TextBox_EndTime.ClientID %>').datepicker({ dateFormat: 'yyyy-MM-dd hh:mm:ss' });
            CKEDITOR.replace('<%=TextBox_Brief.ClientID %>', {
                toolbar: 'Basic',
                width:'400px',
                height:'200px'
            });

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
            if ($('#<%=TextBox_AddPrice.ClientID %>').val() == '') {
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
                inform($('#<%=FileUpload_ProductImage.ClientID %>'), '请选择产品图片');
            }
            
            return result;
        }
        function inform(o, message) {
            o.parent().children('span[type=inform]').html(message);
            o.focus();
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <div>
        <table>
            <tr>
            <td>
                <asp:Label runat="server" ID="Label_Category" />
                <asp:HiddenField runat="server" ID="Hidden_CategoryID" />
                <a href="../CateSelect.aspx" >重新选择</a>
            </td>
            </tr>
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
                <td><asp:TextBox runat="server" ID="TextBox_Brief" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td>产品图片<span class="red">*</span>：</td>
                <td><asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" OnClientClick="return validate()" OnClick="Button_Add_Click" Text="提交" />
    </div>
</asp:Content>