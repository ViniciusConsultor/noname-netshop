<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MemberCenter.master" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Auction.Add" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
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
                        <ul class="form">
                            <li>
                                <span class="field">商品名称</span>
                                <input type="text" class="textField1" />
                                <span class="tip">要提交的拍卖品名称</span>
                            </li>
                            <li id="productPictures">
                                <span class="field">商品图片</span>
                                <div class="fileSelector">
                                	<input type="text" class="textField" id="productPic0" readonly="readonly" />
                                    <a class="button_blue" href="javascript:void(0)">
                                    	<input type="file" size="1" class="realFile" name="productPic0" hidefocus=”true” onchange="selectFile(this,'productPic0')"/>
                                        <lable>浏  览</lable>
                                    </a>
                                </div>
                                <span><a href="javascript:void(0)" class="linkButton" onclick="addPicture();">【增加图片】</a></span>
                            </li>
                            <li>
                                <span class="field">起 拍 价</span>
                                <input type="text" class="textField1" />
                                <span class="tip">要提交的拍卖品名称</span>
                            </li>
                            <li>
                                <span class="field">最低加价</span>
                                <input type="text" class="textField1" />
                                <span class="tip">单位：元</span>
                            </li>
                            <li>
                                <span class="field">最高加价</span>
                                <input type="text" class="textField1" />
                                <span class="tip">单位：元</span>
                            </li>
                            <li>
                                <span class="field">起拍时间</span>
                                <input type="text" class="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li>
                                <span class="field">结束时间</span>
                                <input type="text" class="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li>
                            	<span class="field">姓　　名</span>
                                <input type="text" class="textField1" />
                                <span class="tip">请填写您的真实姓名</span>
                            </li>
                            <li>
                            	<span class="field">电　　话</span>
                                <input type="text" class="textField1" />
                                <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                            </li>
                            <li>
                            	<span class="field">手　　机</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                            	<span class="field">邮政编码</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                            	<span class="field">所在地区</span>
                                <div class="component">
									<script type="text/javascript">
									    var provinceBox = new RainySelectBox();
									    provinceBox.boxName = "province";
									    provinceBox.fire = "click";
									    provinceBox.name = "province";
									    provinceBox.id = "province";
									    provinceBox.width = 109;
									    provinceBox.listMaxHeight = 300;
									    provinceBox.selectedClass = "commonSelectBox_currentOption";
									    provinceBox.listClass = "commonSelectBox_list";
									    provinceBox.addOption("数据加载中", "0");
									    provinceBox.listener = "showCityData";
									    provinceBox.show();
                                    </script>
                                </div>
                                <div class="component">
									<script type="text/javascript">
									    var cityBox = new RainySelectBox();
									    cityBox.boxName = "city";
									    cityBox.fire = "click";
									    cityBox.name = "city";
									    cityBox.id = "city";
									    cityBox.width = 109;
									    cityBox.listMaxHeight = 300;
									    cityBox.selectedClass = "commonSelectBox_currentOption";
									    cityBox.listClass = "commonSelectBox_list";
									    cityBox.addOption("数据加载中", "0", "");
									    cityBox.show();
									    loadInitData();
                                    </script>
                                </div>
                                <span class="tip">请选择所在地区</span>
                            </li>
                            <li>
                            	<span class="field">详细地址</span>
                                <input type="text" class="textField2" />
                            </li>
                            <li class="submit">
                                <a class="button_blue" href="#">提　交</a>
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