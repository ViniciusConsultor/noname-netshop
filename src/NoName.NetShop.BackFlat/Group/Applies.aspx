<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Applies.aspx.cs" Inherits="NoName.NetShop.BackFlat.Group.Applies" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <b><asp:Literal runat="server" ID="Literal_ProductName" /></b>
            的申请列表
        </div>
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="GroupApplyID" />
                    <asp:BoundField HeaderText="用户" DataField="UserID" />
                    <asp:BoundField HeaderText="申请留言" DataField="ApplyBrief" />
                    <asp:TemplateField HeaderText="申请时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ApplyTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="确认时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ConfirmTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("ApplyStatus"))==1?true:(Convert.ToInt32(Eval("ApplyStatus"))==2?true:false) %>' runat="server" ID="Button_Refuse" Text="驳回" CommandArgument='<%# Eval("GroupApplyID") %>' CommandName="r" />
                            <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("ApplyStatus"))==1?true:(Convert.ToInt32(Eval("ApplyStatus"))==2?false:true) %>' runat="server" ID="Button_Accept" Text="通过" CommandArgument='<%# Eval("GroupApplyID") %>' CommandName="a" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
        <div id="page">
            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' ShowInputBox="Always"
                LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8" 
                ShowPrevNext="True" SubmitButtonClass="buttom" ShowPageIndex="true"
                NumericButtonTextFormatString=''>
            </cc1:AspNetPager>
        </div>
    </form>
</body>
</html>