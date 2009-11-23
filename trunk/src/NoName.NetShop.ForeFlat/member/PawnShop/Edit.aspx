<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.PawnShop.Edit" %>
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
            if ($('#<%=TextBox_Count.ClientID %>').val() == '' || !$('#<% =TextBox_Count.ClientID %>').val().isNumber()) {
                result = false;
                inform($('#<%=TextBox_Count.ClientID %>'), '请输入正确的数量');
            }
            if ($('#<%=TextBox_Keyword.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_Keyword.ClientID %>'), '请输入产品名称');
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
    <b>修改当品</b>
    <table>
        <tr>
            <td>产品名称<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_ProductName" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>数量<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" ID="TextBox_Count" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>关键词<span class="red">*</span>：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_Keyword" /><span type="inform" class="red"></span></td>
        </tr>
        <tr>
            <td>描述：</td>
            <td><asp:TextBox runat="server" Width="400" ID="TextBox_Brief" TextMode="MultiLine" Height="400" /></td>
        </tr>
        <tr>
            <td>图片<span class="red">*</span>：</td>
            <td>
                <asp:Image Width="200" Height="200" runat="server" ID="Image_ProductImage" />
                <asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="Button_Edit" Text="提交" OnClientClick="return validate()" OnClick="Button_Edit_Click" />

</asp:Content>