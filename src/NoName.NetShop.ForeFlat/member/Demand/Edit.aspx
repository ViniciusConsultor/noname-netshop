<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Demand.Edit" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">魔力世界</a> &gt;&gt; <a href="#">二手交易</a> &gt;&gt; <a href="#">求购商品</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="#">视听租赁</a>
                <a class="button_blue2" href="#">二手交易</a>
                <a class="button_blue" href="#">视听当铺</a>
                <a class="button_blue" href="#">视听拍卖</a>
            </div>
        </div>
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
                        <ul class="form">
                            <li>
                                <span class="field">商品名称</span>
                                <input type="text" class="textField1" />
                                <span class="tip">要求购的商品名称</span>
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
                                <span class="field">所属类别</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                                <span class="field">单　　价</span>
                                <input type="text" class="textField1" />
                                <span class="tip">单位：元</span>
                            </li>
                            <li>
                                <span class="field">数　　量</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                                <span class="field">新旧程度</span>
                                <input type="text" class="textField1" />
                            </li>
                            <li>
                                <span class="field">有 效 期</span>
                                <input type="text" class="textField1" />
                                <span class="tip">格式：xxxx-xx-xx</span>
                            </li>
                            <li class="description">
                                <span class="field">商品描述</span>
                                <textarea></textarea>
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
</asp:Content>