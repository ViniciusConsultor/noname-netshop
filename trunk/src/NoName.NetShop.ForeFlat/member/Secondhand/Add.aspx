<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Secondhand.Add" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
    <script type="text/javascript" src="../../js/validate.js"></script>
    <script type="text/javascript">
        function validate() {
            $('table td span[type=inform]').html('');

            var result = true;

            if ($('#<%=TextBox_ProductName.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_ProductName.ClientID %>'), '请输入产品名称');
            }
            if ($('#<%=TextBox_Price.ClientID %>').val() == '' || !$('#<% =TextBox_Price.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_Price.ClientID %>'), '请输入正确的价格');
            }
            if ($('#<%=TextBox_Count.ClientID %>').val() == '' || !$('#<% =TextBox_Count.ClientID %>').val().isNumber()) {
                result = false;
                inform($('#<%=TextBox_Count.ClientID %>'), '请输入正确的数量');
            }
            if ($('#<%=TextBox_Keyword.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_Keyword.ClientID %>'), '请输入产品名称');
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
<div style="text-align:left;">
    <b>添加二手商品</b>
    <table>
        <tr>
            <td>名称：</td>
            <td><asp:TextBox runat="server" ID="TextBox_ProductName" Width="400" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>价格：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Price" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>数量：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Count" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>关键词：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Keyword" Width="400" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>描述：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Brief" Width="500" Height="400" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td>图片：</td>
            <td><asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="提交" OnClientClick="return validate()" OnClick="Button_Add_Click" ID="Button_Add" />
</div>
</asp:Content>