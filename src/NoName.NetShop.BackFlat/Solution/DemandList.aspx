<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemandList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.DemandList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="demandid" />
                    <asp:BoundField HeaderText="用户ID" DataField="userid" />
                    <asp:BoundField HeaderText="预算" DataField="budget" />
                    <asp:BoundField HeaderText="联系人" DataField="contactor" />
                    <asp:BoundField HeaderText="联系电话" DataField="contactphone" />
                    <asp:BoundField HeaderText="地区" DataField="region" />
                    <asp:BoundField HeaderText="创建时间" DataField="createtime" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.DemandProductStatus), Eval("status"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Button_Pass" CommandArgument='<%# Eval("demandid") %>' CommandName="p" Text="通过审核" Enabled='<%# Convert.ToInt32(Eval("status"))==1? true:false %>' />
                            <a href='<%# "DemandDetail.aspx?id="+Eval("demandid") %>'>查看详细</a>
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
