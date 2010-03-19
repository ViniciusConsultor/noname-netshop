﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIY.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Solution.DIY" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script type="text/javascript" src="/js/hashtable.js"></script>
    <script type="text/javascript" src="/js/cookie.js"></script>
    <script type="text/javascript" src="/js/jquery.url.js"></script>
    <script type="text/javascript" src="/js/solution.diy3.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">影音解决方案</a> &gt;&gt; <a href="#">经典套装</a> &gt;&gt; <a href="#">配置</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="Demand.aspx">按需制定</a>
                <a class="button_blue" href="SuiteList.aspx">推荐套装</a>
                <a class="button_blue2" href="Home.aspx">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionCustomize_mainbody clearfix newline">
    	<div class="leftColumn">
        	<span class="columnTitle">套装配置单</span>
            <div class="table1" id="suit-config-list-wrapper">
            </div>
            <div class="buttons">
            	<a class="button_blue3" style="cursor:pointer" id="clear-select">
                    <span class="left"></span>
                    <span class="text">清空配置单</span>
                    <span class="right"></span>
                </a>
                <a class="button_blue3" style="cursor:pointer" id="submit-select">
                    <span class="left"></span>
                    <span class="text">提交订单</span>
                    <span class="right"></span>
                </a>
                <a class="button_blue3" href="#">
                    <span class="left"></span>
                    <span class="text">保存配置单</span>
                    <span class="right"></span>
                </a>
            </div>
    	</div>
        
        <div class="rightColumn">
        	<span class="columnTitle">设备列表</span>
            <div class="equipmentCategory" id="equipment-category">
            </div>
            <ul class="form">
            	<li>
                	<span class="field">投影机吊架</span>
                    <div class="component">
                    	<script type="text/javascript">
							var brandBox=new RainySelectBox();
							brandBox.boxName="brand";
							brandBox.fire="click";
							brandBox.name="brand";
							brandBox.id="brand";
							brandBox.width=120;
							brandBox.listMaxHeight=300;
							brandBox.selectedClass="commonSelectBox_currentOption";
							brandBox.listClass="commonSelectBox_list";
							brandBox.addOption("品牌","0","Selected");
							brandBox.addOption("西门子","1");
							brandBox.addOption("松下","2");
							brandBox.show();
						</script>
                    </div>
                    <input type="text" class="textField1" id="search-product-name" />
                    <div class="component">
                    	<a class="button_blue3" style="cursor:pointer;" id="button-search">
                            <span class="left"></span>
                            <span class="text">搜索</span>
                            <span class="right"></span>
                        </a>
                    </div>
                </li>
            </ul>
            <div class="box6">
                <div class="title">
                	<span>商品列表</span>
                    <div class="sort">
                    	<a href="#" class="on">价格由高到低</a>
                        <a href="#">价格由低到高</a>
                    </div>
                </div>
                <div class="content noPaddingContentBox" id="list-table">
                </div>
                
            </div>
            <div class="buttons">
                <a class="linkButton" href="#">去看看推荐套装&gt;&gt;</a>
            </div>
        </div>
    </div>
    <!--MainBody End-->
</div>
</asp:Content>
