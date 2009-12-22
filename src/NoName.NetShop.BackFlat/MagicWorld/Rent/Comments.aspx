<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Rent.Comments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h5>租赁商品评论列表</h5>
    <div>
        <asp:GridView runat="server" ID="GridView1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="评论ID" DataField="commentid" />
                <asp:BoundField HeaderText="被评论产品" DataField="rentname" />
                <asp:BoundField HeaderText="用户名" DataField="userid" />
                <asp:BoundField HeaderText="内容" DataField="content" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Button_Delete" Text="删除" CommandArgument='<%# Eval("commentid") %>' CommandName='d' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
            UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' LastPageText='末页'
            NextPageText='下一页' PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
            ShowPrevNext="True" SubmitButtonClass="buttom" NumericButtonTextFormatString=''>
        </cc1:AspNetPager>
    </div>
    </form>
</body>
</html>
