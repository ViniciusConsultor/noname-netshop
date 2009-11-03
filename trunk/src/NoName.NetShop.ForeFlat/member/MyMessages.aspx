<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyMessages" %>

<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
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
                                        <cc1:AspNetPager ID="pager" runat="server" HorizontalAlign="Right">
                                        </cc1:AspNetPager>
                                        </div>
                                    </td>
                                  </tr>
                                </table>
                            </div>
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
