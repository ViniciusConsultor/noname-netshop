<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteResult.aspx.cs" Inherits="NoName.NetShop.ForeFlat.vote.VoteResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>查看调查结果</title>
<link type="text/css" rel="stylesheet" href="/css/common.css" />
<link type="text/css" rel="stylesheet" href="/css/others.css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="voteCanvas">
	<div class="bgForRightBottom">
    	<div class="voteMainbody">
    	<h1><asp:Literal runat="server" ID="litTitle"></asp:Literal></h1>
    	<code><asp:Literal runat="server" ID="litContent"></asp:Literal></code>
    	<asp:Repeater runat="server" ID="rpList" onitemdatabound="rpList_ItemDataBound">
    	<ItemTemplate>
        	<h1><%# Eval("Subject") %></h1>
        	<code><%# Eval("Content") %></code>
            <ul>
            <asp:Repeater runat="server" ID="rpItem">
            <ItemTemplate>
            	<li>
                	<span class="option"><%#Eval("ItemContent")%></span>
                    <div class="votebarParent">
                        <div style="width:<%# Eval("Percent") %>%">
                            <div class="votebar votebar1">
                                <div class="light"></div>
                            </div>
                        </div>
                    </div>
                    <span class="result"><%#Eval("VoteCount")%>(<%# Eval("Percent") %>)</span>
                </li>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
     	</ItemTemplate>
    	</asp:Repeater>
               	<span class="button">
                    	<a class="button_blue2" href="#">关闭</a>
                    </span>
        </div>
    </div>
</div>
    </form>
</body>
</html>
