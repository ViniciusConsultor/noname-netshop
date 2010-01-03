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
    <script type="text/javascript" src="/controls/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="/js/addressData.js"></script>
    <script type="text/javascript">

        $(function() {
            //$('#<%=TextBox_StartTime.ClientID %>').datepicker({dateFormat:'yyyy-MM-dd hh:mm:ss'});
            //$('#<%=TextBox_EndTime.ClientID %>').datepicker({ dateFormat: 'yyyy-MM-dd hh:mm:ss' });
            //CKEDITOR.replace('<%=TextBox_Brief.ClientID %>', {
            //    toolbar: 'Basic',
            //    width:'400px',
            //    height:'200px'
            //});

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
                        <ul class="form">
                            <li>
                                <span class="field">��������</span>
                                <asp:TextBox runat="server" ID="TextBox_Category" CssClass="textField1" Enabled="false" />
                                <a href="../CateSelect.aspx?app=Auction">����ѡ��</a>
                            </li>
                            <li>
                                <span class="field">��Ʒ����</span>
                                <input type="text" class="textField1" />
                                <span class="tip">Ҫ�ύ������Ʒ����</span>
                            </li>
                            <li id="productPictures">
                                <span class="field">��ƷͼƬ</span>
                                <div class="fileSelector">
                                	<input type="text" class="textField" id="productPic0" readonly="readonly" />
                                    <a class="button_blue" href="javascript:void(0)">
                                    	<input type="file" size="1" class="realFile" name="productPic0" hidefocus=��true�� onchange="selectFile(this,'productPic0')"/>
                                        <lable>�  ��</lable>
                                    </a>
                                </div>
                                <span><a href="javascript:void(0)" class="linkButton" onclick="addPicture();">������ͼƬ��</a></span>
                            </li>
                            <li>
                                <span class="field">�� �� ��</span>
                                <input type="text" class="textField1" />
                                <span class="tip">Ҫ�ύ������Ʒ����</span>
                            </li>
                            <li>
                                <span class="field">��ͼӼ�</span>
                                <input type="text" class="textField1" />
                                <span class="tip">��λ��Ԫ</span>
                            </li>
                            <li>
                                <span class="field">��߼Ӽ�</span>
                                <input type="text" class="textField1" />
                                <span class="tip">��λ��Ԫ</span>
                            </li>
                            <li>
                                <span class="field">����ʱ��</span>
                                <input type="text" class="textField1" />
                                <span class="tip">��ʽ��xxxx-xx-xx</span>
                            </li>
                            <li>
                                <span class="field">����ʱ��</span>
                                <input type="text" class="textField1" />
                                <span class="tip">��ʽ��xxxx-xx-xx</span>
                            </li>
                            <li>
                            	<span class="field">�ա�����</span>
                                <input type="text" class="textField1" />
                                <span class="tip">����д������ʵ����</span>
                            </li>
                            <li>
                            	<span class="field">�硡����</span>
                                <input type="text" class="textField1" />
                                <span class="tip">��ʽ������ - �绰���� - �ֻ���</span>
                            </li>
                            <li>
                            	<span class="field">�֡�����</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                            	<span class="field">��������</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                            	<span class="field">���ڵ���</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                                <span class="tip">��ѡ�����ڵ���</span>
                            </li>
                            <li>
                            	<span class="field">��ϸ��ַ</span>
                                <input type="text" class="textField2" />
                            </li>
                            <li class="submit">
                                <asp:Button runat="server" CssClass="button_blue" Text="�ᡡ��" ID="Button_Add2" OnClick="Button_Add_Click" />
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
    
    <!--
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
    -->
</asp:Content>