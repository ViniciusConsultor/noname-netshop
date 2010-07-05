<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Auction.Comments" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jquery.timers.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $('a[cmtcontent]').click(function() {
                $.ui.dialog.defaults.bgiframe = true;

                var msg = $(this).next().html();
                $("#dialog").find("p").html(msg);
                $("#dialog").dialog({ 
                    autoOpen: false ,
                    width:500,
                    height:300
               
                }).dialog("open");
            });
        });
    </script>
</head>
<body>
    <div id="dialog" title="评论内容" style="display:none">
	    <p style="font-size:12px;">
	    </p>
    </div>
    <form id="form1" runat="server">
    <h5>拍卖商品评论列表</h5>
    <div>
        <asp:GridView runat="server" ID="GridView1" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="评论ID" DataField="commentid" />
                <asp:BoundField HeaderText="被评论产品" DataField="productname" />
                <asp:BoundField HeaderText="用户名" DataField="userid" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="javascript:void(0);" cmtcontent="true">查看内容</a>
                        <div style="display:none"><%# Eval("content")%></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Button_Delete" Text="删除" CommandArgument='<%# Eval("commentid") %>' CommandName='d' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12" OnPageChanged="AspNetPager_PageChanged"
            UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' LastPageText='末页'
            NextPageText='下一页' PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
            ShowPrevNext="True" SubmitButtonClass="buttom" NumericButtonTextFormatString=''>
        </cc1:AspNetPager>
    </div>
    </form>
</body>
</html>
