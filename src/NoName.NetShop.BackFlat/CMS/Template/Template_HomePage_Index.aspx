<%@ Page Language="C#" AutoEventWireup="true" Inherits="NoName.NetShop.BackFlat.CMS.Template.Template" %>
<%@ Register Assembly="NoName.NetShop.CMS" Namespace="NoName.NetShop.CMS" TagPrefix="dd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <link type="text/css" rel="stylesheet" href="/css/common.css" />
    <link rel="stylesheet" type="text/css" href="/css/Rainy.css" />
    <script type="text/javascript" src="/js/DingdingJsLib.js"></script>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/mini-Rainy.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">    
            <dd:CMSTag ID="cmsTag1" Description="鼎鼎标准头标签" TagID="2" runat="server" />
            <!--MainBody Begin-->
            <div class="homePage_mainbody newline clearfix">
                <div class="leftColumn">
                    <div class="box2 cateBox">
                        <ul class="title">
                            <li class="left"></li>
                            <li><span>影音套装</span></li>
                            <li class="right"></li>
                        </ul>
                        <div class="content">
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            <div id="checkLoadCate"></div>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                    
                    <div class="box2 cateBox newline">
                        <ul class="title">
                            <li class="left"></li>
                            <li><a class="Tab_on" rel="ProductsCate" href="javascript:void(0)" onclick="TabTransfer(this)">商品分类</a><a class="Tab_off" rel="BrandsCate" href="javascript:void(0)" onclick="TabTransfer(this)">品牌分类</a></li>
                            <li class="right"></li>
                        </ul>
                        <div id="ProductsCate" style="display:none">
                          <div class="mainCategory">  
                            <div class="groupTitle">影像电器</div>
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div class="groupTitle">影像电器</div>
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div class="groupTitle">影像电器</div>
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div class="groupTitle">影像电器</div>
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div class="groupTitle">影像电器</div>
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">私人影院</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">办公会议</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                               <a href="#">客厅</a>
                               <a href="#">办公会议</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">教学培训</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop">
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>

                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">休闲娱乐</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">公共展示</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                              <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            
                            <div rel="cateMenu" class="cateMenu_normal">
                             <div class="topCate">套装服务</div>
                             <span>入门</span>
                             <span>客厅</span>
                             <span>整房</span>
                             <div class="pop"> 
                               <a href="#">入门</a>
                               <a href="#">客厅</a>
                               <a href="#">整房</a>
                             </div>
                             <div class="popShadow"></div>
                            </div>
                            <div id="checkLoadCate"></div>
                          </div>
                        </div>
                        <div id="BrandsCate" style="display:none">
                            <div class="category_non-popMenu clearfix">
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                                <a class="class" href="#">影像电器</a>
                                <div class="subs clearfix">
                                    <a href="#">东芝</a>
                                    <a href="#">日立</a>
                                    <a href="#">西门子</a>
                                    <a href="#">索尼</a>
                                    <a href="#">联想</a>
                                    <a href="#">海尔</a>
                                    <a href="#">富士康</a>
                                    <a href="#">松下</a>
                                    <a class="more more1" href="#"></a>
                                </div>
                            </div>
                        </div>
                        <div class="content">
                          <script type="text/javascript">
                              document.write(document.getElementById("ProductsCate").innerHTML);
                          </script>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                    
                    <div class="banner newline">
                        <a href="#"><img src="Pictures/banner3.jpg" /></a>
                    </div>
                    
                </div>
                <div class="rightColumn">
                    <div class="box2">
                        <ul class="title">
                            <li class="left"></li>
                            <li><span>鼎鼎快讯</span></li>
                            <li class="right"></li>
                            <li class="more"><a class="more1" href="#"></a></li>
                        </ul>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a href="#">开学好礼大放送，DIY放血大促销</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                            </ul>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                    
                    <div class="banner newline">
                        <a href="#"><img src="Pictures/banner4.jpg" /></a>
                    </div>
                    
                    <div class="box2 newline">
                        <ul class="title">
                            <li class="left"></li>
                            <li><span>资讯排行榜</span></li>
                            <li class="right"></li>
                            <li class="more"><a class="more1" href="#"></a></li>
                        </ul>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a href="#">开学好礼大放送，DIY放血大促销</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">开学好礼大放送，DIY放血大促销</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">开学好礼大放送，DIY放血大促销</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                                <li>
                                    <a href="#">初春必败男装 全场2折起</a>
                                </li>
                                <li>
                                    <a href="#">欧米茄手表3折</a>
                                </li>
                            </ul>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                    <div class="box2 newline">
                        <ul class="title">
                            <li class="left"></li>
                            <li>
                                <span>热卖榜单</span>
                                <a class="Tab_on" rel="hotProducts" href="javascript:void(0)" onclick="TabTransfer(this)">商品</a>
                                <a class="Tab_off" rel="hotBrands" href="javascript:void(0)" onclick="TabTransfer(this)">品牌</a>
                                <a class="Tab_off" rel="hotSuites" href="javascript:void(0)" onclick="TabTransfer(this)">套装</a>
                            </li>
                            <li class="right"></li>
                        </ul>
                        <div id="hotProducts" style="display:none">
                            <div class="hotlist">
                                <div class="tableHeader clearfix">
                                    <div class="column column1">排名</div>
                                    <div class="column column2">产品</div>
                                    <div class="column column3">价格</div>
                                </div>
                                <ul class="listContent">
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R1"></span></a>
                                            <a href="#" class="name">[明基] MP512 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R2"></span></a>
                                            <a href="#" class="name">[纽曼] NM-PT01 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R3"></span></a>
                                            <a href="#" class="name">[明基] MP512ST</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R4"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R5"></span></a>
                                            <a href="#" class="name">[奥图码] PV2223</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R6"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX13</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R7"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R8"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R9"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R10"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R11"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R12"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R13"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R14"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R15"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R16"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R17"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li><li>
                                            <a href="#" class="rank"><span class="rankIndex R18"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R19"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R20"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                </ul>
                            </div>
                        </div>
                        <div id="hotBrands" style="display:none">
                            <div class="hotlist">
                                <div class="tableHeader clearfix">
                                    <div class="column column1">排名</div>
                                    <div class="column column2">品牌</div>
                                    <div class="column column3">人气</div>
                                </div>
                                <ul class="listContent">
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R1"></span></a>
                                            <a href="#" class="name">[明基] MP512 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R2"></span></a>
                                            <a href="#" class="name">[纽曼] NM-PT01 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R3"></span></a>
                                            <a href="#" class="name">[明基] MP512ST</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R4"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R5"></span></a>
                                            <a href="#" class="name">[奥图码] PV2223</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R6"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX13</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R7"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R8"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R9"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R10"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R11"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R12"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R13"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R14"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R15"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R16"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R17"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li><li>
                                            <a href="#" class="rank"><span class="rankIndex R18"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R19"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R20"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                </ul>
                            </div>
                        </div>
                        <div id="hotSuites" style="display:none">
                            <div class="hotlist">
                                <div class="tableHeader clearfix">
                                    <div class="column column1">排名</div>
                                    <div class="column column2">套装</div>
                                    <div class="column column3">价格</div>
                                </div>
                                <ul class="listContent">
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R1"></span></a>
                                            <a href="#" class="name">[明基] MP512 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R2"></span></a>
                                            <a href="#" class="name">[纽曼] NM-PT01 </a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R3"></span></a>
                                            <a href="#" class="name">[明基] MP512ST</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R4"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R5"></span></a>
                                            <a href="#" class="name">[奥图码] PV2223</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R6"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX13</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R7"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R8"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R9"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R10"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R11"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R12"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R13"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R14"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R15"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R16"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R17"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li><li>
                                            <a href="#" class="rank"><span class="rankIndex R18"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R19"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                        <li>
                                            <a href="#" class="rank"><span class="rankIndex R20"></span></a>
                                            <a href="#" class="name">[索尼] VPL-CX130</a>
                                            <a href="#" class="price">￥9998</a>
                                        </li>
                                </ul>
                            </div>
                        </div>
                        <div class="content">
                            <script type="text/javascript">
                                document.write(document.getElementById("hotProducts").innerHTML);
                            </script>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                    <div class="box2 newline">
                        <ul class="title">
                            <li class="left"></li>
                            <li><span>调查投票</span></li>
                            <li class="right"></li>
                        </ul>
                        <div class="content">
                            <div class="vote">
                                <div class="topic">您曾经在哪里尝试过网络购物？</div>
                                <ul class="options">
                                    <li><input type="checkbox" /><span>淘宝</span></li>
                                    <li><input type="checkbox" /><span>易趣</span></li>
                                    <li><input type="checkbox" /><span>拍拍</span></li>
                                    <li><input type="checkbox" /><span>京东商城</span></li>
                                    <li><input type="checkbox" /><span>其它</span></li>
                                    <li><input type="checkbox" /><span>从未尝试</span></li>
                                </ul>
                                <div class="buttons clearfix">
                                    <a class="button_blue" href="#">提　交</a>
                                    <a class="button_blue" href="#">重　置</a>
                                </div>
                            </div>
                        </div>
                        <ul class="bottom">
                           <li class="left"></li>
                           <li class="right"></li>
                        </ul>
                    </div>
                </div>
                <div class="midColumn">
                    <div class="midColumnContainer">
                        <div class="banner">
                        <script type="text/javascript">
                            var slider = new RainySlide();
                            slider.slideName = "slide1";
                            slider.textBgClass = "SlideTextBg";
                            slider.textClass = "SlideText";
                            slider.barClass = "SlideBar"
                            slider.indexClass = "SlideIndex"
                            slider.width = 530;
                            slider.height = 275;
                            slider.imageUrl = ["pictures/banner1.jpg", "pictures/banner2.jpg"];
                            slider.linkUrl = ["#1", "#2"];
                            slider.linkTarget = "_self";
                            slider.duration = 3500;
                            slider.render();
                        </script>
                        </div>
                        <div class="box3 newline">
                            <div class="left"></div>
                            <div class="right"></div>
                            <div class="middle">
                                <div class="boxContainer">
                                    <ul class="recommendation">
                                        <li>
                                            <div class="picBox">
                                                <span>特价</span>
                                                <a href="#"><img src="pictures/productPic.gif" /></a>
                                            </div>
                                            <a href="#">
                                                <span class="price">鼎诚价：￥459.00</span>
                                                <span class="name">伊莱克斯（Electrolux）</span>
                                            </a>
                                        </li>
                                        <li>
                                            <div class="picBox">
                                                <span>热卖</span>
                                                <a href="#"><img src="pictures/productPic.gif" /></a>
                                            </div>
                                            <a href="#">
                                                <span class="price">鼎诚价：￥459.00</span>
                                                <span class="name">伊莱克斯（Electrolux）</span>
                                            </a>
                                        </li>
                                        <li>
                                            <div class="picBox">
                                                <span>特价</span>
                                                <a href="#"><img src="pictures/productPic.gif" /></a>
                                            </div>
                                            <a href="#">
                                                <span class="price">鼎诚价：￥459.00</span>
                                                <span class="name">伊莱克斯（Electrolux）</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        
                        <div class="box4 newline">
                            <ul class="title">
                                <li class="left"></li>
                                <li><span>新品上架</span></li>
                                <li class="right"></li>
                                <li class="more"><a class="more1" href="#"></a></li>
                            </ul>
                            <div class="content">
                                <ul class="thumbnailList_1">
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <ul class="bottom">
                               <li class="left"></li>
                               <li class="right"></li>
                            </ul>
                        </div>
                        
                        <div class="box4 newline">
                            <ul class="title">
                                <li class="left"></li>
                                <li><span>直降特卖</span></li>
                                <li class="right"></li>
                                <li class="more"><a class="more1" href="#"></a></li>
                            </ul>
                            <div class="content">
                                <ul class="thumbnailList_1">
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <ul class="bottom">
                               <li class="left"></li>
                               <li class="right"></li>
                            </ul>
                        </div>
                        
                        <div class="box3 newline">
                            <div class="left"></div>
                            <div class="right"></div>
                            <div class="middle">
                                <div class="boxContainer">
                                    <ul class="infos clearfix">
                                        <li>
                                            <span>最新拍卖</span>
                                            <a href="#">最热门的主流商务投影</a>
                                            <a href="#">机联想个人投影3199元团购</a>
                                            <a href="#">三星7999元投影送谁？</a>
                                            <a href="#">2019年世界什么样</a>
                                            <a href="#">顶级家庭影院啥样？</a>
                                            <a href="#">LED光源09年能否上位？</a>
                                            <a href="#">最热门的主流商务投影</a>
                                        </li>
                                        <li>
                                            <span>二手信息</span>
                                            <a href="#">最热门的主流商务投影</a>
                                            <a href="#">机联想个人投影3199元团购</a>
                                            <a href="#">三星7999元投影送谁？</a>
                                            <a href="#">2019年世界什么样</a>
                                            <a href="#">顶级家庭影院啥样？</a>
                                            <a href="#">LED光源09年能否上位？</a>
                                            <a href="#">最热门的主流商务投影</a>
                                        </li>
                                        <li>
                                            <span>最新交易</span>
                                            <a href="#">最热门的主流商务投影</a>
                                            <a href="#">机联想个人投影3199元团购</a>
                                            <a href="#">三星7999元投影送谁？</a>
                                            <a href="#">2019年世界什么样</a>
                                            <a href="#">顶级家庭影院啥样？</a>
                                            <a href="#">LED光源09年能否上位？</a>
                                            <a href="#">最热门的主流商务投影</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    
                    </div>
                </div>
            </div>
            <!--MainBody End-->            
            <dd:CMSTag ID="cmsTag1" Description="鼎鼎标准尾标签" TagID="3" runat="server" />
        </div>
    </form>
</body>
</html>
