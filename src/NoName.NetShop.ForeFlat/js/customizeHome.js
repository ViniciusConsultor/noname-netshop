function loadingComponentList(){
	document.getElementById("componentList").innerHTML="组件列表加载中...";
}

function createComponentList(data){
	var componentList=data.split(",");
	var tempStr="";
	for (var i=0;i<componentList.length;i++){
		tempStr+='<span><input type="checkbox"  class="checkbox" onclick="changeComponentStatu(this,' + i + ')"/><label>'+componentList[i]+'</label></span>';
	}
	document.getElementById("componentList").innerHTML=tempStr;
}

function changeComponentStatu(obj,i){
	var action=obj.checked?"show":"hide";
	window.document.customizeFlash.changeComponentStatus(action,i);
}

function selectSuite(obj,index){
	var lis=obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.getElementsByTagName("li");
	for(var i=0;i<lis.length;i++){
		if(lis[i].getElementsByTagName("a")[0]){
			lis[i].getElementsByTagName("a")[0].className="";
		}
	}
	obj.className="bold";
	window.document.customizeFlash.selectSuite(index);
}

function showSuiteList(){
	document.getElementById("suiteListContainer").innerHTML=document.getElementById("suiteList").innerHTML;
}

function resetComponents(){
	var listObj=document.getElementById("componentList");
	for(var i=0;i<listObj.getElementsByTagName("span").length;i++){
		listObj.getElementsByTagName("span")[i].getElementsByTagName("input")[0].checked=false;
	}
}

function expandGroup(obj){
	for(var i=0;i<obj.parentNode.parentNode.getElementsByTagName("div").length;i++){
		//alert(obj.parentNode.parentNode.getElementsByTagName("div")[i].className)
		obj.parentNode.parentNode.getElementsByTagName("div")[i].className=obj.parentNode.parentNode.getElementsByTagName("div")[i].className.replace("expanded","collapsed")
	}
	obj.parentNode.className=obj.parentNode.className.replace("collapsed","expanded");
}