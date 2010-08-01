<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PawnShop.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.PawnShop" %>


<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script type="text/javascript">
        if(Rainy.ie){
	        window.attachEvent("onload", this.showMainScene);
        }else{
	        window.addEventListener("load", this.showMainScene, false);
        };

        function showMainScene(){
	        document.getElementById("mainSceneParent").style.backgroundImage="none";
	        document.getElementById("mainSceneParent").style.height="auto";
	        document.getElementById("mainSceneContent").style.display="block";
        }
    </script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="#">视听当铺</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealList.aspx">二手交易</a>
                <a class="button_blue2" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicPawnShopHome_mainbody newline">
    	<div id="rules" style="display:none">
        	<div class="rulesContent">
        	<p>春暖花开，大地复苏。春节之后天气也逐渐暖和起来，短暂的寒假也将告一段落，轻松的假期之后学生朋友们也要为新一阶段的学习生活做好准备。三星显示器从2月开始启动了最新的春季促销活动方案，打出了“买三星显示器，赢三星C288至酷手机！”的口号，活动一直持续到3月31日。</p>
            <p>
本次促销方案依然以送刮刮卡为主，当然参加活动的显示器型号依然由官方指定。详细液晶型号为： T190/T190P/2033SW/2243SW/2243EW/2233SW/T220/T220G/T220P/2232MW及23寸以上型号(含 23寸)(批量订单不参加活动)。</p>
			<p>春暖花开，大地复苏。春节之后天气也逐渐暖和起来，短暂的寒假也将告一段落，轻松的假期之后学生朋友们也要为新一阶段的学习生活做好准备。三星显示器从2月开始启动了最新的春季促销活动方案，打出了“买三星显示器，赢三星C288至酷手机！”的口号，活动一直持续到3月31日。</p>
            <p>
本次促销方案依然以送刮刮卡为主，当然参加活动的显示器型号依然由官方指定。详细液晶型号为： T190/T190P/2033SW/2243SW/2243EW/2233SW/T220/T220G/T220P/2232MW及23寸以上型号(含 23寸)(批量订单不参加活动)。</p>
			<p>春暖花开，大地复苏。春节之后天气也逐渐暖和起来，短暂的寒假也将告一段落，轻松的假期之后学生朋友们也要为新一阶段的学习生活做好准备。三星显示器从2月开始启动了最新的春季促销活动方案，打出了“买三星显示器，赢三星C288至酷手机！”的口号，活动一直持续到3月31日。</p>
            <p>
本次促销方案依然以送刮刮卡为主，当然参加活动的显示器型号依然由官方指定。详细液晶型号为： T190/T190P/2033SW/2243SW/2243EW/2233SW/T220/T220G/T220P/2232MW及23寸以上型号(含 23寸)(批量订单不参加活动)。</p>
			</div>
        </div>
        <script type="text/javascript">
		var pawnShopRules=new Rainy.popupWindow({
			id:"pawnShopRules",
			width:600,
			height:390,
			cls:"",
			title:"当铺规则",
			content:document.getElementById("rules").innerHTML
		});
		</script>
		<div id="mainSceneParent">
            <div class="pawnShopMainContainer" id="mainSceneContent" style="display:none">
                <a class="actionBtn btn1" href="javascript:void(0);" onclick="pawnShopRules.render();"></a>
                <a class="actionBtn btn2" href="#"></a>
                <a class="actionBtn btn3" href="#"></a>
                <a class="moreBtn btn4" href="#"></a>
                <a class="moreBtn btn5" href="#"></a>
                <ul class="shelf1">
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                </ul>
                <ul class="shelf2">
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                    <li><a href="#"><img src="Pictures/productThumb.jpg" /></a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>