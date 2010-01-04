<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Auction.Add" %>
<%@ Register src="/uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/common.css" />
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <link type="text/css" rel="stylesheet" href="/css/Rainy.css" />
    <script type="text/javascript" src="/js/DingdingJsLib.js"></script>
    <script type="text/javascript" src="/js/addressData.js"></script>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/mini-Rainy.js"></script>
    <script type="text/javascript" src="/js/ui.core.js"></script>
    <script type="text/javascript" src="/js/ui.datepicker.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript">
        $(function() {
            InitRegions();

            $('#<%= Button_Add.ClientID %>').click(function() {
                $('#error-inform').hide('fast');
                $('.field').css({ 'color': '#000' });
                var errorMessage = ''; var obj = null;

                obj = $('#<%= TextBox_ProductName.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>�������Ʒ����</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= FileUpload_ProductImage.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>��ѡ���ƷͼƬ</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_StartPrice.ClientID %>')
                if (obj.val() == '' || !obj.val().isCurrency()) {
                    errorMessage += '<li>��������ȷ����ʼ�۸�</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_AddPrices.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>������ÿ�μӼ�</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_StartTime.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>��ѡ��ʼʱ��</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_EndTime.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>��ѡ�����ʱ��</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_Brief.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>�������Ʒ��Ҫ����</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_TrueName.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>��������������</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_PostCode.ClientID %>')
                if (obj.val() == '' || !obj.val().isPostalCode()) {
                    errorMessage += '<li>��������ȷ����������</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_Address.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>�������ַ</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                
                /*phone*/
                if ($('#<%= TextBox_Phone.ClientID %>').val() == '' && $('#<%= TextBox_CellPhone.ClientID %>').val() == '') {
                    errorMessage += '<li>���������ĵ绰��������ֻ�����</li>';
                    $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                    $('#<%= TextBox_CellPhone.ClientID %>').prev().css({ 'color': 'red' });
                }
                else {
                    if ($('#<%= TextBox_Phone.ClientID %>').val() == '' || !$('#<%= TextBox_Phone.ClientID %>').val().isTelephone()) {
                        errorMessage += '<li>��������ȷ�ĵ绰����</li>';
                        $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                    }
                    if ($('#<%= TextBox_CellPhone.ClientID %>').val() == '' || !$('#<%= TextBox_CellPhone.ClientID %>').val().isMobile()) {
                        errorMessage += '<li>��������ȷ���ֻ�����</li>';
                        $('#<%= TextBox_CellPhone.ClientID %>').prev().css({ 'color': 'red' });
                    }
                }
                /*region*/
                if ($('#region0').val() == '' || $('#region1').val() == '' || $('#region2').val() == '') {
                    if ($('#region0').val() == '') {
                        errorMessage += '<li>��ѡ��ʡ��</li>';
                    }
                    if ($('#region1').val() == '') {
                        errorMessage += '<li>��ѡ�����</li>';
                    }
                    if ($('#region2').val() == '') {
                        errorMessage += '<li>��ѡ������</li>';
                    }
                    $('#region0').parent().prev().prev().css({ 'color': 'red' });
                }


                if (errorMessage != '') {
                    $('#error-inform').html(errorMessage).show('fast');
                    return false;
                }
                else return true;
            });

        });

    </script>
</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="cpMain">
    <!--Position Begin-->
    <div class="currentPosition">
    	�����ڵ�λ��: <a href="#">��ҳ</a> &gt;&gt; <a href="#">ħ������</a> &gt;&gt; <a href="#">��������</a> &gt;&gt; <a href="#">�ύ����Ʒ</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="#">��������</a>
                <a class="button_blue" href="#">���ֽ���</a>
                <a class="button_blue" href="#">��������</a>
                <a class="button_blue2" href="#">��������</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicSubmitAuction_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>�ύ����Ʒ</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="tipContainer">
                    <ul class="tip2">
                        <li class="left"></li>
                        <li class="middle"><span>��������д����Ʒ��������Ϣ</span></li>
                        <li class="right"></li>
                    </ul>
                </div>
                
                <div class="section padding2">
                    <div class="sheet1">
                        <ul style="color:Red;display:none;" id="error-inform"></ul>
                        <ul class="form">
                            <li>
                                <span class="field">��������</span>
                                <asp:TextBox runat="server" ID="TextBox_Category" CssClass="textField1" Enabled="false" />
                                <span class="tip"><a href="../CateSelect.aspx?app=Auction">����ѡ��</a></span>
                            </li>
                            <li>
                                <span class="field">��Ʒ����</span>
                                <asp:TextBox ID="TextBox_ProductName" runat="server" CssClass="textField1" />
                                <span class="tip">Ҫ�ύ������Ʒ����</span>
                            </li>
                            <li id="productPictures">
                                <span class="field">��ƷͼƬ</span>
                                <asp:FileUpload runat="server" ID="FileUpload_ProductImage" />
                            </li>
                            <li>
                                <span class="field">�� �� ��</span>
                                <asp:TextBox ID="TextBox_StartPrice" runat="server" CssClass="textField1" />
                                <span class="tip">Ҫ�ύ������Ʒ����</span>
                            </li>
                            <li>
                                <span class="field">�Ӽ�</span>
                                <asp:TextBox ID="TextBox_AddPrices" runat="server" CssClass="textField1" />
                                <span class="tip">��λ��Ԫ����Ӣ�Ķ��Ÿ���(��: 10,20.5,30,50)</span>
                            </li>
                            <li>
                                <span class="field">����ʱ��</span>
                                <asp:TextBox ID="TextBox_StartTime" runat="server" CssClass="textField1" />
                                <span class="tip">��ʽ��xxxx-xx-xx</span>
                            </li>
                            <li>
                                <span class="field">����ʱ��</span>
                                <asp:TextBox ID="TextBox_EndTime" runat="server" CssClass="textField1" />
                                <span class="tip">��ʽ��xxxx-xx-xx</span>
                            </li>
                            <li class="description">
                                <span class="field">��Ʒ����</span>
                                <asp:TextBox runat="server" ID="TextBox_Brief" CssClass="textField1" TextMode="MultiLine" />
                            </li>
                            <li>
                            	<span class="field">�ա�����</span>
                                <asp:TextBox ID="TextBox_TrueName" runat="server" CssClass="textField1" />
                                <span class="tip">����д������ʵ����</span>
                            </li>
                            <li>
                            	<span class="field">�硡����</span>
                                <asp:TextBox ID="TextBox_Phone" runat="server" CssClass="textField1" />
                                <span class="tip">��ʽ������ - �绰���� - �ֻ���</span>
                            </li>
                            <li>
                            	<span class="field">�֡�����</span>
                                <asp:TextBox ID="TextBox_CellPhone" runat="server" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">��������</span>
                                <asp:TextBox ID="TextBox_PostCode" runat="server" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">���ڵ���</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                                <span class="tip">��ѡ�����ڵ���</span>
                            </li>
                            <li>
                            	<span class="field">��ϸ��ַ</span>
                                <asp:TextBox ID="TextBox_Address" runat="server" CssClass="textField1" />
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" CssClass="button_blue" Text="�ᡡ��" ID="Button_Add" OnClick="Button_Add_Click" />
                                <!--<a class="button_blue" href="#">�ᡡ��</a>-->
                            </li>
                        </ul>
                    </div>
                </div>
                
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>

    </div>
    <!--MainBody End-->
</asp:Content>