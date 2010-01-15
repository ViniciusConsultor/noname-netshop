<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScenceList.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ScenceList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="data-list">
        <a href="ShowScence.aspx?id=0">添加场景</a>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
               onrowcommand="gvList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ScenceId" HeaderText="ID" />            
                    <asp:BoundField DataField="ScenceName" HeaderText="名称" />
                   <asp:BoundField DataField="SenceType"  HeaderText="类型" />
                   <asp:TemplateField FooterText="类型">
                   <ItemTemplate>
                   <asp:Literal runat="server" Text='<%#Convert.ToInt32(Eval("SenceType"))==0? "经典套装":"推荐套装" %>'></asp:Literal>
                   </ItemTemplate>
                   </asp:TemplateField>
                  <asp:TemplateField FooterText="状态">
                   <ItemTemplate>
                   <asp:Literal runat="server" Text='<%# Convert.ToBoolean(Eval("IsActive"))? "启用":"禁用" %>'></asp:Literal>
                   </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="维护">
                        <ItemTemplate>
                             <asp:HyperLink runat="server" ID="HyperLink1" Text="编辑场景" NavigateUrl='<%# "ShowScence.aspx"?id="+Eval("ScenceId") %>' />
                             <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看内容" NavigateUrl='<%# (Convert.ToInt32(Eval("SenceType"))==0? "ShowClassicalScence.aspx":"ShowCommendScence.aspx") + "?id="+Eval("ScenceId") %>' />
                            <asp:LinkButton runat="server" ID="lbtnToggle" Text='<%# Convert.ToBoolean(Eval("IsActive"))?"禁止":"允许" %>' CommandName="toggle" CommandArgument='<%#Eval("ScenceId")%>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager  ID="pageNav" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString='' onpagechanged="pageNav_PageChanged">
            </cc1:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
