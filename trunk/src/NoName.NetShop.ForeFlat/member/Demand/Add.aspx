<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Demand.Add" %>
<%@ Register src="/uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <link type="text/css" rel="stylesheet" href="/css/jquery-ui.css" />
    
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="/js/jquery.ui.core.js"></script>
    <script type="text/javascript">
        $(function() {
            InitRegions();

            $('#<%= Button_Add.ClientID %>').click(function() {
                $('#error-inform').hide('fast');
                $('.field').css({ 'color': '#000' });
                var errorMessage = ''; var obj = null;

                obj = $('#<%= TextBox_ProductName.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入产品名称</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= FileUpload_ProductImage.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请选择产品图片</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Price.ClientID %>');
                if (obj.val() == '' || !obj.val().isCurrency()) {
                    errorMessage += '<li>请输入正确的产品价格</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Count.ClientID %>');
                if (obj.val() == '' || !obj.val().isInteger()) {
                    errorMessage += '<li>请输入正确的产品数量</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_ExpireTime.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请选择有效期时间</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Brief.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入产品简要描述</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_TrueName.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入您的姓名</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_PostCode.ClientID %>');
                if (obj.val() == '' || !obj.val().isPostalCode()) {
                    errorMessage += '<li>请输入正确的邮政编码</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Address.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入您的详细地址</li>';
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

                /*data format*/


                if (errorMessage != '') {
                    $('#error-inform').html(errorMessage).show('fast');
                    return false;
                }
                else return true;
            });

            $('#<%= TextBox_ExpireTime.ClientID %>').datepicker({ dateFormat: 'yy-mm-dd' });

        });
    </script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; <a href="/member/Demand/List.aspx">我的需求</a> &gt;&gt; <a href="#">添加需求</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicSubmitWantedInfo_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>求购商品</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="tipContainer">
                    <ul class="tip2">
                        <li class="left"></li>
                        <li class="middle"><span>请认真填写求购的商品及个人信息信息</span></li>
                        <li class="right"></li>
                    </ul>
                </div>
                
                <div class="section padding2">
                    <div class="sheet1">
                        <ul style="color:Red;display:none;" id="error-inform"></ul>
                        <ul class="form">
                            <li>
                                <span class="field">商品名称</span>
                                <asp:TextBox runat="server" ID="TextBox_ProductName" CssClass="textField1" />
                                <span class="tip">要求购的商品名称</span>
                            </li>
                            <li id="productPictures">
                                <span class="field">商品图片</span>
                                <asp:FileUpload runat="server" id="FileUpload_ProductImage" />
                                <%--<span><a href="javascript:void(0)" class="linkButton" onclick="addPicture();">【增加图片】</a></span>--%>
                            </li>
                            <li>
                                <span class="field">所属类别</span>
                                <asp:TextBox runat="server" ID="TextBox_Category" CssClass="textField1" Enabled="false" />
                                <span class="tip"><a href="../CateSelect.aspx?app=Demand">重新选择</a></span>
                            </li>
                            <li>
                                <span class="field">单　　价</span>
                                <asp:TextBox runat="server" ID="TextBox_Price" CssClass="textField1" />
                                <span class="tip">单位：元</span>
                            </li>
                            <li>
                                <span class="field">数　　量</span>
                                <asp:TextBox runat="server" ID="TextBox_Count" CssClass="textField1" />
                            </li>
                            <li>
                                <span class="field">新旧程度</span>
                                <asp:DropDownList runat="server" ID="DropDown_Usage" />
                            </li>
                            <li>
                                <span class="field">有 效 期</span>
                                <asp:TextBox runat="server" ID="TextBox_ExpireTime" CssClass="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li class="description">
                                <span class="field">商品描述</span>
                                <asp:TextBox runat="server" ID="TextBox_Brief" CssClass="textField1" TextMode="MultiLine" />
                            </li>
                            <li>
                            	<span class="field">姓　　名</span>
                                <asp:TextBox runat="server" ID="TextBox_TrueName" CssClass="textField1" />
                                <span class="tip">请填写您的真实姓名</span>
                            </li>
                            <li>
                            	<span class="field">电　　话</span>
                                <asp:TextBox runat="server" ID="TextBox_Phone" CssClass="textField1" />
                                <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                            </li>
                            <li>
                            	<span class="field">手　　机</span>
                                <asp:TextBox runat="server" ID="TextBox_CellPhone" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">邮政编码</span>
                                <asp:TextBox runat="server" ID="TextBox_PostCode" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">所在地区</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                            	<%--
                                <div class="component">
									<script type="text/javascript">
                                        var provinceBox=new RainySelectBox();
                                        provinceBox.boxName="province";
                                        provinceBox.fire="click";
                                        provinceBox.name="province";
                                        provinceBox.id="province";
                                        provinceBox.width=109;
                                        provinceBox.listMaxHeight=300;
                                        provinceBox.selectedClass="commonSelectBox_currentOption";
                                        provinceBox.listClass="commonSelectBox_list";
                                        provinceBox.addOption("数据加载中","0");
										provinceBox.listener="showCityData";
                                        provinceBox.show();
                                    </script>
                                </div>
                                <div class="component">
									<script type="text/javascript">
                                        var cityBox=new RainySelectBox();
                                        cityBox.boxName="city";
                                        cityBox.fire="click";
                                        cityBox.name="city";
                                        cityBox.id="city";
                                        cityBox.width=109;
                                        cityBox.listMaxHeight=300;
                                        cityBox.selectedClass="commonSelectBox_currentOption";
                                        cityBox.listClass="commonSelectBox_list";
                                        cityBox.addOption("数据加载中","0","");
                                        cityBox.show();
										loadInitData();
                                    </script>
                                </div>
                                --%>
                                <span class="tip">请选择所在地区</span>
                            </li>
                            <li>
                            	<span class="field">详细地址</span>
                                <asp:TextBox runat="server" ID="TextBox_Address" CssClass="textField2" />
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" ID="Button_Add" OnClick="Button_Add_Click" Text="提　交"  CssClass="button_blue"/>
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