<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Rent.LogList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="出租订单ID" DataField="rentorderid" />
                    <asp:BoundField HeaderText="出租商品" DataField="rentname" />
                    <asp:BoundField HeaderText="用户" DataField="userid" />
                    <asp:BoundField HeaderText="申请时间" DataField="applytime" />
                    <asp:BoundField HeaderText="申请时长(月)" DataField="rentmonths" />
                    <asp:TemplateField HeaderText="起至时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("starttime")) == Convert.ToDateTime(Eval("endtime")) ? "--" : Eval("starttime")+" ~ "+Eval("endtime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.RentLogStatus),Eval("status")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Button_Pass" Text="通过" CommandArgument='<%# Eval("rentorderid") %>' CommandName="p" />
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
