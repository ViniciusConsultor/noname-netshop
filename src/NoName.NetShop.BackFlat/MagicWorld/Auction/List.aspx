<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Auction.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="拍品ID" DataField="AuctionId" />
                    <asp:TemplateField HeaderText="名称">
                        <ItemTemplate>
                            <%# Eval("ProductName")%>
                            <a href='<%# "LogList.aspx?auctionid="+Eval("AuctionId") %>'>查看竞价记录</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户名" DataField="Userid" />
                    <asp:TemplateField HeaderText="起拍价">
                        <ItemTemplate>
                            <%# Convert.ToDecimal(Eval("StartPrice")).ToString("0.00") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="当前价">
                        <ItemTemplate>
                            <%# Convert.ToDecimal(Eval("CurPrice")).ToString("0.00") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="起拍时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结束时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.AuctionProductStatus),Eval("status"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"p")  %>' runat="server" ID="Button_Pass" CommandArgument='<%# Eval("AuctionId") %>' CommandName="p" Text="通过" />
                            <asp:LinkButton Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"u") %>' runat="server" ID="Button_DePass" CommandArgument='<%# Eval("AuctionId") %>' CommandName="u" Text="驳回" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:LinkButton Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"f")  %>' runat="server" ID="Button_Freeze" CommandArgument='<%# Eval("AuctionId") %>' CommandName="f" Text="冻结" />
                            <asp:LinkButton Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"m")  %>' runat="server" ID="Button_DeFreeze" CommandArgument='<%# Eval("AuctionId") %>' CommandName="m" Text="解冻" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("AuctionId") %>' CommandName="d" Text="删除" />
                        </ItemTemplate>
                    </asp:TemplateField>                        
                </Columns>
            </asp:GridView>
        </div>
        <div id="page">
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