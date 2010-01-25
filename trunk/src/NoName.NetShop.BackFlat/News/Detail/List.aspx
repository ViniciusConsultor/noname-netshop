<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.News.Detail.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="LinkButton_Delete" CommandArgument='<%# Eval("newsid") %>' CommandName="d" Text="删除" />
                        <asp:HyperLink runat="server" ID="HyperLink_Edit" NavigateUrl='<%# "Edit.aspx?id="+Eval("newsid") %>' Text="编辑" />
                    </ItemTemplate>                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </div>
    <div>
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>            
    </div>
    </form>
</body>
</html>
