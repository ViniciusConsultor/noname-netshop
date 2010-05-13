checkLoadCategory();
function checkLoadCategory(){
if (document.getElementById("checkLoadCate")!==null){
showSubCategory();clearTimeout(cateTimer)
}else{var cateTimer=setTimeout("checkLoadCategory()",500)}
}

function showSubCategory(){
 var allNodes=document.getElementsByTagName("*");
 for (i=0;i<allNodes.length;i++){
  if (allNodes[i].getAttribute('rel')=='cateMenu'){allNodes[i].onmouseover=cateMenuHover;allNodes[i].onmouseout=cateMenuNormal}
 }
 
 function cateMenuHover(e){
 	var targ;
    if (!e) var e = window.event
    if (e.target) targ = e.target
    else if (e.srcElement) targ = e.srcElement
    if (targ.nodeType == 3) targ = targ.parentNode// defeat Safari bug
	
	do{
	if(targ.getAttribute("rel")!=="cateMenu"){targ=targ.parentNode}else{break}
	}while(1)

	targ.className="cateMenu_hover";
	getElementsByClassName(targ,"popShadow")[0].style.height=getElementsByClassName(targ,"pop")[0].clientHeight+"px";
 }
  function cateMenuNormal(e){
 	var targ
    if (!e) var e = window.event
    if (e.target) targ = e.target
    else if (e.srcElement) targ = e.srcElement;
    if (targ.nodeType == 3) targ = targ.parentNode;// defeat Safari bug
	
	do{
	if(targ.getAttribute("rel")!=="cateMenu"){targ=targ.parentNode}else{break}
	}while(1)	
	
 targ.className="cateMenu_normal" 
 }
}

function getElementsByClassName(parentElement,ClassName){
	var result=new Array();
    for(i=0;i<parentElement.getElementsByTagName("*").length;i++){
	    if(parentElement.getElementsByTagName("*")[i].className==ClassName){
			result.push(parentElement.getElementsByTagName("*")[i]);
		}
	}
	return result;
}

function TabTransfer(obj){
	obj.blur();
    obj.className="Tab_on";
	for(i=0;i<obj.parentNode.getElementsByTagName("a").length;i++){
	    if(obj.parentNode.getElementsByTagName("a")[i]!==obj){
		    obj.parentNode.getElementsByTagName("a")[i].className="Tab_off";
		}
	}
	
	getElementsByClassName(obj.parentNode.parentNode.parentNode,"content")[0].innerHTML=document.getElementById(obj.getAttribute("rel")).innerHTML;
	showSubCategory();
}

function transferTab2(obj){
	obj.blur();
    obj.className="on";
	for(i=0;i<obj.parentNode.getElementsByTagName("a").length;i++){
	    if(obj.parentNode.getElementsByTagName("a")[i]!==obj){
		    obj.parentNode.getElementsByTagName("a")[i].className="";
		}
	}
	getElementsByClassName(obj.parentNode.parentNode,"content")[0].innerHTML=document.getElementById(obj.getAttribute("rel")).innerHTML;
}

function selectAll(obj,container){
	obj.blur();
	var checkBoxes=container.getElementsByTagName("input");
	if(obj.state!=="cancelAll"){
		for(i=0;i<checkBoxes.length;i++){
			if(checkBoxes[i].type=="checkbox"){
				checkBoxes[i].checked="checked";
				checkBoxes[i].onclick=function(e){
					obj.innerHTML="全选";
					obj.state="selectAll";
				}
			}
		}
		obj.innerHTML="取消全选";
		obj.state="cancelAll";
	}else{
		for(i=0;i<checkBoxes.length;i++){
			if(checkBoxes[i].type=="checkbox"){
				checkBoxes[i].checked="";
			}
		}
		obj.innerHTML="全选";
		obj.state="selectAll";
	}
}

function viewTransfer(obj){
	obj.blur();
	var btns=obj.parentNode.getElementsByTagName("a");
	for(i=0;i<btns.length;i++){
		if(btns[i].className.split("_on")){btns[i].className=btns[i].className.split("_on")[0]}	
	}
	obj.className+="_on";
	if (obj.className.indexOf("vertical")!==-1){
		document.getElementById("productList").className="list_vertical";
	}else{
		document.getElementById("productList").className="list_horizontal";
	}
	document.getElementById("productList").innerHTML=document.getElementById("productList").innerHTML; //for IE6 bug
}

function selectFile(obj,id){
	document.getElementById(id).value=obj.value;
}

function addPicture(){
	var firstPictureNode=document.getElementById("productPictures");
	if(firstPictureNode.clickedAddPicture!==true){
		firstPictureNode.clickedAddPicture=true;
		firstPictureNode.currentNumber=0;
		firstPictureNode.lastNode=getNextsibling(firstPictureNode);
	}
	firstPictureNode.currentNumber+=1;
	
	var liNode=document.createElement("li");
	var tempStr="";
	tempStr='';
	tempStr+='<span class="field"></span>';
	tempStr+='<div class="fileSelector">';
	tempStr+='<input type="text" class="textField" id="productPic'+ firstPictureNode.currentNumber + '" readonly="readonly" />';
	tempStr+='<a class="button_blue" href="javascript:void(0)">';
	tempStr+='<input type="file" size="1" name="productPic'+ firstPictureNode.currentNumber + '"  class="realFile" hidefocus=”true” onchange="selectFile(this,\'productPic' + firstPictureNode.currentNumber + '\')"/>';
	tempStr+='<lable>浏  览</lable>';
	tempStr+='</a>';
	tempStr+='</div>';
	liNode.innerHTML=tempStr;
	firstPictureNode.parentNode.insertBefore(liNode,firstPictureNode.lastNode);
}

function zoomInThumb(e,obj){
	var targetArea=getElementsByClassName(obj,"targetArea")[0];
	var zoomArea=getElementsByClassName(obj,"zoomInArea")[0];
	showZoomIn();
	obj.onmouseout=hideZoomIn;
	var scrollLeft=document.documentElement.scrollLeft?document.documentElement.scrollLeft:document.body.scrollLeft;
	var scrollTop=document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop;
	if((scrollLeft+e.clientX-getXY(obj).l)>(obj.clientWidth-2)){hideZoomIn();}
	
	var left=scrollLeft+e.clientX-getXY(obj).l-targetArea.clientWidth/2;
	var top=scrollTop+e.clientY-getXY(obj).t-targetArea.clientHeight/2;
	
	if(left<0){
		left=0;		
	}else if(left>obj.clientWidth-targetArea.clientWidth-2){
		left=obj.clientWidth-targetArea.clientWidth-2;
	}
	targetArea.style.left=left+"px";
	
	if(top<0){
		top=0;		
	}else if(top>obj.clientHeight-targetArea.clientHeight-2){
		top=obj.clientHeight-targetArea.clientHeight-2;
	}
	targetArea.style.top=top+"px";
	
	zoomArea.scrollLeft=parseInt(targetArea.style.left)*3;
	zoomArea.scrollTop=parseInt(targetArea.style.top)*3;
		
	function hideZoomIn(){
		zoomArea.style.display="none";
		targetArea.style.display="none";
	}
	
	function showZoomIn(){
		zoomArea.style.display="block";
		targetArea.style.display="block";
	}
}

function selectProductPicture(obj,i){
	obj.blur();
	var elements=obj.parentNode.getElementsByTagName("a");
	for(var j in elements){
		elements[j].className="";
	}
	obj.className="selected";
	document.getElementById("mainThumbArea").innerHTML=document.getElementById("productThumb"+i).innerHTML;
}

function productThumbListScroll(obj,type){
	var picWidth=74;
	if(obj){obj.blur()}
	if((type=="next")&&(document.getElementById("picList").scrollLeft<(document.getElementById("scrollContainer").getElementsByTagName("a").length-4)*picWidth)){
		document.getElementById("picList").scrollLeft+=picWidth;
	}else if((type=="prev")&&(document.getElementById("picList").scrollLeft>0)){
		document.getElementById("picList").scrollLeft-=picWidth;
	}
	
	document.getElementById("nextBtn").className="nextBtn";
	document.getElementById("prevBtn").className="prevBtn";
	if(document.getElementById("picList").scrollLeft>=(document.getElementById("scrollContainer").getElementsByTagName("a").length-4)*picWidth){
		document.getElementById("nextBtn").className="nextBtn disabled"
	}
	if(document.getElementById("picList").scrollLeft<=0){
		document.getElementById("prevBtn").className="prevBtn disabled"
	}
}

var getXY = function(el){
				var d = document,
					bd = d.body,
					r={t:0,l:0},
					ua = navigator.userAgent.toLowerCase(),
					isStrict = d.compatMode == "CSS1Compat",
					isGecko = /gecko/.test(ua),
					add = function(t,l){r.l+=l,r.t+=t},
					p = el;
				if(el&&el!=bd){
					if(el.getBoundingClientRect){
						var b = el.getBoundingClientRect();
						add(b.top + Math.max(d.body.scrollTop,d.documentElement.scrollTop),
							b.left+Math.max(d.body.scrollLeft,d.documentElement.scrollLeft));
						isStrict?add(-d.documentElement.clientTop,-d.documentElement.clientLeft):add(-1,-1)
					}else{
						var dv = d.defaultView;
						while(p){
							add(p.offsetTop,p.offsetLeft);
							var computStyle = dv.getComputedStyle( p, null );
							if(isGecko){
								var bl = parseInt(computStyle.getPropertyValue('border-left-width'),10)||0,
									bt = parseInt(computStyle.getPropertyValue('border-top-width'),10)||0;
								add(bt,bl);
								if(p!=el&&computStyle.getPropertyValue('overflow')!='visible')
									add(bt,bl);
							}
							p = p.offsetParent;
						}
						p = el.parentNode;
						while (p && p != bd) {
							add(-p.scrollTop,-p.scrollLeft); 
							p = p.parentNode;
						}
					}
				}
				return r;
			}
			
function getNextsibling(n)
  {
  var x=n.nextSibling;
  while (x.nodeType!=1)
   {
   x=x.nextSibling;
   }
  return x;
  }
  
  
function showPriceSortDropdownList(obj){
	clearTimeout(obj.hideTimer);
	var dropdownList = document.getElementById("priceSortOptions");
	dropdownList.style.display = "block";
}

function hidePriceSortDropdownList(obj){
	obj.hideTimer = setTimeout(function(){
		var dropdownList = document.getElementById("priceSortOptions");
		dropdownList.style.display = "none";
	},100);
}