<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Demand.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Solution.Demand" %>
<%@ Register src="/uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript">
        $(function() {
            InitRegions();

            $('#<%= Button_Add.ClientID %>').click(function() {
                $('#error-inform').hide('fast');
                $('.field').css({ 'color': '#000' });
                var errorMessage = ''; var obj = null;

                obj = $('#<%= TextBox_DemandDetail.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入需求信息</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= FileUpload_FieldImage.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请选择场地图片</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Field.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入场地描述</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Effect.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入效果描述</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Budget.ClientID %>');
                if (obj.val() == '' || !obj.val().isCurrency()) {
                    errorMessage += '<li>请输入正确的预算金额</li>';
                    obj.prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Contactor.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入联系人姓名</li>';
                    obj.prev().css({ 'color': 'red' });
                }
                
                obj = $('#<%= TextBox_Phone.ClientID %>');
                if (obj.val() == '' || !obj.val().isTelephone()) {
                    errorMessage += '<li>请输入正确的电话号码</li>';
                    $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_PostCode.ClientID %>');
                if (obj.val() == '' || !obj.val().isPostalCode()) {
                    errorMessage += '<li>请输入正确的邮政编码</li>';
                    $('#<%= TextBox_Phone.ClientID %>').prev().css({ 'color': 'red' });
                }

                obj = $('#<%= TextBox_Address.ClientID %>');
                if (obj.val() == '') {
                    errorMessage += '<li>请输入通信地址</li>';
                    obj.prev().css({ 'color': 'red' });
                }


                /*region*/
                if ($('#region0').val() == '' || $('#region1').val() == '' || $('#region2').val() == '') {
                    if ($('#region0').val() == '') {
                        errorMessage += '<li>请选择省份</li>';
                    }
                    if ($('#region1').val() == '') {
                        errorMessage += '<li>请选择城市</li>';
                    }
                    if ($('#region2').val() == '') {
                        errorMessage += '<li>请选择区县</li>';
                    }
                    $('#region0').parent().prev().prev().css({ 'color': 'red' });
                }

                /*data format*/


                if (errorMessage != '') {
                    $('#error-inform').html(errorMessage).show('fast');
                    return false;
                }
                else return true;
            });
        });
    </script>    
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/Channel/solution/">影音解决方案</a> &gt;&gt; <a href="#">按需定制</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue2" href="/solution/Demand.aspx">按需制定</a>
                <a class="button_blue" href="/solution/SuiteList.aspx">推荐套装</a>
                <a class="button_blue" href="/solution/Home.aspx">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionCustomizeForm_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>按需定制</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="tipContainer">
                    <ul class="tip2">
                        <li class="left"></li>
                        <li class="middle"><span>请认真填写您的需求信息，以便于我们及时与您取得联系</span></li>
                        <li class="right"></li>
                    </ul>
                </div>
                
                <div class="section padding2">
                    <div class="sheet1">
                        <ul style="color:Red;display:none;" id="error-inform"></ul>
                        <ul class="form">
                            <li>
                                <span class="field">1.您的需求</span>
                                <asp:TextBox runat="server" ID="TextBox_DemandDetail" CssClass="textarea3" TextMode="MultiLine" />
                            </li>
                            <li id="productPictures">
                                <span class="field">2.请上传相关场地的照片</span>
                                <asp:FileUpload runat="server" id="FileUpload_FieldImage" />
                            </li>
                            <li>
                                <span class="field">3.您的场地情况</span>
                                <asp:TextBox runat="server" ID="TextBox_Field" CssClass="textarea3" TextMode="MultiLine" />
                            </li>
                            <li>
                                <span class="field">4.需要实现的影音效果</span>
                                <asp:TextBox runat="server" ID="TextBox_Effect" CssClass="textarea3" TextMode="MultiLine" />
                            </li>
                            <li>
                                <span class="field">5.您的预算</span>
                                <asp:TextBox runat="server" ID="TextBox_Budget" CssClass="textField1" />
                                <span class="tip">单位：元</span>
                            </li>
                            <li>
                                <span class="field">6.联系人姓名</span>
                                <asp:TextBox runat="server" ID="TextBox_Contactor" CssClass="textField1" />
                            </li>
                            <li>
                                <span class="field">7.联系人电话</span>
                                <asp:TextBox runat="server" ID="TextBox_Phone" CssClass="textField1" />
                                <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                            </li>
                            <li>
                            	<span class="field">8.邮政编码</span>
                                <asp:TextBox runat="server" ID="TextBox_PostCode" CssClass="textField1" />
                            </li>
                            <li>
                            	<span class="field">9.所在地区</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                                <span class="tip">请选择所在地区</span>
                            </li>
                            <li>
                            	<span class="field">10.详细地址</span>
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