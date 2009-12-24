<%@ Page Language="C#" AutoEventWireup="true" Inherits="NoName.NetShop.BackFlat.CMS.Template.Template" %>
<%@ Register Assembly="NoName.NetShop.CMS" Namespace="NoName.NetShop.CMS" TagPrefix="dd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <dd:CMSTag ID="cmsTag3" Description="左1影音套装" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag4" Description="左2商品分类" TagID="1" runat="server" />
                </div>
                <div class="rightColumn">
                    <dd:CMSTag ID="cmsTag10" Description="右1鼎鼎快讯" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag12" Description="右2资讯排行榜" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag13" Description="右3热卖榜单" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag14" Description="右4调查投票" TagID="1" runat="server" />
                </div>
                <div class="midColumn">
                    <div class="midColumnContainer">
                        <dd:CMSTag ID="cmsTag5" Description="中1焦点图" TagID="1" runat="server" />
                        <dd:CMSTag ID="cmsTag6" Description="中2特价商品" TagID="1" runat="server" />
                        <dd:CMSTag ID="cmsTag7" Description="中3新品上架" TagID="1" runat="server" />
                        <dd:CMSTag ID="cmsTag8" Description="中4直降特卖" TagID="1" runat="server" />
                        <dd:CMSTag ID="cmsTag9" Description="中5资讯区域" TagID="1" runat="server" />
                    </div>
                </div>
            </div>
            <!--MainBody End-->            
            <dd:CMSTag ID="cmsTag2" Description="鼎鼎标准尾标签" TagID="3" runat="server" />
        </div>
    </form>
</body>
</html>
