<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Solution.Home" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script src="/js/customizeHome.js" type="text/javascript"></script>
    <script src="/js/AC_RunActiveContent.js" type="text/javascript"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">解决方案</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="#">按需制定</a>
                <a class="button_blue" href="#">推荐套装</a>
                <a class="button_blue2" href="#">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionHome_mainbody newline clearfix">
		<div class="leftColumn">
		  <div class="box2">
          <ul class="title">
                    <li class="left"></li>
                    <li><span>选择场景</span></li>
                    <li class="right"></li>
                </ul>
                <div id="suiteList" style="display:none">
                    <ul class="articleList_1 bullet_2">
                        <li>
                            <a href="javascript:void(0)" onclick="selectSuite(this,0)" class="bold">入门家庭影院</a>
                        </li>
                        <li>
                            <a href="javascript:void(0)" onclick="selectSuite(this,1)">多媒体教学</a>
                        </li>
                        <li>
                            <a  href="javascript:void(0)" onclick="selectSuite(this,2)">家庭影院</a>
                        </li>
                        <li>
                            <a href="#">影音娱乐</a>
                        </li>
                        <li>
                            <a href="#">影音游戏</a>
                        </li>
                        <li>
                            <a href="#">影音互动</a>
                        </li>
                        <li>
                            <a href="#">影音展示</a>
                        </li>
                        <li>
                            <a href="#">影音无线传输</a>
                        </li>
                        <li>
                            <a href="#">影像拼接</a>
                        </li>
                        <li>
                            <a href="#">智能影音</a>
                        </li>
                        <li>
                            <a href="#">背景音乐</a>
                        </li>
                    </ul>
                </div>
                <div class="content suiteListContainer" id="suiteListContainer">
					<div>套装列表加载中...</div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
        </div>
        
        <div class="rightColumn">
		  <div class="box2">
          <ul class="title">
                    <li class="left"></li>
                    <li><span>组件列表</span></li>
                    <li class="right"></li>
            </ul>
                <div class="content">
                  <div class="category_non-popMenu clearfix">
                        <div class="subs clearfix componentList" id="componentList">
                        	组件列表加载中...
                    </div>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
          </div>
            
        </div>
        <div class="mainColumn">
        	<div class="mainColumnContainer"> 
           	  <script type="text/javascript">
				AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0','width','530','height','400','src','flash/CustomizeSuite','quality','high','pluginspage','http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash','id','customizeFlash','name','customizeFlash','allowscriptaccess','sameDomain','movie','flash/CustomizeSuite' ); //end AC code
				</script>
				<noscript>
				<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="530" height="400">
				  <param name="movie" value="flash/CustomizeSuite.swf" />
				  <param name="quality" value="high" />
				  
				  <param name="id" value="customizeFlash" />
				  <param name="name" value="customizeFlash" />
				  <param name="allowScriptAccess" value="sameDomain" />
				  <embed src="flash/CustomizeSuite.swf" width="530" height="400" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" id="customizeFlash" name="customizeFlash" allowscriptaccess="sameDomain"></embed>
				</object>
			  </noscript>
          </div>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>