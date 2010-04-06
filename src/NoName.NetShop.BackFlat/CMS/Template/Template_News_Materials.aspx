<%@ Page Language="C#" AutoEventWireup="true" Inherits="NoName.NetShop.BackFlat.CMS.Template.Template" %>
<%@ Register Assembly="NoName.NetShop.CMS" Namespace="NoName.NetShop.CMS" TagPrefix="dd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>视听资讯</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link type="text/css" rel="stylesheet" href="/css/common.css" />
    <link type="text/css" rel="stylesheet" href="/css/news.css" />
    <link type="text/css" rel="stylesheet" href="/css/Rainy.css" />
    <script type="text/javascript" src="/js/DingdingJsLib.js"></script>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/mini-Rainy.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">    
            <dd:CMSTag ID="cmsTag1" Description="鼎鼎标准头标签" TagID="2" runat="server" ></dd:CMSTag>
            <!--Position Begin-->
            <dd:CMSTag ID="cmsTag3" Description="导航条" TagID="1" runat="server" />
            <!--Position End-->
            
            <!--MainBody Begin-->
            <div class="newsMaterialsHome_mainbody clearfix newline">
		        <div class="leftColumn">
                    <dd:CMSTag ID="cmsTag4" Description="分类导航" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag5" Description="热门资料排行榜" TagID="1" runat="server" />
                </div>
                <div class="rightColumn">
        	        <div class="rightColumnContainer">
                        <div class="box1">
                            <ul class="title">
                                <li class="left"></li>
                                <li><span>影音资料馆</span></li>
                                <li class="right"></li>
                            </ul>
                            <div class="content">
                                <dd:CMSTag ID="cmsTag6" Description="视频资料" TagID="1" runat="server" />
                                <dd:CMSTag ID="cmsTag7" Description="音频资料" TagID="1" runat="server" />
                            </div>
                            <ul class="bottom">
                               <li class="left"></li>
                               <li class="right"></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!--MainBody End-->

            <dd:CMSTag ID="cmsTag2" Description="鼎鼎标准尾标签" TagID="3" runat="server" ></dd:CMSTag>
        </div>
    </form>
</body>
</html>
