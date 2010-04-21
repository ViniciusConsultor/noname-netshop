<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Solution.Home" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script src="/js/customizeHome.js" type="text/javascript"></script>
    <script src="/js/AC_RunActiveContent.js" type="text/javascript"></script>
    <script src="/js/jquery.query.js" type="text/javascript"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/solution">解决方案</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="/solution/Demand.aspx">按需制定</a>
                <a class="button_blue" href="/solution/SuiteList.aspx">推荐套装</a>
                <a class="button_blue2" href="/solution/Home.aspx">经典套装</a>
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
                    <div class="box9 expanded">
                    	<div class="title" onclick="expandGroup(this)">私人影院</div>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a id="suite0" href="javascript:void(0)" onclick="selectSuite(this,0)">入门家庭影院</a>
                                </li>
                                <li>
                                    <a id="suite1" href="javascript:void(0)" onclick="selectSuite(this,1)">客厅家庭影院</a>
                                </li>
                                <li>
                                    <a id="suite2"  href="javascript:void(0)" onclick="selectSuite(this,2)">标准家庭影院</a>
                                </li>
                                <li>
                                    <a id="suite3"  href="javascript:void(0)" onclick="selectSuite(this,3)">顶级家庭影院</a>
                                </li>
                            </ul>
                   		</div>
                    </div>
                    <div class="box9 newline collapsed">
                    	<div class="title" onclick="expandGroup(this)">办公会议</div>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a id="suite4" href="javascript:void(0)" onclick="selectSuite(this,4)">小型会议室</a>
                                </li>
                                <li>
                                    <a id="suite5" href="javascript:void(0)" onclick="selectSuite(this,5)">中型会议室</a>
                                </li>
                                <li>
                                    <a id="suite6"  href="javascript:void(0)" onclick="selectSuite(this,6)">大型会议室</a>
                                </li>
                                <li>
                                    <a id="suite7"  href="javascript:void(0)" onclick="selectSuite(this,7)">大型报告厅</a>
                                </li>
                            </ul>
                   		</div>
                    </div>
                    <div class="box9 newline collapsed">
                    	<div class="title" onclick="expandGroup(this)">教学培训</div>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a id="suite8" href="javascript:void(0)" onclick="selectSuite(this,8)">40人教室</a>
                                </li>
                                <li>
                                    <a id="suite9" href="javascript:void(0)" onclick="selectSuite(this,9)">60人教室</a>
                                </li>
                                <li>
                                    <a id="suite10"  href="javascript:void(0)" onclick="selectSuite(this,10)">90人教室</a>
                                </li>
                                <li>
                                    <a  id="suite11" href="javascript:void(0)" onclick="selectSuite(this,11)">120人报告厅</a>
                                </li>
                            </ul>
                   		</div>
                    </div>
                    <div class="box9 newline collapsed">
                    	<div class="title" onclick="expandGroup(this)">休闲娱乐</div>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a id="suite12" href="javascript:void(0)" onclick="selectSuite(this,12)">星级客房</a>
                                </li>
                                <li>
                                    <a id="suite13" href="javascript:void(0)" onclick="selectSuite(this,13)">餐饮休闲</a>
                                </li>
                                <li>
                                    <a id="suite14"  href="javascript:void(0)" onclick="selectSuite(this,14)">KTV包房</a>
                                </li>
                                <li>
                                    <a id="suite15" href="javascript:void(0)" onclick="selectSuite(this,15)">养生会所</a>
                                </li>
                            </ul>
                   		</div>
                    </div>
                    <div class="box9 newline collapsed">
                    	<div class="title" onclick="expandGroup(this)">公共展示</div>
                        <div class="content">
                            <ul class="articleList_1 bullet_2">
                                <li>
                                    <a id="suite16" href="javascript:void(0)" onclick="selectSuite(this,16)">信息发布</a>
                                </li>
                                <li>
                                    <a id="suite17" href="javascript:void(0)" onclick="selectSuite(this,17)">公共展示</a>
                                </li>
                                <li>
                                    <a id="suite18"  href="javascript:void(0)" onclick="selectSuite(this,18)">大屏监控</a>
                                </li>
                                <li>
                                    <a id="suite19"  href="javascript:void(0)" onclick="selectSuite(this,19)">活动中心</a>
                                </li>
                            </ul>
                   		</div>
                    </div>
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