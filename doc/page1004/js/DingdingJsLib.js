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