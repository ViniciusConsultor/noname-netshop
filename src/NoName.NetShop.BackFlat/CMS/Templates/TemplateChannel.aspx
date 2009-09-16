<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateChannel.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Templates.Template" %>
<%@ Register Assembly="NoName.NetShop.CMS" Namespace="NoName.NetShop.CMS" TagPrefix="NetShop" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>测试模板</title>
    <style type="text/css">
        #header{width:960px;margin:0 auto;height:120px;border:1px solid #ccc;}
        #footer{width:960px;margin:0 auto;height:120px;border:1px solid #ccc;}
        #wrapper{width:960px;margin:0 auto;border:1px solid #eee;}
        .left{float:left;width:200px;}
        .right{float:right;width:740px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <NetShop:CMSTag ID="CMSTag1" Description="页面头部区域" TagID="1" runat="server"/>
        </div>
        <div id="wrapper">
            <div class="left">
                <NetShop:CMSTag ID="CMSTag2" Description="正文左部区域" TagID="1" runat="server"/>
            </div>
            <div class="right">
                <NetShop:CMSTag ID="CMSTag3" Description="正文右部区域" TagID="1" runat="server"/>
            </div>
            <div style="clear:both;"></div>
        </div>
        <div id="footer">
            <NetShop:CMSTag ID="CMSTag4" Description="页面底部区域" TagID="1" runat="server"/>        
        </div>
    </form>
</body>
</html>
