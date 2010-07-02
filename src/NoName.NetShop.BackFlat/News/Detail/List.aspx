﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.News.Detail.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<%@ Register src="../../Controls/NewsCategorySelect.ascx" tagname="NewsCategorySelect" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
        InitRegions();
            
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="500">
            <tr>
                <td><asp:CheckBox runat="server" ID="CheckBox_NewsID" Text="按新闻ID" /></td>
                <td><asp:TextBox runat="server" ID="TextBox_NewsID" /></td>
                <td><asp:CheckBox runat="server" ID="CheckBox_NewsName" Text="按新闻标题" /></td>
                <td><asp:TextBox runat="server" ID="TextBox_NewsName" /></td>
            </tr>
            <tr>
                <td><asp:CheckBox runat="server" ID="CheckBox_Category" Text="按所属分类" /></td>
                <td colspan="3"><uc1:NewsCategorySelect ID="NewsCategorySelect1" runat="server" /></td>
            </tr>
        </table>
        <asp:Button runat="server" ID="Button_Search" Text="搜索" OnClick="Button_Search_Click" />
    </div>
    <div>
        <asp:GridView runat="server" ID="GridView1" CssClass="GridView" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="新闻ID" DataField="newsid" />
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <a href='<%# Eval("fronturl") %>' target="_blank"><%# Eval("title")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="分类" DataField="catename" />
                <asp:BoundField HeaderText="作者" DataField="author" />
                <asp:TemplateField HeaderText="发布日期">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("inserttime")).ToString("yyyy-MM-dd hh:mm:ss") %>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButton_SetSplendid" CommandArgument='<%# Eval("newsid") %>' CommandName="ss" Text="设为精彩" Visible='<%# !Convert.ToBoolean(Eval("issplendid")) %>' />
                        <asp:LinkButton runat="server" ID="LinkButton_DesetSplendid" CommandArgument='<%# Eval("newsid") %>' CommandName="ds" Text="取消精彩" Visible='<%# Convert.ToBoolean(Eval("issplendid")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButton_Delete" CommandArgument='<%# Eval("newsid") %>' CommandName="d" Text="删除" />
                        <asp:HyperLink runat="server" ID="HyperLink_Edit" NavigateUrl='<%# "Edit.aspx?id="+Eval("newsid")+"&pageid="+ InitialPageIndex %>' Text="编辑" />
                    </ItemTemplate>                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </div>
    <div>
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>            
    </div>
    </form>
</body>
</html>
