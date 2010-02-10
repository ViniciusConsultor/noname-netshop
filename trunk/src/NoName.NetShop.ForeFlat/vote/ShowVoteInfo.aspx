<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVoteInfo.aspx.cs" Inherits="NoName.NetShop.ForeFlat.vote.ShowVoteInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1"  target="_blank" action="DoVote.aspx">
<div class="voteCanvas">
	<div class="bgForRightBottom">
    	<div class="voteMainbody">
    	<h1>
    	<input type="hidden" name="voteId" value='<%=Request.QueryString["voteId"] %>' />
    	<asp:Literal runat="server" ID="litTitle"></asp:Literal></h1>
    	<code><asp:Literal runat="server" ID="litContent"></asp:Literal></code>
    	<asp:Repeater runat="server" ID="rpList" onitemdatabound="rpList_ItemDataBound">
    	<ItemTemplate>
        	<h1><%# Eval("Subject") %></h1>
        	<code><%# Eval("Content") %></code>
            <ul>
            <asp:Repeater runat="server" ID="rpItem">
            <ItemTemplate>
            	<li>
                	<span class="option">
                	<input type="checkbox" name="itemId" value='<%#Eval("ItemId") %>' /><%#Eval("ItemContent")%> </span>
                </li>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
     	</ItemTemplate>
    	</asp:Repeater>
               	<span class="button">
               	<input type="submit" value="提交" />
                    </span>
        </div>
    </div>
</div>
    </form>
</body>
</html>
