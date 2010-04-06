<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.News.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Add.aspx">新建页面</a>
        </div>
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="listGrid" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <%# Eval("pageid") %>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:BoundField HeaderText="页面名称" DataField="pagename" />
                    <asp:BoundField HeaderText="标题" DataField="pagetitle" />
                    <asp:BoundField HeaderText="作者" DataField="author" />
                    <asp:TemplateField HeaderText="创建时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("createtime")).ToString("yyyy-MM-dd hh:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# "Edit.aspx?pageid=" + Eval("pageid") %>'>修改名称</a>
                            <a href='<%# "Publish.aspx?pageid="+Eval("pageid") %>'>编辑内容</a>
                            <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("pageid") %>' CommandName="d" Text="删除" />
                        </ItemTemplate>
                    </asp:TemplateField>                    
                </Columns>            
            </asp:GridView>                
        </div>
        <div>
            <cc1:AspNetPager ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页' AlwaysShow="true"
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>        
        </div>
    </form>
</body>
</html>
