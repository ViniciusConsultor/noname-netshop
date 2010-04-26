﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyComplaint.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyComplaint" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headerContent" runat="server">
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的投诉</a>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="rightColumnContainer">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>我的投诉</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="box7">
                    <div class="title">
                        我的投诉</div>
                    <div class="content">
                        <ul class="questions">
                            <asp:Repeater runat="server" ID="rpList" OnItemDataBound="rpList_ItemDataBound">
                                <ItemTemplate>
                                    <li class="odd">
                                        <div class="question">
                                            <span class="user">
                                                <%#Eval("UserId") %>：</span> <span>
                                                    <%#Eval("Content") %></span> <span class="date">
                                                        <%#Eval("InsertTime", "{0:yyyy-MM-dd HH:mm}")%></span>
                                        </div>
                                        <div class="answer">
                                            <asp:Repeater runat="server" ID="rpSubList">
                                                <ItemTemplate>
                                                <div>
                                                    <span class="answerer">鼎视回答：</span> <span>
                                                        <%#Eval("Content") %></span> <span class="date">
                                                            <%#Eval("AnswerTime","{0:yyyy-MM-dd HH:mm}") %></span>
                                                            </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <li class="even">
                                        <div class="question">
                                            <span class="user">
                                                <%#Eval("UserId") %>：</span> <span>
                                                    <%#Eval("Content") %></span> <span class="date">
                                                        <%#Eval("InsertTime", "{0:yyyy-MM-dd HH:mm}")%></span>
                                        </div>
                                        <div class="answer">
                                            <asp:Repeater runat="server" ID="rpSubList">
                                                <ItemTemplate>
                                                    <div>
                                                        <span class="answerer">鼎视回答：</span> <span>
                                                            <%#Eval("Content") %></span> <span class="date">
                                                                <%#Eval("AnswerTime","{0:yyyy-MM-dd HH:mm}") %></span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </li>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="paginationParent">
                            <div class="pagination">
                                <cc1:AspNetPager ID="pageNav" runat="server" PageSize="12" UrlPageIndexName="" AlwaysShow="true"
                                    ImagePath="/" FirstPageText='首页' LastPageText='末页' NextPageText='下一页' PrevPageText='上一页'
                                    ShowBoxThreshold="16" NumericButtonCount="8" ShowPrevNext="True" SubmitButtonClass="buttom"
                                    NumericButtonTextFormatString='' OnPageChanged="pageNav_PageChanged">
                                </cc1:AspNetPager>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box7">
                    <div class="title">
                        我要投诉</div>
                    <div class="content">
                        <ul class="form">
                            <li><span class="field">投诉内容</span>
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtContent" CssClass="textarea4"></asp:TextBox>
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" ID="lbtnDoQuestion" CssClass="button_blue" Text="提交咨询"
                                    OnClick="lbtnDoQuestion_Click"></asp:LinkButton>
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
