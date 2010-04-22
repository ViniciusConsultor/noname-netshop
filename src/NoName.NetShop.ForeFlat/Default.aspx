<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoName.NetShop.ForeFlat._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>

    <script src="js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <span id="abc"></span>
<script type="text/javascript" src="js/noname.identtity.js"></script>
<script type="text/javascript">
    var iden = new Identity();
    iden.Show($("#abc"));
</script>

    <span id="vote"></span>
<script type="text/javascript" src="js/noname.vote.js"></script>
<script type="text/javascript">
    var vote = new VoteInfo();
    vote.Show($("#vote"),1);
</script>
    </div>
    </form>
</body>
</html>
