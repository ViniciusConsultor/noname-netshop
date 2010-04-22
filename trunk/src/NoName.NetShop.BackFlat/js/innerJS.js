docTitle = document.title; 
if(docTitle == null){ 
    var t_titles = document.getElementByTagName("title") 
    if(t_titles && t_titles.length >0) 
    { 
       docTitle = t_titles[0]; 
    }else{ 
       docTitle = ""; 
    } 
}
parent.document.getElementById("currentPostion").innerHTML=docTitle;