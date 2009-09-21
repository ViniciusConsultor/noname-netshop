<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoName.NetShop.BackFlat._Default" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>鼎鼎网店管理系统</title>
</head>
<body style="margin:0 0 0 0">
	
<script language="javascript" type="text/javascript">
function switchbar(){
if (switchPoint.innerText==3){
switchPoint.innerText=4
document.all("frm").style.display="none"
}else{
switchPoint.innerText=3
document.all("frm").style.display=""
}}
</script>
<table style=" height:100%"  cellspacing=0 cellpadding=0 width="100%" border=0>
  <tr>
    <td id="frm" style="height: 443px; " ><iframe 
      style="z-index: 2;   width: 200px; height: 100%"
      name=rijcm src="left.aspx"
      frameborder=0></iframe></td>
    <td width=10  style="height: 443px; background-color:#4397c5">
      <table height="100%" cellSpacing="0" cellPadding="0" border="0">
        <tbody>
        <tr>
          <td style="height: 100%" onclick=switchbar()><font
            style="font-size: 9pt; cursor: hand; color: white; font-family: Webdings"><span 
            id="switchPoint">3</span> </font></tr></tbody></table></td>
    <td width="100%" style="height: 443px">
    <div>
<table width="99%" align="center" cellpadding="3" cellspacing="0" border="0">
	<tr class="head">
	<td height="25">
	<span style=" float:left;">系统公告：</span><marquee direction="left">滚动信息</marquee>
	</td>
	<td style="width:200px; text-align:right">
	<script type="text/javascript">
	    var d = new Date();
	    document.write("今天是：" + d.getYear() + "年" + (d.getMonth() + 1) + "月" + d.getDate() + "日");
	</script>
	</td></tr>
</table>

    </div>
      <iframe id="mainFrame" style="z-index: 1; width: 100%; height: 96%"
      name="mainFrame" src="Welcome.aspx" frameBorder="0" scrolling="yes"></iframe>
    </td>
  </tr></table>
	</body>
	

</html>
