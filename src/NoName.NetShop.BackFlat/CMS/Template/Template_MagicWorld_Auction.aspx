<%@ Page Language="C#" AutoEventWireup="true" Inherits="NoName.NetShop.BackFlat.CMS.Template.Template" %>
<%@ Register Assembly="NoName.NetShop.CMS" Namespace="NoName.NetShop.CMS" TagPrefix="dd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>魔力世界</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link type="text/css" rel="stylesheet" href="/css/common.css" />
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <link type="text/css" rel="stylesheet" href="/css/Rainy.css" />
    <script type="text/javascript" src="js/DingdingJsLib.js"></script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/mini-Rainy.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">    
            <dd:CMSTag ID="cmsTag1" Description="鼎鼎标准头标签" TagID="2" runat="server" ></dd:CMSTag>
            <!--Position Begin-->
            <div class="currentPosition">
                <dd:CMSTag ID="cmsTag3" Description="导航条" TagID="1" runat="server" />
            </div>
            <!--Position End-->
            
            <!--MainBody Begin-->
            <div class="magicRentHome_mainbody clearfix newline">
		        <div class="row">
                    <dd:CMSTag ID="cmsTag4" Description="租赁协议" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag5" Description="最新开租" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag6" Description="租赁中的商品" TagID="1" runat="server" />
                </div>
                    
                <div class="row newline">
                    <dd:CMSTag ID="cmsTag7" Description="租赁分类1" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag8" Description="租赁分类2" TagID="1" runat="server" />
                </div>
                <div class="row newline">
                    <dd:CMSTag ID="cmsTag9" Description="租赁分类3" TagID="1" runat="server" />
                    <dd:CMSTag ID="cmsTag10" Description="租赁分类4" TagID="1" runat="server" />
                </div>
                
            </div>
            <!--MainBody End-->

            <dd:CMSTag ID="cmsTag2" Description="鼎鼎标准尾标签" TagID="3" runat="server" ></dd:CMSTag>
        </div>
    </form>
</body>
</html>
