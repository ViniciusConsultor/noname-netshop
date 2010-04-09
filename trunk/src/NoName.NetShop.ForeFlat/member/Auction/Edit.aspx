<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.member.Auction.Edit" %>
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

            $('#<%= Button_Edit.ClientID %>').click(function() {
                $('#error-inform').hide('fast');
                $('.field').css({ 'color': '#000' });
                var errorMessage = ''; var obj = null;

                obj = $('#<%= TextBox_ProductName.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请输入产品名称</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_StartPrice.ClientID %>')
                if (obj.val() == '' || !obj.val().isCurrency()) {
                    errorMessage += '<li>请输入正确的起始价格</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_AddPrices.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请输入每次加价</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_StartTime.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请选择开始时间</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_EndTime.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请选择结束时间</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_Brief.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入产品简要描述</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_TrueName.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请输入您的姓名</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_PostCode.ClientID %>')
                if (obj.val() == '' || !obj.val().isPostalCode()) {
                    errorMessage += '<li>请输入正确的邮政编码</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                obj = $('#<%= TextBox_Address.ClientID %>')
                if (obj.val() == '') {
                    errorMessage += '<li>请输入地址</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                /*phone*/
                if ($('#<%= TextBox_Phone.ClientID %>').val() == '' && $('#<%= TextBox_CellPhone.ClientID %>').val() == '') {
                    errorMessage += '<li>请输入您的电话号码或者手机号码</li>';
                    $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                    $('#<%= TextBox_CellPhone.ClientID %>').prev().css({ 'color': 'red' });
                }
                else {
                    if ($('#<%= TextBox_Phone.ClientID %>').val() == '' || !$('#<%= TextBox_Phone.ClientID %>').val().isTelephone()) {
                        errorMessage += '<li>请输入正确的电话号码</li>';
                        $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                    }
                    if ($('#<%= TextBox_CellPhone.ClientID %>').val() == '' || !$('#<%= TextBox_CellPhone.ClientID %>').val().isMobile()) {
                        errorMessage += '<li>请输入正确的手机号码</li>';
                        $('#<%= TextBox_CellPhone.ClientID %>').prev().css({ 'color': 'red' });
                    }
                }
                /*region*/
                if (!regionValideSelect()) {
                    errorMessage += '<li>请选择地区</li>';
                    $('#region0').parent().prev().prev().css({ 'color': 'red' });
                }
//                if ($('#region0').val() == '' || $('#region1').val() == '' || $('#region2').val() == '') {
//                    if ($('#region0').val() == '') {
//                        errorMessage += '<li>请选择省份</li>';
//                    }
//                    if ($('#region1').val() == '') {
//                        errorMessage += '<li>请选择城市</li>';
//                    }
//                    if ($('#region2').val() == '') {
//                        errorMessage += '<li>请选择区县</li>';
//                    }
//                    $('#region0').parent().prev().prev().css({ 'color': 'red' });
//                }


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
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">魔力世界</a> &gt;&gt; <a href="#">视听拍卖</a> &gt;&gt; <a href="#">提交拍卖品</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="#">视听租赁</a>
                <a class="button_blue" href="#">二手交易</a>
                <a class="button_blue" href="#">视听当铺</a>
                <a class="button_blue2" href="#">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicSubmitAuction_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>提交拍卖品</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="tipContainer">
                    <ul class="tip2">
                        <li class="left"></li>
                        <li class="middle"><span>请认真填写拍卖品及个人信息</span></li>
                        <li class="right"></li>
                    </ul>
                </div>
                
                <div class="section padding2">
                    <div class="sheet1">
                        <ul style="color:Red;display:none;" id="error-inform"></ul>
                        <ul class="form">
                            <li>
                                <span class="field">所属分类</span>
                                <asp:TextBox runat="server" ID="TextBox_Category" CssClass="textField1" Enabled="false" />
                                <span class="tip"><a href="../CateSelect.aspx?app=Auction&pid=<%= AuctionID %>">重新选择</a></span>
                            </li>
                            <li>
                                <span class="field">商品名称</span>
                                <asp:TextBox ID="TextBox_ProductName" runat="server" CssClass="textField1" />
                                <span class="tip">要提交的拍卖品名称</span>
                            </li>
                            <li id="productPictures">
                                <span class="field">商品图片</span>
                                <asp:FileUpload runat="server" ID="FileUpload_ProductImage" />
                            </li>
                            <li>
                                <span class="field">起 拍 价</span>
                                <asp:TextBox ID="TextBox_StartPrice" runat="server" CssClass="textField1" />
                                <span class="tip">要提交的拍卖品名称</span>
                            </li>
                            <li>
                                <span class="field">加价</span>
                                <asp:TextBox ID="TextBox_AddPrices" runat="server" CssClass="textField1" />
                                <span class="tip">单位：元，用英文逗号隔开(如: 10,20.5,30,50)</span>
                            </li>
                            <li>
                                <span class="field">起拍时间</span>
                                <asp:TextBox ID="TextBox_StartTime" runat="server" CssClass="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li>
                                <span class="field">结束时间</span>
                                <asp:TextBox ID="TextBox_EndTime" runat="server" CssClass="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li class="description">
                                <span class="field">商品描述</span>
                                <asp:TextBox runat="server" ID="TextBox_Brief" CssClass="textField1" TextMode="MultiLine" />
                            </li>
                            <li>
                            	<span class="field">姓　　名</span>
                                <asp:TextBox ID="TextBox_TrueName" runat="server" CssClass="textField1" />
                                <span class="tip">请填写您的真实姓名</span>
                            </li>
                            <li>
                            	<span class="field">电　　话</span>
                                <asp:TextBox ID="TextBox_Phone" runat="server" CssClass="textField1" />
                                <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                            </li>
                            <li>
                            	<span class="field">手　　机</span>
                                <asp:TextBox ID="TextBox_CellPhone" runat="server" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">邮政编码</span>
                                <asp:TextBox ID="TextBox_PostCode" runat="server" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">所在地区</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                                <span class="tip">请选择所在地区</span>
                            </li>
                            <li>
                            	<span class="field">详细地址</span>
                                <asp:TextBox ID="TextBox_Address" runat="server" CssClass="textField1" />
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" CssClass="button_blue" Text="提　交" ID="Button_Edit" OnClick="Button_Edit_Click" />
                                <!--<a class="button_blue" href="#">提　交</a>-->
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