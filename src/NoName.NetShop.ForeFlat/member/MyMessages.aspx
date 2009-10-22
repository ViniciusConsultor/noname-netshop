<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的站内信</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
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
                                    <th><span>回复消息</span></th>
                                    <th class="last actions"><span>操作</span></th>
                                  </tr>
                                  <tr class="odd">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td><a href="#">回复</a></td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="even">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td><span class="disabled">已回复</span></td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="odd">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td><span class="disabled">已回复</span></td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="even">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td><span class="disabled">已回复</span></td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>                                  
                                  <tr class="bottom">
                                  	<td><a href="javascript:void(0)" onclick="selectAll(this,this.parentNode.parentNode.parentNode)">全选</a></td>
                                    <td colspan="5">
                                    	<a class="button_blue" href="#">删　除</a>
                                        <div class="pagination">
                                        	<a class="prev" href="#"></a>
                                            <div class="pageNum">
                                            	<a class="on" href="#">1</a>
                                                <a href="#">2</a>
                                                <a href="#">3</a>
                                                <a href="#">4</a>
                                                <a href="#">5</a>
                                                <a href="#">6</a>
                                                <a href="#">7</a>
                                            </div>
                                            <a class="next" href="#"></a>
                                            <div class="jumpTo">
                                            	<span>跳转到</span><input type="text" value="1" /><span>页</span>
                                            </div>
                                        </div>
                                    </td>
                                  </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="box6 newline">
                    	<div class="title">已发短信</div>
                        <div class="content noPaddingContentBox">
                            <div class="table2">
                                <table>
                                  <tr>
                                    <th class="first checkBox"><span>选择</span></th>
                                    <th><span>标题</span></th>
                                    <th><span>发件时间</span></th>
                                    <th><span>收件人</span></th>
                                    <th class="last actions"><span>操作</span></th>
                                  </tr>
                                  <tr class="odd">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="even">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="odd">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>
                                  <tr class="even">
                                    <td><input type="checkbox" /></td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>text</td>
                                    <td>
                                    	<a href="#" class="iconButton viewMessage"></a>
                                        <a href="#" class="iconButton delete"></a>
                                    </td>
                                  </tr>                                  
                                  <tr class="bottom">
                                  	<td><a href="javascript:void(0)" onclick="selectAll(this,this.parentNode.parentNode.parentNode)">全选</a></td>
                                    <td colspan="4">
                                    	<a class="button_blue" href="#">删　除</a>
                                        <div class="pagination">
                                        	<a class="prev" href="#"></a>
                                            <div class="pageNum">
                                            	<a class="on" href="#">1</a>
                                                <a href="#">2</a>
                                                <a href="#">3</a>
                                                <a href="#">4</a>
                                                <a href="#">5</a>
                                                <a href="#">6</a>
                                                <a href="#">7</a>
                                            </div>
                                            <a class="next" href="#"></a>
                                            <div class="jumpTo">
                                            	<span>跳转到</span><input type="text" value="1" /><span>页</span>
                                            </div>
                                        </div>
                                    </td>
                                  </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="box6 newline">
                    	<div class="title">发送站内信</div>
                        <div class="content">
                        	<ul class="form">
                            	<li>
                                	<span class="field">标　题</span>
                                    <input type="text" class="textField2" />
                                </li>
                                <li>
                                	<span class="field">发件人</span>
                                    <input type="text" class="textField2" />
                                </li>
                                <li>
                                    <span class="field">内　容</span>
                                    <textarea class="textarea2"></textarea>
                            	</li>
                                <li class="submit">
                                	<a class="button_blue" href="#">发　送</a>
                                </li>
                            </ul>
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
