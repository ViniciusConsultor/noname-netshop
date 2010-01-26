<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.MagicWorld.Demand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="demandid" />
                    <asp:BoundField HeaderText="产品名称" DataField="demandname" />
                    <asp:BoundField HeaderText="价格" DataField="price" />
                    <asp:BoundField HeaderText="数量" DataField="count" />
                    <asp:BoundField HeaderText="新旧程度" DataField="usagecondition" />
                    <asp:BoundField HeaderText="用户" DataField="userid" />
                    <asp:BoundField HeaderText="所在地" DataField="region" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.DemandProductStatus), Eval("status")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"p") %>' ID="Button_Pass" CommandArgument='<%# Eval("demandid") %>' CommandName="p" Text="通过" />
                            <asp:LinkButton runat="server" Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"u") %>' ID="Button_DePass" CommandArgument='<%# Eval("demandid") %>' CommandName="u" Text="驳回" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"f") %>' ID="Button_Freeze" CommandArgument='<%# Eval("demandid") %>' CommandName="f" Text="冻结" />
                            <asp:LinkButton runat="server" Enabled='<%# GetButtonStatus(Convert.ToInt32(Eval("status")),"m") %>' ID="Button_DeFreeze" CommandArgument='<%# Eval("demandid") %>' CommandName="m" Text="解冻" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("demandid") %>' CommandName="d" Text="删除" />
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
