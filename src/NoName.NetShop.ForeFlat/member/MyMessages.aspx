<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyMessages" %>

<%@ Register Assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.DynamicData" TagPrefix="cc2" %>

<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的站内信</a>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
<link href="../css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.3.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
<script src="../js/date.js" type="text/javascript"></script>
    
<div id="dialog" title="站内信" style="display:none">
	<p>
	</p>
</div>
<script type="text/javascript">
    $.ui.dialog.defaults.bgiframe = true;
    function showMessage(msgId) {
        $.ajax({
            type: "POST",
            url: "../api/CartOpenApi.ashx",
            data: "action=getmessage&msgId=" + msgId,
            dataType: "json",
            success: function(data) {
                if (data) {
                    var inserttime = eval('new' + data.InsertTime.replace(/\//g, ' '));
                    datastr = inserttime.pattern('yyyy-MM-dd HH:mm');

                    var msg = "<div>" + data.Subject + "（发送时间：" + datastr + "）</div>";
                    msg += "<div>" + data.Content + "</div>";
                    $("#dialog").find("p").html(msg);
                    $("#dialog").dialog({ autoOpen: false }).dialog("open");
                }
            }
        });
    }
</script>

            <div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的站内信</span></li>
                    <li class="right"></li>
                </ul>
                
                	<div class="box6" id="panNotice" runat="server">
                    	<div class="title">公告信息</div>
   
                           <div class="content noPaddingContentBox">
                            <div class="table2">
                                <table>
                                  <tr>
                                    <th><span>标题</span></th>
                                    <th><span>收件时间</span></th>
                                    <th class="last actions"><span>查看</span></th>
                                  </tr>
                                  <asp:Repeater runat="server" ID="rpNotice">
                                  <ItemTemplate>
                                  <tr class="odd">
                                    <td><%#Eval("Subject") %></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td>
                                    	<a href="javascript:void(0)" onclick="showMessage('<%# Eval("msgId") %>')" class="iconButton viewMessage"></a>
                                    </td>
                                  </tr>
                                  </ItemTemplate>
                                  <AlternatingItemTemplate>
                                  <tr class="even">
                                    <td><%#Eval("Subject") %></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td>
                                    	<a href="javascript:void(0)" onclick="showMessage('<%# Eval("msgId") %>')" class="iconButton viewMessage"></a>
                                    </td>
                                  </tr>
                                  </AlternatingItemTemplate>
                                  </asp:Repeater>
                                  </table>
                            </div>
                        </div>                 	
                    	
                    </div>
<div style="height:10px"></div>

                	<div class="box6">
                    	<div class="title">已收短信</div>
   
                           <div class="content noPaddingContentBox">
                            <div class="table2">
                                <table>
                                  <tr>
                                    <th class="first checkBox"><span>选择</span></th>
                                    <th><span>标题</span></th>
                                    <th><span>收件时间</span></th>
                                    <th><span>发件人</span></th>
                                    <th class="last actions"><span>操作</span></th>
                                  </tr>
                                  <asp:Repeater runat="server" ID="rpList" onitemcommand="rpList_ItemCommand">
                                  <ItemTemplate>
                                  <tr class="odd">
                                    <td><input type="checkbox" name="msgid" value='<%#Eval("msgId") %>' /></td>
                                    <td><%#Eval("Subject") %></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td><%#Eval("SenderId") %></td>
                                    <td>
                                    	<a href="javascript:void(0)" onclick="showMessage('<%# Eval("msgId") %>')" class="iconButton viewMessage"></a>
                                        <asp:LinkButton  runat="server" CommandName="delete" CommandArgument='<%# Eval("msgId") %>' CssClass="iconButton delete"></asp:LinkButton>
                                    </td>
                                  </tr>
                                  </ItemTemplate>
                                  <AlternatingItemTemplate>
                                  <tr class="even">
                                    <td><input type="checkbox" name="msgid" value='<%#Eval("msgId") %>' /></td>
                                    <td><%#Eval("Subject") %></td>
                                    <td><%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%></td>
                                    <td><%#Eval("SenderId") %></td>
                                    <td>
                                    	<a href="javascript:void(0)" onclick="showMessage('<%# Eval("msgId") %>')" class="iconButton viewMessage"></a>
                                        <asp:LinkButton  runat="server" CommandName="delete" CommandArgument='<%# Eval("msgId") %>' CssClass="iconButton delete"></asp:LinkButton>
                                    </td>
                                  </tr>
                                  </AlternatingItemTemplate>
                                  </asp:Repeater>
                                  <tr class="bottom">
                                  	<td><a href="javascript:void(0)" onclick="selectAll(this,this.parentNode.parentNode.parentNode)">全选</a></td>
                                    <td colspan="4">
                                    	<asp:LinkButton CssClass="button_blue" ID="btnBatDelete" runat="server" Text="删　除" 
                                            onclick="btnBatDelete_Click"></asp:LinkButton>
                                        <div class="pagination">
                                    <cc1:AspNetPager ID="pageNav"  runat="server" HorizontalAlign="Center" 
                                                CssClass="pageNum" onpagechanged="pageNav_PageChanged">
                                    </cc1:AspNetPager>

                                        </div>
                                    </td>
                                  </tr>
                                </table>
                            </div>
                        </div>                 	
                    	
                    </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
