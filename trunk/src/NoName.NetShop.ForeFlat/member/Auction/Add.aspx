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
                inform($('#<%=TextBox_AuctionProductName.ClientID %>'), '�������Ʒ����');
            }
            if ($('#<%=TextBox_StartPrice.ClientID %>').val() == '' || !$('#<% =TextBox_StartPrice.ClientID %>').val().isCurrency()) {
                result = false;
                inform($('#<%=TextBox_StartPrice.ClientID %>'), '��������ȷ�ļ۸�');
            }
            if ($('#<%=TextBox_AddPrice.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_AddPrice.ClientID %>'), '��������ȷ�ļ۸�');
            }
            if ($('#<%=TextBox_StartTime.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_StartTime.ClientID %>'), '������������ʼʱ��');
            }
            if ($('#<%=TextBox_EndTime.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=TextBox_EndTime.ClientID %>'), '��������������ʱ��');
            }
            if ($('#<%=FileUpload_ProductImage.ClientID %>').val() == '') {
                result = false;
                inform($('#<%=FileUpload_ProductImage.ClientID %>'), '��ѡ���ƷͼƬ');
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
                <a href="../CateSelect.aspx" >����ѡ��</a>
            </td>
            </tr>
            <tr>
                <td>��Ʒ����<span class="red">*</span>��</td>
                <td><asp:TextBox runat="server" ID="TextBox_AuctionProductName" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>���ļ�<span class="red">*</span>��</td>
                <td><asp:TextBox runat="server" ID="TextBox_StartPrice" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>ÿ�μӼ�<span class="red">*</span>��</td>
                <td><asp:TextBox runat="server" ID="TextBox_AddPrice" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>��ʼʱ��<span class="red">*</span>��</td>
                <td><asp:TextBox runat="server" ID="TextBox_StartTime" />(��ʽ��yyyy-MM-dd hh:mm:ss)<span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>����ʱ��<span class="red">*</span>��</td>
                <td><asp:TextBox runat="server" ID="TextBox_EndTime" />(��ʽ��yyyy-MM-dd hh:mm:ss)<span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>��飺</td>
                <td><asp:TextBox runat="server" ID="TextBox_Brief" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td>��ƷͼƬ<span class="red">*</span>��</td>
                <td><asp:FileUpload runat="server" ID="FileUpload_ProductImage" /><span type="inform" class="red"></span></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Add" OnClientClick="return validate()" OnClick="Button_Add_Click" Text="�ύ" />
    </div>
</asp:Content>